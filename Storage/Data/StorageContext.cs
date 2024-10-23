using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storage.Models;
using Storage.Models.ViewModels;

namespace Storage.Data
{
    public class StorageContext : DbContext
    {
        public StorageContext (DbContextOptions<StorageContext> options)
            : base(options)
        {
        }

        public DbSet<Storage.Models.Product> Product { get; set; } = default!;
        //public DbSet<Storage.Models.ViewModels.ProductIndexViewModel> ProductIndexViewModel { get; set; } = default!;
        //public DbSet<Storage.Models.ViewModels.ProductIndexViewModel> ProductIndexViewModel { get; set; } = default!;
        //Ska inte anändas för att skapa en databas
    }
}
