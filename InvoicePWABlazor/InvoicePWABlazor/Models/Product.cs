using System.ComponentModel.DataAnnotations;

namespace InvoicePWABlazor.Models
{
    public class Product
    {
        private int id { get; set; } = 0;
        [Required]

        public string name { get; set; }
        [Required]

        public double quantity { get; set; }
        [Required]

        public string unit { get; set; }
        public double price { get; set; }
        public double vat { get; set; }
        public double nettoPrice { get; set; }
        public double bruttoPrice { get; set; }

        public Product()
        {
        }

        public Product(int id, string name, double quantity, string unit, double price, double vat, double nettoPrice, double bruttoPrice)
        {
            this.id = id;
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
