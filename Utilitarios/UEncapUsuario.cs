using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Utilitarios
{
    [Serializable]
    [Table("usuario", Schema = "usuario")]

    public class UEncapUsuario
    {
        private int user_id;
        private string nombre;
        private string apellido;
        private string correo;
        private int rol_id;
        private string clave;
        private DateTime fecha_nacimiento;
        private string identificacion;
        private string token;
        private int estado_id;
        private Nullable<DateTime> tiempo_token;
        private string sesion; 
        private Nullable<DateTime> last_modify;
        private string rolNombre;
        private string estadoNombre;
        private string ip_;
        private string mac_;

        private int expiracion;
        private string key;
        private int aplicacionId;

        [Key]
        [Column("user_id")]
        public int User_id { get => user_id; set => user_id = value; }
        [Column("nombres")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Column("apellidos")]
        public string Apellido { get => apellido; set => apellido = value; }
        [Column("correo")]
        public string Correo { get => correo; set => correo = value; }
        [Column("rol_id")]
        public int Rol_id { get => rol_id; set => rol_id = value; }
        [Column("fecha_nacimiento")]
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        [Column("identificacion")]
        public string Identificacion { get => identificacion; set => identificacion = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
        [Column("estado_id")]
        public int Estado_id { get => estado_id; set => estado_id = value; }
        [Column("tiempo_token")]
        public DateTime? Tiempo_token { get => tiempo_token; set => tiempo_token = value; }
        [Column("session")]
        public string Sesion { get => sesion; set => sesion = value; }
        [Column("clave")]
        public string Clave { get => clave; set => clave = value; }
        [Column("last_modify")]
        public DateTime? Last_modify { get => last_modify; set => last_modify = value; }
        [Column("ip")]
        public string Ip_ { get => ip_; set => ip_ = value; }
        [Column("mac")]
        public string Mac_ { get => mac_; set => mac_ = value; }



        [NotMapped]
        public string RolNombre { get => rolNombre; set => rolNombre = value; }
        [NotMapped]
        public string EstadoNombre { get => estadoNombre; set => estadoNombre = value; }
        [NotMapped]
        public int Expiracion { get => expiracion; set => expiracion = value; }
        [NotMapped]
        public string Key { get => key; set => key = value; }
        [NotMapped]
        public int AplicacionId { get => aplicacionId; set => aplicacionId = value; }
    }
}
