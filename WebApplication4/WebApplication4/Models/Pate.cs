using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Pate
    {
        [Required(ErrorMessage = "Un pizza doit avoir une pate")]
        public int Id { get; set; }
        public string Nom { get; set; }
    }
}