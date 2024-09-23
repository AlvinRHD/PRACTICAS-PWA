using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tarea1.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }

        [Required]
        [Display(Name = "Nombre de la categoria")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "orden")]
        public string orden { get; set; }

    }
}
