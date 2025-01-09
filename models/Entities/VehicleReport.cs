namespace models.Entities
{
    public class VehicleReport
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public DateTime? Date { get; set; }
    }
}
