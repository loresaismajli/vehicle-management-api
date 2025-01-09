namespace models.Entities
{
    public class Producer
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public List<Vehicle>? Vehicles { get; set; }
    }
}
