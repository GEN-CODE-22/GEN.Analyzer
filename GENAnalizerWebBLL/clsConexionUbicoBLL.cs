using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENAnalizerWebDAL;
using GENAnalizerWebETY;
using GENAnalizerWebETY.Ubiqo;


namespace GENAnalizerWebBLL
{
   public class clsConexionUbicoBLL
    {
       public List<clsDatosAppCliente> infoAppCliente(clParametros param)
       {
           clsConexionAnalizerUbiqo conexion= new clsConexionAnalizerUbiqo();
           return conexion.infoAppCliente(param);
       }

       public List<clsDatosAppCliente> infoConsumoCliente(clParametros param)
       {
           clsConexionAnalizerUbiqo conexion = new clsConexionAnalizerUbiqo();
           return conexion.infoConsumoCliente(param);
       }

       public List<clsDatosAppCliente> infoPedidosClienteBLL(String idCliente)
       {
           clsConexionAnalizerUbiqo conexion = new clsConexionAnalizerUbiqo();
           return conexion.infoPedidosCliente(idCliente);
       }
        public List<clsDat_Pedidos_Actuales> getPedidosAppXidDom(clParametros param)
       {
           clsConexionAnalizerUbiqo conexion = new clsConexionAnalizerUbiqo();
           return conexion.getPedidosAppXidDom(param);
       }

    }
}
