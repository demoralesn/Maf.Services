using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Maf.Services.Utiles
{
    public static class Generales
    {
        private const string ENCRYPTER = "aa544@<.AAKKL?=y";
        /// <summary>
        /// Encripta el texto ingresado
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string Encrypt(string texto)
        {
            return new Encripta.GOEncripta().EncriptarTexto(ENCRYPTER, texto);
        }
        /// <summary>
        /// Desencripta el texto ingresado
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static string Decrypt(string texto)
        {
            return new Desencripta.GODesencripta().DesencriptaTexto(ENCRYPTER, texto);
        }
        /// <summary>
        /// Devuelve el string de conexion correspondiente a la llave ingresada
        /// </summary>
        /// <param name="texto">Key BDD</param>
        /// <returns></returns>
        public static string DBConnStr(string texto)
        {
            string stringConexion = ConfigurationManager.ConnectionStrings[texto].ToString();
            return new Desencripta.GODesencripta().DesencriptaTexto(ENCRYPTER, stringConexion);
        }
    }

}