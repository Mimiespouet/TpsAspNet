using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class WebApplication7Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication7Context() : base("name=WebApplication7Context")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasMany(s => s.ArtMartiaux);
            modelBuilder.Entity<Samourai>().HasOptional(s => s.Arme).WithOptionalPrincipal();
        }

        public System.Data.Entity.DbSet<WebApplication7.Models.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<WebApplication7.Models.ArtMartial> ArtMartials { get; set; }
    }
}
