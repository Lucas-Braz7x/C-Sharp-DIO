const livros = [
  {
    id: 1,
    nome: 'Sherlock Holmes: Rache',
    autor: 'alguem',
    categoria: 'suspense',
    paginas: 300,
    recomenda: false,
    leu: false,
  },
  {
    id: 2,
    nome: 'O estranho misterioso',
    autor: 'alguem',
    categoria: 'suspense',
    paginas: 99,
    recomenda: false,
    leu: true
  },
  {
    id: 3,
    nome: 'Pequeno principe',
    autor: 'alguem',
    categoria: 'infantil',
    paginas: 100,
    recomenda: true,
    leu: true
  },
  {
    id: 4,
    nome: 'divina comédia',
    autor: 'alguem',
    categoria: 'Drama',
    paginas: 200,
    recomenda: false,
    leu: false
  },
  {
    id: 5,
    nome: 'Além do bem e do mal',
    autor: 'alguem',
    categoria: 'filosofia',
    paginas: 150,
    recomenda: true,
    leu: true
  }
]

const [{id, nome, autor, categoria, recomenda, leu}] = livros

module.exports = livros;