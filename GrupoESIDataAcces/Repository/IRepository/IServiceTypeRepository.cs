using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IServiceTypeRepository : IRepository<ServiceType>
    {
        void Update(ServiceType obj);
    }
}
