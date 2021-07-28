using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesApi.Domain.Entities;

namespace MoviesApi.Infra.Data.Mappings
{
    public class MovieViewersMap : IEntityTypeConfiguration<MovieViewer>
    {
        public void Configure(EntityTypeBuilder<MovieViewer> builder)
        {
            builder.ToTable("MovieViewer");
            builder.HasKey(x => new { x.MovieId, x.ViewerId });
        }
    }
}
