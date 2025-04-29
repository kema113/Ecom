using Ecom.Data.Base;
using Ecom.Models;

namespace Ecom.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
    }
}
