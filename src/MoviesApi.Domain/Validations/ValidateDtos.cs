using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MoviesApi.Domain.Validations
{
    class ValidateDtos : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "Date value should not be a future date";
        }

        protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
        {
            string stringYear = objValue.ToString();
            Regex regex = new Regex(@"[12]\d{3}");
            Match match = regex.Match(stringYear);

            if (!match.Success)
                FormatErrorMessage("Released year format not valid!");

            if (stringYear.Length > 4)
                FormatErrorMessage("Released year format not valid!");

            return ValidationResult.Success;
        }
    }
}
