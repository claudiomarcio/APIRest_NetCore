using ED.Domain.Model.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ED.Infra.Data.EntityConfiguration.Mapping
{
    public class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            {
                builder.ToTable("Gender");
                builder.HasKey(x => x.CodGender);
                builder.Property(x => x.CodGender).ValueGeneratedOnAdd();
            }
        }
    }
}
