

namespace RestauApp.Domain.Entities
{
    public class Cuisine
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
