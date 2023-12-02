using Microsoft.EntityFrameworkCore;

namespace DemoAPIA.Models
{
    public class InvoiceContext:DbContext
    {
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}
