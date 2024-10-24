using System.ComponentModel.DataAnnotations;

namespace SmartSpend.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public decimal Amount { get; set; }
    }
}
