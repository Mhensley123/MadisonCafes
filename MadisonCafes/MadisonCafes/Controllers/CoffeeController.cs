using Microsoft.AspNetCore.Mvc;

namespace MadisonCafes.Controllers
{
    public class CoffeeController : Controller
    {
        private readonly ICoffeeRepository repo;

        public CoffeeController(ICoffeeRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var coffee = repo.GetAllCoffee();

            return View(coffee);
        }
    }
}
