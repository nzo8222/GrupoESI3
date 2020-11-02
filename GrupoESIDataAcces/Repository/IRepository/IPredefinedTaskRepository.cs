using GrupoESIModels;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IPredefinedTaskRepository : IRepository<PredefinedTask>
    {
        public void Update(PredefinedTask obj);
    }
}
