
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class QuotationRepository : Repository<Quotation>, IQuotationRepository
    {
        private readonly ApplicationDbContext _db;
        public QuotationRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(Quotation obj)
        {
            var objFromDb = _db.Quotation.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Description = obj.Description;
                objFromDb.Tasks = obj.Tasks;
                
              
            }
        }
    }
}
