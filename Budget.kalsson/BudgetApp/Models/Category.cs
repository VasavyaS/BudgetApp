using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    // Navigation property for related transactions
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

}