﻿namespace BlazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
