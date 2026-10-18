using System.ComponentModel.DataAnnotations;

namespace Harden_CRUD_Web_API.Models
{
    public class UpdateProductRequest
    {
        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 10000.00, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
    }
}
