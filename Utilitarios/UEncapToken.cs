using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Utilitarios
{
    [Serializable]
    [Table("token_usuario_app", Schema = "security")]
    public class UEncapToken
    {

        private int id;
        private int aplicacionId;
        private Nullable<int> userId;
        private DateTime fechaGenerado;
        private DateTime fechaVigencia;
        private string token;

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }
        [Column("aplicacion_id")]
        public int AplicacionId { get => aplicacionId; set => aplicacionId = value; }
        [Column("user_id")]
        public int? UserId { get => userId; set => userId = value; }
        [Column("fecha_generado")]
        public DateTime FechaGenerado { get => fechaGenerado; set => fechaGenerado = value; }
        [Column("fecha_vigencia")]
        public DateTime FechaVigencia { get => fechaVigencia; set => fechaVigencia = value; }
        [Column("token")]
        public string Token { get => token; set => token = value; }
    }
}
