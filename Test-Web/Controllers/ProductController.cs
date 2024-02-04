using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_Web.Contracts;
using Test_Web.Data.Models;
using Test_Web.Models;

namespace Test_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        public async Task<IActionResult> Index(ProductViewModel model)
        {

            return View();
        }

        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Error));
            }

            try
            {
                await _service.CreateProductAsync(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Succses));
        }

        public async Task<IActionResult> Explore()
        {
            var model = await _service.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var prod = await _service.GetByIdAsync(id);

            return View(prod);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    await _service.UpdateProductAsync(model);

                }
                catch (Exception e)
                {
                    RedirectToAction(nameof(Error));
                    throw;
                }

            }
            return RedirectToAction(nameof(Explore));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                await _service.DeleteProductAsync(id);
            }
            catch (Exception e)
            {
                RedirectToAction(nameof(Error));
            }

            return RedirectToAction(nameof(Explore));
        }

        public IActionResult Succses()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
