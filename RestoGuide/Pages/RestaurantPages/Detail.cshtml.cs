using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoGuide.DAL;
using RestoGuide.Entities;

namespace RestoGuide.Pages.RestaurantPages
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [TempData]
        public string Message { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
            if (Restaurant == null)
                return RedirectToPage("./GenericError");
            return Page();
        }
    }
}