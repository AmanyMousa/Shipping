using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IUnitofwork
    {
        IOrderRepository Orders { get; }
        IGovernmentRepository Governments { get; }
        IProductRepository Products { get; }


        IWeightPriceRepository WeightPrices { get; }
        IShippingTypeRepository ShippingTypes { get; }
        IGenericRepo<T,t1> GetRepository<T,t1>() where T : class;
        Task<int> CompleteAsync();
    }
}
