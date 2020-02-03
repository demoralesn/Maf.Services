using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maf.Services.Entity
{
    public static class StoredProcedure
    {
        public const string AlzamientoUpdate = "sp_c_Alz_Cambia_Estado";
        public const string GetClientInformation = "spGetClientInformation";
        public const string GetCouponCollection = "spGetCouponCollection";
        public const string SetRetention = "spRetencionIngreso";
        public const string GetClientRut = "spGetRutCliente";
        public const string GetDebtType = "spGetDebtType";
    }
}