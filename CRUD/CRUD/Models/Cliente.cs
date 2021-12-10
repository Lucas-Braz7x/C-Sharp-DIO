
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
  public class Cliente
  {//Classe Cliente que através das migrations será transformada em tabela
    [Key]
    public int id { get; set; }
    public string nome { get; set; }

    public double cpf { get; set; }
    public int idade { get; set; }

    public List<Passagem> passagens { get; set; }//Relação com a tabela passagem 

  }
}