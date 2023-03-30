using GENAnalizerWebDAL;
using GENAnalizerWebETY.MySQL31;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENAnalizerWebBLL
{
   public class clsConexionMySQL31BLL
    {
       public List<clsUsuariosAnr> getUsrAnr(clsUsuariosAnr usr)
       {
           clsConexionMySQL31 conexion = new clsConexionMySQL31();
           return conexion.getUsrAnr(usr);
       }
       public clsUsuariosAnr uptUsrAnr(clsUsuariosAnr usr)
       {
           clsConexionMySQL31 conexion = new clsConexionMySQL31();
           return conexion.uptUsrAnr(usr);
       }
       public clsEquipoComputo GetEpoCom(string ip)
       {
           clsConexionMySQL31 conexion = new clsConexionMySQL31();
           return conexion.GetEpoCom(ip);
       }



    }
}
