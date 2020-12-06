using GrupoESIModels;
using GrupoESIModels.Models;

using System.Linq;


namespace GrupoESIDataAccess.Repository.IRepository
{
    public class PredefinedMaterialRepository : Repository<PredefinedMaterial>, IPredefinedMaterialRepository
    {
        private readonly ApplicationDbContext _db;
        public PredefinedMaterialRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
        public void Update(PredefinedMaterial obj)
        {
           
        }
    }
}
