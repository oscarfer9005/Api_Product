using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Events;

namespace Application.InterfacesRepository
{
    public interface IProductRepository
    {
        Task<bool> Create(IProduct product);

        Task<IProduct> GetProductById(int id);

        Task<IProduct> GetProductByName(string name, int price1, int price2);

        Task<bool> Update(IProduct product);
        Task<bool> Delete(int id);
    }
}
