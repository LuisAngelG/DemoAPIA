namespace DemoAPIA.Models
{
    public class Detail
    {
        public int DetailID { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }

        public Invoices? Invoices { get; set; }
        public int? InvoicesID { get; set; }

        public Product? Product { get; set; }
        public int? ProductID { get; set; }
    }
}
