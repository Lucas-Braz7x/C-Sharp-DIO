using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ApiWeb.Models;
using System.Linq;

/*
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
*/

namespace ApiWeb.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CursoController : ControllerBase
  {

    //Instancia um objeto da class CursoDbContext
    private readonly CursoDbContext _context;

    public CursoController(CursoDbContext context)//Método construtor
    {
      _context = context;
    }
    //GET
    [HttpGet]
    public IEnumerable<Curso> GetCursos()//Pega os cursos
    {
      return _context.Cursos;
    }

    [HttpGet("{id}")]
    public IActionResult GetCursoPorId(int id)
    {
      Curso curso = _context.Cursos.SingleOrDefault(modelo => modelo.Id == id);
      if (curso == null)
      {
        return NotFound();
      }
      return new ObjectResult(curso);
    }

    [HttpPost]
    public IActionResult CriarCurso([FromBody] Curso Item)
    {
      if (Item == null)
      {
        return BadRequest();
      }
      _context.Cursos.Add(Item);
      _context.SaveChanges();

      return CreatedAtAction("GetCursos", new { id = Item.Id }, Item);
    }
    [HttpPut("{id}")]
    public IActionResult AtualizaCurso(int id, [FromBody] Curso Item)
    {
      if (id != Item.Id)
      {
        return BadRequest();
      }

      _context.Entry(Item).State = EntityState.Modified;
      _context.SaveChanges();

      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCurso(int id)
    {
      var curso = _context.Cursos.SingleOrDefault(m => m.Id == id);
      if (curso == null)
      {
        return BadRequest();
      }

      _context.Cursos.Remove(curso);
      _context.SaveChanges();
      return Ok();
    }

  }
}