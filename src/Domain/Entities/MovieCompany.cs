#nullable disable

namespace Domain.Entities
{
    public partial class MovieCompany
    {
        public int? MovieId { get; set; }
        public int? CompanyId { get; set; }

        public virtual ProductionCompany Company { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
