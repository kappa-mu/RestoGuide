using RestoGuide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestoGuide.DAL
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>() {
                new Restaurant  {   Id = 1, Name = "6 Ballygunge Place", Cuisine = CuisineType.Bengali, Location = "Saltlake" },
                new Restaurant  {   Id = 2, Name = "Karaikudi", Cuisine = CuisineType.Chettinad, Location = "Chennai" },
                new Restaurant  {   Id = 3, Name = "Hatari", Cuisine = CuisineType.Chinese, Location = "Tegharia" },
                new Restaurant  {   Id = 4, Name = "Brickwood Pizza", Cuisine = CuisineType.Continental, Location = "Ripon Street" },
                new Restaurant  {   Id = 5, Name = "Momo I Am", Cuisine = CuisineType.Tibetan, Location = "Chinar Park" }
            };
        }

        public int commit()
        {
            return 0;
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int RestaurantId)
        {
            Restaurant deletedRestaurant = restaurants.FirstOrDefault(r => r.Id == RestaurantId);
            if(deletedRestaurant != null)
            {
                restaurants.Remove(deletedRestaurant);
            }
            return deletedRestaurant;
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restaurants.FirstOrDefault(r => r.Id == restaurantId);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(r => String.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name);
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            Restaurant restaurant = restaurants.FirstOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant = CopyRestaurant(updatedRestaurant, restaurant);
            }
            return restaurant;
        }

        //Helper Methods
        private Restaurant CopyRestaurant(Restaurant updatedRestaurant, Restaurant restaurant)
        {
            restaurant.Name = updatedRestaurant.Name;
            restaurant.Location = updatedRestaurant.Location;
            restaurant.Cuisine = updatedRestaurant.Cuisine;

            return restaurant;
        }
    }
}
