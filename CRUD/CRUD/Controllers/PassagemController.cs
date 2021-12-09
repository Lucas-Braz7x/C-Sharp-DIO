using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD.Controllers
{
  public class PassagemController : Controller
  {
    private readonly Context _context;

    public PassagemController(Context context)
    {
      _context = context;
    }

    // GET: Passagem
    public async Task<IActionResult> Index()
    {
      var context = _context.Passagens.Include(p => p.cliente);
      return View(await context.ToListAsync());
    }

    // GET: Passagem/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var passagem = await _context.Passagens
          .Include(p => p.cliente)
          .FirstOrDefaultAsync(m => m.id == id);
      if (passagem == null)
      {
        return NotFound();
      }

      return View(passagem);
    }

    // GET: Passagem/Create
    public IActionResult Create()
    {
      ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "nome");
      return View();
    }

    // POST: Passagem/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,destino,taxas,clienteId")] Passagem passagem)
    {
      if (ModelState.IsValid)
      {
        _context.Add(passagem);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "Nome", passagem.clienteId);
      return View(passagem);
    }

    // GET: Passagem/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var passagem = await _context.Passagens.FindAsync(id);
      if (passagem == null)
      {
        return NotFound();
      }
      ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "Nome", passagem.clienteId);
      return View(passagem);
    }

    // POST: Passagem/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,destino,taxas,clienteId")] Passagem passagem)
    {
      if (id != passagem.id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(passagem);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PassagemExists(passagem.id))
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
      ViewData["clienteId"] = new SelectList(_context.Clientes, "id", "Nome", passagem.clienteId);
      return View(passagem);
    }

    // GET: Passagem/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var passagem = await _context.Passagens
          .Include(p => p.cliente)
          .FirstOrDefaultAsync(m => m.id == id);
      if (passagem == null)
      {
        return NotFound();
      }

      return View(passagem);
    }

    // POST: Passagem/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var passagem = await _context.Passagens.FindAsync(id);
      _context.Passagens.Remove(passagem);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool PassagemExists(int id)
    {
      return _context.Passagens.Any(e => e.id == id);
    }
  }
}
