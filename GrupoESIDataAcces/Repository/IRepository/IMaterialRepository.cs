using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IMaterialRepository : IRepository<Material>
    {
        public void Update(Material obj);
    }
}
