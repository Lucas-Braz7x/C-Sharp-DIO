using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace app_web.Models
{
  public class Categoria
  {
    public int id { get; set; }

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "Não pode faltar esse dado")]
    public string descricao { get; set; }

    public List<Produto> produtos { get; set; }
  }
}