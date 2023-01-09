namespace InvoicePWABlazor.Dtos
{
    public class BuyerDto
    {
        public string Name { get; set; }
        public string Adres { get; set; }
        public string PostCode { get; set; }
        public string NIP { get; set; }
        public string Country { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice> { };

    }
}
