namespace Shipping.Data.Entities
{
    public class WeightPrice
    {
        public int Id { get; set; }
        public decimal AdditionalPrice { get; set; }
        public decimal DefaultWeight { get; set; }
        public decimal DefaultPrice { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
