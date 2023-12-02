using DemoAPIA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        private readonly InvoiceContext _context;

        public InvoicesController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Invoices> Get()
        {
            var response = _context.Invoices.ToList();

            return response;
        }

        [HttpGet]
        public List<Invoices> GetWithCustomer()
        {
            var response = _context.Invoices.Include(x => x.Customer).ToList();

            return response;
        }
    }
}
