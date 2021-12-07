using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_web.Models;

namespace app_web.Controllers
{
  public class ProdutoController : Controller
  {
    private readonly Context _context;

    public ProdutoController(Context context)
    {
      _context = context;
    }

    // GET: Produto
    public async Task<IActionResult> Index()
    {
      var context = _context.Produtos.Include(p => p.categoria);
      return View(await context.ToListAsync());
    }

    // GET: Produto/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var produto = await _context.Produtos
          .Include(p => p.categoria)
          .FirstOrDefaultAsync(m => m.id == id);
      if (produto == null)
      {
        return NotFound();
      }

      return View(produto);
    }

    // GET: Produto/Create
    public IActionResult Create()
    {
      //O segundo parâmetro exibe o texto na página de criação
      ViewData["categoriaId"] = new SelectList(_context.Categorias, "id", "descricao");
      return View();
    }

    // POST: Produto/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,descricao,quantidade,categoriaId")] Produto produto)
    {
      if (ModelState.IsValid)
      {
        _context.Add(produto);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["categoriaId"] = new SelectList(_context.Categorias, "id", "descricao", produto.categoriaId);
      return View(produto);
    }

    // GET: Produto/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var produto = await _context.Produtos.FindAsync(id);
      if (produto == null)
      {
        return NotFound();
      }
      ViewData["categoriaId"] = new SelectList(_context.Categorias, "id", "descricao", produto.categoriaId);
      return View(produto);
    }

    // POST: Produto/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,descricao,quantidade,categoriaId")] Produto produto)
    {
      if (id != produto.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(produto);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ProdutoExists(produto.id))
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
      ViewData["categoriaId"] = new SelectList(_context.Categorias, "id", "descricao", produto.categoriaId);
      return View(produto);
    }

    // GET: Produto/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var produto = await _context.Produtos
          .Include(p => p.categoria)
          .FirstOrDefaultAsync(m => m.id == id);
      if (produto == null)
      {
        return NotFound();
      }

      return View(produto);
    }

    // POST: Produto/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var produto = await _context.Produtos.FindAsync(id);
      _context.Produtos.Remove(produto);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool ProdutoExists(int id)
    {
      return _context.Produtos.Any(e => e.id == id);
    }
  }
}
