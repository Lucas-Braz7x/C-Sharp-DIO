using Microsoft.EntityFrameworkCore;
{

}
namespace dbC_sharp
{
  public class AppDbContext : DbContext
  {
    //Mapeando a entidade para a Tabela
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Data Source=DESKTOP-3PLJOV1;Initial"
      + " Catalog=DB_CSharp; Integrated Security=true;");
      base.OnConfiguring(optionsBuilder);
    }
  }
}