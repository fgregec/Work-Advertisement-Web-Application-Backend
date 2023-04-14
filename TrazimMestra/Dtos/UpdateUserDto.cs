﻿namespace TrazimMestra.Dtos
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public Guid CityID { get; set; }
        public bool IsMestar{ get; set; }
    }
}
