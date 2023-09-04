using Domain.Entities;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfacesApplication
{
    public interface IProductUseCase
    {
        Task<bool> CreateProduct(IProduct product);
        ProductDomain CreateProductDomain(string name, string descripcion, string categoria, decimal precio, int cantidadInicial);
        Task<IProduct> GetProduct(string name, int price1, int price2);
        Task<bool> UpdateProduct(IProduct product);
        Task<bool> DeleteProduct(int id);
    }
}
