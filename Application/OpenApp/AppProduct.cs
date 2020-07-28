using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProducts;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : IInterfaceProductApp
    {
        IProduct _iproduct;
        IServiceProduct _iserviceproduct;

        public AppProduct(IProduct iproduct, IServiceProduct iserviceproduct)
        {
            _iproduct = iproduct;
            _iserviceproduct = iserviceproduct;
        }

        public async Task AddProduct(Product product)
        {
            await _iserviceproduct.AddProduct(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _iserviceproduct.UpdateProduct(product);
        }


        public async Task Add(Product Objeto)
        {
            await _iproduct.Add(Objeto);
        }

        public async Task Update(Product Objeto)
        {
            await _iproduct.Update(Objeto);
        }

        public async Task Delete(Product Objeto)
        {
            await _iproduct.Delete(Objeto);
        }

        public async Task<Product> GetEntityById(int Id)
        {
            return await _iproduct.GetEntityById(Id);
        }

        public async Task<List<Product>> List()
        {
            return await _iproduct.List();
        }
    }
}
