
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(ApplicationUser obj)
        {
            var objFromDb = _db.ApplicationUser.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                
                
              
            }
        }
    }
}
