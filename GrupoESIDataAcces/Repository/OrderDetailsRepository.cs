
using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailsRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(OrderDetails obj)
        {
            var objFromDb = _db.OrderDetails.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Service = obj.Service;
                objFromDb.Status = obj.Status;
                objFromDb.Cost = obj.Cost;
              
            }
        }
    }
}
