using Ecom.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Cinema: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
