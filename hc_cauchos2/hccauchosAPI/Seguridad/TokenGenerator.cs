using System;
using System.Configuration;
using System.Security.Claims;
using LogicaNegocio;
using Microsoft.IdentityModel.Tokens;
using Utilitarios;

namespace WebApiSegura.Security
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// more info: https://self-issued.info/docs/draft-ietf-oauth-json-web-token.html
    /// </summary>
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(UEncapUsuario user)
        {
            //TODO: appsetting for Demo JWT - protect correctly this settings

            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];


            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(user.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity 
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.NameIdentifier, user.User_id.ToString()),
                new Claim(ClaimTypes.Email, user.Correo),            
                new Claim(ClaimTypes.Name, user.Nombre),
                new Claim(ClaimTypes.SerialNumber, user.Identificacion),
                new Claim(ClaimTypes.Role, user.Rol_id.ToString()),
                new Claim(ClaimTypes.Gender, user.AplicacionId.ToString())
            });

            // create token to the user 
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(user.Expiracion),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);

            UEncapToken token = new UEncapToken();
            token.AplicacionId = user.AplicacionId;
            token.FechaGenerado = DateTime.Now;
            token.FechaVigencia = DateTime.Now.AddMinutes(user.Expiracion);
            token.UserId = user.User_id;
            token.Token = jwtTokenString;
            new LLogin().guararToken(token);
            return jwtTokenString;
        }
    }
}
