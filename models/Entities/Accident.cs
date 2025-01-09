namespace models.Entities
{
    public class Accident
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public bool? IsGuilty { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public DateTime? Date { get; set; }
        public double? TotalPrice { get; set; }
    }
}
