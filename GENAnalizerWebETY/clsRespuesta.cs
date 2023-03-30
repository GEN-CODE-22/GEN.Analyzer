using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENAnalizerWebETY
{
  public  class clsRespuesta
    {
        /// <summary>
        /// Clase para gestionar la respuesta de una peticion
        /// Hecho por: Hector Aleman Pineda
        /// Fecha: 2021-03-04
        /// Email: haleman@gasexpressnieto.com.mx
        /// Fecha de modificaicon:2021-03-04
        public Object ObjetReturn { set; get; }

        public string MesajeReturn { set; get; }

        public string ErrorReturn { set; get; }

        /*success,error,warning,info,question*/
        public string iconMessage { set; get; }
    }
}
