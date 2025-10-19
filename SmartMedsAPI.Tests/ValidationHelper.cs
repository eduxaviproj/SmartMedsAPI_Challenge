using System.ComponentModel.DataAnnotations;

namespace SmartMedsAPI.Tests
{
    public static class ValidationHelper
    {
        public static IList<ValidationResult> Validate(object obj)
        {
            var ctx = new ValidationContext(obj);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(obj, ctx, results, validateAllProperties: true);
            return results; // vazia = válido; com items = inválido
        }
    }
}
