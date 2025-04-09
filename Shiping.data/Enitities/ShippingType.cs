using System.ComponentModel.DataAnnotations;

namespace Shipping.Data.Entities
{
    public class ShippingType
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public ShippingTypeOrder Type { get; set; }
        public decimal Cost { get; set; }

        public int numberofday  { get; set; }
       

        // Navigation property
        public virtual ICollection< Order>?  Order { get; set; }
        public void SetShippingDetails()
        {
            switch (Type)
            {
                case ShippingTypeOrder.normalshipping:
                    numberofday = 15; // الشحن العادي خلال 15 يوم
                    Cost = 50; // تكلفة الشحن العادي
                    break;

                case ShippingTypeOrder.shipping_24:
                    numberofday = 1; // الشحن خلال 24 ساعة
                    Cost = 150; // يمكنك تعديل السعر حسب احتياجاتك
                    break;

                case ShippingTypeOrder.shipping_15:
                    numberofday = 1; // الشحن خلال 15 يوم
                    Cost = 200; // نفس سعر الشحن العادي
                    break;

                default:
                    numberofday = 15; // القيمة الافتراضية
                    Cost = 89;
                    break;
            }
            }
        }

    
       



    public enum ShippingTypeOrder
    {
        normalshipping=0,
        shipping_24=1,
        shipping_15 = 2,
    }
}

