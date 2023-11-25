using DemoAPIA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAPIA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {

        private readonly InvoiceContext _context;

        public ProductCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProductWithCategoryName(string CategoryName)
        {
            //Inner Join para inclusion de categoria y producto
            var response = _context.Products.Include(x => x.Category).
                Where(x => x.Category.Name.Contains(CategoryName)).
                ToList();

            return response;
        }

        [HttpGet]
        public List<Product> GetProductWithCategory()
        {
            //Inner Join para inclusion de categoria y producto
            var response = _context.Products.Include(x => x.Category).ToList();

            return response;
        }

        [HttpGet]
        public List<Product> GetProductsWithCategoryNameDescending(string categoryName)
        {

            var response = _context.Products.Include(x => x.Category).
                Where(x => x.Category.Name.Contains(categoryName)).
                OrderByDescending(x => x.Name)
                .ToList();

            return response;

        }
    }
}
