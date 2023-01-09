namespace ApiProject.Models
{
    public class Buyer
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public string NIP { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Invoice> Invoices { get; set; }
        public List<Order> Orders { get; set; }


    }
}
