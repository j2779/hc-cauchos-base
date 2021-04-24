using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class DAOAdmin
    {
        //METODO PARA ACTUALIZAR CONTRASEÑA ADMIN 
        public void ActualizarContraseña(UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.usuario.SingleOrDefault(b => b.User_id == user.User_id);
                if (resultado != null)
                {
                 ;
                    resultado.Clave = user.Clave;
                    db.SaveChanges();
                }

            }

        }

        //METODO PARA ACTUALIZAR CORREO ADMIN 
        public void ActualizarCorreo(UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.usuario.SingleOrDefault(b => b.User_id == user.User_id);
                if (resultado != null)
                {
                    ;
                    resultado.Correo = user.Correo;
                    db.SaveChanges();
                }

            }

        }

        //METODO PARA VERIFICAR CORREO ADMIN
        public bool verificarCorreo (UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.usuario.SingleOrDefault(b => b.Correo == user.Correo);
                if (resultado != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        //METODO PARA INSERTAR EMPLEADO 
        public void InsertarEmpleado(UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {
                db.usuario.Add(user);
                db.SaveChanges();
            }
        }

        //METODO PARA OBTENER EMPLEADOS EN CAMBIOSEMPLEADO
        public List<UEncapUsuario> ObtenerEmpleados()
        {
            using (var db = new Mapeo())
            {
                return (
                        //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                        from usu in db.usuario
                        where usu.Rol_id == 2 || usu.Rol_id == 3
                        //join usuario - rol
                        join rol in db.rol on usu.Rol_id equals rol.Id
                        //join usuario - estado 
                        join estado in db.estado on usu.Estado_id equals estado.Id

                        select new
                        {
                            usu,
                            rol,
                            estado

                        }).ToList().Select(m => new UEncapUsuario
                        {
                            User_id = m.usu.User_id,
                            Nombre = m.usu.Nombre,
                            Apellido = m.usu.Apellido,
                            Correo = m.usu.Correo,
                            Clave = m.usu.Clave,
                            Fecha_nacimiento = m.usu.Fecha_nacimiento,
                            Identificacion = m.usu.Identificacion,
                            //
                            Rol_id = m.usu.Rol_id,
                            RolNombre = m.rol.Nombre,
                            //
                            Estado_id = m.usu.Estado_id,
                            EstadoNombre = m.estado.Nombre

                        }).ToList();
            }
        }

        //metodo para realizar cambios a empleado 
        public void actualizarEmpleado(UEncapUsuario empleado)
        {
            using (var db = new Mapeo())
            {
                UEncapUsuario encapUsuario = db.usuario.Where(x => x.User_id == empleado.User_id).First();

                encapUsuario.Nombre = empleado.Nombre;
                encapUsuario.Apellido = empleado.Apellido;
                encapUsuario.Correo = empleado.Correo;
                encapUsuario.Identificacion = empleado.Identificacion;
                encapUsuario.Rol_id = empleado.Rol_id;
                encapUsuario.Estado_id = empleado.Estado_id;
                encapUsuario.Fecha_nacimiento = empleado.Fecha_nacimiento;
                encapUsuario.Last_modify = DateTime.Now;
                encapUsuario.Sesion = empleado.Sesion;
                db.usuario.Attach(encapUsuario);
                var entry = db.Entry(encapUsuario);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        //METODO ACTUALIZAR TABLA EN EL INVENTARIO
        public void ActualizarInventario(UEncapInventario invent)
        {
            using (var db = new Mapeo())
            {
                var resultado = db.inventario.SingleOrDefault(x => x.Id == invent.Id);
                if (resultado != null)
                {
                    resultado.Titulo = invent.Titulo;
                    resultado.Imagen = invent.Imagen;
                    resultado.Referencia = invent.Referencia;
                    resultado.Precio = invent.Precio;
                    resultado.Ca_actual = invent.Ca_actual;
                    resultado.Ca_minima = invent.Ca_minima;
                    resultado.Id_marca = invent.Id_marca;
                    resultado.Id_estado = invent.Id_estado;
                    resultado.Id_categoria = invent.Id_categoria;
                    resultado.Last_modify = DateTime.Now;
                    resultado.Session = invent.Session;
                    db.SaveChanges();
                }
            }

        }

        //METODO PARA OBTENER MISION
        public EncapMision ObtenerMision()
        {
            using (var db = new Mapeo())
            {
                var mision = db.mision.Where(x => x.Id == 1).FirstOrDefault();
                return mision;
            }
        }

        //METODO PARA OBTENER VISION
        public EncapVision ObtenerVision()
        {
            using (var db = new Mapeo())
            {
                return db.vision.Where(x => x.Id ==1).FirstOrDefault();
            }
        }

        //METODO PARA OBTENER OBJETIVO 
        public EncapObjetivo ObtenerObjetivon()
        {
            using (var db = new Mapeo())
            {
                return db.objetivo.Where(x => x.Id ==1).FirstOrDefault();
            }
        }

        //METODO PARA ACTUALIZAR VISION
        public void ActualizarMision(EncapMision mision)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.mision.SingleOrDefault(x => x.Id == 1);
                if (resultado != null)
                {
                    resultado.Mision = mision.Mision;
                    db.SaveChanges();
                }

            }

        }
        //METODO PARA ACTUALIZAR VISION
        public void ActualizarVision(EncapVision vision)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.vision.SingleOrDefault(x => x.Id == 1);
                if (resultado != null)
                {
                    resultado.Vision = vision.Vision;
                    db.SaveChanges();
                }

            }

        }
        //METODO PARA ACTUALIZAR OBJETIVO
        public void ActualizarObjetivo(EncapObjetivo objetivo)
        {
            using (var db = new Mapeo())
            {

                var resultado = db.objetivo.SingleOrDefault(x => x.Id == 1);
                if (resultado != null)
                {
                    resultado.Objetivo = objetivo.Objetivo;
                    db.SaveChanges();
                }

            }

        }

        //LISTOS-------------













        //METODO PARA OBTENER ADMIN 
        public UEncapUsuario obtenerAdmin(UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo.Equals(user.Correo)).FirstOrDefault();
            }
        }
       
        
        
        

        

        //METODO PARAMETRO DE TIMEPO CARRITO

        public void ActualizarTiempoCarrito(UEncapParametros tiempocarrito)
        {
            using (var db = new Mapeo())
            {
                UEncapParametros resultado = db.parametros.Where(x => x.Id == tiempocarrito.Id).First();
                if (resultado != null)
                {
                    resultado.Valor = tiempocarrito.Valor;
                    db.SaveChanges();
                }

            }

        }

        //METODO CONSULTAR MARCA DE INVENTARIO
        public List<UEncapMarca> ColsultarMarca()
        {
            using (var db = new Mapeo())
            {
                return db.marca_carro.OrderBy(x => x.Id).ToList();
            }
        }

        //METODO CONSULTAR CATEGORIA DE INVENTARIO 
        public List<UEncapCategoria> ColsultarCategoria()
        {
            using (var db = new Mapeo())
            {
                return db.categoria.OrderBy(x => x.Id).ToList();
            }
        }

        //METODO PARA CONSULTAR SI EXISTE REFERENCIA

        public UEncapInventario ConsultarReferencia(UEncapInventario referencia)
        {
            using (var db = new Mapeo())
            {
               
                return db.inventario.Where(x => x.Referencia.Equals(referencia.Referencia)).FirstOrDefault();
            }
        }

        //METODO PARA INSERTAR UN ITEM INVENTARIO
        public void InsertarItem(UEncapInventario invent)
        {
            using (var db = new Mapeo())
            {
                db.inventario.Add(invent);
                db.SaveChanges();
            }
        }
        //CONSULTAR EMPLEADO EN HISTORIAL VENTAS
        public List<UEncapUsuario> ConsultarEmpleado()
        {
            using (Mapeo db = new Mapeo())
            {
                return db.usuario.Where(x => x.Rol_id == 2).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS EN HISTORIAL DE VENTAS
        public List<UEncapPedido> ConsultarVentas()
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id

                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,

                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado,
                            Empleado = m.empleado.Nombre,

                        }
                          ).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS DIAS EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasDia(int dia)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Day == dia)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS_MES EN HISTORIALVENTAS
        public List<UEncapPedido> ConsultarVentasMes(int mes)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Month == mes)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS_ANIO EN HISROTIALVENTAS
        public List<UEncapPedido> ConsultarVentasAno(int ano)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }

        //METODO DE BUSCAR EL HISTORIA DE VENTAS_ANO_DIA EN HISTORIALVENTAS
        public List<UEncapPedido> ConsultarVentasAnoDia(int ano, int dia)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano && x.Fecha_pedido.Day == dia)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS ANO_MES_DIA EN HISTORIALVENTAS
        public List<UEncapPedido> ConsultarVentasAnoMesDia(int ano, int mes, int dia)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano &&
                        x.Fecha_pedido.Month == mes && x.Fecha_pedido.Day == dia)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS MES_DIA EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasMesDia(int mes, int dia)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Month == mes && x.Fecha_pedido.Day == dia)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }

        //METODO PARA CONSULTAR VENTAS ANO_MES_DIA_EMPLEADO
        public List<UEncapPedido> ConsultarVentasAnoMesDiaEmpleado(int ano, int mes, int dia, int emp)


        {
            string Query = "";
            //solo Empleado
            if (ano == 0 && mes == 0 && dia == 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id = " + emp;
            }
            //empleado y Dia
            if (ano == 0 && mes == 0 && dia != 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                       " AND to_char(fecha_pedido, 'DD')::integer = " + dia;

            }
            //empleado dia y mes
            if (ano == 0 && mes != 0 && dia != 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 5 AND atendido_id =" + emp +
                       " AND to_char(fecha_pedido, 'DD')::integer = " + dia +
                       " AND  to_char(fecha_pedido, 'MM')::integer =" + mes;
            }
            //empleado y mes
            if (ano == 0 && mes != 0 && dia == 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +

                       " AND  to_char(fecha_pedido, 'MM')::integer =" + mes;
            }
            //empleado y año
            if (ano != 0 && mes == 0 && dia == 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +

                       " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
            }

            //empleado año y dia
            if (ano != 0 && mes == 0 && dia != 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                    " AND to_char(fecha_pedido, 'DD')::integer = " + dia +
                       " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
            }
            //empleado mes y ano
            if (ano != 0 && mes != 0 && dia == 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                    " AND to_char(fecha_pedido, 'MM')::integer = " + mes +
                       " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
            }
            //Combinado
            if (ano != 0 && mes != 0 && dia != 0 && emp != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 AND atendido_id =" + emp +
                     " AND to_char(fecha_pedido, 'DD')::integer = " + dia +
                    " AND to_char(fecha_pedido, 'MM')::integer = " + mes +

                       " AND to_char(fecha_pedido, 'YYYY')::integer =" + ano;
            }
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.SqlQuery(Query)

                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }
        }
        //METODO PARA CONSULTAR VENTAS EN UN MES DEL AÑO
        public List<UEncapPedido> ConsultarVentasAnMes(int ano, int mes)
        {
            string Query = "";
            if (ano != 0 && mes != 0)
            {
                Query = "SELECT * FROM pedidos.pedidos pp WHERE estado_pedido = 6 " +
                    " AND to_char(fecha_pedido, 'MM')::INTEGER = " + mes +
                       " AND to_char(fecha_pedido, 'YYYY')::INTEGER =" + ano;
            }
            using (var db = new Mapeo())
            {

                return (from uu in db.pedidos.Where(x => x.Estado_pedido == 6 && x.Fecha_pedido.Year == ano && x.Fecha_pedido.Month == mes)

                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado
                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            Empleado = m.empleado.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado

                        }
                          ).ToList();
            }

        }
        //CONSULTAR ESTADO PEDIDOS EN HISTORIALPEDIDOS
        public List<UEncapPedido> ConsultarPedidosEstado(int est)
        {
            using (var db = new Mapeo())
            {



                return (from uu in db.pedidos.Where(x => x.Estado_pedido == est)
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id

                        //join domi in db.usuario on uu.Domiciliario_id equals domi.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado,
                            //domi


                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,

                            //Domiciliaro = m.domi.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado,
                            Empleado = m.empleado.Nombre,

                        }
                          ).ToList();
            }

        }

        //CONSULTAR ESTADO PEDIDO

        public List<UEncapEstadoPedido> ConsultarEstadoPedidos()
        {
            using (var db = new Mapeo())
            {
                return db.estado_pedido.ToList();
            }
        }
        //METODO PARA CONSULTAR PEDUDOS EN HISITORIAL PEDIDOS 

        public List<UEncapPedido> ConsultarPedidos()
        {
            using (var db = new Mapeo())
            {



                return (from uu in db.pedidos
                        join usuario in db.usuario on uu.User_id equals usuario.User_id
                        join empleado in db.usuario on uu.Atendido_id equals empleado.User_id
                        join estado in db.estado_pedido on uu.Estado_pedido equals estado.Id
                        //join domi in db.usuario on uu.Domiciliario_id equals domi.User_id
                        select new
                        {
                            uu,
                            usuario,
                            estado,
                            empleado,
                            //domi

                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.uu.Id,
                            User_id = m.usuario.User_id,
                            Atendido_id = m.uu.Atendido_id,
                            Domiciliario_id = m.uu.Domiciliario_id,
                            Fecha_pedido = m.uu.Fecha_pedido,
                            Estado_pedido = m.uu.Estado_pedido,
                            Total = m.uu.Total,
                            //Domiciliaro = m.domi.Nombre,
                            Usuario = m.usuario.Nombre,
                            Estado = m.estado.Estado,
                            Empleado = m.empleado.Nombre,

                        }
                          ).ToList();
            }

        }

        //METODO PARA CONSULTAR PRODUCTOS EN ALERTAS 
        public List<UEncapInventario> ConsultarAlertas()
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario
                        where uu.Ca_actual <= uu.Ca_minima
                        join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                        join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                        join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                        select new
                        {
                            uu,
                            marca_carro,
                            categoria,

                            estadoitem


                        }).ToList().Select(m => new UEncapInventario
                        {
                            Id = m.uu.Id,
                            Imagen = m.uu.Imagen,
                            Titulo = m.uu.Titulo,
                            Precio = m.uu.Precio,
                            Referencia = m.uu.Referencia,
                            Ca_actual = m.uu.Ca_actual,
                            Ca_minima = m.uu.Ca_minima,
                            Id_marca = m.uu.Id_marca,
                            Id_categoria = m.uu.Id_categoria,
                            Id_estado = m.uu.Id_estado,


                            Nombre_categoria = m.categoria.Categoria,


                            Estado = m.estadoitem.Estado_item
                        }).ToList();
            }
        }
       
        //METODO PARA ACTUALIZAR USUARIOS 
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

        //METODO PARA OBTENER EL EMPLEADO POR NOMBRE 
        public List<UEncapUsuario> ObtenerEmpleadosNombre(string nombre)
        {
            using (var db = new Mapeo())
            {
                return (
                        //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                        from usu in db.usuario
                        where (usu.Rol_id == 2 || usu.Rol_id == 3) && (usu.Nombre == nombre)
                    //join usuario - rol
                    join rol in db.rol on usu.Rol_id equals rol.Id
                    //join usuario - estado 
                    join estado in db.estado on usu.Estado_id equals estado.Id

                        select new
                        {
                            usu,
                            rol,
                            estado

                        }).ToList().Select(m => new UEncapUsuario
                        {

                            User_id = m.usu.User_id,
                            Nombre = m.usu.Nombre,
                            Apellido = m.usu.Apellido,
                            Correo = m.usu.Correo,
                            Clave = m.usu.Clave,
                            Fecha_nacimiento = m.usu.Fecha_nacimiento,
                            Identificacion = m.usu.Identificacion,
                        //
                        Rol_id = m.usu.Rol_id,
                            RolNombre = m.rol.Nombre,
                        //
                        Estado_id = m.usu.Estado_id,
                            EstadoNombre = m.estado.Nombre

                        }).ToList();
            }
        }

        //METODO CONSULTAR INVENTARIO
        public List<UEncapInventario> ConsultarInventario()
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario
                        join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                        join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                        join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                        let _cantCarrito = (from ss in db.carrito where ss.Producto_id == uu.Id select ss.Cantidad).Sum()

                        select new
                        {
                            uu,
                            marca_carro,
                            categoria,
                            estadoitem,

                            _cantCarrito


                        }).ToList().Select(m => new UEncapInventario
                        {
                            Id = m.uu.Id,
                            Imagen = m.uu.Imagen,
                            Titulo = m.uu.Titulo,
                            Precio = m.uu.Precio,
                            Referencia = m.uu.Referencia,
                            Ca_actual = m.uu.Ca_actual - (m._cantCarrito.HasValue ? m._cantCarrito.Value : 0),
                            Ca_minima = m.uu.Ca_minima,
                            Id_marca = m.uu.Id_marca,
                            Id_categoria = m.uu.Id_categoria,
                            Id_estado = m.uu.Id_estado,

                            Nombre_categoria = m.categoria.Categoria,
                            Nombre_marca = m.marca_carro.Marca,
                            Estado = m.estadoitem.Estado_item





                        }).ToList();
            }
        }

    

        //METODO CONSULATAR REFERENCIA
        public List<UEncapInventario> BuscarReferencia(string a)
        {
            using (var db = new Mapeo())
            {

                return (from uu in db.inventario.Where(x => x.Referencia == a)
                        join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                        join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                        join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                        select new
                        {
                            uu,
                            marca_carro,
                            categoria,

                            estadoitem


                        }).ToList().Select(m => new UEncapInventario
                        {
                            Id = m.uu.Id,
                            Imagen = m.uu.Imagen,
                            Titulo = m.uu.Titulo,
                            Precio = m.uu.Precio,
                            Referencia = m.uu.Referencia,
                            Ca_actual = m.uu.Ca_actual,
                            Ca_minima = m.uu.Ca_minima,
                            Id_marca = m.uu.Id_marca,
                            Id_categoria = m.uu.Id_categoria,
                            Id_estado = m.uu.Id_estado,

                            Nombre_categoria = m.categoria.Categoria,
                            Nombre_marca = m.marca_carro.Marca,

                            Estado = m.estadoitem.Estado_item




                        }).ToList();
            }
        }

        //METODO DE CONSULTAR ITEM CON ID_MARCA
        public List<UEncapInventario> BuscarMarca(int marca)
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Id_marca == marca)
                        join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                        join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                        join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                        select new
                        {
                            uu,
                            marca_carro,
                            categoria,

                            estadoitem


                        }).ToList().Select(m => new UEncapInventario
                        {
                            Id = m.uu.Id,
                            Imagen = m.uu.Imagen,
                            Titulo = m.uu.Titulo,
                            Precio = m.uu.Precio,
                            Referencia = m.uu.Referencia,
                            Ca_actual = m.uu.Ca_actual,
                            Ca_minima = m.uu.Ca_minima,
                            Id_marca = m.uu.Id_marca,
                            Id_categoria = m.uu.Id_categoria,
                            Id_estado = m.uu.Id_estado,

                            Nombre_categoria = m.categoria.Categoria,
                            Nombre_marca = m.marca_carro.Marca,

                            Estado = m.estadoitem.Estado_item




                        }).ToList();
            }
        }

        //METODO DE CONSULTAR ITEM CON ID_Categoria
        public List<UEncapInventario> BuscarCategoria(int categ)
        {
            using (var db = new Mapeo())
            {


                return (from uu in db.inventario.Where(x => x.Id_categoria == categ)

                        join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                        join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                        join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                        select new
                        {
                            uu,
                            marca_carro,
                            categoria,

                            estadoitem


                        }).ToList().Select(m => new UEncapInventario
                        {
                            Id = m.uu.Id,
                            Imagen = m.uu.Imagen,
                            Titulo = m.uu.Titulo,
                            Precio = m.uu.Precio,
                            Referencia = m.uu.Referencia,
                            Ca_actual = m.uu.Ca_actual,
                            Ca_minima = m.uu.Ca_minima,
                            Id_marca = m.uu.Id_marca,
                            Id_categoria = m.uu.Id_categoria,
                            Id_estado = m.uu.Id_estado,

                            Nombre_categoria = m.categoria.Categoria,
                            Nombre_marca = m.marca_carro.Marca,

                            Estado = m.estadoitem.Estado_item





                        }).ToList();
            }
        }


        //METODO DE CONSULTAR ITEM MARCA Y CATEGORIA
        public List<UEncapInventario> BuscarMarcaCategoria(int marca, int categ)
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Id_marca == marca && x.Id_categoria == categ)
                        join marca_carro in db.marca_carro on uu.Id_marca equals marca_carro.Id
                        join categoria in db.categoria on uu.Id_categoria equals categoria.Id
                        join estadoitem in db.estado_item on uu.Id_estado equals estadoitem.Id

                        select new
                        {
                            uu,
                            marca_carro,
                            categoria,

                            estadoitem


                        }).ToList().Select(m => new UEncapInventario
                        {
                            Id = m.uu.Id,
                            Imagen = m.uu.Imagen,
                            Titulo = m.uu.Titulo,
                            Precio = m.uu.Precio,
                            Referencia = m.uu.Referencia,
                            Ca_actual = m.uu.Ca_actual,
                            Ca_minima = m.uu.Ca_minima,
                            Id_marca = m.uu.Id_marca,
                            Id_categoria = m.uu.Id_categoria,
                            Id_estado = m.uu.Id_estado,

                            Nombre_categoria = m.categoria.Categoria,
                            Nombre_marca = m.marca_carro.Marca,

                            Estado = m.estadoitem.Estado_item





                        }).ToList();
            }
        }

        //METODO PARA OBTENER LOS ROLES DEL EMPLEADO
        public List<UEncapRol> ObtenerRoles()
        {
            using (var db = new Mapeo())
            {
                return db.rol.ToList();
            }
        }

        //METODO PARA OBTENER LOS ESTADOS DE LOS USUARIOS 
        public List<UEncapEstado> ObtenerEstados()
        {
            using (var db = new Mapeo())
            {
                return db.estado.ToList();
            }
        }

        public List<UEncapCategoria> ColsultarCategoria2()
        {
            using (var db = new Mapeo())
            {
                return db.categoria.OrderBy(x => x.Id >= 1).ToList();
            }
        }

        //METODO CONSULTAR ESTADO DE INVENTARIO 
        public List<UEncapEstadoItem> ColsultarEstado()
        {
            using (var db = new Mapeo())
            {
                return db.estado_item.ToList();
            }
        }


    }
}
