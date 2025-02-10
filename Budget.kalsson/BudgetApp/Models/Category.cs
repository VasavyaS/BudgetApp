using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; }

    // Navigation property for related transactions
    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

}