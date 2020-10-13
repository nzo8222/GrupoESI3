using GrupoESIModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface ITaskRepository : IRepository<TaskModel>
    {
        public void Update(TaskModel obj);
    }
}
