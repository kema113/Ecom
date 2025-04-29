using Ecom.Data.Base;
using Ecom.Data.ViewModels;
using Ecom.Models;

namespace Ecom.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();

    }
}
