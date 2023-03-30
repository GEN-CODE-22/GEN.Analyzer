using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using GENAnalizerWebDAL;

using GEN.DAL.NH;
using GEN.DAL.NH.Connection;
using NHibernate;



using GENAnalizerWebETY;


namespace program
{
    class Program
    {
        static void Main(string[] args)
        {

           // UnitOfWorkNH u = new UnitOfWorkNH("DSN=Nietocde;UID=sicogas;PWD=imponente;");
           // ISession s = u._sessionFactory.OpenSession();
           // clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
           // List<clGeocercas> li = new List<clGeocercas>();
           // IList il = sqldir.GetDataFromSicoBySQL("select * from geocercas");
           // DataTable dt = (DataTable)il[0];
           //string  JSONresult = JsonConvert.SerializeObject(dt);
           //li = JsonConvert.DeserializeObject<List<clGeocercas>>(JSONresult);

             UnitOfWorkNH u = new UnitOfWorkNH("DSN=consolidacion;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);

            clConexionAnalizerDAL conexion = new clConexionAnalizerDAL();
            clParametros parametros = new clParametros();
            parametros.paramSrv = "'queretar'";
            parametros.fechaI =  new DateTime(2019,07,01);
            parametros.fechaF = new DateTime(2019,07,02);
            //conexion.getPedidos(sqldir,parametros);
            
            
            Console.Read();

        }
    }
}
