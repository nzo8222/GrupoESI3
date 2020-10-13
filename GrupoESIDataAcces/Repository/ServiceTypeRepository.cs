using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class ServiceTypeRepository : Repository<ServiceType>, IServiceTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceTypeRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(ServiceType obj)
        {
            var objFromDb = _db.ServiceType.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Category = obj.Category;
                objFromDb.Descripcion = obj.Descripcion;
                
            }
        }
    }
}
