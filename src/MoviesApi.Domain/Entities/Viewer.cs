using System;
using System.Text.RegularExpressions;

namespace MoviesApi.Domain.Entities
{
    public class Viewer : BaseEntity
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        private Viewer()
        {
        }

        public Viewer(string name, int age, string email, string phoneNumber)
        {
            Validations(name, age, email);

            Name = name;
            Age = age;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        private void Validations(string name, int age, string email)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name is required!");

            if (name.Length <= 2)
                throw new ArgumentException("Name not valid!");

            if (age < 1)
                throw new ArgumentException("Age not valid!");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email is required!");

            if (!ValidateEmail(email))
                throw new ArgumentException("Email not valid!");
        }

        private bool ValidateEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
