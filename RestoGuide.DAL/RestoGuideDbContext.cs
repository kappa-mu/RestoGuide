using Microsoft.EntityFrameworkCore;
using RestoGuide.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestoGuide.DAL
{
    public class RestoGuideDbContext : DbContext
    {
        public RestoGuideDbContext(DbContextOptions<RestoGuideDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
