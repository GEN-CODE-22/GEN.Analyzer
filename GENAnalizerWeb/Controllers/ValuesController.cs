using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services;

using GENAnalizerWebBLL;
using GENAnalizerWebETY.MySQL31;

namespace GENAnalizerWeb.Controllers
{
    public class ValuesController : ApiController
    {
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}


        #region [EquiposComputo]
        
        [HttpGet]
        public String existEquipo(string id)
        {
            clsConexionMySQL31BLL conexion31 = new clsConexionMySQL31BLL();
           // obteniendo ip cliente 
            String ip = String.Empty;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress)) 
               {
                    string[] addresses = ipAddress.Split(','); 
                    if (addresses.Length != 0) 
                    {
                        ip = addresses[0]; 
                    }
               }

             ip= context.Request.ServerVariables["REMOTE_ADDR"];
             clsEquipoComputo eq=conexion31.GetEpoCom(ip);
             if (!string.IsNullOrWhiteSpace(eq.ip_pc))
             {
                 return "SI";
             }
            else
             {
                 return "NO";
             }


           
        }


        


        #endregion
    }
}