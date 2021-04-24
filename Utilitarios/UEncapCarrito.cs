using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("carrito_compras_producto", Schema = "carrito")]
    public class UEncapCarrito
    {
        private int id_Carrito;
        private int user_id;
        private int producto_id;
        private Nullable<int> cantidad;
        private DateTime fecha;
        private int precio;
        private int total;
        private int estadocar;
        private string nom_producto;
        private int cant_Actual;
        private int id_pedido;
        private string session;
        private Nullable<DateTime> last_modify;

        [Key]
        [Column("id_carrito")]
        public int Id_Carrito { get => id_Carrito; set => id_Carrito = value; }
        [Column("user_id")]
        public int User_id { get => user_id; set => user_id = value; }
        [Column("producto_id")]
        public int Producto_id { get => producto_id; set => producto_id = value; }
        [Column("cantidad")]
        public Nullable<int> Cantidad { get => cantidad; set => cantidad = value; }
        [Column("fecha")]
        public DateTime Fecha { get => fecha; set => fecha = value; }
        [Column("precio")]
        public int Precio { get => precio; set => precio = value; }
        [Column("total")]
        public int Total { get => total; set => total = value; }
        [Column("estadocar")]
        public int Estadocar { get => estadocar; set => estadocar = value; }
        [Column("id_pedido")]
        public int Id_pedido { get => id_pedido; set => id_pedido = value; }



        [NotMapped]
        public string Nom_producto { get => nom_producto; set => nom_producto = value; }
        [NotMapped]
        public int Cant_Actual { get => cant_Actual; set => cant_Actual = value; }
        [Column("session")]
        public string Session { get => session; set => session = value; }
        [Column("last_modify")]
        public DateTime? Last_modify { get => last_modify; set => last_modify = value; }

    }
}
