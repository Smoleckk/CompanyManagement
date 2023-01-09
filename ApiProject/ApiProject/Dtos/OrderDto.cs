using ApiProject.Models;

namespace ApiProject.Dtos
{
    public class OrderDto
    {
        public string Buyer { get; set; } = string.Empty;
        public string OrderNumber { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
        public DateTime DateOfExecution { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
