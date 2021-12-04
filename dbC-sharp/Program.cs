using System;
using System.Linq;
//Pra usar o ToList

namespace dbC_sharp
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.WriteLine("Olá");

      using (var contexto = new AppDbContext())
      {
        var listaProdutos = new System.Collections.Generic.List<Produto>
        {
            new Produto {nome="Lápis", preco=0.9M, estoque=80},
            new Produto {nome="Borracha", preco=0.35M, estoque=100},
        };
        contexto.Produtos.AddRange(listaProdutos);
        contexto.SaveChanges();
        Console.WriteLine("Olá");
        ExibirProdutos(contexto);
      };
      Console.ReadLine();
    }
    public static void ExibirProdutos(AppDbContext db)
    {
      var produtos = db.Produtos.ToList();
      foreach (var itemProduto in produtos)
      {
        Console.WriteLine("Olá");
        Console.WriteLine(itemProduto.nome + "\t" + itemProduto.preco.ToString("c"));
      }
    }
  }
}
