using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GENAnalizerWebETY;
using GEN.DAL.NH;
using GEN.DAL.NH.Connection;
using NHibernate;
using GENAnalizerWebDAL;
using GENAnalizerWebETY.MySQL31;
using GENAnalizerWebETY.Consolidacion;

namespace GENAnalizerWebBLL
{
    public class clConexionBLL
    {
        /// <summary>
        /// OPTIENE LAS GEOCERCAS DE UN SERVIDOR 
        /// </summary>
        /// <param name="sqldir"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<clGeocercas> getGeocercasBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.Geocercas(sqldir,id);
        }
        public clsRespuesta userLoginBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.userLogin(sqldir, id);
        }
        public List<clsNotas_con> getNotasBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getNotas(sqldir,id);
        }
        public List<clsNotas_con> getNotasCarbBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getNotasCarb(sqldir, id);
        }
        public List<clsNotas_con> getNotasCteBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getNotascte(sqldir, id);
        }
        public List<clsLiquida> getLiquidasBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getLiquidas(sqldir, id);
        }
        public List<clsLiquida> geUltimaFechaCopiadoBLL(clsSQLDirectosService sqldir, clParametros id)
       {
           clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
           return conexion.geUltimaFechaCopiado(sqldir, id);
       }
        public List<clsColoniaGeo> getColoniaBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getColonia(sqldir, id);
        }
        public List<clsColoniaGeo> getEstadosIndexBLL(clsSQLDirectosService sqldir, clParametros id)
       {
           clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
           return conexion.getEstadosIndex(sqldir, id);
       }
        public String saveFreePoligonBLL(clsSQLDirectosService sqldir, clGeocercas poligono)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.saveFreePoligon(sqldir, poligono);
        }
        public List<clGeocercas> getPoligonosLibresBLL(clsSQLDirectosService sqldir, clGeocercas id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getPoligonosLibres(sqldir, id);
        }
        public String deleteFreePoligonBLL(clsSQLDirectosService sqldir, clGeocercas poligono)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.deleteFreePoligon(sqldir, poligono);
        }
        public List<clsColoniaGeo> getMunicipiosBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getMunicipios(sqldir, id);
        }

        public List<clsColoniaGeo> todasLasColoniasBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.todasLasColonias(sqldir, id);

        }
        public List<clsColoniaGeo> getColoniaXmunBLL(clsSQLDirectosService sqldir, clsColoniaGeo col)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getColoniaXmun(sqldir, col);
        }
        public List<clsUsuarios> getUsrsBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getUsrs(sqldir,id);
        }
        public List<clsUsuarios> getUsrsLoginBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getUsrsLogin(sqldir, id);
        }
        public List<clsUsuarios> getUsrsLoginGrfBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getUsrsLoginGfr(sqldir, id);
        }
        public String userLoginAltaBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.userLoginAlta(sqldir, id);

        }
        public String actualizarBajaUserBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.actualizarBajaUser(sqldir, id);
        }
        public List<clsPedidos> getPedidosBLL(clsSQLDirectosService sqldir, clParametros id, List<GEN.ETY.clsRutaModel> listaRutas)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getPedidos(sqldir, id, listaRutas);
        }
        public List<GEN.ETY.clsRutaModel> getRutasByCiaPla(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            return conexion.getRutasByCiaPla(sqldir, id);
        }

        public void ingresoModuloBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            conexion.ingresoModulo(sqldir, id);
        }

        public List<clsIngresosModulos> getIngrModBLL(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            //return conexion.getIngrMod(sqldir, id);

            return conexion.getIngrMod(sqldir, id);

        }
        public String enviarCorreo(String asunto, List<String> correos, String cuerpo, List<String> copias, String msgRespuesta)
        {

            try
            {
                clsSendMail correo = new clsSendMail();
                return correo.EnvioDeEmail(asunto, correos, cuerpo, copias, msgRespuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<clsInv> getLecturaAlmacenesBLL(clsSQLDirectosService sqldir)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            //return conexion.getIngrMod(sqldir, id);

            return conexion.getLecturaAlmacenes(sqldir);

        }
        public List<clsLec_med> getHistMediciones(clsSQLDirectosService sqldir, clParametros id)
        {
            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            //return conexion.getIngrMod(sqldir, id);

            return conexion.getHistMediciones(sqldir,  id);
        }







    }
}
