using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENAnalizerWebETY.Gerenrete.ETY;
using GENAnalizerWebETY;
using GENAnalizerWebDAL;
using GEN.DAL.NH.Connection;
using GEN.DAL.NH;
using NHibernate;

namespace GENAnalizerWebBLL
{
   public  class clsGerentesBLL
    {
       public List<clsCuentasXCobrar> getVtaNtaBLL(clsSQLDirectosService sqldir, clParametros param)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.getVtaNtaDAL(sqldir, param);


       }
       public List<clsMovAnt> getMovAntBLL(clsSQLDirectosService sqldir, clParametros param)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.getMovAntDAL(sqldir, param);
       }

       public Object[] GetreportesEstadosBLL(ISession s)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.GetreportesEstadosDAL(s);

       }
       public List<clsPedidos> pedPenXRutBLL(clsSQLDirectosService sqldir, clParametros param)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.pedPenXRut(sqldir, param);
       }

       public List<clsNotasVta> getNotas(clsSQLDirectosService sqldir, clParametros id)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.getNotas(sqldir, id);
       }
       public String getDepBanBLL(clsSQLDirectosService sqldir, clParametros id)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.getDepBan(sqldir,id);
       }
       public String CobranzaCreditoNtasCred_Acomulado(clsSQLDirectosService sqldir, clParametros id)
       {
           clsGerentesDAL conexion = new clsGerentesDAL();
           return conexion.CobranzaCreditoNtasCred_Acomulado(sqldir, id);
       }

        
    }
}
