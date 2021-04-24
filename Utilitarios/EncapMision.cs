using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("mision", Schema = "mision_vision")]
    public class EncapMision
    {
        private int id;
        private string mision;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("mision")]
        public string Mision { get => mision; set => mision = value; }

    }
}
