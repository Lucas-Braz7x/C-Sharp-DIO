using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
  public class Context : DbContext
  {
    /*Criando uma tabela Clientes*/
    public DbSet<Cliente> Clientes { get; set; }

    /*Criando uma tabela Passagens*/
    public DbSet<Passagem> Passagens { get; set; }

    /*Dentro deste método que eu informo o BD que vou utilizar*/
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //DESKTOP-3PLJOV1
      //"Data Source=MSSQL1;Initial Catalog=AdventureWorks; "Integrated Security=true;" (ESTE FUNCIONOU)
      //@"Server=NT Service\MSSQLSERVER;Database=app_web;Integrated Security=True"
      optionsBuilder.UseSqlServer(connectionString: "Data Source=DESKTOP-3PLJOV1;Initial Catalog=CRUD_TESTE; Integrated Security=true;");
      //Data Source = "Nome do teu servidor, da pra pegar na IDE do sqlserver"
      // Initial Catalog="Nome do teu banco de dados"
      // Integrated Security= "Autenticação se TRUE não precisa informar senha, se false precisa"
    }
  }
}