using Bogus;
using MoviesApi.Domain.Entities;
using System;

namespace MoviesApi.Domain.Test.Builders
{
    public class ViewerBuilder
    {
        static Faker faker = new Faker();
        private static Random random = new Random();

        public string Name = faker.Person.FullName;
        public int Age = random.Next(5, 40);
        public string Email = faker.Person.Email;
        public string PhoneNumber = faker.Person.Phone;

        public static ViewerBuilder New()
        {
            return new ViewerBuilder();
        }

        public ViewerBuilder ViewerWithName(string name)
        {
            Name = name;
            return this;
        }

        public ViewerBuilder ViewerWithAge(int age)
        {
            Age = age;
            return this;
        }

        public ViewerBuilder ViewerWithEmail(string email)
        {
            Email = email;
            return this;
        }

        public ViewerBuilder ViewerWithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public Viewer Build()
        {
            return new Viewer(Name, Age, Email, PhoneNumber);
        }
    }
}
