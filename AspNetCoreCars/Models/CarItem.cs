using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreCars.Models
{
    public class CarItem
    {
        
        public Guid Id { get; set; }
        [Required]
        public string Maker { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Year { get; set; }

    }
}
