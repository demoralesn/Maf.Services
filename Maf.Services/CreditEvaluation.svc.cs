using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Maf.Services.Interface;
using Maf.Services.Entity;

namespace Maf.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "CreditEvaluation" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione CreditEvaluation.svc o CreditEvaluation.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class CreditEvaluation : ICreditEvaluation
    {
        public string GetDicomState(RequestDicomInformation requestDicom)
        {
            try
            {
                return Business.Client.GetDicomState(requestDicom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ResponseDicomInformation> GetDicomDebtDetail(RequestDicomInformation requestDicom)
        {
            try
            {
                return Business.Client.GetDicomDebtDetail(requestDicom);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
