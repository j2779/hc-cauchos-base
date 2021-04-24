using System;
using System.ComponentModel.DataAnnotations;

namespace Utilitarios
{
    public class pedidosrequest
    {
        [Required(ErrorMessage = "el id es requerido.")]
        public int pedido { get; set; }
        [Required(ErrorMessage = "el id es requerido.")]
        public int empleadoid { get; set; }
        [Required]
        public string novedad { get; set; }


    }
    public class registrocliente
    {
        [Required(ErrorMessage = "el nombre es requerido.")]
        public string nombre { get ; set ; }
        [Required(ErrorMessage = "el apellido es requerido.")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "el correo es requerido.")]
        public string correo { get; set; }
        [Required]
        public int rol_id { get; set; }
        [Required(ErrorMessage = "la fecha de aniversario es requerido.")]
        public DateTime fecha_nacimiento { get; set; }
        [Required(ErrorMessage = "la identificacion es requerido.")]
        public string identificacion { get; set; }
        [Required]
        public int estado_id { get; set; }
       // public dateTime? Last_modify { get; set; }
        [Required]
        public string Sesion { get; set; }
    }
}
