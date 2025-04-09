using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.ProductDTO
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[Range(1, int.MaxValue, ErrorMessage = "Must Be one at least")]
        public int Quantity { get; set; }

        //[Range(0.1, double.MaxValue, ErrorMessage = "Must Be At Least 1")]
        public decimal Weight { get; set; }

        public int WeightPriceId { get; set; }
    }
}
