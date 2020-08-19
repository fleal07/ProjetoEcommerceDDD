using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace Web_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IInterfaceProductApp _iInterfaceProductApp;

        public ProductController(IInterfaceProductApp iInterfaceProductApp)
        {
            _iInterfaceProductApp = iInterfaceProductApp;
        }

        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            return View(await _iInterfaceProductApp.List());
        }

        // GET: ProductController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(await _iInterfaceProductApp.GetEntityById(id));
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            try
            {
                await _iInterfaceProductApp.AddProduct(product);

                if (product.Notificacoes.Any())
                {
                    foreach (var item in product.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View("Edit", product);
                }
            }
            catch
            {
                return View("Edit", product);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _iInterfaceProductApp.GetEntityById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            try
            {
                //Tenta realizar a alteração
                await _iInterfaceProductApp.UpdateProduct(product);

                //Se houver algum erro
                if (product.Notificacoes.Any())
                {
                    //Cria uma lista de erros
                    foreach (var item in product.Notificacoes)
                    {
                        ModelState.AddModelError(item.NomePropriedade, item.Mensagem);
                    }

                    return View("Edit", product);
                }
            }
            catch
            {
                return View("Edit", product);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _iInterfaceProductApp.GetEntityById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Product product)
        {
            try
            {
                await _iInterfaceProductApp.Delete(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
