using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("country")]
    public partial class Country
    {
        [Key]
        [Column("country_id")]
        public int CountryId { get; set; }
        [Column("country_iso_code")]
        [StringLength(10)]
        public string CountryIsoCode { get; set; }
        [Column("country_name")]
        [StringLength(200)]
        public string CountryName { get; set; }
    }
}
