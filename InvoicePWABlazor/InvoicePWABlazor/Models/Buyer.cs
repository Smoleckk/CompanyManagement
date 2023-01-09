using System.ComponentModel.DataAnnotations;

namespace InvoicePWABlazor.Models
{
    public class Buyer
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Adres { get; set; }
        public string PostCode { get; set; }
        public string NIP { get; set; }
        public string Country { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice> { };
        public List<Order> Orders { get; set; } = new List<Order> { };

    }
}
