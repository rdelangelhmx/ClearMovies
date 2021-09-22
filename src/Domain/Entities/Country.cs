#nullable disable

namespace Domain.Entities
{
    public partial class Country
    {
        public int CountryId { get; set; }
        public string CountryIsoCode { get; set; }
        public string CountryName { get; set; }
    }
}
