using Domain.Models.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.WinForm.ViewModels;
using Infra.Common;

namespace UI.WinForm.ChildForms
{
    public partial class FormClients : Form
    {



        #region -> Campos

        private IClientModel domainModel = new ClientModel();//Modelo de dominio del Usuario.
        private ClientViewModel clientViewModel = new ClientViewModel();//Modelo de vista del Usuario.
        private List<ClientViewModel> clientViewList;//Lista de usuarios.
        private FormClientMaintenance maintenanceForm;//formulario de mantenimiento.

        #endregion

        #region -> Constructor
        public FormClients()
        {
            InitializeComponent();
        }
        #endregion

        #region -> Métodos

        private void LoadClientData()
        {//LLenar la cuadricula de datos con la lista de usuarios.
            clientViewList = clientViewModel.MapClientViewModel(domainModel.GetAll());//Obtener todos los usuarios.
            dataGridView1.DataSource = clientViewList;//Establecer la fuente de datos.
        }
        private void FindClient(string value)
        { //Buscar usuarios.           
            clientViewList = clientViewModel.MapClientViewModel(domainModel.GetByValue(value));//Filtrar usuario por valor.
            dataGridView1.DataSource = clientViewList;//Establecer la fuente de datos con los resultados.
        }
        private ClientViewModel GetClient(int id)
        {//Obtener usuario por ID.
            var clientModel = domainModel.GetSingle(id.ToString());//Buscar un único usuario.
            if (clientModel != null)//Si hay resultado, retornar un objeto modelo de vista de usuario.
                return clientViewModel.MapClientViewModel(clientModel);
            else //Caso contrario, retornar un valor nulo, y mostrar mensaje.
            {
                MessageBox.Show("No se ha encontrado cliente con id: " + id.ToString(), "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
        #endregion

        #region -> Métodos de Eventos

        private void FormClients_Load(object sender, EventArgs e)
        {
            LoadClientData();//Cargar datos.
            dataGridView1.Columns[0].Width = 50;//Establecer un ancho fijo para la columna ID.
            dataGridView1.Columns[1].Width = 100;//Establecer un ancho fijo para la columna Username.
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FindClient(txtSearch.Text);//Buscar usuario.
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FindClient(txtSearch.Text);//Buscar usuario si se preciona tecla enter en cuadro de texto buscar.
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {//Mostrar detalles de usuario.
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var client = GetClient((int)dataGridView1.CurrentRow.Cells[0].Value);//Obtener ID del usuario y buscar usando el método GetUser(id).
                if (client == null) return;
                var frm = new FormClientMaintenance(client, TransactionAction.View);//Instanciar formulario, y enviar parámetros (modelo de vista y acción).
                frm.ShowDialog();//Mostrar formulario.
            }
            else
                MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {//Agregar nuevo usuario.
            maintenanceForm = new FormClientMaintenance(new ClientViewModel(), TransactionAction.Add);//Instanciar formulario, y enviar parámetros (modelo de vista y acción).
            maintenanceForm.FormClosed += new FormClosedEventHandler(MaintenanceFormClosed);//Asociar evento cerrado, para actualizar el datagrdiview despues que el formualario de mantenimiento se cierre.
            maintenanceForm.ShowDialog();//Mostrar formulario de mantenimiento.

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {//Editar usuario.
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridView1.SelectedCells.Count > 1)
            {
                var client = GetClient((int)dataGridView1.CurrentRow.Cells[0].Value);//Obtener ID del usuario y buscar usando el método GetUser(id).
                if (client == null) return;

                maintenanceForm = new FormClientMaintenance(client, TransactionAction.Edit);//Instanciar formulario, y enviar parámetros (modelo de vista y acción).
                maintenanceForm.FormClosed += new FormClosedEventHandler(MaintenanceFormClosed);//Asociar evento cerrado, para actualizar el datagrdiview despues que el formualario de mantenimiento se cierre.
                maintenanceForm.ShowDialog();//Mostrar formulario de mantenimiento.            
            }
            else
                MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {//Eliminar usuario.
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("No hay datos para seleccionar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var client = GetClient((int)dataGridView1.CurrentRow.Cells[0].Value);//Obtener ID del usuario y buscar usando el método GetUser(id).
                if (client == null) return;

                maintenanceForm = new FormClientMaintenance(client, TransactionAction.Remove);//Instanciar formulario, y enviar parámetros (modelo de vista y acción).
                maintenanceForm.FormClosed += new FormClosedEventHandler(MaintenanceFormClosed);//Asociar evento cerrado, para actualizar el datagrdiview despues que el formualario de mantenimiento se cierre.
                maintenanceForm.ShowDialog();   //Mostrar formulario de mantenimiento.              
            }
            else
                MessageBox.Show("Por favor seleccione una fila", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MaintenanceFormClosed(object sender, FormClosedEventArgs e)
        {//Actualizar el datagridview despues que el formualario de mantenimiento se cierre.
            var lastData = maintenanceForm.LastRecord;//Obtener el último registro del formulario de mantenimiento.
            if (lastData != null)//Si tiene un último registro.
            {
                LoadClientData();//Actualizar el datagridview.
                if (lastData != "")//Si el campo último registro, es diferente a una cadena vacia, entonces debe resaltar y visualizar el usuario agregado o editado.
                {
                    var index = clientViewList.FindIndex(c => c.FirstName == lastData);//Buscar el index del ultimo usuario registrado o modificado.
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[0];//Enfocar la celda del ultimo registro.
                    dataGridView1.Rows[index].Selected = true;//Seleccionar fila.
                    //Nota, si agregó varios usuarios a la vez (Inserción masiva) se seleccionará el primer registro de la colección de usuarios.
                }
            }
        }

        #endregion

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}
