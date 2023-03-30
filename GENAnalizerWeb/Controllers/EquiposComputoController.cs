using GENAnalizerWebBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GENAnalizerWeb.Controllers
{
    public class EquiposComputoController : Controller
    {

        public ActionResult EquiposComputo()
        {           
            return View();
        }
        //
        // GET: /EquiposComputo/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /EquiposComputo/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /EquiposComputo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EquiposComputo/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EquiposComputo/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /EquiposComputo/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EquiposComputo/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /EquiposComputo/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region [Metodos]
        [HttpGet]
        public object GetEquipo(String id)
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

            ip = context.Request.ServerVariables["REMOTE_ADDR"];
            return Json(conexion31.GetEpoCom(ip), JsonRequestBehavior.AllowGet);
           




        }
        #endregion
    }
}
