using Utilitarios;
using Datos;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class LAdministrador
    {
        public UEncapUsuario obtenerAdmin (UEncapUsuario usu)
        {
            var usuario = new DAOAdmin().obtenerAdmin(usu);
            return usuario;
        }

        //METODO PARA INSERTAR EMPLEADO
        public void insertarEmpleado(UEncapUsuario empleado)
        {
             new DAOAdmin().InsertarEmpleado(empleado);

        }

        //METODO PARA OBTENER EMPLEADOS
        public List<UEncapUsuario> obtenerEmpleados()
        {
            var empleados = new DAOAdmin().ObtenerEmpleados();
            return empleados;
        }

        //MEOTODO PARA ACTUALIZAR CONTRASEÑA ADMIN LOS EMPLEADOS
        public void actualizarContraseña(UEncapUsuario user)
        {
            new DAOAdmin().ActualizarContraseña(user);
        }

        //MEOTODO PARA ACTUALIZAR CORREO ADMIN LOS EMPLEADOS
        public void actualizarCorreo(UEncapUsuario user)
        {
            new DAOAdmin().ActualizarCorreo(user);
        }

        //METODO PARA VERIFICAR CORREO
        public bool verifcarCorreo(UEncapUsuario user)
        {
            bool request = new DAOAdmin().verificarCorreo(user);
            return request;
        }

        //METODO PARA MODIFICAR EMPLEADO 

        public void actualizarEmpleado(UEncapUsuario empleado)
        {
            new DAOAdmin().actualizarEmpleado(empleado);
        }

        //METODO PARA ACTUALIZAR EL INVENTARIO
        public void ActualizarInventario(UEncapInventario inventario)
        {
            new DAOAdmin().ActualizarInventario(inventario);
        }

        //METODOS PARA MISION VISION OBJETIVO 
        public EncapMision ObtenerMision()
        {
            var misi = new DAOAdmin().ObtenerMision();
            return misi;
        }

        public EncapVision ObtenerVision()
        {
            var visi = new DAOAdmin().ObtenerVision();
            return visi;
        }

        public EncapObjetivo ObtenerObjetivo()
        {

            var obje = new DAOAdmin().ObtenerObjetivon();

            return obje;
        }

        //metodos para actualizar mision vision objetivo
        public void ActualizarMision(EncapMision mision)
        {
            new DAOAdmin().ActualizarMision(mision);
        }
        public void ActualizarVision(EncapVision Vision)
        {
            new DAOAdmin().ActualizarVision(Vision);
        }
        public void ActualizarObjetivo(EncapObjetivo Objetivo)
        {
            new DAOAdmin().ActualizarObjetivo(Objetivo);
        }


        //LISTOOOOOSS-----------------------------------------------------------



        public void ActualizarTiempoCarrito(UEncapParametros tiempo)
        {
            new DAOAdmin().ActualizarTiempoCarrito(tiempo);
        }
        //METODO PARA CONSULTAR LAS MARCAS DE LOS PRODUCTOS 
        public List<UEncapMarca> ConsultarMarca()
        {
            var marcas = new DAOAdmin().ColsultarMarca();
            return marcas;
        }
        //METODO PARA CONSULTAR LAS CATEGORIAS DE LOS PRODUCTOS
        public List<UEncapCategoria> ConsultarCategoria()
        {
            var categoria = new DAOAdmin().ColsultarCategoria();
            return categoria;
        }

        //metodo para consultar si la referencia existe
        public bool consultarReferencia( UEncapInventario referencia)
        {
            bool respuesta;
            referencia = new DAOAdmin().ConsultarReferencia(referencia);
            if(referencia != null)
            {
                respuesta = true;
            }
            else
            {
                respuesta = false;
            }

            return respuesta;
        }
        //METODO PARA INSERTAR ITEM DE INVENTARIO 
        public void insertarItem(UEncapInventario item)
        {
            new DAOAdmin().InsertarItem(item);
        }


        //METODO PARA CONSULTAR EMPLEADO EN HISTORIALVENTAS
        public List<UEncapUsuario> ConsultarEmpleado()
        {
            var empleado = new DAOAdmin().ConsultarEmpleado();
            return empleado;
        }
        //METODO PARA CONSULTAR VENTAS EN HISTORIALVENTAS
        public List<UEncapPedido> ConsultarVentas()
        {
            var ventas = new DAOAdmin().ConsultarVentas();
            return ventas;
        }
        //METODO PARA CONSULTAR VENTAS_DIA EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasDia(int dia)
        {
            var ventasdia = new DAOAdmin().ConsultarVentasDia(dia);
            return ventasdia;
        }

        //METODO PARA CONSULTAR VENTAS_MES EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasMes(int mes)
        {
            var ventasmes = new DAOAdmin().ConsultarVentasMes(mes);
            return ventasmes;
        }
        //METODO PARA CONSULTAR VENTAS_ANIO EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasAno(int ano)
        {
            var ventasano = new DAOAdmin().ConsultarVentasAno(ano);
            return ventasano;
        }

        //METODO PARA CONSULTAR VENTAS_ANIO_DIA EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasAnoDia(int ano, int dia)
        {
            var ventasanodia = new DAOAdmin().ConsultarVentasAnoDia(ano,dia);
            return ventasanodia;
        }

        //METODO PARA CONSULTAR VENTAS_ANIO_MES_DIA EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasAnoMesDia(int ano, int mes, int dia)
        {
            var ventasfull = new DAOAdmin().ConsultarVentasAnoMesDia(ano,mes, dia);
            return ventasfull;
        }
        //METODO PARA CONSULTAR VENTAS_MES_DIA EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasMesDia(int mes, int dia)
        {
            var ventasmesdia = new DAOAdmin().ConsultarVentasAnoDia(mes, dia);
            return ventasmesdia;
        }

        //METODO PARA CONSULTAR VENTAS_ANO_MES_DIA_EMPLEADO EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasAnoMesDiaEmpleado(int ano,int mes, int dia, int emple)
        {
            var ventascombi = new DAOAdmin().ConsultarVentasAnoMesDiaEmpleado(ano,mes, dia,emple);
            return ventascombi;
        }

        //METODO PARA CONSULTAR VENTAS_MES DEL AÑO EN HISTORIAL VENTAS
        public List<UEncapPedido> ConsultarVentasAnMes(int ano, int mes)
        {
            var ventasanomes = new DAOAdmin().ConsultarVentasAnMes(ano, mes);
            return ventasanomes;
        }

        //CONSULTAR  PEDIDO ESTADO EN HISTORIAL PEDIDOS
        public List<UEncapPedido> ConsultarPedidosEstado(int est)
        {
            var estado = new DAOAdmin().ConsultarPedidosEstado(est);
            return estado;
        }

        //CONSULTAR  ESTADO PEDIDO EN HISTORIAL PEDIDOS
        public List<UEncapEstadoPedido> ConsultarEstadoPedidos()
        {
            var estado = new DAOAdmin().ConsultarEstadoPedidos();
            return estado;
        }

        //CONSULTAR PEDIDOS EN HISTORIAL PEDIDOS 
        public List<UEncapPedido> ConsultarPedidos()
        {
            var pedido = new DAOAdmin().ConsultarPedidos();
            return pedido;
        }

        //METODO PARA CONSULTAR ALERTAS
        public List<UEncapInventario> ConsultarAlertas()
        {
            var alerta = new DAOAdmin().ConsultarAlertas();
            return alerta;
        }
    

     




        //METODO PARA OBTENER EMPLEADOS POOR NOMBRE
        public List<UEncapUsuario> obtenerEmpleadosNombre(string nombre)
        {
            var empleados = new DAOAdmin().ObtenerEmpleados();
            return empleados;
        }

        //METODO PARA CONSULTAR INVENTARIO
        public List<UEncapInventario> ConsultarInventario()
        {
            var inventario = new DAOAdmin().ConsultarInventario();
            return inventario;
        }

        

        //METODO PARA CONSULTAR INVETARIO POR REFERENCIA
        public List<UEncapInventario> BuscarReferencia( string a)
        {
            var inventario = new DAOAdmin().BuscarReferencia(a);
            return inventario;
        }

        //METODO PARA CONSULTAR INVETARIO POR MARCA
        public List<UEncapInventario> BuscarMarca(int marca)
        {
            var inventario = new DAOAdmin().BuscarMarca(marca);
            return inventario;
        }

        //METODO PARA CONSULTAR INVETARIO POR MARCA
        public List<UEncapInventario> BuscarCategoria(int categ)
        {
            var categoria = new DAOAdmin().BuscarCategoria(categ);
            return categoria;
        }

        //METODO PARA CONSULTAR INVETARIO POR MARCA Y CATEGORIA
        public List<UEncapInventario> BuscarMarcaCategoria(int marca, int catego)
        {
            var categoria = new DAOAdmin().BuscarMarcaCategoria(marca, catego);
            return categoria;
        }
        public List<UEncapRol> ObtenerRoles()
        {
            var roles = new DAOAdmin().ObtenerRoles();
            return roles;
        }
        public List<UEncapEstado> ObtenerEstados()
        {
            var estados = new DAOAdmin().ObtenerEstados();
            return estados;
        }
        public IList<UEncapCategoria> ColsultarCategoria2()
        {
            var categoria = new DAOAdmin().ColsultarCategoria2();
            return categoria;
        }

        public IList<UEncapEstadoItem> ColsultarEstado()
        {
            var estado = new DAOAdmin().ColsultarEstado();
            return estado;
        }







    }
}
