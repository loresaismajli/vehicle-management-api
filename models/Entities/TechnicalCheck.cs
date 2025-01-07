namespace models.Entities
{
    public class TechnicalCheck
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public bool IsOk { get; set; }
    }
}
