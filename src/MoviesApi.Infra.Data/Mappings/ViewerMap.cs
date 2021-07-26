using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Infra.Data.Mappings
{
    public class ViewerMap : IEntityTypeConfiguration<Viewer>
    {
        public void Configure(EntityTypeBuilder<Viewer> builder)
        {
            builder.ToTable("Viewer");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(200);

            builder.Property(x => x.Email)
                    .IsRequired();
        }
    }
}
