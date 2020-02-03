using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maf.Services.Entity
{
    public class RequestDicomInformation
    {
        #region Private Variable
        private string rut;
        private ErrorHandler errorHandler = new ErrorHandler();
        #endregion

        public string Rut
        {
            get
            {
                return this.rut;
            }
            set
            {
                this.rut = value;
            }
        }
        /// <summary>
        /// Class of default error of applicaction
        /// </summary>
        public ErrorHandler ErrorResponse
        {
            get
            {
                return this.errorHandler;
            }
            set
            {
                this.errorHandler = value;
            }
        }
    }
}