using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
  public class Passagem
  {//Classe Passagem que através das migrations será transformada em tabela
    [Key]//Define que é uma chave primária
    public int id { get; set; }

    [Required(ErrorMessage = "Informe o destino")]//Define que é um campo requerido
    public string destino { get; set; }

    [Range(1, 100, ErrorMessage = "Valor fora da faixa 1-100")]
    public int taxas { get; set; }

    //Relação com a tabela Categoria:
    public int clienteId { get; set; }//Define uma chave estrangeira
    public Cliente cliente { get; set; }
  }
}