using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
namespace Datos
{
    public class DAODomiciliario
    {
        //METODO PARA VEIRIFICAR EL USUARIO ACTIVO
        public UEncapUsuario UsuarioActivo(string session)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Sesion == session).FirstOrDefault();
            }
        }
        //METODO PARA VERIFICAR SI EXISTE REGISTRADO EL CORREO
        public UEncapUsuario verificarCorreo(UEncapUsuario verificar)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo.Equals(verificar.Correo)).FirstOrDefault();
            }
        }
        //METODO PARA ACTUALIZAR EL USUARIO
        public void ActualizarUsuario(UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.usuario.SingleOrDefault(b => b.User_id == user.User_id);
                if (resultado != null)
                {
                    resultado.Nombre = user.Nombre;
                    resultado.Apellido = user.Apellido;
                    resultado.Correo = user.Correo;
                    resultado.Clave = user.Clave;
                    resultado.Fecha_nacimiento = user.Fecha_nacimiento;
                    resultado.Identificacion = user.Identificacion;
                    resultado.Token = user.Token;
                    resultado.Estado_id = user.Estado_id;
                    resultado.Rol_id = user.Rol_id;
                    resultado.Tiempo_token = user.Tiempo_token;
                    resultado.Sesion = user.Sesion;
                    resultado.Last_modify = DateTime.Now;
                    resultado.Ip_ = user.Ip_;
                    resultado.Mac_ = user.Mac_;

                    db.SaveChanges();
                }

            }

        }
        //ACTUALIZAR ESTADO EN EL PEDIDO POR DOMICILIARIO
        public void ActualizarNovedadPedido(UEncapPedido estado5)
        {
            using (var db = new Mapeo())
            {
                UEncapPedido entrega = db.pedidos.Where(x => x.Id == estado5.Id).SingleOrDefault();
                entrega.Estado_pedido = 5;
                entrega.Fecha_pedido_fin = estado5.Fecha_pedido_fin;

                db.SaveChanges();
            }
        }
        public List<UEncapPedido> ObtenerPedidos()
        {
            using (var db = new Mapeo())

                return (from pedi in db.pedidos.Where(x =>x.Estado_pedido == 4)
                        join usu in db.usuario on pedi.User_id equals usu.User_id
                        join emple in db.usuario on pedi.Atendido_id equals emple.User_id
                        join domi in db.usuario on pedi.Domiciliario_id equals domi.User_id
                        join ciudad_dep in db.ciudades_departamentso on pedi.Ciu_dep_id equals ciudad_dep.Id
                        join municipio in db.municipios on pedi.Municipio_id equals municipio.Id

                        select new
                        {
                            pedi,
                            usu,
                            emple,
                            domi,
                            municipio,
                            ciudad_dep

                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.pedi.Id,
                            Fecha_pedido = m.pedi.Fecha_pedido,
                            User_id = m.pedi.User_id,
                            Usuario = m.usu.Nombre,
                            Atendido_id = m.pedi.Atendido_id,
                            Empleado = m.emple.Nombre,
                            Domiciliario_id = m.pedi.Domiciliario_id,
                            Domiciliaro = m.domi.Nombre,
                            Estado_pedido = m.pedi.Estado_pedido,
                            Total = m.pedi.Total,
                            Direccion = m.pedi.Direccion,
                            Ciu_dep_id = m.pedi.Ciu_dep_id,
                            Municipio_id = m.pedi.Municipio_id,
                            Fecha_pedido_fin = m.pedi.Fecha_pedido_fin,
                            Ciudad_dep = m.ciudad_dep.Nombre,
                            Municipio = m.municipio.Nombre


                        }).ToList();
        }



    }
}
