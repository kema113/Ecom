using Ecom.Data.Base;
using Ecom.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecom.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>,IActorsService
    {
        public ActorsService(AppDbContext db) : base(db) { }
           
    }
}
