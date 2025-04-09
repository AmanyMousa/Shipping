using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.Data.Entities;

namespace Shipping.Service.DTOS.Order
{
    public class OrderCreateDto   
    {
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public DateTime Date { get; set; }
        public bool IsToVillage { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal ShippingCost { get; set; }
        public OrderType OrderType { get; set; }
        public int BranchId { get; set; }
        public int GovId { get; set; }
        public int CityId { get; set; }
        public string UserId { get; set; }
        public int ShipID { get; set; }
    }
}
