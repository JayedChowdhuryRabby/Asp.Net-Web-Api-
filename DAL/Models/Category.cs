using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Category_Name { get; set;}
        public virtual ICollection<Product> Products { get;set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
