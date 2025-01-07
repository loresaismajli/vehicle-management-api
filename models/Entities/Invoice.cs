namespace models.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public List<Service> Services { get; set; }
        public double TotalPrice { get; set; }
    }
}
