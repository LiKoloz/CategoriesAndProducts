using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ASPNetApp.Models
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
