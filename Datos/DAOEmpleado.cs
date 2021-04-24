using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Utilitarios;

namespace Datos
{
    public class DAOEmpleado
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
        //METODO PARA INSERTAR carrrito
        public void InsertarCarrito(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {
                db.carrito.Add(carrito);
                db.SaveChanges();
            }
        }
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
        public List<UEncapCategoria> ColsultarCategoria2()
        {
            using (var db = new Mapeo())
            {
                return db.categoria.OrderBy(x => x.Id >= 1).ToList();
            }
        }
        public List<UEncapMarca> ColsultarMarca()
        {
            using (var db = new Mapeo())
            {
                return db.marca_carro.OrderBy(x => x.Id).ToList();
            }
        }
        public UEncapUsuario verificarIdentificacion(UEncapUsuario verificar)
        {
            using (var db = new Mapeo())
            {
                return db.usuario.Where(x => x.Correo.Equals(verificar.Correo) || x.Identificacion.Equals(verificar.Identificacion)).FirstOrDefault();
            }
        }
        public void InsertarCliente(UEncapUsuario cliente)
        {
            using (var db = new Mapeo())
            {
                db.usuario.Add(cliente);
                db.SaveChanges();
            }
        }
        public void InsertarEmpleado(UEncapUsuario empleado)
        {
            using (var db = new Mapeo())
            {
                db.usuario.Add(empleado);
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

        //METODO PARA INSERTAR PRODUCTOS AL MOMENTO DE VENTA
        public void InsertarProductos(UEncapProducto_pedido producto)
        {
            using (var db = new Mapeo())
            {
                db.productos.Add(producto);
                db.SaveChanges();
            }
        }
        //ACTUALIZAR  CANTIDAD DEL PRODUCTO EN EL INVENTARIO 
        public void ActualizarCantidadInventario(UEncapInventario producto)
        {
            using (var db = new Mapeo())
            {
                UEncapInventario inventarioedit = db.inventario.Where(x => x.Id == producto.Id).SingleOrDefault();
                inventarioedit.Ca_actual = inventarioedit.Ca_actual - producto.Ca_actual;

                db.SaveChanges();
            }
        }
        //METODO PARA BORRAR EN CARRITO LUEGO DE HACER FACTURACION
        public void limpiarCarrito(int userid)
        {
            using (var db = new Mapeo())
            {
                List<UEncapCarrito> productos = db.carrito.Where(x => x.User_id == userid).ToList();

                foreach (var pro in productos)
                {
                    db.Entry(pro).State = EntityState.Deleted;
                }

                db.SaveChanges();
            }
        }
        public void ActualizarValorpedido(UEncapPedido pedido)
        {
            using (var db = new Mapeo())
            {

                UEncapPedido pedidoedit = db.pedidos.Where(x => x.Id == pedido.Id).SingleOrDefault();
                pedidoedit.Total = pedido.Total;

                db.SaveChanges();
            }
        }
        //METODO PARA OBTENER LOS CLIENTES EN VENTAS 
        public List<UEncapUsuario> ObtenerClientes()
        {
            using (var db = new Mapeo())
            {
                return (
                        //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                        from usu in db.usuario
                        where usu.Rol_id == 4
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
        //METODO PARA OBTEENR CLIENTES POR cedula
        public List<UEncapUsuario> ObtenerClientesCedula(string cedula)
        {
            using (var db = new Mapeo())
            {
                return (
                        //apunto a tabla empleado donde usuario sea empleado/domiciliario 
                        from usu in db.usuario
                        where (usu.Rol_id == 4) && (usu.Identificacion == cedula)
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
        //ELIMINAR PRODUCTO DEL CARRITO 
        public void EliminarItemCarrito(UEncapCarrito carrito)
        {
            using (var db = new Mapeo())
            {
                db.carrito.Attach(carrito);
                var entry = db.Entry(carrito);
                entry.State = EntityState.Deleted;
                db.SaveChanges();
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
        //ACTUALIZAR ESTADO PEDIDO A 2
        public void ActualizarEstadoPedido2(UEncapPedido pedido2)
        {
            using (var db = new Mapeo())
            {
                UEncapPedido estado = db.pedidos.Where(x => x.Id == pedido2.Id).SingleOrDefault();
                estado.Estado_pedido = pedido2.Estado_pedido;

                db.SaveChanges();
            }
        }
        //ACTUALIZAR NOVEDAD EN EL PEDIDO
        public void ActualizarNovedadPedido(UEncapPedido novedad)
        {
            using (var db = new Mapeo())
            {
                UEncapPedido newnovedad = db.pedidos.Where(x => x.Id == novedad.Id).SingleOrDefault();
                newnovedad.Novedad = novedad.Novedad;

                db.SaveChanges();
            }
        }
        //ACTUALIZAR ESTADO PEDIDO A 3
        public void ActualizarEstadoPedido3(UEncapPedido pedido3)
        {
            using (var db = new Mapeo())
            {
                UEncapPedido estado = db.pedidos.Where(x => x.Id == pedido3.Id).SingleOrDefault();
                estado.Estado_pedido = pedido3.Estado_pedido;

                db.SaveChanges();
            }
        }
        //ACTUALIZAR ESTADO EMPLEADO
        public void ActualizarEstadoEmpleado(UEncapUsuario empleado)
        {
            using (var db = new Mapeo())
            {
                UEncapUsuario emple = db.usuario.Where(x => x.User_id == empleado.User_id).SingleOrDefault();
                emple.Estado_id = empleado.Estado_id;

                db.SaveChanges();
            }
        }
        //METODO PARA OBTENER LOS PRODUCTOS DEL PEDIDO
        public List<UEncapProducto_pedido> ObtenerProductos(int pedido)
        {
            using (var db = new Mapeo())

                return (from produc in db.productos.Where(x => x.Pedido_id == pedido)
                        join inventario in db.inventario on produc.Producto_id equals inventario.Id

                        select new
                        {
                            produc,
                            inventario


                        }).ToList().Select(m => new UEncapProducto_pedido
                        {

                            Id = m.produc.Id,
                            Pedido_id = m.produc.Pedido_id,
                            Producto_id = m.produc.Producto_id,
                            Cantidad = m.produc.Cantidad,
                            Precio = m.produc.Precio,
                            Total = m.produc.Total,
                            Nombre_producto = m.inventario.Titulo,
                            Referencia = m.inventario.Referencia


                        }).ToList();
        }
        //METODO PARA OBTENER LOS PEDIDOS DEL EMPLEADO
        public List<UEncapPedido> ObtenerPedidos(int user)
        {
            using (var db = new Mapeo())

                return (from pedi in db.pedidos.Where(x => x.Atendido_id == user && x.Estado_pedido == 2)
                        join usu in db.usuario on pedi.User_id equals usu.User_id
                        //join emple in db.usuario  on pedi.Atendido_id  equals emple.User_id


                        select new
                        {
                            pedi,
                            usu
                            //emple,


                        }).ToList().Select(m => new UEncapPedido
                        {

                            Id = m.pedi.Id,
                            Fecha_pedido = m.pedi.Fecha_pedido,
                            User_id = m.pedi.User_id,
                            Atendido_id = m.pedi.Atendido_id,
                            Domiciliario_id = m.pedi.Domiciliario_id,
                            Estado_pedido = m.pedi.Estado_pedido,
                            Total = m.pedi.Total,
                            Novedad = m.pedi.Novedad,
                            Ciu_dep_id = m.pedi.Ciu_dep_id,
                            Direccion = m.pedi.Direccion,
                            Municipio_id = m.pedi.Municipio_id,
                            Fecha_pedido_fin = m.pedi.Fecha_pedido_fin,
                            Usuario = m.usu.Nombre
                            //Empleado = m.emple.Nombre,               


                        }).ToList();
        }

        public List<UEncapMunicipio> ConsultarMunicipio()
        {
            using (var db = new Mapeo())
            {
                return db.municipios.OrderBy(x => x.Id).ToList();
            }
        }

    }
}
