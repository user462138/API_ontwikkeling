using Microsoft.Extensions.Hosting;
using RestaurantPersonDI.Models;

namespace RestaurantPersonDI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private static readonly List<Restaurant> AllRestaurants = new();
        public Task CreateRestaurant(Restaurant item)
        {
            AllRestaurants.Add(item);
            return Task.CompletedTask;
        }
        public Task<Restaurant> UpdateRestaurant(int id, Restaurant item)
        {
            var Restaurant = AllRestaurants.FirstOrDefault(x => x.Id == id);
            if (Restaurant != null)
            {
                Restaurant.Id = item.Id;
                Restaurant.Name = item.Name;
                Restaurant.Location = item.Location;
                Restaurant.CuisineType = item.CuisineType;
                Restaurant.Rating = item.Rating;
            }
            return Task.FromResult(Restaurant);
        }

        public Task<Restaurant> GetRestaurantById(int id)
        {
            return Task.FromResult(AllRestaurants.FirstOrDefault(x => x.Id == id));
        }

        public Task<List<Restaurant>> GetAllRestaurants()
        {
            return Task.FromResult(AllRestaurants);
        }

        public Task DeleteRestaurant(int id)
        {
            var Restaurant = AllRestaurants.FirstOrDefault(x => x.Id == id);
            if (Restaurant != null)
            {
                AllRestaurants.Remove(Restaurant);
            }

            return Task.CompletedTask;
        }
    }
}
