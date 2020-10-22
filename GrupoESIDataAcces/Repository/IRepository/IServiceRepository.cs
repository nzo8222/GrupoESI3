using GrupoESIModels.Models;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IServiceRepository : IRepository<Service>
    {
        public void Update(Service obj);
    }
}
