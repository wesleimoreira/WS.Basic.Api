
using WS.Basic.Webapi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WS.Basic.Webapi.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(ca => ca.CategoryId);
            builder.Property(ca => ca.Title).HasColumnType("VARCHAR(200)").IsRequired();

            builder
            .HasMany(pro => pro.GetProducts)
            .WithOne(ca => ca.GetCategory)
            .HasForeignKey(pro => pro.CategoryID);
        }
    }
}

