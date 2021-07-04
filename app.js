const { readlinkSync } = require("fs");
const livros = require("./database");//Importando arquivo database.js

const readline = require("readline-sync");//Importando dependencia readline

const entradaInicial = readline.question("Deseja buscar um livro? (S/N)"); 

if(entradaInicial.toUpperCase() === 'S' || entradaInicial.toUpperCase() === "SIM" ){
  console.log("Categorias disponíveis: ");
  const livrosOrdenadosCategorias = livros.map(livro => livro.categoria);
  
  console.table(livrosOrdenadosCategorias.filter((primeiro, segundo ) =>{
    return livrosOrdenadosCategorias.indexOf(primeiro) === segundo
    })
  )
 
  const entradaCategoria = readline.question('Qual categoria voce escolhe? ');

  const retorno = livros.filter(livro => livro.categoria === entradaCategoria.toLocaleLowerCase())
  console.table(retorno)
}else{
  console.log('Esses são todos os livros disponiveis');
  const livrosOrdenados = livros.sort((a,b) => a.paginas-b.paginas);
  console.table(livrosOrdenados);
}



