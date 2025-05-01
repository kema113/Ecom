using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }        
        public Movie Movie { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }        
        public Order Order { get; set; }
    }
}
