using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public int WeightPriceId { get; set; }

        // Navigation property
        public virtual WeightPrice ? WeightPrice { get; set; }

        public virtual ICollection<ProdOrder>? ProdOrders { get; set; }

    }
}
