using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int orderId { get; set; }
        public DateTime Order_Date { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int total_price { get; set; }
        public string status { get; set; }
        public int custId { get; set; }
        public int DelId { get; set; }
    }
}
