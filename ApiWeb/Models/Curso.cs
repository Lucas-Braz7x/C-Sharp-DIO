//Pacotes para escrever anotações no BD
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWeb.Models//DIz o pacote da classe
{
  [Table("Curso")]//Informa o nome da tabela no sqlSever
  public class Curso
  {
    [Key]//Informa que é uma chave primária id
    public int Id { get; set; }
    /* Required indica que é um campo obrigatório, senão for preenchido informa o error */
    [Required(ErrorMessage = "Informe a descrição do curso")]
    [StringLength(50)]//Define o tamanho máximo
    public string Descricao { get; set; }
    [Required(ErrorMessage = "Informe a carga horária")]
    public int CargaHoraria { get; set; }
  }
}