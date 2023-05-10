using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int qty { get; set; }
        public int price { get; set; }
        public int productID { get; set; }
        public int orderID { get; set; }
    }
}
