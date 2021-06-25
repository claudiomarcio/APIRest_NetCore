
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ED.Domain.Model.Models.Entities;

namespace ED.Infra.Data.EntityConfiguration.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
     {
        public void Configure(EntityTypeBuilder<Author> builder)
        {         
            {
                builder.ToTable("Author");
                builder.HasKey(x => x.CodAuthor);                
                builder.Property(x => x.CodAuthor).ValueGeneratedOnAdd();

            }
        }        
    }
}
