

namespace RestauApp.Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }
        public string Note { get; set; }
        public string ImagePath { get; set; }
    }
}
