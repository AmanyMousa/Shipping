using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shipping.Data.Entities.Order;

namespace Shipping.Service.DTOS.OrdersDTOS
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public DateTime Date { get; set; }
        public bool IsToVillage { get; set; }
        public decimal TotalWeight { get; set; }
        public decimal ShippingCost { get; set; }
        public int shipID { set; get; }

        public OrderTypeEnum OrderType { get; set; }
        public int BranchId { get; set; }
        public int GovId { get; set; }
        public int CityId { get; set; }
        //public string UserId { get; set; }
    }
}
