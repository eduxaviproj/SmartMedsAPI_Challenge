namespace SmartMedsAPI.Models.DTOs
{
    public class MedicationViewDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
