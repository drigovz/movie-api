using System;
using System.Text.RegularExpressions;

namespace MoviesApi.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; private set; }
        public string Synopsis { get; private set; }
        public int ReleaseYear { get; private set; }
        public string DirectedBy { get; private set; }

        private Movie()
        {
        }

        public Movie(string title, string synopsis, int releaseYear, string directedBy)
        {
            Validations(title, synopsis);
            ValidateReleaseYear(releaseYear);

            Title = title;
            Synopsis = synopsis;
            ReleaseYear = releaseYear;
            DirectedBy = directedBy;
        }

        private void Validations(string title, string synopsis)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title is required!");

            if (string.IsNullOrEmpty(synopsis))
                throw new ArgumentException("Synopsis is required!");
        }

        private void ValidateReleaseYear(int releaseYear)
        {
            string stringYear = releaseYear.ToString();
            Regex regex = new Regex(@"[12]\d{3}");
            Match match = regex.Match(stringYear);

            if (!match.Success)
                throw new ArgumentException("Released year format not valid!");

            if (stringYear.Length > 4)
                throw new ArgumentException("Released year format not valid!");
        }
    }
}
