namespace InvoicePWABlazor.Dtos
{
    public class ItemDto
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
        public double Vat { get; set; }
        public double NettoPrice { get; set; }
        public double BruttoPrice { get; set; }
        public string Desc { get; set; }
    }
}
