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

namespace UI.WinForm.ChildForms
{
    public partial class FormClients : Form
    {



        #region -> Campos

        private IClientModel domainModel = new ClientModel();//Modelo de dominio del Usuario.
        private ClientViewModel clientViewModel = new ClientViewModel();//Modelo de vista del Usuario.
        private List<ClientViewModel> clientViewList;//Lista de usuarios.
       // private FormClientMaintenance maintenanceForm;//formulario de mantenimiento.

        #endregion




        public FormClients()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void FormPacients_Load(object sender, EventArgs e)
        {

        }
    }
}
