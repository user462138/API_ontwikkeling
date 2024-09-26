using RestaurantMinimalAPI.Models;

namespace RestaurantPersonDI.Services
{
    public interface IRestaurantService
    {
        Task CreateRestaurant(Restaurant item);
        Task<Restaurant> UpdateRestaurant(int id, Restaurant item);
        Task<Restaurant> GetRestaurantById(int id);
        Task<List<Restaurant>> GetAllRestaurants();
        Task DeleteRestaurant(int id);
    }
}
