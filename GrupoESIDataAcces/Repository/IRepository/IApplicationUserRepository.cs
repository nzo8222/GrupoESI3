using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        public void Update(ApplicationUser obj);
    }
}
