using Core.Entities;

namespace Core.Dto
{
    public class SearchMestarDto
    {
        public City City { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
