using Ecom.Data.Base;
using Ecom.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public ICollection<Actor_Movie> Actors_Movie { get; set; }
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema {  get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        
    }
}
