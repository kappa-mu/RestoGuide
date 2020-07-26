using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestoGuide.DAL;

namespace RestoGuide.Pages.RestaurantPages
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration confgiuration;
        private readonly IRestaurantData restaurantData;

        public string Message { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; }

        public IEnumerable<Entities.Restaurant> Restaurants { get; set; }

        public ListModel(IConfiguration confgiuration, IRestaurantData restaurantData)
        {
            this.confgiuration = confgiuration;
            this.restaurantData = restaurantData;   
        }

        public void OnGet()
        {
            Message = confgiuration.GetValue<string>("Message");
            Restaurants = restaurantData.GetRestaurantsByName(SearchString);
        }
    }
}
