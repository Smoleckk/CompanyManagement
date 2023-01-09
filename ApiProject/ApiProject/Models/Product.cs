namespace ApiProject.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public double quantity { get; set; }
        public string unit { get; set; } = string.Empty;
        public double price { get; set; }
        public double vat { get; set; }
        public double nettoPrice { get; set; }
        public double bruttoPrice { get; set; }
    }
}
