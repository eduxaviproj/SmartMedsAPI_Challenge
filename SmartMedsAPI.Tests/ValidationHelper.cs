using System.ComponentModel.DataAnnotations;

namespace SmartMedsAPI.Tests
{
    public static class ValidationHelper
    {
        public static IList<ValidationResult> Validate(object obj)
        {
            var ctx = new ValidationContext(obj); //objetivo a validar 
            var results = new List<ValidationResult>(); // lista de erros
            Validator.TryValidateObject(obj, ctx, results, validateAllProperties: true); // corre DataAnnotations e se falhar, adiciona na lista
            return results; // devolve lista de erros (se estiver vazia, o DTO passou)
        }
    }
}
