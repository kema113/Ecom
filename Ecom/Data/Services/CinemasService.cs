using Ecom.Data.Base;
using Ecom.Models;

namespace Ecom.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext db) : base(db)
        {
        }
    }
}
