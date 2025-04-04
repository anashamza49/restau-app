
using System.ComponentModel.DataAnnotations;

namespace RestauApp.Application.DTOs
{
    public class CuisineDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire !")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas depasser 50 caracteres !!")]
        public required string Nom { get; set; }
    }
}
