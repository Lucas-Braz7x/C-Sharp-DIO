using System.ComponentModel.DataAnnotations;

namespace app_web.Models
{
  public class Produto
  {
    public int id { get; set; }

    [Display(Name = "Descrição")]
    public string descricao { get; set; }

    [Range(1, 100, ErrorMessage = "Valor fora da faixa 1-100")]
    public int quantidade { get; set; }

    //Relação com a tabela Categoria:
    public int categoriaId { get; set; }
    public Categoria categoria { get; set; }


  }
}