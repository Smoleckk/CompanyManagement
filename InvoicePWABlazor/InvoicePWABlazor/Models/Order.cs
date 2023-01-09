using System.ComponentModel.DataAnnotations;

namespace InvoicePWABlazor.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public string OrderNumber { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Buyer { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public DateTime DateOfExecution { get; set; } = DateTime.Now;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
