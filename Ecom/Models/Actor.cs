using Ecom.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Ecom.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePicture { get; set; }
        public ICollection<Actor_Movie> Actor_Movies { get; set; }
    }
}
