using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("categoria", Schema = "productos")]
    public class UEncapCategoria
    {
        private int id;
        private string categoria;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
