namespace models.Entities
{
    public class Contractor : User
    {
        public string? CompanyName { get; set; }

        public override string ToString()
        {
            return "External user";
        }
    }
}