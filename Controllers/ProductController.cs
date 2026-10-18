using Harden_CRUD_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harden_CRUD_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<ProductModel> _products = new()
        {
            new ProductModel { Id = 1, Name = "Laptop", Price = 999.99m },
            new ProductModel { Id = 2, Name = "Mouse", Price = 25.00m }
        };
 
        [HttpGet]
        public IActionResult GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var totalCount = _products.Count;
            var items = _products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

          
            return Ok(new
            {
                data = items,
                meta = new
                {
                    page,
                    pageSize,
                    totalCount
                }
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"Product with ID {id} was not found.");
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequest request)
        {
            if (_products.Any(p => p.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ConflictException($"A product named '{request.Name}' already exists.");
            }

            var newProduct = new ProductModel
            {
                Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1,
                Name = request.Name,
                Price = request.Price
            };

            _products.Add(newProduct);

            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductRequest request)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"Product with ID {id} was not found.");
            }

            product.Name = request.Name;
            product.Price = request.Price;

            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new NotFoundException($"Product with ID {id} was not found.");
            }

            _products.Remove(product);

            return NoContent();
        }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}