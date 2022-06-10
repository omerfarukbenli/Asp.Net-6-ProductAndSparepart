using Microsoft.EntityFrameworkCore;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Data.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //  {
        //       base.OnConfiguring(optionsBuilder);
        //      optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=odev;Trusted_Connection=True;");
        // }


        public DbSet<Product> Products { get; set; }
        public DbSet<Sparepart> Spareparts { get; set; }
        public DbSet<ProductWithSparepart> ProductWithSpareparts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //mapin kısa yolu // bütün assembly'yi tara // mapin klasötünü tarıyor seed'ide mapin klasörüne at o da taransın

            base.OnModelCreating(modelBuilder);
        }
    }
}
