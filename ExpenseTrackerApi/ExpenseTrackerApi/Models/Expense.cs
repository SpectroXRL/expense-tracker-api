using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.Models
{
    public class Expense
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        //public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
