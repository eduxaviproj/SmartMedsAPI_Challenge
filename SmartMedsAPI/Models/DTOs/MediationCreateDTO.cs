using System.ComponentModel.DataAnnotations;

namespace SmartMedsAPI.Models.DTOs
{
    public class MediationCreateDTO
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = default!;
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
