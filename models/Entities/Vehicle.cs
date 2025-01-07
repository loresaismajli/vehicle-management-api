namespace models.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VIN { get; set; }
        public int ProductionYear { get; set; }
        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public int ProducerId { get; set; }
        public Producer Producer { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
