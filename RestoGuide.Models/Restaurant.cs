using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace RestoGuide.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
