﻿namespace Core.Entities
{
    public class Natjecaj : BaseEntity
    {
        public User User{ get; set; }
        public Guid UserID { get; set; }
        public City City { get; set; }
        public Guid CityID { get; set; }
        public Category Category{ get; set; }
        public Guid CategoryID { get; set; }
        public bool IsEmergency { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Finished { get; set; }
    }
}
