using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        public void Update(Order obj);
    }
}
