using Infra.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Domain.Models;

namespace UI.WinForm.ViewModels
{
    public class ClientViewModel
    {

        #region -> Atributos
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        #endregion

        #region -> Constructores
        public ClientViewModel()
        {
        }

        public ClientViewModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
        #endregion

        #region -> Propiedades + Validacíon y Visualización de Datos

        //Posición 0 
        [DisplayName("Num")]//Nombre a visualizar (Por ejemplo en la columna del datagridview se mostrará como Num).
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Posición 1
        [DisplayName("Nombre")]//Nombre a visualizar.
        [Browsable(false)]//Ocultar visualización
        [Required(ErrorMessage = "Por favor ingrese nombre")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El nombre debe ser solo letras")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe contener un mínimo de 3 caracteres.")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        //Posición 2
        [DisplayName("Apellido")]//Nombre a visualizar.
        [Browsable(false)]//Ocultar visualización
        [Required(ErrorMessage = "Por favor ingrese apellido.")]//Validaciones
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "El apellido debe ser solo letras")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe contener un mínimo de 3 caracteres.")]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        //Posición 3
        [ReadOnly(true)]//Solo lectura.
        [DisplayName("Nombre completo")]//Nombre a visualizar.
        public string FullName
        {
            get { return _firstName + ", " + _lastName; }
        }

        //Posición 4
        [DisplayName("Email")]//Nombre a visualizar.
        [Required(ErrorMessage = "Por favor ingrese correo electrónico.")]//Validaciones
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        #endregion

        #region -> Métodos (Mapear datos)

        //Mapear modelo de dominio a modelo de vista
        public ClientViewModel MapClientViewModel(ClientModel clientModel)
        {
            var clientViewModel = new ClientViewModel
            {
                Id = clientModel.Id,
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName,
                Email = clientModel.Email,
            };
            return clientViewModel;
        }
        public List<ClientViewModel> MapClientViewModel(IEnumerable<ClientModel> clientModelList)
        {
            var clientViewModelList = new List<ClientViewModel>();

            foreach (var clientModel in clientModelList)
            {
                clientViewModelList.Add(MapClientViewModel(clientModel));
            };
            return clientViewModelList;
        }

        //Mapear modelo de vista a modelo de dominio
        public ClientModel MapClientModel(ClientViewModel clientViewModel)
        {
            var clientModel = new ClientModel
            {
                Id = clientViewModel.Id,
                FirstName = clientViewModel.FirstName,
                LastName = clientViewModel.LastName,
                Email = clientViewModel.Email
            };
            return clientModel;
        }
        public List<ClientModel> MapClientModel(List<ClientViewModel> clientViewModelList)
        {
            var clientModelList = new List<ClientModel>();

            foreach (var clientViewModel in clientViewModelList)
            {
                clientModelList.Add(MapClientModel(clientViewModel));
            };
            return clientModelList;
        }
        #endregion







    }
}
