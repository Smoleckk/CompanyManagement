namespace InvoicePWABlazor.Models
{
    public class Invoice
    {
        public int id { get; set; }
        public string seller { get; set; }
        public string buyer { get; set; }
        public string placeOfIssue { get; set; }
        public string invoiceNumber { get; set; }
        public DateTime dateOfIssue { get; set; }
        public DateTime dateOfExecution { get; set; }
        public string typeOfPay { get; set; }
        public DateTime dateOfPay { get; set; }
        public double finalNettoPrice { get; set; }
        public double finalPrice { get; set; }
        public string payStatus { get; set; }
        public Order? Order { get; set; }
        public List<Product> products { get; set; } = new List<Product>();


        public Invoice()
        {
        }

        public Invoice(int id, string seller, string buyer, string placeOfIssue, string invoiceNumber, DateTime dateOfIssue, DateTime dateOfExecution, string typeOfPay, DateTime dateOfPay, double finalNettoPrice, double finalPrice, string payStatus, List<Product> products)
        {
            this.id = id;
            this.seller = seller;
            this.buyer = buyer;
            this.placeOfIssue = placeOfIssue;
            this.invoiceNumber = invoiceNumber;
            this.dateOfIssue = dateOfIssue;
            this.dateOfExecution = dateOfExecution;
            this.typeOfPay = typeOfPay;
            this.dateOfPay = dateOfPay;
            this.finalNettoPrice = finalNettoPrice;
            this.finalPrice = finalPrice;
            this.payStatus = payStatus;
            this.products = products;
        }
    }
}
