using Bogus;
using MoviesApi.Domain.Entities;
using System;

namespace MoviesApi.Domain.Test.Builders
{
    public class MovieBuilder
    {
        static Faker faker = new Faker();
        private static Random random = new Random();
        private static int randomYears = random.Next(5, 10);

        public string Title = faker.Lorem.Paragraph();
        public string Synopsis = faker.Lorem.Paragraphs(2, "\n");
        public int ReleaseYear = faker.Date.Future(randomYears, DateTime.Now).Year;
        public string DirectedBy = faker.Person.FullName;

        public static MovieBuilder New()
        {
            return new MovieBuilder();
        }

        public MovieBuilder MovieWithTitle(string title)
        {
            Title = title;
            return this;
        }

        public MovieBuilder MovieWithSynopsis(string synopsis)
        {
            Synopsis = synopsis;
            return this;
        }

        public MovieBuilder MovieWithReleaseYear(int releaseYear)
        {
            ReleaseYear = releaseYear;
            return this;
        }

        public MovieBuilder MovieWithDirectedBy(string directedBy)
        {
            DirectedBy = directedBy;
            return this;
        }

        public Movie Build()
        {
            return new Movie(Title, Synopsis, ReleaseYear, DirectedBy);
        }
    }
}
