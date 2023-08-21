using WS.Basic.Webapi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WS.Basic.Webapi.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(pro => pro.ProductID);
            builder.Property(pro => pro.Quantity).HasColumnType("INT").IsRequired();
            builder.Property(pro => pro.Name).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(pro => pro.Price).HasColumnType("DECIMAL(10,2)").IsRequired();
            builder.Property(pro => pro.IsProductActive).HasColumnType("BIT").IsRequired();

            builder.Property(pro => pro.CategoryID).HasColumnType("INT").IsRequired();
        }
    }
}