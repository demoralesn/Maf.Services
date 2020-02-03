using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maf.Services.Entity;

namespace Maf.Services.Business
{
    public static class Client
    {
        public static string GetDicomState(RequestDicomInformation requestDicom)
        {
            return Data.Client.GetDicomState(requestDicom);
        }

        public static List<ResponseDicomInformation> GetDicomDebtDetail(RequestDicomInformation requestDicom)
        {
            return Data.Client.GetDicomDebtDetail(requestDicom);
        }
    }

}