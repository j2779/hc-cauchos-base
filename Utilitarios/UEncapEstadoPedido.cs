using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("estado_pedido", Schema = "pedidos")]
    public class UEncapEstadoPedido
    {
        private int id;
        private string estado;
        //private string session;
        //private Nullable<DateTime> time;

        [Key]
        [Column("id_estado")]
        public int Id { get => id; set => id = value; }
        [Column("nombre")]
        public string Estado { get => estado; set => estado = value; }
        //[Column("session")]
        //protected string Session { get => session; set => session = value; }
        //[Column("last_modify")]
        //protected DateTime? Time { get => time; set => time = value; }
    }
}
