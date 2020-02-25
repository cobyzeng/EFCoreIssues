using System.Threading.Tasks;
using Ordering.Domain;

namespace Ordering.Repository
{
    public interface IOrderRepository
    {
        Task<Order> Find(int orderId);
        Task Complete();
    }
}
