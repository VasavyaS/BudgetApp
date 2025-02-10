using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models;

public class Transaction
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
    public string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    // Foreign key for Category
    [Display(Name = "Category")]
    [Required(ErrorMessage = "The Category field is required.")]
    public int CategoryId { get; set; }

    // Navigation property
    public Category? Category { get; set; }

}