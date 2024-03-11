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
    }
}
