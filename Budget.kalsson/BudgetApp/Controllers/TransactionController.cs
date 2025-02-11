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

    /// Retrieves and displays a list of all transactions.
    /// The transactions are displayed along with their associated categories.
    /// <returns>A task that represents the asynchronous operation. The task result contains an IActionResult that renders the transactions view.</returns>
    public async Task<IActionResult> Index()
    {
        var transactions = _context.Transactions.Include(t => t.Category);
        return View(await transactions.ToListAsync());
    }

    /// Displays a view for creating a new transaction.
    /// The view includes a dropdown list of available categories for selection.
    /// <returns>An IActionResult that renders the partial view for creating a transaction.</returns>
    public IActionResult Create()
    {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        return PartialView("_CreatePartial");
    }

    /// Displays a view for creating a new transaction.
    /// The view includes a dropdown list of available categories for selection.
    /// <returns>An IActionResult that renders the partial view for creating a transaction.</returns>
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

    /// Displays a view for editing an existing transaction.
    /// Retrieves the transaction details based on the provided ID.
    /// The view includes a dropdown list of available categories for selection.
    /// <param name="id">The ID of the transaction to be edited. If null, a NotFound result is returned.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an IActionResult that renders the partial view for editing the transaction, or a NotFound result if the transaction is not found.</returns>
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