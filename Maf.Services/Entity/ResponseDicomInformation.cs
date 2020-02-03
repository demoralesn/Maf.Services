using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Maf.Services.Entity
{
    public class ResponseDicomInformation
    {
        #region Private Variable
        private int id;
        private string tipo;
        private string fec_venc;
        private string cod_mon;
        private double monto;
        private string librador;
        private string categoria;
        private ErrorHandler errorHandler = new ErrorHandler();
        #endregion

        public ErrorHandler ErrorDefault
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

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }

        public string Fec_Venc
        {
            get
            {
                return this.fec_venc;
            }
            set
            {
                this.fec_venc = value;
            }
        }

        public string Cod_Mon
        {
            get
            {
                return this.cod_mon;
            }
            set
            {
                this.cod_mon = value;
            }
        }

        public double Monto
        {
            get
            {
                return this.monto;
            }
            set
            {
                this.monto = value;
            }
        }

        public string Librador
        {
            get
            {
                return this.librador;
            }
            set
            {
                this.librador = value;
            }
        }

        public string Categoria
        {
            get
            {
                return this.categoria;
            }
            set
            {
                this.categoria = value;
            }
        }
    }
}