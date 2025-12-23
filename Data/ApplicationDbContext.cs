using Microsoft.EntityFrameworkCore;
using ComputerPart.Models;



namespace ComputerPart.Data
{
  
    public class ApplicationDbContext : DbContext // DbContext class contains database
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ComputerPart.Models.ComputerPart> ComputerParts {get; set;}
    }
}
