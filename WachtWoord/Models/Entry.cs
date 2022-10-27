﻿using System.ComponentModel.DataAnnotations;

namespace WachtWoord.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? URL { get; set; } 
        public string? Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int Strength { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
