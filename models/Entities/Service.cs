﻿namespace models.Entities
{
    public class Service
    {
        public int? Id { get; set; }
        public string? Number { get; set; }
        public string? Name { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int? ServiceTypeId { get; set; }
        public ServiceType? ServiceType { get; set; }
        public DateTime? Date { get; set; }
        public double? TotalPrice { get; set; }
    }
}
