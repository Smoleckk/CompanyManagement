using System.ComponentModel.DataAnnotations;

namespace InvoicePWABlazor.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public double Quantity { get; set; } = 1;
        [Required]
        public string Unit { get; set; } = "szt";
        [Required]
        public double Price { get; set; }
        public double Vat { get; set; } = 23;
        public double NettoPrice { get; set; }
        public double BruttoPrice { get; set; }
        public string Desc { get; set; } = string.Empty;
    }
}
