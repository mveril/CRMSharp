using CRMSharp.Models;

namespace CRMSharp.Services
{
    public class OrderRepository : CRUDRepositoryBase<Order, CRMContext>, IOrderRepository
    {
        public OrderRepository(CRMContext context) : base(context)
        {

        }
    }
}
