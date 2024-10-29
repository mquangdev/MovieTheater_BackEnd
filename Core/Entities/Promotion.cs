﻿using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Promotion : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; } // Title of the promotion

        [StringLength(500)]
        public string Detail { get; set; } // Details about the promotion

        [Range(0, 100)]
        public double DiscountLevel { get; set; } // Discount percentage (e.g., 20 for 20%)

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; } // URL or path to the promotion image

        [Required]
        public DateTime StartTime { get; set; } // Start time of the promotion

        [Required]
        public DateTime EndTime { get; set; } // End time of the promotion
    }
}