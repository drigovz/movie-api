using Api.Domain.Test.Builders;
using System;
using Xunit;

namespace Api.Domain.Test.Entities.Test
{
    public class ViewerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_be_not_accept_null_or_empty_names(string invalidNames)
        {
            Assert.Throws<ArgumentException>(() =>
                ViewerBuilder.New().ViewerWithName(invalidNames).Build()
            )
            .AssertThrowsWithMessage("Name is required!");
        }

        [Theory]
        [InlineData("a")]
        [InlineData("ab")]
        public void Should_be_not_accept_invalid_names(string invalidNames)
        {
            Assert.Throws<ArgumentException>(() =>
                ViewerBuilder.New().ViewerWithName(invalidNames).Build()
            )
            .AssertThrowsWithMessage("Name not valid!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Should_be_not_accept_invalid_ages(int invalidAges)
        {
            Assert.Throws<ArgumentException>(() =>
                ViewerBuilder.New().ViewerWithAge(invalidAges).Build()
            )
            .AssertThrowsWithMessage("Age not valid!");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Should_be_not_accept_null_or_empty_email(string invalidEmails)
        {
            Assert.Throws<ArgumentException>(() =>
                ViewerBuilder.New().ViewerWithEmail(invalidEmails).Build()
            )
            .AssertThrowsWithMessage("Email is required!");
        }

        [Theory]
        [InlineData("email")]
        [InlineData("email@")]
        [InlineData(".com")]
        [InlineData("test@email")]
        public void Should_be_not_accept_invalid_emails(string invalidEmails)
        {
            Assert.Throws<ArgumentException>(() =>
                ViewerBuilder.New().ViewerWithEmail(invalidEmails).Build()
            )
            .AssertThrowsWithMessage("Email not valid!");
        }
    }
}