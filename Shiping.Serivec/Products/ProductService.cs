using AutoMapper;
using Microsoft.Extensions.Logging;
using Shipping.Data.Entities;
using Shipping.Repostory.Interfaces;
using Shipping.Repostory.Repostories;
using Shipping.Service.DTOS.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Service.Products
{
   
 
        public class ProductService : IProductServices
        {
            private readonly IUnitofwork _unitOfWork;
            private readonly IMapper _mapper;

            public ProductService(
                IUnitofwork unitOfWork,
                IMapper mapper
                )
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<ProductDTO> GetByIdAsync(int id)
            {
            //try
            //{
            //    var product = await _unitOfWork.Products.GetByIdAsync(id);
            //    if (product == null)
            //    {
            //        throw new KeyNotFoundException($"Product with ID {id} not found");
            //    }
            //    return _mapper.Map<ProductDTO>(product);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Product Id Expetion");
            //}

            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
        }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
            {
            //try
            //{
            //    var products = await _unitOfWork.Products.GetAllAsync();
            //    return _mapper.Map<IEnumerable<ProductDTO>>(products);
            //}
            //catch (Exception ex)
            //{
            //throw new Exception ("Error getting all products",ex);

            //}
                        var products = await _unitOfWork.Products.GetAllAsync();

            if (!products.Any())
            {
                return Enumerable.Empty<ProductDTO>();
            }
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

            public async Task AddAsync(ProductUpdateDTO productDto)
            {
            if (_unitOfWork == null)
                throw new InvalidOperationException("UnitOfWork is not initialized.");
            if (_unitOfWork.Products == null)
                throw new InvalidOperationException("Products repository is not initialized.");


            if (productDto == null)
                throw new ArgumentNullException(nameof(productDto));

            var product = _mapper.Map<Product>(productDto);

            // التحقق من صحة المابينج
            if (product == null)
                throw new InvalidOperationException("Mapping failed - result is null");

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

        }

            public async Task<bool> UpdateAsync(int id, ProductUpdateDTO productDto)
            {
                try
                {
                    if (id != productDto.Id)
                        return false;

                    var existingProduct = await _unitOfWork.Products.GetByIdAsync(id);
                    if (existingProduct == null)
                        return false;

                    _mapper.Map(productDto, existingProduct);
                    _unitOfWork.Products.Update(existingProduct);
                    await _unitOfWork.CompleteAsync();
                    return true;
                }
                catch (Exception ex)
                {
                throw new Exception ("Error updating product",ex);
                    
                }
            }

            public async Task<bool> DeleteAsync(int id)
            {
                try
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(id);
                    if (product == null)
                        return false;

                    _unitOfWork.Products.Delete(product);
                    await _unitOfWork.CompleteAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception ( "Error deleting product with ID", ex);
                    
                }
            }

            public async Task<IEnumerable<ProductDTO>> GetByWeightPriceIdAsync(int weightPriceId)
            {
                try
                {
                    var products = await _unitOfWork.Products.GetByWeightPriceIdAsync(weightPriceId);
                    return _mapper.Map<IEnumerable<ProductDTO>>(products);
                }
                catch (Exception ex)
                {
                throw new Exception ( "Error getting products by weight price ID", ex);
                   
                }
            }

            public async Task<int> GetProductCountAsync()
            {
            try
            {
                return await _unitOfWork.Products.CountAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product count", ex);
            }
            }

       
        public async Task<IEnumerable<ProductDTO>> GetProductsInStockAsync()
            {
                try
                {
                    var products = await _unitOfWork.Products.GetProductsInStockAsync();
                    return _mapper.Map<IEnumerable<ProductDTO>>(products);
                }
                catch (Exception ex)
                {
                   throw new Exception( "Error getting products in stock",ex);
                    
                }
            }
        }
    }

