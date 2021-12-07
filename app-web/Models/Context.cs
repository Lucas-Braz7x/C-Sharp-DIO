using Microsoft.EntityFrameworkCore;

namespace app_web.Models
{
  public class Context : DbContext
  {
    /*Criando uma tabela Categorias*/
    public DbSet<Categoria> Categorias { get; set; }

    /*Criando uma tabela Produtos*/
    public DbSet<Produto> Produtos { get; set; }

    /*Dentro deste método que eu informo o BD que vou utilizar*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //DESKTOP-3PLJOV1
      //"Data Source=MSSQL1;Initial Catalog=AdventureWorks; "Integrated Security=true;" (ESTE FUNCIONOU)
      //@"Server=NT Service\MSSQLSERVER;Database=app_web;Integrated Security=True"
      optionsBuilder.UseSqlServer(connectionString: "Data Source=DESKTOP-3PLJOV1;Initial Catalog=AdventureWorks; Integrated Security=true;");
    }
  }
}