using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using app_web.Models;

namespace app_web.Controllers
{
  public class CategoriaController : Controller
  {
    private readonly Context _context;

    public CategoriaController(Context context)
    {
      _context = context;
    }

    // GET: Categoria
    public async Task<IActionResult> Index()
    {
      //Pega todas as categorias do DB e joga pra view
      return View(await _context.Categorias.ToListAsync());
    }

    // GET: Categoria/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var categoria = await _context.Categorias
          .FirstOrDefaultAsync(m => m.id == id);
      if (categoria == null)
      {
        return NotFound();
      }

      return View(categoria);
    }

    // GET: Categoria/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Categoria/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,descricao")] Categoria categoria)
    {
      if (ModelState.IsValid)
      {
        _context.Add(categoria);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(categoria);
    }

    // GET: Categoria/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var categoria = await _context.Categorias.FindAsync(id);
      if (categoria == null)
      {
        return NotFound();
      }
      return View(categoria);
    }

    // POST: Categoria/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,descricao")] Categoria categoria)
    {
      if (id != categoria.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(categoria);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CategoriaExists(categoria.id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(categoria);
    }

    // GET: Categoria/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var categoria = await _context.Categorias
          .FirstOrDefaultAsync(m => m.id == id);
      if (categoria == null)
      {
        return NotFound();
      }

      return View(categoria);
    }

    // POST: Categoria/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var categoria = await _context.Categorias.FindAsync(id);
      _context.Categorias.Remove(categoria);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CategoriaExists(int id)
    {
      return _context.Categorias.Any(e => e.id == id);
    }
  }
}
