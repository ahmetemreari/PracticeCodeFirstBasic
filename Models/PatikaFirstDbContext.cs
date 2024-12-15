using Microsoft.EntityFrameworkCore;
using EmrePracticeDbOne.Models;

public class PatikaFirstDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Game> Games { get; set; }

    public PatikaFirstDbContext(DbContextOptions<PatikaFirstDbContext> options) : base(options)
    {
    }
   
 

}
//dotnet ef migrations add InitialCreate