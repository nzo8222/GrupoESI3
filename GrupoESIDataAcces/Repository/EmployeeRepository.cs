using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class EmployeeRepository : Repository<EmployeeUser>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;
        public EmployeeRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(EmployeeUser obj)
        {
            var objFromDb = _db.Employee.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {

                
            }
        }
    }
}
