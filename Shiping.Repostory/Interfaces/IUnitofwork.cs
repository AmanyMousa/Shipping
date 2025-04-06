using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Repostory.Interfaces
{
    public interface IUnitofwork
    {
        IGenericRepo<T> GetRepository<T>() where T : class;
        Task<int> CompleteAsync();
    }
}
