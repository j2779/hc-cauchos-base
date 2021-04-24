using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Utilitarios
{
    public class Correo
    {
        public void enviarCorreo(String correoDestino, String userToken, String mensaje)
        {

            try
            {   
            var Emailtemplate = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory.Insert(AppDomain.CurrentDomain.BaseDirectory.Length, "Plantilla\\mailer.html"));
            var strBody = string.Format(Emailtemplate.ReadToEnd(), userToken);
            Emailtemplate.Close(); Emailtemplate.Dispose(); Emailtemplate = null;
            

                //strBody = strBody.Replace("#TOKEN#", mensaje);
                //Configuración del Mensaje
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //Especificamos el correo desde el que se enviará el Email y el nombre de la persona que lo envía
                mail.From = new MailAddress("coaceros57@gmail.com", "HC CAUCHOS");
                SmtpServer.Host = "smtp.gmail.com";
                //Aquí ponemos el asunto del correo
                mail.Subject = "Recuperación Contraseña";
                //Aquí ponemos el mensaje que incluirá el correo
                string likserv = "proyectosisw12020.tk/CauchosHC/Views/Actualizacion_clave.aspx?" + userToken;
                string linkLocal = "http://localhost:57160/Views/Actualizacion_clave.aspx?" + userToken;
                //mail.Body = "Para recuperar su cuenta ingrese al siguiente link  :<a href = "+ linkLocal +"   > </a> ";

                mail.Body = "Para recuperar su cuenta ingrese al siguiente link: " + likserv;
                mail.To.Add(correoDestino);
                //Si queremos enviar archivos adjuntos tenemos que especificar la ruta en donde se encuentran
                //mail.Attachments.Add(new Attachment(@"C:\Documentos\carta.docx"));
                mail.IsBodyHtml = true;

                mail.Priority = MailPriority.Normal;
                //Configuracion del SMTP
                SmtpServer.Port = 587; //Puerto que utiliza Gmail para sus servicios
                                       //Especificamos las credenciales con las que enviaremos el mail
                SmtpServer.Credentials = new System.Net.NetworkCredential("coaceros57@gmail.com", "juan1003495052");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
    }
   
}
