using Domain.Models;
using Domain.Models.Contracts;
using Infra.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.WinForm.Helpers;
using UI.WinForm.Utils;
using UI.WinForm.ViewModels;

namespace UI.WinForm.ChildForms
{
    public partial class FormClientMaintenance : Base.BaseFixedForm
    {

        #region -> Definición de Campos

        private IClientModel domainModel;//Interfaz del modelo de dominio Usuario.
        private BindingList<ClientViewModel> clientCollection;//Colección de usuarios para la inserción masiva.
        private ClientViewModel clientViewModel;//Modelo de vista del usuario.
        private TransactionAction transaction;//Acción de transacción para la persistencia.
        private TransactionAction listOperation = TransactionAction.Add; //Acción de transacción para la colección de usuarios.
       
        private string lastRecord = "";/*Campo para almacenar el ultimo dato insertado o editado.
                                         Esto permitirá seleccionar y visualizar los cambios en el datagridview del formulario Users.*/
        #endregion

        #region -> Definición de Propiedades

        public string LastRecord
        {/*Propiedad para almacenar el ultimo dato insertado o editado.
          Esto permitirá seleccionar y visualizar los cambios en el datagridview del formulario Users.*/
            get { return lastRecord; }
            set { lastRecord = value; }
        }
        #endregion

        #region -> Constructor

        public FormClientMaintenance(ClientViewModel _clientViewModel, TransactionAction _transaction)
        {
            InitializeComponent();

            //Inicializar campos
            domainModel = new ClientModel();
            clientCollection = new BindingList<ClientViewModel>();
            clientViewModel = _clientViewModel;
            transaction = _transaction;

            //Inicializar propiedades de control
            rbSingleInsert.Checked = true;
           
            dataGridView1.DataSource = clientCollection;
            FillFields(_clientViewModel);
            InitializeTransactionUI();
            InitializeDataGridView();
        }
        #endregion

        #region -> Definición de métodos

        private void InitializeTransactionUI()
        {//Este método es responsable de establecer las propiedades de apariencia según la acción de la transacción.
            switch (transaction)
            {
                case TransactionAction.View:
                    LastRecord = null;
                    this.TitleBarColor = Color.MediumSlateBlue;
                    lblTitle.Text = "Detalles de usuario";
                    lblTitle.ForeColor = Color.MediumSlateBlue;
                    btnSave.Visible = false;
                    panelAddedControl.Visible = false;
                   
                    btnCancel.Text = "X  Cerrar";
                    btnCancel.Location = new Point(300, 310);
                    btnCancel.BackColor = Color.MediumSlateBlue;
                    ReadOnlyFields();
                    break;

                case TransactionAction.Add:
                    this.TitleBarColor = Color.SeaGreen;
                    lblTitle.Text = "Agregar cliente";
                    lblTitle.ForeColor = Color.SeaGreen;
                    btnSave.BackColor = Color.SeaGreen;
                   
                    break;

                case TransactionAction.Edit:
                    this.TitleBarColor = Color.RoyalBlue;
                    lblTitle.Text = "Editar usuario";
                    lblTitle.ForeColor = Color.RoyalBlue;
                    btnSave.BackColor = Color.RoyalBlue;
                    panelAddedControl.Visible = false;
                    
                    break;

                case TransactionAction.Remove:
                    this.TitleBarColor = Color.IndianRed;
                    lblTitle.Text = "Eliminar usuario";
                    lblTitle.ForeColor = Color.IndianRed;
                    btnSave.Text = "Eliminar";
                    btnSave.BackColor = Color.IndianRed;
                    panelAddedControl.Visible = false;
                   
                    ReadOnlyFields();
                    break;

                case TransactionAction.Special:
                    this.TitleBarColor = Color.RoyalBlue;
                    lblTitle.Text = "Actualizar mi perfil de usuario";
                    lblTitle.ForeColor = Color.RoyalBlue;
                    btnSave.BackColor = Color.RoyalBlue;
                    panelAddedControl.Visible = false;
                
                    break;
            }
        }
        private void InitializeDataGridView()
        {//Este método es responsable de agregar columnas de editar y eliminar usuarios
         //de la colección de usuarios de la opción inserción masiva.

            DataGridViewImageColumn EditColumn = new DataGridViewImageColumn();
            DataGridViewImageColumn DeleteColumn = new DataGridViewImageColumn();

            EditColumn.Image = Properties.Resources.editIcon;
            EditColumn.Name = "EditColumn";
            EditColumn.HeaderText = " ";
            DeleteColumn.Image = Properties.Resources.deleteIcon;
            DeleteColumn.Name = "DeleteColumn";
            DeleteColumn.HeaderText = " ";

            this.dataGridView1.Columns.Add(EditColumn);
            this.dataGridView1.Columns.Add(DeleteColumn);

            dataGridView1.Columns["EditColumn"].Width = 25;
            dataGridView1.Columns["DeleteColumn"].Width = 25;
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 100;
        }

