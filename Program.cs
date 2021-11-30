using System;
namespace Cadastro_series
{
  class Program
  {
    static SerieRepositorio repositorio = new SerieRepositorio();
    private static string ObterOpcaoUsuario()
    {
      Console.WriteLine();
      Console.WriteLine("Só série boa, qual vai ser a de hoje?");
      Console.WriteLine("Fala pra gente: ");

      Console.WriteLine("1 - Listar séries");
      Console.WriteLine("2 - Inserir nova série");
      Console.WriteLine("3 - Atualizar série");
      Console.WriteLine("4 - Excluir série");
      Console.WriteLine("5 - Visualizar série");
      Console.WriteLine("L - Limpar a tela");
      Console.WriteLine("Esc - Sair");
      string opcaoUsuario = Console.ReadLine().ToLower();
      Console.WriteLine();
      return opcaoUsuario;
    }

    private static void listarSeries()
    {
      Console.WriteLine("Listar Séries!!!!!");
      var lista = repositorio.Lista();

      if (lista.Count == 0)
      {
        Console.WriteLine("Nenhuma série cadastrada...");
        return;
      }

      foreach (var serie in lista)
      {
        var excluido = serie.retornaExcluido();

        Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "Excluído" : "");

      }
    }

    private static void inserirSeries()
    {
      Console.Write("Inserir uma nova série!!!");
      Console.Write("");

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        ///Parei aqui - 11:16.
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();
      Console.WriteLine("Digite o ano de início da série");
      int entradaAno = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie novaSerie = new Serie(
        id: repositorio.proximoId(),
        genero: (Genero)entradaGenero,
        titulo: entradaTitulo,
        ano: entradaAno,
        descricao: entradaDescricao
      );
      repositorio.Insere(novaSerie);
    }

    private static void atualizarSeries()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());

      foreach (int i in Enum.GetValues(typeof(Genero)))
      {
        Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
      }

      Console.WriteLine("Digite o gênero entre as opções acima: ");
      int entradaGenero = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite o título da série: ");
      string entradaTitulo = Console.ReadLine();
      Console.WriteLine("Digite o ano de início da série");
      int entradaAno = int.Parse(Console.ReadLine());
      Console.WriteLine("Digite a descrição da série: ");
      string entradaDescricao = Console.ReadLine();

      Serie atualizarSerie = new Serie(
      id: indiceSerie,
      genero: (Genero)entradaGenero,
      titulo: entradaTitulo,
      ano: entradaAno,
      descricao: entradaDescricao
      );
      repositorio.Atualiza(indiceSerie, atualizarSerie);
    }

    private static void excluirSeries()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      repositorio.Exclui(indiceSerie);
    }

    private static void visualizarSerie()
    {
      Console.WriteLine("Digite o id da série: ");
      int indiceSerie = int.Parse(Console.ReadLine());
      var serie = repositorio.RetornaPorId(indiceSerie);
      Console.WriteLine(serie);
    }

    static void Main(string[] args)
    {

      string opcaoUsuario = ObterOpcaoUsuario();

      while (opcaoUsuario != "esc")
      {
        switch (opcaoUsuario)
        {
          case "1":
            listarSeries();
            break;
          case "2":
            inserirSeries();
            break;
          case "3":
            atualizarSeries();
            break;
          case "4":
            excluirSeries();
            break;
          case "5":
            visualizarSerie();
            break;
          case "l":
            Console.Clear();
            break;
          default:
            throw new ArgumentOutOfRangeException();
        }
        opcaoUsuario = ObterOpcaoUsuario();
      }
    }
  }
}
