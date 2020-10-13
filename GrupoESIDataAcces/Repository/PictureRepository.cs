using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class PictureRepository : Repository<Picture>, IPictureRepository
    {
        private readonly ApplicationDbContext _db;
        public PictureRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(Picture obj)
        {
            var objFromDb = _db.Pictures.FirstOrDefault(o => o.PictureId == obj.PictureId);
            if (objFromDb != null)
            {
                objFromDb.PictureBytes = obj.PictureBytes;
                
            }
        }
    }
}
