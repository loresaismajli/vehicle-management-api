﻿namespace models.Entities
{
    public class Employee : User
    {
        public int? RegionId { get; set; } // foregin key
        public Region? Region { get; set; }

        public override string ToString()
        {
            return "Internal user";
        }
    }
}
