namespace models.Entities
{
    public class Consumption
    {
        public int? Id { get; set; }
        public int? Fuel { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
