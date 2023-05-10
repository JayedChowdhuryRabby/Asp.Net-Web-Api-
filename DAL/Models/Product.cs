using DAL.Models.SignUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public string Image { get; set; }
        [ForeignKey("Category")]
        public int C_Id { get; set; }
        [ForeignKey("Seller")]
        public int SellBy { get; set; }
        public virtual Category Category { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
