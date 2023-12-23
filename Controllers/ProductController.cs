using DotNetCoreDominationBootcampDay2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreDominationBootcampDay2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product1", UnitPrice = 10.99m, Category = new Category { Id = 1, Name = "Category1" } },
            new Product { Id = 2, Name = "Product2", UnitPrice = 20.99m, Category = new Category { Id = 2, Name = "Category2" } },
            new Product { Id = 3, Name = "Product3", UnitPrice = 15.99m, Category = new Category { Id = 1, Name = "Category1" } },
            new Product { Id = 4, Name = "Product4", UnitPrice = 25.99m, Category = new Category { Id = 2, Name = "Category2" } },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            try
            {
                product.Id = products.Max(p => p.Id) + 1;
                products.Add(product);

                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest("işlem başarısız");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);

            return Ok(product);
        }
    }
}
