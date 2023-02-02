using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Contracts
{
    public interface IClientModel : IBaseModel<ClientModel> 
    {

        int AddRange(List<ClientModel> clients);
        int RemoveRange(List<ClientModel> clients);

    }
}
