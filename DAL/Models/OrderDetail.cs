using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int qty { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int productID { get; set; }
        [Required]
        public int orderID { get; set; }

    }
}
