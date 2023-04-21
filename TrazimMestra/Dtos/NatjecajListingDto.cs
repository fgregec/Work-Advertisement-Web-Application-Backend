using Core.Entities;

namespace TrazimMestra.Dtos
{
    public class NatjecajListingDto
    {
        public Guid Id { get; set; }
        public BasicUserDto User { get; set; }
        public City City { get; set; }
        public Category Category { get; set; }
        public bool IsEmergency { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
