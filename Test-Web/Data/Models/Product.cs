using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test_Web.Validation;

namespace Test_Web.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(ValidationConstants.MinAmount, ValidationConstants.MaxAmount)]
        public int Amount { get; set; }

        [Required]
        [MaxLength(ValidationConstants.MaxTypeLength)]
        public string Type { get; set; } = string.Empty;

        [MaxLength(ValidationConstants.MaxDescriptionLength)]
        public string? Description { get; set; }

        [Required]
        [Range(ValidationConstants.MinPrice,ValidationConstants.MaxPrice)]
        public decimal Price { get; set; }

    }

}
