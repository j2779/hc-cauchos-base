using System;
using System.ComponentModel.DataAnnotations;

namespace Utilitarios
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "el correo es requerido.")]
        public string correo { get; set; }

        [Required(ErrorMessage = "la contraseña es requerida.")]
        public string clave { get; set; }
        
        [Required]
        public int AplicacionId { get; set; }
    }
    public class catalogocat
    {
        [Required(ErrorMessage = "necesita ingresar una categoria.")]
        public int categoria { get; set; }
    }
    public class catalogomarca
    {
        [Required(ErrorMessage = "necesita ingresar una marca.")]
        public int marca { get; set; }
    }
    public class catalogocombinado
    {
        [Required(ErrorMessage = "necesita ingresar una categoria.")]
        public int categoria { get; set; }
        [Required(ErrorMessage = "necesita ingresar una marca.")]
        public int marca { get; set; }
    }
    public class catalogoprecio
    {
        [Required(ErrorMessage = "necesita ingresar un precio.")]
        public string precio { get; set; }
    }
    public class catalogopreciocategoria
    {
            [Required(ErrorMessage = "necesita ingresar una categoria.")]
            public int categoria { get; set; }
            [Required(ErrorMessage = "necesita ingresar un precio.")]
            public string precio { get; set; }
    }
    public class catalogopreciomarca
    {
        [Required(ErrorMessage = "necesita ingresar una marca.")]
        public int marca { get; set; }
        [Required(ErrorMessage = "necesita ingresar un precio.")]
        public string precio { get; set; }
    }
    public class combinadorequest
    {
        [Required(ErrorMessage = "necesita ingresar una marca.")]
        public int marca { get; set; }
        [Required(ErrorMessage = "necesita ingresar una categoria.")]
        public int categoria { get; set; }
        [Required(ErrorMessage = "necesita ingresar un precio.")]
        public string precio { get; set; }
    }

}