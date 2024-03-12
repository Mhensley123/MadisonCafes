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

        public void UpdateCoffee(Coffee coffee)
        {
            _conn.Execute("UPDATE coffee SET Cafe = @cafe, Location = @location, Late_Night_Spots =@late_night_spots, Starting_Price = @starting_price, Ambience = @ambience, Wifi = @wifi, Tipping = @tipping, Featured_Cafe = @featured_cafe WHERE COFFEEID = @COFFEEID",
             new { COFFEEID = coffee.CoffeeID, cafe = coffee.Cafe, location = coffee.Location, late_night_spots = coffee.Late_Night_Spots, starting_price = coffee.Starting_Price, ambience = coffee.Ambience, wifi = coffee.Wifi, tipping = coffee.Tipping, featured_cafe = coffee.Featured_Cafe });
        }
    }
}
