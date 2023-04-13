using Core.Entities;

namespace Core.Dto
{
    public class SearchMestarDto
    {
        public Guid? CityID { get; set; }
        public Guid? CategoryID { get; set; }
        public string MestarName { get; set; }
    }
}
