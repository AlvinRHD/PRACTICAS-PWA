using System.ComponentModel.DataAnnotations;

namespace tarea1.Models
{
    public class Casa
    {
        [Key]
        public int idCasa { get; set; }

        [Required]
        [Display(Name = "Nombre de la consola")]

        public string nombre { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }
    }
}
