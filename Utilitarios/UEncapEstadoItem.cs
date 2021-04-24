using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilitarios
{
    [Serializable]
    [Table("estado_item", Schema = "productos")]
    public class UEncapEstadoItem
    {
        private int id;
        private string estado_item;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("estado")]
        public string Estado_item { get => estado_item; set => estado_item = value; }
    }
}
