using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

#nullable disable

namespace Persistence.Context
{
    public partial class MoviesContext : DbContext
    {
        #region DbSet
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LanguageRole> LanguageRoles { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieCast> MovieCasts { get; set; }
        public virtual DbSet<MovieCompany> MovieCompanies { get; set; }
        public virtual DbSet<MovieCrew> MovieCrews { get; set; }
        public virtual DbSet<MovieGenre> MovieGenres { get; set; }
        public virtual DbSet<MovieKeyword> MovieKeywords { get; set; }
        public virtual DbSet<MovieLanguage> MovieLanguages { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public virtual DbSet<ProductionCountry> ProductionCountries { get; set; }
        public virtual DbSet<VwMovie> VwMovies { get; set; }
        #endregion

        #region Creating Model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new KeywordConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageRoleConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new MovieCastConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MovieCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MovieCrewConfiguration());
            modelBuilder.ApplyConfiguration(new MovieGenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new MovieKeywordConfiguration());
            modelBuilder.ApplyConfiguration(new MovieLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionCountryConfiguration());
            modelBuilder.ApplyConfiguration(new VwMovieConfiguration());
        }
        #endregion
    }
}