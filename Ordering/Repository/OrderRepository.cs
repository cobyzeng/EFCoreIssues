using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain;
using Ordering.Infrastructure;

namespace Ordering.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderingContext _context;

        public OrderRepository(OrderingContext context)
        {
            _context = context;
        }

        public async Task<Order> Find(int orderId)
        {
            _context.AttachRange(JobStatus.List());
            var entity = await _context.Orders
                .Where(o => o.Id == orderId)
                .Include(o => o.Jobs)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task Complete()
        {
            _context.ChangeTracker.DetectChanges();
            await _context.SaveChangesAsync(true);
        }
    }
}
