using Shipping.Data.Entities;
using Shipping.Data;
using Shipping.Repostory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shipping.Repostory.Repostories
{

    public class ShippingTypeRepository
    :IShippingTypeRepository
    {
        private readonly ShippingDbContext _context;

        public ShippingTypeRepository(ShippingDbContext context) 
        {
            _context = context;

        }          
      
        public async Task<IEnumerable<ShippingType>> GetAllShippingTypesAsync()
        {
            return await _context.ShippingTypes.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<ShippingType> GetShippingTypeByIdAsync(int id)
        {
            return await _context.ShippingTypes.FindAsync(id);
        }

        public async Task AddShippingTypeAsync(ShippingType shippingType)
        {
            await _context.ShippingTypes.AddAsync(shippingType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShippingTypeAsync(int id, ShippingType updatedShippingType)
        {
            var existingShippingType = await _context.ShippingTypes.FindAsync(id);
            if (existingShippingType != null)
            {
                // تحديث الخصائص المطلوبة فقط
                existingShippingType.Type = updatedShippingType.Type;
                existingShippingType.Cost = updatedShippingType.Cost;
                existingShippingType.numberofday = updatedShippingType.numberofday;
                // لا تقم بتعديل IsDeleted هنا إلا إذا كنت تريد إعادة تفعيل السجل
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteShippingTypeAsync(int id)//soft delete
        {
            var shippingType = await _context.ShippingTypes.FindAsync(id); // استخدام FindAsync لتحسين الأداء
            if (shippingType != null)
            {
                shippingType.IsDeleted = true;  // تعيين السجل كـ "محذوف"
                await _context.SaveChangesAsync();  // استخدم SaveChangesAsync بدلاً من SaveChanges
            }
        }
    }
}
