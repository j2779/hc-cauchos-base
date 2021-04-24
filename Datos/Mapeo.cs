using System.Data.Entity;
using Utilitarios;

namespace Datos
{
    public class Mapeo : DbContext
    {
        static Mapeo()
        {
            Database.SetInitializer<Mapeo>(null);
        }
        private readonly string schema;
        public Mapeo()
            : base("Name=postgres")
        {

        }


        public DbSet<UEncapUsuario> usuario { get; set; }
        public DbSet<UEncapRol> rol { get; set; }
        public DbSet<UEncapEstado> estado { get; set; }
        public DbSet<UEncapInventario> inventario { get; set; }
        public DbSet<UEncapMarca> marca_carro { get; set; }
        public DbSet<UEncapCategoria> categoria { get; set; }
        public DbSet<UEncapEstadoItem> estado_item { get; set; }
        public DbSet<EncapMision> mision { get; set; }
        public DbSet<EncapVision> vision { get; set; }
        public DbSet<EncapObjetivo> objetivo { get; set; }
        public DbSet<UEncapCarrito> carrito { get; set; }
        public DbSet<UEncapEstadoPProveedor> estado_pedido_proveedor { get; set; }
        public DbSet<UEncapParametros> parametros { get; set; }
        public DbSet<UEncapPedido> pedidos { get; set; }
        public DbSet<UEncapProducto_pedido> productos { get; set; }
        public DbSet<UEncapEstadoPedido> estado_pedido { get; set; }
        public DbSet<UEncapCiudades_Dep> ciudades_departamentso { get; set; }
        public DbSet<UEncapMunicipio> municipios { get; set; }
        public DbSet<UEncapToken>token { get; set; }
        public DbSet<UEncapAplicacion> aplicacion { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(this.schema);
            base.OnModelCreating(modelBuilder);
        }
    }
}
