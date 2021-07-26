using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Infra.Data.Mappings
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.Synopsis)
                    .IsRequired()
                    .HasMaxLength(250);
        }
    }
}
