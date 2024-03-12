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


        public Coffee GetCoffee(int id)
        {
            return _conn.QuerySingle<Coffee>("SELECT * FROM COFFEE WHERE COFFEEID = @id",
                new { id = id });
        }
    }
}
