using Infra.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataAccess.Contracts
{

    public interface IClientRepository : IGenericRepository<Client>

    {
        int AddRange(List<Client> clients);//Agregar una colección de usuarios (Insercción masiva)
        int RemoveRange(List<Client> clients);//Eliminar una colección de usuarios (remoción masiva)


    }
}
