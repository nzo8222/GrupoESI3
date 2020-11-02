using GrupoESIModels.Models;


namespace GrupoESIDataAccess.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        public void Update(Order obj);
    }
}
