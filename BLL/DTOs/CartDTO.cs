using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class CartDTO
    {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public virtual Product Product { get; set; }
            public string CustomerId { get; set; }
            public virtual Customer Customer { get; set; }
     

    }
}
