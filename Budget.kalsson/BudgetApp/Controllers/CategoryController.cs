using Microsoft.AspNetCore.Mvc;
using BudgetApp.Models;
using System.Linq;
using System.Threading.Tasks;
using BudgetApp.Data;
using Microsoft.EntityFrameworkCore;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _context;

    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Categories.ToListAsync());
    }

    public IActionResult Create()
    {
        return PartialView("_CreatePartial");
    }

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
        return PartialView("_CreatePartial", category);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        return PartialView("_EditPartial", category);
    }

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
        return PartialView("_EditPartial", category);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _context.Categories.FindAsync(id);
        if (category == null)
            return NotFound();

        return PartialView("_DeletePartial", category);
    }

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