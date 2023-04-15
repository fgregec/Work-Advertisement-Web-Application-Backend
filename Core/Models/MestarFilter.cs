namespace Core.Models
{
    public class MestarFilter
    {
        public Guid? CityID { get; set; }
        public Guid? CategoryID { get; set; }
        public string Name { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
