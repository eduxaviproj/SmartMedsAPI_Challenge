using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartMedsAPI.Models.DTOs
{
    public class MedicationCreateDTO
    {
        [Required, MaxLength(200)] public string Name { get; set; } = default!;
        [DefaultValue(10)][Range(1, int.MaxValue, ErrorMessage = "Quantity must be > 0")] public int Quantity { get; set; }
    }
}
