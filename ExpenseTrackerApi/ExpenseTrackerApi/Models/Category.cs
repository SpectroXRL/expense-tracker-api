using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
