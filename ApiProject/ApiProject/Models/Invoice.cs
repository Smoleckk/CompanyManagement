namespace ApiProject.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public string seller { get; set; } = string.Empty;
        public string buyer { get; set; } = string.Empty;
        public string placeOfIssue { get; set; } = string.Empty;
        public string invoiceNumber { get; set; } = string.Empty;
        public DateTime dateOfIssue { get; set; }
        public DateTime dateOfExecution { get; set; }
        public string typeOfPay { get; set; } = string.Empty;
        public DateTime dateOfPay { get; set; }
        public double finalNettoPrice { get; set; }
        public double finalPrice { get; set; }
        public string payStatus { get; set; } = string.Empty;
        public List<Product> products { get; set; } = new List<Product>();

    }
}
