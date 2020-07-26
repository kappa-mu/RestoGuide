using RestoGuide.Entities;
using System.Collections;
using System.Collections.Generic;

namespace RestoGuide.DAL
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int restaurantId);

        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);

        Restaurant CreateRestaurant(Restaurant newRestaurant);

        Restaurant DeleteRestaurant(int restaurantId);
        int commit();
    }
}