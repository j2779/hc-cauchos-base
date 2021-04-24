using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("aplicaciones", Schema = "security")]
    public class UEncapAplicacion
    {
        private int id;
        private string nombre;
        private int tiempo;
        private string llave;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("tiempo")]
        public int Tiempo { get => tiempo; set => tiempo = value; }
        [Column("llave")]
        public string Llave { get => llave; set => llave = value; }
    }
}
