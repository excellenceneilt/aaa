using Domain.Models.Contracts;
using Infra.Common;
using Infra.DataAccess.Contracts;
using Infra.DataAccess.Entities;
using Infra.DataAccess.Repositories;
using Infra.EmailServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ClientModel : IClientModel
    {
        #region -> Atributos
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private IClientRepository _clientRepository;
        #endregion

        #region -> Constructores

        public ClientModel()
        {
            _clientRepository = new ClientRepository();
        }

        public ClientModel(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            _clientRepository = new ClientRepository();
        }
        #endregion

        #region -> Propiedades

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
       
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
       
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        #endregion

        #region -> Métodos Públicos        

        public int Add(ClientModel clientModel)
        {
            var clientEntity = MapClientEntity(clientModel);
            return _clientRepository.Add(clientEntity);
        }
        public int Edit(ClientModel clientModel)
        {
            var clientEntity = MapClientEntity(clientModel);
            return _clientRepository.Edit(clientEntity);
        }
        public int Remove(ClientModel clientModel)
        {
            var clientEntity = MapClientEntity(clientModel);
            return _clientRepository.Remove(clientEntity);
        }
        public int AddRange(List<ClientModel> clientModels)
        {
            var clientEntityList = MapClientEntity(clientModels);
            return _clientRepository.AddRange(clientEntityList);
        }
        public int RemoveRange(List<ClientModel> clientModels)
        {
            var clientEntityList = MapClientEntity(clientModels);
            return _clientRepository.RemoveRange(clientEntityList);
        }
        
        public ClientModel GetSingle(string value)
        {
            var clientEntity = _clientRepository.GetSingle(value);
            if (clientEntity != null)
                return MapClientModel(clientEntity);
            else return null;
        }
        
        public IEnumerable<ClientModel> GetAll()
        {
            var clientEntityList = _clientRepository.GetAll();
            return MapClientModel(clientEntityList);
        }
        public IEnumerable<ClientModel> GetByValue(string value)
        {
            var clientEntityList = _clientRepository.GetByValue(value);
            return MapClientModel(clientEntityList);
        }

        #endregion

        #region -> Métodos Privados (Mapear datos)

        //Mapear modelo entidad a modelo de dominio.
        private ClientModel MapClientModel(Client clientEntity)
        {//Mapear un solo objeto.
            var clientModel = new ClientModel
            {
                Id = clientEntity.Id,
                FirstName = clientEntity.FirstName,
                LastName = clientEntity.LastName,
                Email = clientEntity.Email,
            };
            return clientModel;

        }
        private List<ClientModel> MapClientModel(IEnumerable<Client> clientEntityList)
        {//Mapear colección de objetos.
            var clientModelList = new List<ClientModel>();

            foreach (var clientEntity in clientEntityList)
            {
                clientModelList.Add(MapClientModel(clientEntity));
            };
            return clientModelList;
        }


        //Mapear modelo de dominio a modelo de entidad.
        private Client MapClientEntity(ClientModel clientModel)
        {//Mapear un solo objeto.
            var clientEntity = new Client
            {
                Id = clientModel.Id,
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName,
                Email = clientModel.Email,
            };
            return clientEntity;
        }
        private List<Client> MapClientEntity(List<ClientModel> clientModelList)
        {//Mapear una colección de usuarios.
            var clientEntityList = new List<Client>();

            foreach (var clientModel in clientModelList)
            {
                clientEntityList.Add(MapClientEntity(clientModel));
            };
            return clientEntityList;
        }
        #endregion










    }




}
