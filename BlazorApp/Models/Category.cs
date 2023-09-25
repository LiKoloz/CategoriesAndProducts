using Newtonsoft.Json;

namespace BlazorApp.Models
{
    public class Category
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? ParentId { get; set; }
        public List<Category> Children { get; set; } = new List<Category> { };
    }
}
