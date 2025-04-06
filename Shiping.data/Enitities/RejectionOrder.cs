namespace Shipping.Data.Entities
{
    public class RejectionOrder
    {
        public int Id { get; set; } // Primary key
        public string Reason { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderId { get; set; } // Foreign key from Order
        public virtual Order? Order { get; set; }
    }
}
