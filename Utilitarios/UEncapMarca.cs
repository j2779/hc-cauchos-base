using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("marca_carro", Schema = "productos")]
    public class UEncapMarca
    {
        private int id;
        private string marca;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Marca { get => marca; set => marca = value; }

    }
}
