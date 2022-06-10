using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductAndSparepart.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAndSparepart.Data.Configurations
{
    public class ProductWithSparepartConfiguration : IEntityTypeConfiguration<ProductWithSparepart>
    {
        public void Configure(EntityTypeBuilder<ProductWithSparepart> builder)
        {
            builder.HasKey(a => new { a.SparepartID, a.ProductID });
            builder.HasOne(pt => pt.Product).WithMany(p => p.ProductWithSpareparts).HasForeignKey(pt => pt.ProductID);
            builder.HasOne(pt => pt.Sparepart).WithMany(t => t.ProductWithSpareparts).HasForeignKey(pt => pt.SparepartID);
        }
    }
}
