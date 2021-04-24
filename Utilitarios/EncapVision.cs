using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("vision", Schema = "mision_vision")]
    public class EncapVision
    {
        private int id;
        private string vision;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("vision")]
        public string Vision { get => vision; set => vision = value; }


    }
}
