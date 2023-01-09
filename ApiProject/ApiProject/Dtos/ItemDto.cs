namespace ApiProject.Dtos
{
    public class ItemDto
    {
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Vat { get; set; }
        public double NettoPrice { get; set; }
        public double BruttoPrice { get; set; }
        public string Desc { get; set; } = string.Empty;
    }
}
