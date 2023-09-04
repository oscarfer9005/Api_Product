using Application.InterfacesRepository;
using Domain.Entities;
using Domain.Events;
using Infraestructure.Configdb;
using Infraestructure.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.persistence
{
    public class ProductRepository : IProductRepository
    {
        private ApiDbContext _apiDbContext;

        public ProductRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public async Task<bool> Create(IProduct product)
        {
            var productDto = new ProductDto()
            { Name = product.Name, Description = product.Description, Category = product.Category, Price = product.Price, Stock = product.Stock };

            _apiDbContext.productDto.Add(productDto);
            var insert = await _apiDbContext.SaveChangesAsync();
            if (insert != 0)
            {
                return true;
            }

            return false;
        }

        public async Task<IProduct> GetProductById(int id)
        {
            ProductDto product = await _apiDbContext.productDto
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);

            if (product == null)
                throw new KeyNotFoundException("product not found");

            return ConvertDtotoDomain(product);

        }

        public async Task<IProduct> GetProductByName(string name, int price1, int price2)
        {
            ProductDto product = await _apiDbContext.productDto
                .AsNoTracking()
                .Where(x => x.Name == name || (x.Price >= price1 && x.Price <= price2))
                .FirstOrDefaultAsync().ConfigureAwait(true);

            if (product == null)
                return null;

            return ConvertDtotoDomain(product);
        }


        public async Task<bool> Update(IProduct product)
        {
            var productDto = new ProductDto()
            { Name = product.Name, Description = product.Description, Category = product.Category, Price = product.Price, Stock = product.Stock };

            _apiDbContext.productDto.Update(productDto);
            var update = await _apiDbContext.SaveChangesAsync();
            if (update != 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            ProductDto product = await _apiDbContext.productDto
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync().ConfigureAwait(true);
            _apiDbContext.productDto.Remove(product);
            var delete = await _apiDbContext.SaveChangesAsync();
            if (delete != 0)
            {
                return true;
            }

            return false;
        }

        public IProduct ConvertDtotoDomain(ProductDto productDto)
        {
            return new ProductDomain() { Name = productDto.Name, Description = productDto.Description, Category = productDto.Category, Price = productDto.Price, Stock = productDto.Stock };
        }
    }
}
