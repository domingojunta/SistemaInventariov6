using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventariov6.Modelos.Entities
{
    [Table("bodegas")]
    public class Bodega
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio y no puede estar vacío")]
        [MaxLength(60, ErrorMessage ="El nombre debe tener como máximo 60 caracteres")]
        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("descripcion")]
        [Required(ErrorMessage = "La descripción es obligatorio y no puede estar vacío")]
        [MaxLength(255, ErrorMessage = "La descripción debe tener como máximo 255 caracteres")]
        public string Descripcion { get; set; }


        [Column("estado")]
        [Required(ErrorMessage ="El campo Estado es obligatorio y tiene que ser true/false")]
        public bool Estado { get; set; }
    }
}
