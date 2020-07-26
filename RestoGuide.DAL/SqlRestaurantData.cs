using Microsoft.EntityFrameworkCore;
using RestoGuide.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoGuide.DAL
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestoGuideDbContext restoGuideDbContext;

        public SqlRestaurantData(RestoGuideDbContext restoGuideDbContext)
        {
            this.restoGuideDbContext = restoGuideDbContext;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return restoGuideDbContext.Restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.StartsWith(name)).OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return restoGuideDbContext.Restaurants.Find(restaurantId);

        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            restoGuideDbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = restoGuideDbContext.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant DeleteRestaurant(int restaurantId)
        {
            Restaurant restaurant = GetRestaurantById(restaurantId);

            if(restaurant != null)
            {
                restoGuideDbContext.Remove(restaurant);
            }
            return restaurant;
        }
        public int commit()
        {
            return restoGuideDbContext.SaveChanges();
        }
    }
}
