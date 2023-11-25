using DemoAPIA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPIA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomerCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Customer> GetCustomerDescending(string FirstName, string LastName)
        {
            var response = _context.Customers.Where(x => x.IsActive).OrderByDescending(x => x.LastName).ToList();
            
            return response;
        }
    }
}
