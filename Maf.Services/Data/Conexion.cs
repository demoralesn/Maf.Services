using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Maf.Services.Data
{
    public class Conexion
    {
        private string cadenaConexion;
        private string enumString;
        SqlConnection conexionActiva;
        public SqlConnection SqlEntregaConexion(Enums.Tipologia.TipoConexion tipoConexionParam)
        {
            try
            {
                enumString = tipoConexionParam.ToString();
                cadenaConexion = Utiles.Generales.DBConnStr(enumString);
                conexionActiva = new SqlConnection(cadenaConexion);
                return conexionActiva;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexionActiva = null;
            }

        }

    }


}