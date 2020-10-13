
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(Order obj)
        {
            var objFromDb = _db.Order.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                
              
            }
        }
    }
}
