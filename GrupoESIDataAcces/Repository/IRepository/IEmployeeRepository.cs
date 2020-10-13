using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IEmployeeRepository : IRepository<EmployeeUser>
    {
        public void Update(EmployeeUser obj);
    }
}
