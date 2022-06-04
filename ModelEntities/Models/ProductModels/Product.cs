using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zModelEntities.Models.ProductModels
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string ProductCode { get; set; } = string.Empty;

        [Column(TypeName = "varchar(100)")]
        public string ProductCategory { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(32, 2)")]
        public double ProductPrice { get; set; } = 0;
        public DateTime ExpiredDate { get; set; } = DateTime.Now;
    }
}
