using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Maf.Services.Entity;

namespace Maf.Services.Interface
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ICreditEvaluation" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ICreditEvaluation
    {
        [OperationContract]
        string GetDicomState(RequestDicomInformation requestDicomInformation);

        [OperationContract]
        List<ResponseDicomInformation> GetDicomDebtDetail(RequestDicomInformation requestDicomInformation);
    }
}
