using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMasterDetails.Models
{
    public class Product
    {
        [Key]
        [MaxLength(6)] // Length validation
        [Required]
        public string Code { get; set; }

        [Required]
        [MaxLength(75)] // Length validation
        public string Name { get; set; }

        [Required]
        [MaxLength(255)] // Length validation
        public string Description { get; set; }

        [Required]
        [MaxLength(15)] // Length validation
        public string Category { get; set; }

        [Required]
        [Range(5, 1000)] // Range validation
        public float Cost { get; set; }

        [Required]
        [Range(5, 3000)] // Range validation
        public float Price { get; set; }

    }
    }
