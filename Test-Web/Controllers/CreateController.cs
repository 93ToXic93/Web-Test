using Microsoft.AspNetCore.Mvc;
using Test_Web.Contracts;
using Test_Web.Models;

namespace Test_Web.Controllers
{
    public class CreateController : Controller
    {
        private readonly IProductService _service;

        public CreateController(IProductService service)
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
