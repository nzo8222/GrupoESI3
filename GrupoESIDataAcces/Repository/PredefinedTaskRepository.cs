using GrupoESIModels;
using GrupoESIModels.Models;

using System.Linq;


namespace GrupoESIDataAccess.Repository.IRepository
{
    public class PredefinedTaskRepository : Repository<PredefinedTask>, IPredefinedTaskRepository
    {
        private readonly ApplicationDbContext _db;
        public PredefinedTaskRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(PredefinedTask obj)
        {
           
        }
    }
}
