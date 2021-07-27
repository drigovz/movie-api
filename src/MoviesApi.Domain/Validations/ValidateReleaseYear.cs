using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MoviesApi.Domain.Validations
{
    public class ValidateReleaseYear : ValidationAttribute
    {
        public override bool IsValid(object objValue)
        {
            string stringYear = objValue.ToString();
            Regex regex = new Regex(@"[12]\d{3}");
            Match match = regex.Match(stringYear);

            if (!match.Success)
                return false;

            if (stringYear.Length > 4)
                return false;

            return true;
        }
    }
}
