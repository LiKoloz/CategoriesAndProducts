using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DbWorker.Classes
{
    public class Category : ICloneable
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public List<Category>? Children { get; set; } = new List<Category> { };

        [JsonIgnore]
        public Category? Parent { get; set; }
  
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product> { };


        public object Clone() => MemberwiseClone();
    }
}
