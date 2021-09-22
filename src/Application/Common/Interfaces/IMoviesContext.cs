using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IMoviesContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Gender> Genders { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Keyword> Keywords { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<LanguageRole> LanguageRoles { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<MovieCast> MovieCasts { get; set; }
        DbSet<MovieCompany> MovieCompanies { get; set; }
        DbSet<MovieCrew> MovieCrews { get; set; }
        DbSet<MovieGenre> MovieGenres { get; set; }
        DbSet<MovieKeyword> MovieKeywords { get; set; }
        DbSet<MovieLanguage> MovieLanguages { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<ProductionCompany> ProductionCompanies { get; set; }
        DbSet<ProductionCountry> ProductionCountries { get; set; }
        DbSet<VwMovie> VwMovies { get; set; }
    }
}
