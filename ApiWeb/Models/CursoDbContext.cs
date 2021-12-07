using Microsoft.EntityFrameworkCore;

namespace ApiWeb.Models
{
  public class CursoDbContext : DbContext
  {
    public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options) { }
    public DbSet<Curso> Cursos { get; set; }
    /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-3PLJOV1;Initial"
      + " Catalog=DB_CSharp; Integrated Security=true;");
      base.OnConfiguring(optionsBuilder);
    } */
  }
}