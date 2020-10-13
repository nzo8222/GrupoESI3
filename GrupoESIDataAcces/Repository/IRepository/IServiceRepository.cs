using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        public void Update(Service obj);
    }
}
