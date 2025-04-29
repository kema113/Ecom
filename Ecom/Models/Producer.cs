using Ecom.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Producer: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
