using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TransactionController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var transactions = _context.Transactions.Include(t => t.Category);
        return View(await transactions.ToListAsync());
    }

    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return PartialView("_CreatePartial");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Amount,Date,CategoryId")] Transaction transaction)
    {
        if (ModelState.IsValid)
        {
            _context.Add(transaction);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", transaction.CategoryId);
        return PartialView("_CreatePartial", transaction);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
            return NotFound();

        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", transaction.CategoryId);
        return PartialView("_EditPartial", transaction);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,Date,CategoryId")] Transaction transaction)
    {
        if (id != transaction.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(transaction);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", transaction.CategoryId);
        return PartialView("_EditPartial", transaction);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var transaction = await _context.Transactions
                            .Include(t => t.Category)
                            .FirstOrDefaultAsync(m => m.Id == id);
        if (transaction == null)
            return NotFound();

        return PartialView("_DeletePartial", transaction);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        return Json(new { success = true });
    }
}