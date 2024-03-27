using MadisonCafes.Models;
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

        public IActionResult ViewCoffee(int id)
        {
            var coffee = repo.GetCoffee(id);

            return View(coffee);
        }

        public IActionResult UpdateCoffee(int id)
        {
            Coffee coff = repo.GetCoffee(id);

            if (coff == null)
            {
                return View("CoffeeNotFound");
            }

            return View(coff);
        }

        public IActionResult UpdateCoffeeToDatabase(Coffee coffee, IFormFile file)
        {
            string fileName = string.Empty;
            if (file != null && file.Length > 0)
            {
                if (UploadFile(file))
                {
                    fileName = file.FileName;
                }
            }
            coffee.Photo = fileName;
            repo.UpdateCoffee(coffee);

            return RedirectToAction("ViewCoffee", new { id = coffee.CoffeeID });
        }
        public IActionResult InsertCoffee()
        {
            var coff = repo.AssignFeaturedCafe();

            return View(coff);
        }

        public IActionResult InsertCoffeeToDatabase(Coffee coffeeToInsert)
        {
            repo.InsertCoffee(coffeeToInsert);

            return RedirectToAction("Index");
        }
        public IActionResult DeleteCoffee(Coffee coffee)
        {
            repo.DeleteCoffee(coffee);

            return RedirectToAction("Index");
        }

        public bool UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "wwwroot"));
                    string path1 = Path.GetFullPath(Path.Combine(path, "Images"));
                    if (!Directory.Exists(path1))
                    {
                        Directory.CreateDirectory(path1);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path1, file.FileName), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }


        private class Photo
        {
        }
    }
}
