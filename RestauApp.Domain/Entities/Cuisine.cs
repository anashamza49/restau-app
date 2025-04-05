

using System.ComponentModel.DataAnnotations;

namespace RestauApp.Domain.Entities
{
    public class Cuisine
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
