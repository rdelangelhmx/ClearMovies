using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Domain.Entities
{
    [Table("department")]
    public partial class Department
    {
        [Key]
        [Column("department_id")]
        public int DepartmentId { get; set; }
        [Column("department_name")]
        [StringLength(200)]
        public string DepartmentName { get; set; }
    }
}
