using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public class TaskRepository : Repository<TaskModel>, ITaskRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(TaskModel obj)
        {
            var objFromDb = _db.Task.FirstOrDefault(o => o.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.ListMaterial = obj.ListMaterial;
                objFromDb.Description = obj.Description;
                objFromDb.Duration = obj.Duration;
                objFromDb.Cost = obj.Cost;
                objFromDb.CostHandLabor = obj.CostHandLabor;
                objFromDb.Pictures = obj.Pictures;
                
            }
        }
    }
}
