using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Datos
{
    public class DaoUsuario
    {
        //metodo para verificar que el usuario sea valido para login
        public UEncapUsuario verificarUsuario(UEncapUsuario verificar)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo.Equals(verificar.Correo) && x.Clave.Equals(verificar.Clave)).FirstOrDefault();
            }
        }
        //metodo para login de servicios
        public UEncapUsuario verificarUsuario2(LoginRequest verificar)
        {
            using (var db = new Mapeo())
            {
                UEncapUsuario usuario = db.usuario.FirstOrDefault(x => x.Correo == verificar.correo && x.Clave == verificar.clave);
                if (usuario!= null){
                    var propiedades = db.aplicacion.Where(x => x.Id == verificar.AplicacionId).FirstOrDefault();
                    usuario.Expiracion = propiedades.Tiempo;
                    usuario.Key = propiedades.Llave;
                    usuario.AplicacionId = verificar.AplicacionId;
                }    
                return usuario;
            }
        }

        //metodo para almacenar token 
        public void almacenarToken(UEncapToken token)
        {
            using (var db = new Mapeo())
            {
                db.token.Add(token);
                db.SaveChanges();
            }
        }

        //metodo para obtener aplicaciones por token
        public UEncapAplicacion getAplicaionesByToken(string token)
        {
            using (var db = new Mapeo())
            {
                return (from t in db.token
                        join a in db.aplicacion on t.AplicacionId equals a.Id
                        where t.Token.Equals(token)
                        select new
                        {
                            a
                        }).ToList().Select(m => new UEncapAplicacion
                        {
                            Id = m.a.Id,
                            Tiempo = m.a.Tiempo,
                            Llave = m.a.Llave,
                            Nombre = m.a.Nombre
                        }).FirstOrDefault();
            }
        }
        //metodo de actualizacion de session

        public UEncapUsuario actualizarsession(UEncapUsuario actualizar)
        {
            using (var db = new Mapeo())
            {
                var resultado = db.usuario.FirstOrDefault(x => x.Correo == actualizar.Correo);
                if (resultado != null)
                {
                    resultado.Ip_ = null;
                    resultado.Mac_ = null;
                    resultado.Sesion = null;
                    db.SaveChanges();
                    
                }
                return resultado;
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
        //METODO PARA VERIFICAR SI EXISTE REGISTRADA LA IDENTIFICACION
        public UEncapUsuario verificarIdentificacion(UEncapUsuario verificar)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo.Equals(verificar.Correo) || x.Identificacion.Equals(verificar.Identificacion)).FirstOrDefault();
            }
        }

        //METODO PARA INSERTAR USUARIO AL MOMENTO DEL LOGIN
        public void InsertarUsuario(UEncapUsuario user)
        {
            using (var db = new Mapeo())
            {
                db.usuario.Add(user);
                db.SaveChanges();
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

        //METODO CONSULTAR USUARIO ACTIVO
        public UEncapUsuario UsuarioActivo2(string correo)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo == correo).FirstOrDefault();
            }
        }
        //METODO PARA VERIFICAR TOKEN DE RECUPERACION EN LOGIN 
        public UEncapUsuario BuscarToken(string token)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Token.Equals(token) && x.Estado_id == 2).FirstOrDefault();
            }

        }

        public UEncapUsuario UsuarioActivo(string sesion)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Sesion == sesion).FirstOrDefault();
            }
        }
        //METODO ELIMINAR CUENTA DE USUARIO
        public void EliminarCuenta(UEncapUsuario usuario)
        {

            using (var db = new Mapeo())
            {
                db.usuario.Attach(usuario);

                var usuario_eliminar = db.usuario.Where(x => x.User_id == usuario.User_id);

                var entry = db.Entry(usuario);
                entry.State = EntityState.Deleted;

                db.usuario.RemoveRange(usuario_eliminar);

                db.SaveChanges();
            }
        }

        //OBTENGO CANTIDAD DE PRODUCTOS DE USUARIO CARRITO
        public int ObtenerCantidadxProductoCarritoxUser(int user_id)
        {
            using (var db = new Mapeo())
            {
                return db.carrito.Where(x => x.User_id == user_id).Count();
            }
        }

        //OBTENGO CANTIDAD ACTUAL DEL INVENTARIO Y LE RESTO LA CANTIDAD QUE SE ENCUENTRA EN EL CARRITO
        public int ObtenerCantidadxProductoCarrito(int producto_id)
        {
            using (var db = new Mapeo())
            {
                //return db.inventario.Where(x => x.Id == producto_id).Select(x=> x.Ca_actual).First() - db.carrito.Where(x => x.Prod ucto_id == producto_id).Sum(x => x.Cantidad);
                Nullable<int> carrito = db.carrito.Where(x => x.Producto_id == producto_id).Sum(x => x.Cantidad);
                int cantidad = db.inventario.Where(x => x.Id == producto_id).Select(x => x.Ca_actual).First();
                return cantidad - (carrito != null ? carrito.Value : 0);
            }
        }

        //METODO PARA VERIFICAR SI EL USUARIO TIENE PEDIDO
        public UEncapCarrito verificarUsuarioTienePedido(UEncapCarrito verificar)
        {
            using (var db = new Mapeo())
            {
                return db.carrito.Where(x => x.User_id.Equals(verificar.User_id) && x.Estadocar.Equals(2)).FirstOrDefault();
            }
        }


        //METODO PARA VERIFICAR SI EL ITEM SELECCIONADO YA ESTA EN LA LISTA 
        public UEncapCarrito verificarArticuloEnCarrito(UEncapCarrito verificar)
        {
            using (var db = new Mapeo())
            {
                return db.carrito.Where(x => x.Producto_id.Equals(verificar.Producto_id) && x.User_id.Equals(verificar.User_id)).FirstOrDefault();
            }
        }


        //METODO ACTUALIZAR + ITEMS EN CARRITO 
        public void ActualizarCarritoItems(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {
                var resultado = db.carrito.FirstOrDefault(x => x.Producto_id == carrito.Producto_id && x.User_id == carrito.User_id);
                if (resultado != null)
                {
                    resultado.Id_Carrito = resultado.Id_Carrito;
                    resultado.User_id = resultado.User_id;
                    resultado.Producto_id = resultado.Producto_id;
                    resultado.Cantidad = resultado.Cantidad + carrito.Cantidad;
                    resultado.Fecha = resultado.Fecha;
                    resultado.Precio = resultado.Precio;
                    resultado.Total = resultado.Total + (carrito.Cantidad * resultado.Precio).Value;
                    resultado.Session = resultado.Session;
                    resultado.Last_modify = DateTime.Now;
                    db.SaveChanges();
                }
            }

        }

        //METODO PARA INSERTAR USUARIO AL MOMENTO DEL LOGIN
        public void InsertarCarrito(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {
                db.carrito.Add(carrito);
                db.SaveChanges();
            }
        }

        //METODO CONSULTAR INVENTARIO MENOS LA CANTIDAD DEL CARRITO 
        public List<UEncapInventario> ConsultarInventario()
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Ca_actual > 0)
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

        //METODO CONSULTAR INVENTARIO CATEGORIA MENOS LA CANTIDAD DEL CARRITO 
        public List<UEncapInventario> ConsultarInventarioCategoria(int categ)
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Ca_actual > 0 && x.Id_categoria == categ)
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

        //METODO CONSULTAR INVENTARIO MARCA MENOS LA CANTIDAD DEL CARRITO 
        public List<UEncapInventario> ConsultarInventariMarca(int marca)
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Ca_actual > 0 && x.Id_marca == marca)
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

        //METODO CONSULTAR INVENTARIO CATEGORIA Y MARCA MENOS LA CANTIDAD DEL CARRITO 
        public List<UEncapInventario> ConsultarInventariCombinado(int marca, int categ)
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Ca_actual > 0 && x.Id_marca == marca && x.Id_categoria == categ)
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
        //METODO CONSULTAR PRECIO ASCEDENE
        public List<UEncapInventario> ConsultarInventarioPrecio(string valores)
        {
            //Metodo de Slip
            string[] split = valores.Split(',');
            int can1 = Convert.ToInt32(split[0]);
            int can2 = Convert.ToInt32(split[1]);


            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2)
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





                        }


                        ).ToList();

            }
        }
        //METODO CONSULTAR PRECIO ASCEDENE
        public List<UEncapInventario> ConsultarInventarioPrecioCategoria(string valores, int categ)
        {
            //Metodo de Slip
            string[] split = valores.Split(',');
            int can1 = Convert.ToInt32(split[0]);
            int can2 = Convert.ToInt32(split[1]);


            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2 && x.Id_categoria == categ)
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





                        }


                        ).ToList();

            }
        }

        public List<UEncapInventario> ConsultarInventarioPrecioMarca(string valores, int marca)
        {
            //Metodo de Slip
            string[] split = valores.Split(',');
            int can1 = Convert.ToInt32(split[0]);
            int can2 = Convert.ToInt32(split[1]);


            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2 && x.Id_marca == marca)
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





                        }


                        ).ToList();

            }
        }
        public List<UEncapInventario> ConsultarInventarioPrecioCombinado(string valores, int marca, int categor)
        {
            //Metodo de Slip
            string[] split = valores.Split(',');
            int can1 = Convert.ToInt32(split[0]);
            int can2 = Convert.ToInt32(split[1]);


            using (var db = new Mapeo())
            {
                return (from uu in db.inventario.Where(x => x.Precio >= can1 && x.Precio <= can2 &&
                        x.Id_marca == marca && x.Id_categoria == categor)
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





                        }


                        ).ToList();

            }
        }
        //METODO PARA OBTENER TODOS LOS ELEMENTOS DEL CARRITO 
        public List<UEncapCarrito> ObtenerCarritoxUsuario(int usu)
        {
            using (var db = new Mapeo())
            {
                return (from carrito in db.carrito.Where(x => x.User_id == usu)
                        join iven in db.inventario on carrito.Producto_id equals iven.Id
                        select new
                        {
                            carrito,
                            iven
                        }).ToList().Select(m => new UEncapCarrito
                        {
                            Id_Carrito = m.carrito.Id_Carrito,
                            User_id = m.carrito.User_id,
                            Producto_id = m.carrito.Producto_id,
                            Cantidad = m.carrito.Cantidad,
                            Fecha = m.carrito.Fecha,
                            Precio = m.carrito.Precio,
                            Total = m.carrito.Total,
                            Nom_producto = m.iven.Titulo,
                            Cant_Actual = (m.iven.Ca_actual - m.carrito.Cantidad).Value,
                            Id_pedido = m.carrito.Id_pedido
                        }).ToList();
            }
        }

        //MODIFICAR VALOR EN PEDIDO SI MODIFICAN CARRITO
        public void ActualizarValorpedido(UEncapPedido pedido)
        {
            using (var db = new Mapeo())
            {

                UEncapPedido pedidoedit = db.pedidos.Where(x => x.Id == pedido.Id).SingleOrDefault();
                pedidoedit.Total = pedido.Total;

                db.SaveChanges();
            }
        }

        //CAMBIO TODOS LOS ESTADOS DEL PRODUCTO CUANDO DAN FACTURAR EN EL CARRITO
        public void ActualizarCarritoEstado(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {

                var carritoedit = db.carrito.Where(x => x.User_id == carrito.User_id).ToList();
                foreach (var car in carritoedit)
                {
                    car.Estadocar = carrito.Estadocar;
                }
                db.SaveChanges();
            }
        }

        //METODO PARA INSERTAR PEDIDO
        public int InsertarPedido(UEncapPedido pedido)
        {
            using (var db = new Mapeo())
            {
                db.pedidos.Add(pedido);
                db.SaveChanges();
            }
            return pedido.Id;
        }


        //MODIFICAR ID DEL PEDIDO EN CARRITO
        public void ActualizarIdpedidoCarrito(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {

                var carritoedit = db.carrito.Where(x => x.User_id == carrito.User_id).ToList();
                foreach (var car in carritoedit)
                {
                    car.Id_pedido = carrito.Id_pedido;
                }
                db.SaveChanges();
            }
        }

        //METODO PARA OBTENER TODOS LOS ELEMENTOS DEL CARRITO 
        public UEncapParametros ObtenerTiempo(UEncapParametros nombre)
        {
            using (var db = new Mapeo())
            {
                return db.parametros.Where(x => x.Nombre.Equals(nombre.Nombre)).FirstOrDefault();
            }
        }
        public List<UEncapPedido> ObtenerPedidosActivo(int usu)
        {
            using (var db = new Mapeo())
            {
                return (from pedido in db.pedidos.Where(x => x.User_id == usu && x.Estado_pedido != 6)
                            //join atendido in db.usuario on pedido.Atendido_id equals atendido.User_id
                            //join domiciliario in db.usuario on pedido.Domiciliario_id equals domiciliario.User_id
                        join estado in db.estado_pedido on pedido.Estado_pedido equals estado.Id
                        join ciudad_dep in db.ciudades_departamentso on pedido.Ciu_dep_id equals ciudad_dep.Id
                        join municipio in db.municipios on pedido.Municipio_id equals municipio.Id
                        select new
                        {
                            pedido,
                            //atendido,
                            //domiciliario,
                            estado,
                            ciudad_dep,
                            municipio

                        }).ToList().Select(m => new UEncapPedido
                        {
                            Id = m.pedido.Id,
                            Fecha_pedido = m.pedido.Fecha_pedido,
                            User_id = m.pedido.User_id,
                            Atendido_id = m.pedido.Atendido_id,
                            //Empleado=m.atendido.Nombre,
                            Domiciliario_id = m.pedido.Domiciliario_id,
                            //Domiciliaro=m.domiciliario.Nombre,
                            Estado_pedido = m.pedido.Estado_pedido,
                            Estado = m.estado.Estado,
                            Total = m.pedido.Total,
                            Novedad = m.pedido.Novedad,
                            Direccion = m.pedido.Direccion,
                            Ciu_dep_id = m.pedido.Ciu_dep_id,
                            Ciudad_dep = m.ciudad_dep.Nombre,
                            Municipio_id = m.pedido.Municipio_id,
                            Municipio = m.municipio.Nombre,
                            Fecha_pedido_fin = m.pedido.Fecha_pedido_fin

                        }).ToList();
            }
        }
        //METODO PARA OBTENER LOS PEDIDOS FINALZIADOS POR USUARIO
        public List<UEncapPedido> ObtenerPedidosFin(int usu)
        {
            using (var db = new Mapeo())
            {
                return (from pedido in db.pedidos.Where(x => x.User_id == usu && x.Estado_pedido == 6)
                        join atendido in db.usuario on pedido.Atendido_id equals atendido.User_id
                        join domiciliario in db.usuario on pedido.Domiciliario_id equals domiciliario.User_id
                        join estado in db.estado_pedido on pedido.Estado_pedido equals estado.Id
                        join ciudad_dep in db.ciudades_departamentso on pedido.Ciu_dep_id equals ciudad_dep.Id
                        join municipio in db.municipios on pedido.Municipio_id equals municipio.Id
                        select new
                        {
                            pedido,
                            atendido,
                            domiciliario,
                            estado,
                            ciudad_dep,
                            municipio

                        }).ToList().Select(m => new UEncapPedido
                        {
                            Id = m.pedido.Id,
                            Fecha_pedido = m.pedido.Fecha_pedido,
                            User_id = m.pedido.User_id,
                            Atendido_id = m.pedido.Atendido_id,
                            Empleado = m.atendido.Nombre,
                            Domiciliario_id = m.pedido.Domiciliario_id,
                            Domiciliaro = m.domiciliario.Nombre,
                            Estado_pedido = m.pedido.Estado_pedido,
                            Estado = m.estado.Estado,
                            Total = m.pedido.Total,
                            Novedad = m.pedido.Novedad,
                            Direccion = m.pedido.Direccion,
                            Ciu_dep_id = m.pedido.Ciu_dep_id,
                            Ciudad_dep = m.ciudad_dep.Nombre,
                            Municipio_id = m.pedido.Municipio_id,
                            Municipio = m.municipio.Nombre,
                            Fecha_pedido_fin = m.pedido.Fecha_pedido_fin

                        }).ToList();
            }
        }
        //METODO PARA BUSCAR CORREO EN LOGIN 
        public UEncapUsuario verificarCorreoRecuperacion(string correo)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo.Equals(correo)).FirstOrDefault();
            }

        }

        //METODO pARA OBTENER pRODUCTOS DEL pEDIDO
        public List<UEncapProducto_pedido> ObtenerProductos(int id)
        {
            using (var db = new Mapeo())
            {
                return (from uu in db.productos.Where(x => x.Pedido_id == id)


                        select new
                        {
                            uu
                        }).ToList().Select(x => new UEncapProducto_pedido
                        {
                            Pedido_id = x.uu.Pedido_id,
                            Producto_id = x.uu.Producto_id,
                            Cantidad = x.uu.Cantidad,
                            Precio = x.uu.Precio,
                            Total = x.uu.Total
                        }

                        ).ToList();
            }
        }

        //ACTUALIZAR DATO DEL PRODUCTO EN EL CARRITO 
        public void ActualizarCarritoFactura(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {
                UEncapCarrito carritoedit = db.carrito.Where(x => x.Id_Carrito == carrito.Id_Carrito).SingleOrDefault();
                carritoedit.Cantidad = carrito.Cantidad;
                carritoedit.Precio = carrito.Precio;
                carritoedit.Cant_Actual = (carritoedit.Cant_Actual - carritoedit.Cantidad).Value;
                carritoedit.Total = (carritoedit.Cantidad * carritoedit.Precio).Value;

                db.SaveChanges();
            }
        }

    }

}
