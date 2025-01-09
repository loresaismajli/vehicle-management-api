namespace models.Entities
{
    public class Role
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
        public List<User>? Users { get; set; }
    }
}
