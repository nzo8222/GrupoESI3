using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        private readonly ApplicationDbContext _db;
        public MaterialRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(Material obj)
        {
            var objFromDb = _db.Material.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Price = obj.Price;
                objFromDb.Description = obj.Description;
                
            }
        }
    }
}
