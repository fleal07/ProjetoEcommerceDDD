using Domain.Interfaces.InterfaceProducts;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServicesProduct : IServiceProduct
    {
        private bool validaNome, validaValor;
        private readonly IProduct _iproduct;

        public ServicesProduct(IProduct iproduct)
        {
            validaNome = false;
            validaValor = false;

            _iproduct = iproduct;
        }

        public async Task AddProduct(Product product)
        {
            validaNome = product.ValidarPropriedadesString(product.Nome, "Nome");
            validaValor = product.ValidarPropriedadesDecimal(product.Valor, "Valor");

            if (validaNome && validaValor)
            {
                product.Estado = true;
                await _iproduct.Add(product);
            }
        }

        public async Task UpdateProduct(Product product)
        {
            validaNome = product.ValidarPropriedadesString(product.Nome, "Nome");
            validaValor = product.ValidarPropriedadesDecimal(product.Valor, "Valor");

            if (validaNome && validaValor)
            {
                await _iproduct.Update(product);
            }

        }
    }
}
