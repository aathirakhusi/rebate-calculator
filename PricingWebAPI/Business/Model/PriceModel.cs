using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model
{
    public class PriceModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public float SubTotal { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
