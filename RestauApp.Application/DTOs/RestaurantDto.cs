


using System.ComponentModel.DataAnnotations;

namespace RestauApp.Application.DTOs
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoi re !")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas depasser 50 caracteres !")]
        public required string Nom { get; set; }
        [Required]
        public required string Note { get; set; }
        [Required]
        public required string ImageUrl { get; set; }
    }
}
