using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Test_Web.Data.Models;
using Test_Web.Validation;

namespace Test_Web.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required!")]
        [Display(Name = "Product name")]
        [StringLength(ValidationConstants.MaxNameLength,MinimumLength = ValidationConstants.MinNameLength, ErrorMessage = "The name should be between {2} and {1} symbols")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Field {0} is required!")]
        [Range(ValidationConstants.MinAmount,ValidationConstants.MaxAmount,ErrorMessage = "The amount should be between {1} and {2}")]
        [Display(Name = "Amount product")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Field {0} is required!")]
        [StringLength(ValidationConstants.MaxTypeLength,MinimumLength = ValidationConstants.MinTypeLength,ErrorMessage = "The type should be between {2} and {1} symbols")]
        [Display(Name = "Type of product")]
        public string Type { get; set; } = string.Empty;

        [StringLength(ValidationConstants.MaxDescriptionLength,MinimumLength = ValidationConstants.MinDescriptionLength,ErrorMessage = "The description should be between {2} and {1} symbols")]
        [Display(Name = "Product description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Field {0} is required!")]
        [Display(Name = "Product price")]
        [Range(ValidationConstants.MinPrice, ValidationConstants.MaxPrice,ErrorMessage = "The price can be between {1} and {2}")]
        public decimal Price { get; set; }

    }
}
