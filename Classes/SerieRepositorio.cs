using System.Collections.Generic;
using Cadastro_series.interfaces;

namespace Cadastro_series
{
  public class SerieRepositorio : IRepositories<Serie>
  {
    private List<Serie> listaSerie = new List<Serie>();
    public void Atualiza(int id, Serie objeto)
    {
      listaSerie[id] = objeto;
    }

    public void Exclui(int id)
    {
      listaSerie[id].excluir();
    }

    public void Insere(Serie entidade)
    {
      listaSerie.Add(entidade);
    }

    public List<Serie> Lista()
    {
      return listaSerie;
    }

    public int proximoId()
    {
      return listaSerie.Count;
    }

    public Serie RetornaPorId(int id)
    {
      return listaSerie[id];
    }
  }
}