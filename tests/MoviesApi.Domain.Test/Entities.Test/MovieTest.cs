using MoviesApi.Domain.Test.Builders;
using System;
using Xunit;

namespace MoviesApi.Domain.Test.Entities.Test
{
    public class MovieTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_be_not_accept_invalid_titles(string invalidTitles)
        {
            Assert.Throws<ArgumentException>(() =>
                MovieBuilder.New().MovieWithTitle(invalidTitles).Build()
            )
            .AssertThrowsWithMessage("Title is required!");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_be_not_accept_invalid_synopsis(string invalidSynopsis)
        {
            Assert.Throws<ArgumentException>(() =>
                MovieBuilder.New().MovieWithSynopsis(invalidSynopsis).Build()
            )
            .AssertThrowsWithMessage("Synopsis is required!");
        }

        [Theory]
        [InlineData(2)]
        [InlineData(20)]
        [InlineData(202)]
        [InlineData(20234)]
        public void Should_be_not_accept_invalid_released_year(int invalidYear)
        {
            Assert.Throws<ArgumentException>(() =>
                MovieBuilder.New().MovieWithReleaseYear(invalidYear).Build()
            )
            .AssertThrowsWithMessage("Released year format not valid!");
        }
    }
}
