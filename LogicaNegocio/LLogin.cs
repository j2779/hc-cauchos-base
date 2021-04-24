
using Utilitarios;
using Datos;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LogicaNegocio
{
    public class LLogin
    {
        // logica de negocio login
        public UEncapUsuario login (UEncapUsuario usuario)
        {
            UEncapUsuario mensaje = new UEncapUsuario();
            mensaje = new DaoUsuario().verificarUsuario(usuario);

            return mensaje;
        }    

        //metodo para login servicios
        public UEncapUsuario login2 (LoginRequest login)
        {
            return new DaoUsuario().verificarUsuario2(login);
        }

        //metodo para almacenar token
        public void guararToken(UEncapToken token)
        {
            new DaoUsuario().almacenarToken(token);
        }

        //metodo para obtener configuracion
        public UEncapAplicacion ObtenerConfiguracion(string token)
        {
            return new DaoUsuario().getAplicaionesByToken(token);
        }

        // actualizacion de usuario
        public string Actualizar (UEncapUsuario userb)
        {
            string aviso;
            userb = new DaoUsuario().actualizarsession(userb);

            if (userb != null)
            {
                aviso = ("$Se han cerrado las sessiones antiguas");
            }
            else {

                aviso = ("$NO Se han cerrado las sessiones antiguas");
            }
            return aviso;
        }
        public bool verificarCorreo(UEncapUsuario usuario)
        {

            bool respuesta;
            usuario = new DaoUsuario().verificarCorreo(usuario);
            if( usuario != null)
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }

            return respuesta;
        }
        public bool verificarIdentificacion(UEncapUsuario usuario)
        {
            bool respuesta;
            usuario = new DaoUsuario().verificarIdentificacion(usuario);
            if (usuario != null)
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }


        public void insertarUsuario(UEncapUsuario usuario)
        {
             new DaoUsuario().InsertarUsuario(usuario);
        }

        public void actualizarUsuario(UEncapUsuario usuario)
        {
            new DaoUsuario().ActualizarUsuario(usuario);
        }

       public UEncapUsuario usuarioActivo2(string correo)
        {
           var usuario = new DaoUsuario().UsuarioActivo2(correo);
           return usuario;
        }

        public void insertarEmpleado(UEncapUsuario usuario)
        {
            new DAOAdmin().InsertarEmpleado(usuario);
        }


        public UEncapUsuario usuarioActivo(string usuario)
        {
            var usu = new DaoUsuario().UsuarioActivo(usuario);
            return usu;
        }

        public List<UEncapMarca> ConsultarMarca()
        {
            var marcas = new DAOAdmin().ColsultarMarca();
            return marcas;
        }
        //encriptacion token de recuperacion clave
        public string encriptar(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }
        public UEncapUsuario BuscarToken(string token)
        {
            return new DaoUsuario().BuscarToken(token);
        }
        //METODO PARA BUSCAR CORREO EN LOGIN 
        public UEncapUsuario verificarCorreoRecuperacion(string correo)
        {
            return new DaoUsuario().verificarCorreoRecuperacion(correo);

        }
    }
}

