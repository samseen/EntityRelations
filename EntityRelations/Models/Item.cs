using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityRelations.Models
{
    public class Item
    {
        public Item()
        {
            Orders = new List<Order>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ItemID { get; set; }

        [Required]
        [MaxLength(128)]
        public String Description { get; set; }

        public int ReorderQuantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}