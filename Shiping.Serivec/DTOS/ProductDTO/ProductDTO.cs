using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.DTOS.ProductDTO
{
    public class ProductDTO
    {
        
          
            //[Required(ErrorMessage = "You Must Enter Product Name ")]
            //[StringLength(100, ErrorMessage = "الاسم لا يجب أن يتجاوز 100 حرف")]
            public string Name { get; set; }

            //[Range(1, int.MaxValue, ErrorMessage = "Must Be one at least")]
            public int Quantity { get; set; }

            //[Range(0.1, double.MaxValue, ErrorMessage = "Must Be At Least 1")]
            public decimal Weight { get; set; }

            public int WeightPriceId { get; set; }
        }
    }

