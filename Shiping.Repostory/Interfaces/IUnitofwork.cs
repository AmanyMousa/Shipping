using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IUnitofwork
    {
        IGenericRepo<T,t1> GetRepository<T,t1>() where T : class;
        Task<int> CompleteAsync();
    }
}
