using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models;
using BudgetApp.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Index - Shows list of categories (search function also works here)
    public async Task<IActionResult> Index(string searchQuery)
    {
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            // Filter categories by search query
            var filteredCategories = await _context.Categories
                .Where(c => c.Name.Contains(searchQuery))
                .ToListAsync();

            return View(filteredCategories);
        }

        return View(await _context.Categories.ToListAsync());
    }

    // GET: Create modal (Partial View)
    public IActionResult Create()
    {
        return PartialView("_CreatePartial");
    }

    // POST: Create a category
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Category category)
    {
        if (ModelState.IsValid)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        return PartialView("_CreatePartial", category); // Return form with validation errors
    }

    // GET: Edit modal (Partial View)
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        return PartialView("_EditPartial", category);
    }

    // POST: Edit a category
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
    {
        if (id != category.Id)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
            return Json(new { success = true });
        }

        return PartialView("_EditPartial", category); // Return form with validation errors
    }

    // GET: Delete modal (Partial View)
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        return PartialView("_DeletePartial", category);
    }

    // POST: Confirm delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        return Json(new { success = true });
    }
}