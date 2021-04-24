using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utilitarios
{
    [Serializable]
    [Table("pedidos", Schema = "pedidos")]
    public class UEncapPedido
    {
        private int id;
        private DateTime fecha_pedido;
        private int user_id;
        private int atendido_id;
        private int domiciliario_id;
        private int estado_pedido;
        private double total;
        private string usuario;
        private string estado;
        private string empleado;
        private string domiciliaro;
        private string novedad;
        private int ciu_dep_id;
        private string direccion;
        private int municipio_id;
        private Nullable<DateTime> fecha_pedido_fin;

        private string ciudad_dep;
        private string municipio;





        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("fecha_pedido")]
        public DateTime Fecha_pedido { get => fecha_pedido; set => fecha_pedido = value; }
        [Column("user_id")]
        public int User_id { get => user_id; set => user_id = value; }
        [Column("atendido_id")]
        public int Atendido_id { get => atendido_id; set => atendido_id = value; }
        [Column("domiciliario_id")]
        public int Domiciliario_id { get => domiciliario_id; set => domiciliario_id = value; }
        [Column("estado_pedido")]
        public int Estado_pedido { get => estado_pedido; set => estado_pedido = value; }
        [Column("total")]
        public Double Total { get => total; set => total = value; }
        [Column("novedad")]
        public string Novedad { get => novedad; set => novedad = value; }
        [Column("ciu_dep_id")]
        public int Ciu_dep_id { get => ciu_dep_id; set => ciu_dep_id = value; }
        [Column("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [Column("municipio_id")]
        public int Municipio_id { get => municipio_id; set => municipio_id = value; }
        [Column("fecha_pedido_fin")]
        public Nullable<DateTime> Fecha_pedido_fin { get => fecha_pedido_fin; set => fecha_pedido_fin = value; }
        [NotMapped]
        public string Usuario { get => usuario; set => usuario = value; }
        [NotMapped]
        public string Estado { get => estado; set => estado = value; }
        [NotMapped]
        public string Empleado { get => empleado; set => empleado = value; }
        [NotMapped]
        public string Domiciliaro { get => domiciliaro; set => domiciliaro = value; }
        [NotMapped]
        public string Ciudad_dep { get => ciudad_dep; set => ciudad_dep = value; }
        [NotMapped]
        public string Municipio { get => municipio; set => municipio = value; }

    }
}
