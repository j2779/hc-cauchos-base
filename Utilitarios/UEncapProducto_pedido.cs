using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Utilitarios
{
    [Serializable]
    [Table("productos_pedidos", Schema = "pedidos")]
    public class UEncapProducto_pedido
    {
        private int id;
        private int pedido_id;
        private int producto_id;
        private int cantidad;
        private double precio;
        private double total;
        private string nombre_producto;
        private string referencia;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("pedido_id")]
        public int Pedido_id { get => pedido_id; set => pedido_id = value; }
        [Column("producto_id")]
        public int Producto_id { get => producto_id; set => producto_id = value; }
        [Column("cantidad")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Column("precio")]
        public double Precio { get => precio; set => precio = value; }
        [Column("total")]
        public double Total { get => total; set => total = value; }

        [NotMapped]
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        [NotMapped]
        public string Referencia { get => referencia; set => referencia = value; }
    }
}