        private void PersistSingleRow()
        {//Método para persistir una sola fila en la base de datos.
            try
            {
                var clientObject = FillViewModel();//Obtener modelo de vista.
                var validateData = new DataValidation(clientObject);//Validar campos del objeto.
             //   var validatePassword = txtPassword.Text == txtConfirmPass.Text;//Validar contraseñas.

                if (validateData.Result == true )//Si el objeto es válido.
                {
                    var clientModel = clientViewModel.MapClientModel(clientObject);//Mapear el modelo de vista a modelo de dominio.
                    switch (transaction)
                    {
                        case TransactionAction.Add://Agregar usuario.
                            AddClient(clientModel);
                            break;
                        case TransactionAction.Edit://Editar usuario.
                            EditClient(clientModel);
                            break;
                        case TransactionAction.Remove://Eliminar usuario.
                            RemoveClient(clientModel);
                            break;
                        
                    }
                }

                else
                {
                    if (validateData.Result == false)
                        MessageBox.Show(validateData.ErrorMessage, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show("Error inesperado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                LastRecord = null;//Establecer nulo como ultimo registro.
                var message = ExceptionManager.GetMessage(ex);//Obtener mensaje de excepción.
                MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);//Mostrar mensaje.
            }

        }
        private void PersistMultipleRows()
        {//Método para persistir varias filas en la base de datos (Inserción masiva).
            try
            {
                if (clientCollection.Count > 0)//Validar si hay datos a insertar.
                {
                    var clientModelList = clientViewModel.MapClientModel(clientCollection.ToList());//Mapear la colección de usuarios a colección de modelos de dominio.
                    switch (transaction)
                    {
                        case TransactionAction.Add:
                            AddClientRange(clientModelList);//Agregar rango de usuarios.
                            break;
                    }
                }
                else MessageBox.Show("No hay datos, por favor agregue datos en la tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                LastRecord = null;
                var message = ExceptionManager.GetMessage(ex);
                MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void AddClient(ClientModel clientModel)
        {
            var result = domainModel.Add(clientModel);
            if (result > 0)
            {
                LastRecord = clientModel.FirstName;//Establecer el ultimo registro USERNAME POR FIRSTNAME   .
                MessageBox.Show("Cliente agregado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                LastRecord = null;
                MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void AddClientRange(List<ClientModel> clientModelList)
        {
            var result = domainModel.AddRange(clientModelList);

            if (result > 0)
            {
                LastRecord = clientModelList[0].FirstName;//Establecer el primer objeto como ultimo registro.
                MessageBox.Show("se agregaron " + result.ToString() + " clientes con éxito");
                this.Close();
            }
            else
            {
                lastRecord = null;
                MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void EditClient(ClientModel clientModel)
        {
            var result = domainModel.Edit(clientModel);
            if (result > 0)
            {
                LastRecord = clientModel.FirstName;//Establecer el ultimo registro.
                MessageBox.Show("Cliente actualizado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                LastRecord = null;
                MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void RemoveClient(ClientModel clientModel)
        {
            var result = domainModel.Remove(clientModel);
            if (result > 0)
            {
                LastRecord = "";//Establecer una cadena vacía como ultimo registro, ya que el usuario ya no existe, por lo tanto no es posible seleccionar y visualizar los cambios (Ver formulario Users).
                MessageBox.Show("Cliente eliminado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                LastRecord = null;
                MessageBox.Show("No se realizó la operación, intente nuevamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ModifyClientCollection()
        {//Este método es responsable de agregar o modificar un usuario de la colección de usuarios para la insercion masiva.
            var clientObject = FillViewModel();

            var validateData = new DataValidation(clientObject);//Validar objeto.
         //   var validatePassword = txtPassword.Text == txtConfirmPass.Text;

            if (validateData.Result == true )
            {
                switch (listOperation)
                {
                    case TransactionAction.Add:
                        var findClient = clientCollection.FirstOrDefault(client => client.Email == clientObject.Email
                                                                   || client.FirstName == clientObject.FirstName);
                        if (findClient == null)
                        {
                            var lastClient = clientCollection.LastOrDefault();
                            if (lastClient == null) clientObject.Id = 1;
                            else clientObject.Id = lastClient.Id + 1;

                            clientCollection.Add(clientObject);
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("Dato duplicado.\nEmail o nombre de usuario ya se ha añadido",
                                "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case TransactionAction.Edit:
                        var findObject = clientCollection.SingleOrDefault(client => client.Id == clientViewModel.Id);
                        var index = clientCollection.IndexOf(findObject);
                        clientCollection[index] = clientObject;

                        clientCollection.ResetBindings();
                        ClearFields();
                        break;
                }

            }
            else
            {
                if (validateData.Result == false)
                    MessageBox.Show(validateData.ErrorMessage, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show("Error inesperado 2", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FillFields(ClientViewModel clientView)
        {//Cargar los datos del modelo de vista en los campos del formulario.
            
            txtFirstName.Text = clientView.FirstName;
            txtLastName.Text = clientView.LastName;
            txtEmail.Text = clientView.Email;
            
        }
        private ClientViewModel FillViewModel()
        {//LLenar y retornar los datos de los campos del formulario en un nuevo objeto.
            var clientView = new ClientViewModel();

            clientView.Id = clientViewModel.Id;
            clientView.FirstName = txtFirstName.Text;
             clientView.LastName = txtLastName.Text;
             clientView.Email = txtEmail.Text;


            return clientView;
        }

        private void ClearFields()
        {//Limpiar los campos del formulario.
            
            txtFirstName.Clear();
              txtLastName.Clear();
              txtEmail.Clear();


            listOperation = TransactionAction.Add;
            btnAddClient.Text = "Agregar";
            btnAddClient.BackColor = Color.CornflowerBlue;
        }
        private void ReadOnlyFields()
        {//Convertir los campos del formulario en solo lectura.
            
            txtFirstName.ReadOnly = true;
             txtLastName.ReadOnly = true;
              txtEmail.ReadOnly = true;

        }
        #endregion



        #region -> Definición de métodos de evento
        /*
        private void btnSave_Click(object sender, EventArgs e)
        {//Boton guardar cambios

            if (rbSingleInsert.Checked) //Si el botón de radio está activado.
                PersistSingleRow();//Ejecutar el método de persistir una sola fila.
            else //Caso contrario, ejecutar el método de persistir varias filas(Insercción masiva)
                PersistMultipleRows();
        }
        
        private void btnAddClientList_Click(object sender, EventArgs e)
        {//Botón de agregar usuario a la colección de usuarios para la insercción masiva.
            ModifyClientCollection();
        }
        */
        private void FormClientMaintenance_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {//Cambiar el cursor si puntero del mouse entra en la columna de editar o eliminar.
            if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index
                || e.ColumnIndex == dataGridView1.Columns["DeleteColumn"].Index)
            {
                dataGridView1.Cursor = Cursors.Hand;
            }
        }
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {//Cambiar el cursor si puntero del mouse entra en la columna de editar o eliminar.
            if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index
                || e.ColumnIndex == dataGridView1.Columns["DeleteColumn"].Index)
            {
                dataGridView1.Cursor = Cursors.Default;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {//Eliminar o editar un usuario de la colección de usuarios.
            if (e.RowIndex == dataGridView1.NewRowIndex || e.RowIndex < 0)
                return;

            if (e.ColumnIndex == dataGridView1.Columns["DeleteColumn"].Index)
            {
                if (listOperation != TransactionAction.Edit)
                    clientCollection.RemoveAt(e.RowIndex);
                else MessageBox.Show("Se está editando datos, por favor termine la operación.");
            }
            if (e.ColumnIndex == dataGridView1.Columns["EditColumn"].Index)
            {
                clientViewModel = clientCollection[e.RowIndex];
                FillFields(clientViewModel);
                listOperation = TransactionAction.Edit;
                btnAddClient.Text = "Actualizar";
                btnAddClient.BackColor = Color.MediumSlateBlue;
            }
        }
        /*
        private void btnCancel_Click(object sender, EventArgs e)
        {//Si se cancela la acción establecer nulo como último registro.
            LastRecord = null;
            this.Close();
        }
        */
        protected override void CloseForm()
        {//Si se cierra el formulario, establecer nulo como último registro.
            base.CloseForm();
            LastRecord = null;
        }


        #endregion

        private void rbSingleInsert_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbSingleInsert.Checked)//Cambiar la apariencia para la inserción única.
            {
                panelMultiInsert.Visible = false;
                btnCancel.Location = new Point(210, 310);
                btnSave.Location = new Point(386, 310);
                this.Size = new Size(754, 370);
            }
            else //Cambiar la apariencia para insercción masiva.
            {
                panelMultiInsert.Visible = true;
                btnCancel.Location = new Point(212, 654);
                btnSave.Location = new Point(388, 654);
                this.Size = new Size(754, 715);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (rbSingleInsert.Checked) //Si el botón de radio está activado.
                PersistSingleRow();//Ejecutar el método de persistir una sola fila.
            else //Caso contrario, ejecutar el método de persistir varias filas(Insercción masiva)
                PersistMultipleRows();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {//Si se cancela la acción establecer nulo como último registro.
            LastRecord = null;
            this.Close();

        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            ModifyClientCollection();
        }
    }
}
