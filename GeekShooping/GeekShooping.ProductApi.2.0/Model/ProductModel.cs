﻿
using GeekShopping.ProductApi._2._0.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi._2._0.Model
{
    [Table("product")]
    public class ProductModel: BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Column("price", TypeName = "decimal(18,4)")]
        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [Column("description")]
        
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("imageUrl")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
