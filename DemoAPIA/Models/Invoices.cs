namespace DemoAPIA.Models
{
    public class Invoices
    {
        public int InvoicesID { get; set; }
        public DateTime DateTime { get; set; }    
        public string InvoicesNumber { get; set; }
        public float Total { get; set; }

        public Customer? Customer { get; set; }
        public int? CustomerID { get; set; }
    }
}
