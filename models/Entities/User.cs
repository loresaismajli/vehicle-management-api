namespace models.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public List<Service>? Services { get; set; }
        public List<Accident>? Accidents { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "Undefined user";
        }
    }
}
