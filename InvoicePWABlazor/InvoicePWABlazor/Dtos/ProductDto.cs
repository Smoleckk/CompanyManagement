namespace InvoicePWABlazor.Dtos
{
    public class ProductDto
    {
        public string name { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
        public double price { get; set; }
        public double vat { get; set; }
        public double nettoPrice { get; set; }
        public double bruttoPrice { get; set; }

        public ProductDto(string name, double quantity, string unit, double price, double vat, double nettoPrice, double bruttoPrice)
        {
            this.name = name;
            this.quantity = quantity;
            this.unit = unit;
            this.price = price;
            this.vat = vat;
            this.nettoPrice = nettoPrice;
            this.bruttoPrice = bruttoPrice;
        }
    }
}
