namespace Cv.Models
{
    public class ClientSearch
    {
        public string companyId { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public string name { get; set; }
        public int countryId { get; set; }
        public int stateId { get; set; }
    }
}
