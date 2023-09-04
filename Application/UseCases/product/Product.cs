using Application.InterfacesApplication;
using Application.InterfacesRepository;
using Domain.Entities;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.product
{
    public class Product : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public Product(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductDomain CreateProductDomain(string name, string descripcion, string categoria, decimal precio, int cantidadInicial)
        {
            return new ProductDomain() { Name = name, Description = descripcion, Category = categoria, Price = precio, Stock = cantidadInicial };
        }

        public async Task<bool> CreateProduct(IProduct product)
        {
            //open/close principle and polymorphism
            var productExist = await _productRepository.GetProductByName(product.Name, 0,0);
            if (productExist != null) throw new ApplicationException("product exists");
            var result = await _productRepository.Create(product);
            if (result) return true;
            return false;
        }

        public async Task<IProduct> GetProduct(string name, int price1, int price2)
        {
            var productDomain = await _productRepository.GetProductByName(name, price1, price2);
            if (productDomain == null)
                throw new KeyNotFoundException("product not found");
            return productDomain;
        }

        public async Task<bool> UpdateProduct(IProduct product)
        {
            //open/close principle and polymorphism
            var productExist = await _productRepository.GetProductByName(product.Name, 0, 0);
            if (productExist != null) throw new ApplicationException("product exists");
            var result = await _productRepository.Update(product);
            if (result) return true;
            return false;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _productRepository.Delete(id);
            if (result) return true;
            return false;
        }
    }
}
