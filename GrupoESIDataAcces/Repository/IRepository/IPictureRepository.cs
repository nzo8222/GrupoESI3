
using GrupoESIModels.Models;

namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IPictureRepository : IRepository<Picture>
    {
        public void Update(Picture obj);
    }
}
