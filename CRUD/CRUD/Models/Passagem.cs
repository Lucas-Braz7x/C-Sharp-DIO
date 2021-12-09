using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
  public class Passagem
  {
    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Informe o destino")]
    public string destino { get; set; }

    [Range(1, 100, ErrorMessage = "Valor fora da faixa 1-100")]
    public int taxas { get; set; }

    //Relação com a tabela Categoria:
    public int clienteId { get; set; }
    public Cliente cliente { get; set; }
  }
}