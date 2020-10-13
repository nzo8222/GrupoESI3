using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(Service obj)
        {
            var objFromDb = _db.ServiceModel.FirstOrDefault(o => o.ID == obj.ID);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.serviceType = obj.serviceType;
                objFromDb.Description = obj.Description;
            }
        }
    }
}
