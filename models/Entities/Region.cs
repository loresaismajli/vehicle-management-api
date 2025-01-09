namespace models.Entities
{
    public class Region
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public List<User>? Users { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
