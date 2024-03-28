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
            _conn.Execute("UPDATE coffee SET Cafe = @cafe, Location = @location, Late_Night_Spots =@late_night_spots, Starting_Price = @starting_price, Ambience = @ambience, Wifi = @wifi, Tipping = @tipping, Featured_Cafe = @featured_cafe, photo = @photo, description = @description WHERE COFFEEID = @COFFEEID",
             new { COFFEEID = coffee.CoffeeID, cafe = coffee.Cafe, location = coffee.Location, late_night_spots = coffee.Late_Night_Spots, starting_price = coffee.Starting_Price, ambience = coffee.Ambience, wifi = coffee.Wifi, tipping = coffee.Tipping, featured_cafe = coffee.Featured_Cafe, photo = coffee.Photo, description = coffee.Description }); 
        }
        public void InsertCoffee(Coffee coffeeToInsert)
        {
            _conn.Execute("INSERT INTO coffee (CAFE, LOCATION, LATE_NIGHT_SPOTS, STARTING_PRICE, AMBIENCE, WIFI, TIPPING, FEATURED_CAFE, PHOTO, DESCRIPTION, COFFEEID) VALUES (@cafe, @location, @late_Night_Spots, @starting_Price, @ambience, @wifi, @tipping, @featured_Cafe, @photo, @description, @coffeeID);",
                new { cafe = coffeeToInsert.Cafe, location = coffeeToInsert.Location, late_night_spots = coffeeToInsert.Late_Night_Spots, starting_price = coffeeToInsert.Starting_Price, ambience = coffeeToInsert.Ambience, wifi = coffeeToInsert.Wifi, tipping = coffeeToInsert.Tipping, featured_cafe = coffeeToInsert.Featured_Cafe, photo = coffeeToInsert.Photo, description = coffeeToInsert.Description, coffeeID = coffeeToInsert.CoffeeID });
        }


        public IEnumerable<FeaturedCafe> GetFeaturedCafe()
        {
            return _conn.Query<FeaturedCafe>("SELECT * FROM featured_cafe;");
        }

        public Coffee AssignFeaturedCafe()
        {
            var featuredCafeList = GetFeaturedCafe();
            var coffee = new Coffee();
            coffee.FeaturedCafe = featuredCafeList;

            return coffee;
        }

        public void DeleteCoffee(Coffee coffee)
        {
            _conn.Execute("DELETE FROM coffee WHERE CoffeeID = @id;",
                                   new { id = coffee.CoffeeID });
            _conn.Execute("DELETE FROM featured_cafe WHERE CoffeeID = @id;",
                                       new { id = coffee.CoffeeID });


        }
    }
}
