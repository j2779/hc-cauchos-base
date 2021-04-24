using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("parametros", Schema = "sistema")]
    public class UEncapParametros
    {
        private int id;
        private string nombre;
        private string valor;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("valor")]
        public string Valor { get; set; }
    }
}
