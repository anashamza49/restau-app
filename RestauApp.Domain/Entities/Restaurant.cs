

using System.ComponentModel.DataAnnotations;

namespace RestauApp.Domain.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public int? CuisineId { get; set; }
        public Cuisine Cuisine { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }
    }
}
