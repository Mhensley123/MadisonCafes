using MadisonCafes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace MadisonCafes
{
    public interface ICoffeeRepository
    {
        public IEnumerable<Coffee> GetAllCoffee();
        public Coffee GetCoffee(int id);
        public void UpdateCoffee(Coffee coffee);
        public void InsertCoffee(Coffee coffeeToInsert);
        public IEnumerable<FeaturedCafe> GetFeaturedCafe();
        public Coffee AssignFeaturedCafe();
        public void DeleteCoffee(Coffee coffee);
    }


}
