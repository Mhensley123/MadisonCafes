using MadisonCafes.Models;
using Dapper;
using System.Data;

namespace MadisonCafes
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly IDbConnection _conn;
        public CoffeeRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Coffee> GetAllCoffee()
        {
            return _conn.Query<Coffee>("Select * from coffee;");
        }

       
        
    }
}
