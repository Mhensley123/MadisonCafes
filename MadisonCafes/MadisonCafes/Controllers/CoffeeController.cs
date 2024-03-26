﻿using MadisonCafes.Models;
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

        public IActionResult UpdateCoffeeToDatabase(Coffee coffee)
        {
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

        

        private class Photo
        {
        }
    }
}
