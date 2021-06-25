using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ED.Domain.Model.Models.Entities;

namespace ED.Infra.Data.EntityConfiguration.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
     {
        public void Configure(EntityTypeBuilder<Category> builder)
        {         
            {
                builder.ToTable("Category");             
                builder.HasKey(x => x.CodCategory);
                builder.Property(x => x.CodCategory).ValueGeneratedOnAdd();
            }
        }

        
    }
}
