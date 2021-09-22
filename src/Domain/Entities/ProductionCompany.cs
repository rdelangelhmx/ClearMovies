using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("production_company")]
    public partial class ProductionCompany
    {
        [Key]
        [Column("company_id")]
        public int CompanyId { get; set; }
        [Column("company_name")]
        [StringLength(200)]
        public string CompanyName { get; set; }
    }
}
