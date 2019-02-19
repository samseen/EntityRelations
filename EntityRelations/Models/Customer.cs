using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EntityRelations.Models
{
    public class Customer
    {
        //public Customer()
        //{
        //    Orders = new HashSet<Order>();
        //}

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerID { get; set; }

        [Required]
        [MaxLength(128)]
        public string CustomerName { get; set; }
    }
}