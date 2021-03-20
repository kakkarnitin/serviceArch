using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ProductOptions
{
    public class UpdateProductOption
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
