namespace Shipping.Data.Entities
{
    public class ProdOrder
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        // Navigation properties
        public virtual Product ? Product { get; set; }
        public virtual Order ? Order { get; set; }
    }
}

