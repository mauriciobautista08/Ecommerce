using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Controllers
{
   
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Products.Single(x => x.Id == id);
        }

        public ActionResult Create(Product model)
        {
            model.Id = Products.Count() + 1;
            Products.Add(model);

            return CreatedAtAction(
                "Get",
                new { id = model.Id }, 
                model
                );
        }

        [HttpPut("{productId}")]
        public ActionResult Update(int productId, Product model)
        {
            var originalEntry = Products.Single(x => x.Id == productId);

            originalEntry.Name = model.Name;
            originalEntry.Description = model.Description;
            originalEntry.Price = model.Price;

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult Delete(int productId)
        {
            Products = Products.Where(x => x.Id != productId).ToList();
            return NoContent();
        }

        private static List<Product> Products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Microservicios",
                Price = 1200,
                Description = "Curso de Microservicios en ASPNETCORE"
            },
            new Product
            {
                Id = 2,
                Name = "JSF Application",
                Price = 1500,
                Description = "Curso de Java Server Faces Nivel 1"
            }
        };
    }
}
