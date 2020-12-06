using GrupoESIModels;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IPredefinedMaterialRepository : IRepository<PredefinedMaterial>
    {
        public void Update(PredefinedMaterial obj);
    }
}
