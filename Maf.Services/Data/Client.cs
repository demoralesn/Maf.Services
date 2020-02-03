using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Maf.Services.Entity;
using System.Xml.Serialization;
using System.IO;
using System.Data;

namespace Maf.Services.Data
{
    public class Client
    {
        /// <summary>
        /// Get basic information
        /// </summary>
        /// <param name="requestClient"></param>
        /// <returns></returns>

        public static string GetDicomState(RequestDicomInformation requestDicom)
        {
            try
            {
                var wsDicom = new WSConsultas.ConsultasSoapClient("ConsultasSoap");

                var response = wsDicom.InformeComercial(requestDicom.Rut,false);

                var resultEval = "Sin datos";

                double totalDebt = 0;
                double educationDebt = 0;

                if (response.detalleInforme != null)
                {
                    foreach (var item in response.detalleInforme)
                    {
                            if (string.IsNullOrWhiteSpace(GetDebtType(item.librador)))
                            {
                                totalDebt += item.monto;
                            }
                            else
                            {
                                educationDebt += item.monto;
                            }
                    }
                }

                if ((totalDebt + educationDebt) > 0)
                {
                    if((totalDebt + educationDebt) <= Constantes.DicomLimit)
                    {
                        resultEval = "Pendiente";
                    }
                    else
                    {
                        resultEval = "Rechazado";
                    }
                }
                else
                {
                    resultEval = "Aprobado";
                }

                return resultEval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<ResponseDicomInformation> GetDicomDebtDetail(RequestDicomInformation requestDicom)
        {
            try
            {
                List<ResponseDicomInformation> listDebtDetail = new List<ResponseDicomInformation>();

                var wsDicom = new WSConsultas.ConsultasSoapClient("ConsultasSoap");

                var response = wsDicom.InformeComercial(requestDicom.Rut, false);

                if (response.detalleInforme != null)
                {
                    foreach (var item in response.detalleInforme)
                    {
                        var debtDetail = new ResponseDicomInformation();

                        debtDetail.Id = item.id;
                        debtDetail.Tipo = item.tipo;
                        debtDetail.Fec_Venc = item.fecha_vencimiento.ToString();
                        debtDetail.Cod_Mon = item.codigo_moneda;
                        debtDetail.Monto = item.monto;
                        debtDetail.Librador = item.librador;
                        debtDetail.Categoria = GetDebtType(item.librador);

                        listDebtDetail.Add(debtDetail);
                    }
                }
                return listDebtDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetDebtType(string debtEntity)
        {
            try
            {
                string debtType = "";
                SqlConnection conexion;
                SqlCommand comandoSql;
                SqlDataReader dataReader;

                conexion = new Conexion().SqlEntregaConexion(Enums.Tipologia.TipoConexion.Credito);
                conexion.Open();
                comandoSql = new SqlCommand(StoredProcedure.GetDebtType, conexion);
                comandoSql.CommandType = System.Data.CommandType.StoredProcedure;
                comandoSql.Parameters.Add(new SqlParameter("@debtEntity", debtEntity));
                dataReader = comandoSql.ExecuteReader();

                while (dataReader.Read())
                {
                    debtType = dataReader["debtType"].ToString();
                }
                dataReader.NextResult();

                comandoSql.Dispose();
                conexion.Dispose();

                return debtType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}