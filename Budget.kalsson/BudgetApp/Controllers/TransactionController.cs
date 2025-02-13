using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;
using BudgetApp.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TransactionController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Index - Displays all transactions with optional search functionality
    public async Task<IActionResult> Index(int? categoryId, DateTime? startDate, string searchQuery)
    {
        // Fetch all transactions
        var transactions = _context.Transactions.Include(t => t.Category).AsQueryable();

        // Filter by category if selected
        if (categoryId.HasValue)
        {
            transactions = transactions.Where(t => t.CategoryId == categoryId.Value);
        }

        // Filter by start date if provided
        if (startDate.HasValue)
        {
            transactions = transactions.Where(t => t.Date >= startDate.Value);
        }

        // Filter by search query (search by name)
        if (!string.IsNullOrEmpty(searchQuery))
        {
            transactions = transactions.Where(t => t.Name.Contains(searchQuery));
        }

        // Fetch categories for the dropdown
        ViewData["Categories"] = new SelectList(await _context.Categories.OrderBy(c => c.Name).ToListAsync(), "Id", "Name");

        return View(await transactions.ToListAsync());
    }


    // GET: Display the Create modal (Partial View)
    public IActionResult Create()
    {
        ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
        return PartialView("_CreatePartial");
    }

    // POST: Create a new transaction
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

        // Reload the modal with validation errors
        ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", transaction.CategoryId);
        return PartialView("_CreatePartial", transaction);
    }

    // GET: Display the Edit modal (Partial View)
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        // Retrieve the transaction by its ID
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction == null)
            return NotFound();

        ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", transaction.CategoryId);
        return PartialView("_EditPartial", transaction);
    }

    // POST: Update an existing transaction
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,Date,CategoryId")] Transaction transaction)
    {
        if (id != transaction.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(transaction);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Transactions.Any(t => t.Id == id))
                    return NotFound();
                else
                    throw;
            }
        }

        ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", transaction.CategoryId);
        return PartialView("_EditPartial", transaction);
    }

    // GET: Display the Delete modal (Partial View)
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        // Retrieve the transaction with its category for display
        var transaction = await _context.Transactions
            .Include(t => t.Category)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transaction == null)
            return NotFound();

        return PartialView("_DeletePartial", transaction);
    }

    // POST: Confirm deletion of a transaction
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