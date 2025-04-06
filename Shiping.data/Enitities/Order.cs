using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public DateTime Data { get; set; }
        public bool IsToVillage { get; set; }
        public bool IsDeleted { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal ShippingCost { get; set; }
        public string OrderType { get; set; }
        public int BranchId { get; set; }
        public int GovId { get; set; }
        public int CityId { get; set; }
        public string UserId { get; set; }

        // Navigation properties
        public Branch Branch { get; set; }
        public Government Gov { get; set; }
        public City City { get; set; }
        public User User { get; set; }

        public virtual ICollection<RejectionOrder>? RejectionOrders { get; set; }
        public virtual ICollection<ShippingType>? ShippingTypes { get; set; }
        public virtual ICollection<ProdOrder>? ProdOrders { get; set; }

    }
}
