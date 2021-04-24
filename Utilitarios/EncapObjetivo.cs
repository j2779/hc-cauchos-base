using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("objetivo", Schema = "mision_vision")]
    public class EncapObjetivo
    {
        private int id;
        private string objetivo;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("objetivo")]
        public string Objetivo { get => objetivo; set => objetivo = value; }
    }
}
