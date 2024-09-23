using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tarea1.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "DescripcionCorta")]
        public string descripcionCorta { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public string Precio { get; set; }

        [Required]
        [Display(Name = "Imagen")]
        public string imagen { get; set; }

        public int idCategproia { get; set; }
        [Display(Name = "Categoria")]
        [ForeignKey("idCategoria")]

        public virtual Categoria MCategoria {get; set;}

        [Display(Name = "Casa")]
        public int idCasa { get; set; }
        [Display(Name = "casa")]
        [ForeignKey("idCasa")]

        public virtual Casa MCasa { get; set; }




    }
}
