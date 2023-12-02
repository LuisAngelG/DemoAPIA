using DemoAPIA.Models;
using DemoAPIA.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPIA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private readonly InvoiceContext _context;

        public Product2Controller(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Product> GetProductsToPrice(double price)
        {
            var response = _context.Products.Where(z => z.Price == price).ToList();

            return response;
        }

        [HttpGet]
        public Product GetProductForPrice(double price)
        {
            var response = _context.Products.Where(z => z.Price == price).FirstOrDefault();

            return response;
        }

        [HttpPost]
        public void Insert(ProductV1 request)
        {

            Product product = new Product
            {
                Price = request.Price,
                Name = request.Name,
                IsActive = true
            };

            _context.Products.Add(product);
            _context.SaveChanges();

        }

        [HttpPost]
        public void InsertRange(List<ProductV1> request)
        {

            //Product product = new Product
            //{
            //    Price = request.Price,
            //    Name = request.Name,
            //    IsActive = true
            //};

            //_context.Products.Add(product);
            //_context.SaveChanges();

            List<Product> products = new List<Product>();

            foreach (var item in request)
            {
                Product product = new Product
                {
                    Price = item.Price,
                    Name = item.Name,
                    IsActive = true
                };

                products.Add(product);
                //_context.Products.Add(product);
                //_context.SaveChanges();
            
            }

            //AddRange -- permite un rollback por si falla la transaccion
            _context.Products.AddRange(products);
            _context.SaveChanges();

        }
    }
}
