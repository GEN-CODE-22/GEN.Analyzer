﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GENAnalizerWebETY;
using GENAnalizerWebBLL;
using GENAnalizerWebDAL;

using GEN.DAL.NH;
using GEN.DAL.NH.Connection;
using NHibernate;

using System.Configuration;
using Newtonsoft.Json;
using System.Text;
using GEN.ETY.Filter;
using GEN.BLL.NH.Classes.Cartera;
using GEN.DAL.NH.CarteraService;
using System.Runtime.Caching;
using GENAnalizerWebETY.MySQL31;

namespace GENAnalizerWeb.Controllers
{
    public class HomeController : Controller
    {
        #region[--ACCION RESULTS--]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MapaGeneral()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();

            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Actividad Pedidos";
            conexion.ingresoModuloBLL(sqldir, param);
            return View();
        }
        public ActionResult Impresion()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();
            return View();
        }
        public ActionResult Medidores()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();
            return View();
        }
        public ActionResult Negocios()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            return View();
        }
        public ActionResult Analizer_app()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();

            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Actividad APP";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }

        public ActionResult Tiempos()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.pla = GetSesPlas();
            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Tiempos";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }
        public ActionResult Gerentes()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            ViewBag.Pwd = GetSesPwd();

            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Gerentes";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }

        public ActionResult PagosQR()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();
            return View();
        }
        public ActionResult CreditoyCobranza()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            ViewBag.Rol = GetSesRol();
            ViewBag.Pwd = GetSesPwd();
            

            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "CreditoCobranza";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }

        public ActionResult Clientes()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();

            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Clientes";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }
        public ActionResult logeos()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();

            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Logeos";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }

        public ActionResult Estaciones()
        {
            ViewBag.Srv = GetSesServ();
            ViewBag.Usr = GetSesUrs();
            //ViewBag.Rol = GetSesRol();
            //ViewBag.cia = GetSesCia();
            ViewBag.pla = GetSesPlas();


            // registar el ingreso al modulo
            UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clConexionBLL conexion = new clConexionBLL();
            clParametros param = new clParametros();
            param.paramSrv = ViewBag.Srv;
            param.paramUsr = ViewBag.Usr;
            param.paramString1 = "Actividad Estaciones";
            conexion.ingresoModuloBLL(sqldir, param);

            return View();
        }
        #endregion


        #region[--METODOS--]

        [HttpPost]
        public ActionResult getGeocercas(clParametros id)
        {
            clConexionBLL connector = new clConexionBLL();
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                //UnitOfWorkNH u = new UnitOfWorkNH("DSN=Nietocde;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
               
                return Json(conexion.getGeocercasBLL(sqldir, id));

            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }

        [HttpPost]
        public ActionResult userLogin(clParametros id)
        {           
            try
            {
                String result = "";
                clsRespuesta respuesta= new clsRespuesta();
                UnitOfWorkNH u;
                List<clsUsuariosAnr> lstUsrAnr = new List<clsUsuariosAnr>();
                clsSQLDirectosService sqldir = null ;
                clConexionBLL conexion = new clConexionBLL();
                ISession s;
                //if (id.paramString1.Equals("Gerente"))
                //{
                u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                   //u  = new UnitOfWorkNH("DSN="+id.paramSrv.Trim()+";UID=sicogas;PWD=imponente;");
                   s = u._sessionFactory.OpenSession();
                   sqldir = new clsSQLDirectosService(s);
                   conexion = new clConexionBLL();

                   respuesta = conexion.userLoginBLL(sqldir, id);
                   
                   if (!respuesta.iconMessage.Equals("success"))
                       return  Json(respuesta);


                   if (id.paramSrv.Equals("Celaya"))
                   {
                      
                   }

                   //lstUsrAnr.Add( conexion.userLoginBLL(sqldir, id));
                   //if (lstUsrAnr.Count>0)
                   //{
                   //    lstUsrAnr[0].srv_usr=id.paramSrv.Trim(); //serv.Split(',')[0].Trim();
                   //    lstUsrAnr[0].rol_usr="Gerente";
                   //}
                   
                //}
                //else
                //{
                //    clsConexionMySQL31BLL conexion31 = new clsConexionMySQL31BLL();
                //    clsUsuariosAnr usrAnr = new clsUsuariosAnr();
                //    usrAnr.pwd_usr = id.paramPwd;
                //    usrAnr.usr_usr = id.paramUsr;
                   
                //    lstUsrAnr = conexion31.getUsrAnr(usrAnr);
                //}
               
               
               
               
                //if (!serv.StartsWith("0"))
                
               
                    Session["DSN"] = id.paramSrv; //serv.Split(',')[0].Trim();
                    Session["rol"] = ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).rol_usr.Trim();//serv.Split(',')[1].Trim();
                    Session["usr"] = ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).nom_usr;//lstUsrAnr[0].usr_usr;//id.paramUsr;
                    Session["pwd"] = ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).pwd_usr;//id.paramPwd;
                    Session["pla_anr"] = ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).pla_usr;

                    // crear las cookies
                    //HttpCookie servCookie = new HttpCookie("servCookie", serv.Split(',')[0]);
                    HttpCookie servCookie = new HttpCookie("servCookie", id.paramSrv);
                    //servCookie.Expires = DateTime.Now.AddMinutes(360.0);
                    ControllerContext.HttpContext.Response.SetCookie(servCookie);

                    //HttpCookie usrCookie = new HttpCookie("usrCookie", id.paramUsr);
                    HttpCookie usrCookie = new HttpCookie("usrCookie", ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).nom_usr);
                    //usrCookie.Expires = DateTime.Now.AddMinutes(360.0);
                    ControllerContext.HttpContext.Response.SetCookie(usrCookie);

                    //HttpCookie rolCookie = new HttpCookie("rolCookie", serv.Split(',')[1]);
                    HttpCookie rolCookie = new HttpCookie("rolCookie", ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).rol_usr);
                    //rolCookie.Expires = DateTime.Now.AddMinutes(360.0);
                    ControllerContext.HttpContext.Response.SetCookie(rolCookie);

                    //HttpCookie pwdCookie = new HttpCookie("pwdCookie",id.paramPwd);
                    HttpCookie pwdCookie = new HttpCookie("pwdCookie", ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).pwd_usr);
                    //rolCookie.Expires = DateTime.Now.AddMinutes(360.0);
                    ControllerContext.HttpContext.Response.SetCookie(pwdCookie);

                    HttpCookie plaCookie = new HttpCookie("pla_anrCookie", ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).pla_usr);
                    //rolCookie.Expires = DateTime.Now.AddMinutes(360.0);
                    ControllerContext.HttpContext.Response.SetCookie(pwdCookie);
                   
                    // registrar el logeo;
                    clParametros param = new clParametros();
                    param.paramSrv = id.paramSrv;
                    param.paramUsr = ((clsUsuarios)((List<object>)respuesta.ObjetReturn)[0]).nom_usr;
                    param.paramString1 = "Login";


                    u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                    s = u._sessionFactory.OpenSession();
                    sqldir = new clsSQLDirectosService(s);
                    conexion.ingresoModuloBLL(sqldir, param);
                    s.Dispose();

                    /*using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LoginAnlizer.txt", true))
                    {
                        file.WriteLine(string.Format("Ingreso de sesion: fecha  {0}  usuario {1} servidor {2}", DateTime.Now, id.paramUsr, serv));
                    }
                     */
                    
                

                return Json(respuesta); 


            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LoginAnlizer.txt", true))
                    {
                        file.WriteLine(string.Format(ex.ToString()));
                    }
                     
                throw new Exception("error", ex);
            }
            finally
            {
               
            }
        }
        [HttpPost]
        public ActionResult setCiaPla(String id)
        {
            try
            {

                Session["cia"] = id.Split(',')[0].Trim(); 
                Session["pla"] = id.Split(',')[1].Trim();
                  

                // crear las cookies de compañia y planta

                HttpCookie ciaCookie = new HttpCookie("ciaCookie", id.Split(',')[0].Trim());
                ControllerContext.HttpContext.Response.SetCookie(ciaCookie);

                HttpCookie plaCookie = new HttpCookie("plaCookie", id.Split(',')[1].Trim());
                ControllerContext.HttpContext.Response.SetCookie(plaCookie);

                    



                return Json("OK");
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LoginAnlizer.txt", true))
                {
                    file.WriteLine(string.Format(ex.ToString()));
                }

                throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult uptUserLogin(clsUsuariosAnr usr)
        {
            try
            {
               
                clsConexionMySQL31BLL conexion31 = new clsConexionMySQL31BLL();
                clsUsuariosAnr UsrAnr = new clsUsuariosAnr();
                UsrAnr = conexion31.uptUsrAnr(usr);


                return Json(UsrAnr);
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LoginAnlizer.txt", true))
                {
                    file.WriteLine(string.Format(ex.ToString()));
                }

                throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getNotas(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();              
                return Json(conexion.getNotasBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar las notas de: {2}{0}{1}", DateTime.Now, ex,id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
               // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getNotasCarb(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getNotasCarbBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar las notas de carburacion de: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getNotasCte(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getNotasCteBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar las notas de: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getLiquidas(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getLiquidasBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar las Liquidas de: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getUltimaDiaCopiado(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.geUltimaFechaCopiadoBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar el ultimo dia copiado de: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult infoApp(clParametros id)
        {
            try
            {
               
                clsConexionUbicoBLL conexion = new clsConexionUbicoBLL();
                return Json(conexion.infoAppCliente(id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult infoConsumoCte(clParametros id)
        {
            try
            {

                clsConexionUbicoBLL conexion = new clsConexionUbicoBLL();
                return Json(conexion.infoConsumoCliente(id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
    
        public ActionResult infoPedidosClientes(clParametros id)
        {
            try
            {
                
                clsConexionUbicoBLL conexion = new clsConexionUbicoBLL();
                return Json(conexion.infoPedidosClienteBLL(id.paramString1));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getColonias(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getColoniaBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        //obtiene los municipios
        [HttpPost]
        public ActionResult getMunicipios(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getMunicipiosBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        public ActionResult getEstadosIndex(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getEstadosIndexBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        // guarda un poligono libre en la base de datos 
        [HttpPost]
        public ActionResult savePoligon(clGeocercas id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.saveFreePoligonBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        // obtiene los poligonos libres dibujados por los usuarios
        [HttpPost]
        public ActionResult getPilogonosLibres(clGeocercas id)
        {
            clConexionBLL connector = new clConexionBLL();
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                //UnitOfWorkNH u = new UnitOfWorkNH("DSN=Nietocde;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();

                return Json(conexion.getPoligonosLibresBLL(sqldir, id));

            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult deletePologonosLibres(clGeocercas id)
        {
            clConexionBLL connector = new clConexionBLL();
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                //UnitOfWorkNH u = new UnitOfWorkNH("DSN=Nietocde;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();

                return Json(conexion.deleteFreePoligonBLL(sqldir, id));

            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }
        //obtiene las colonias por municipio
        public ActionResult getColXMun(clsColoniaGeo id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getColoniaXmunBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\AnlizerErrors.txt", true))
                {
                    file.WriteLine(string.Format("ERROR : Fecha  {0}  Error: {1} Metodo{2}", DateTime.Now, ex.Message, "getColXMun"));
                }
                throw;
            }
        }
        // obtiene un listado de los los usuarios de la base de datos 
        [HttpPost]
        public ActionResult getUsrs(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getUsrsBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\ErrAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar los usuarios: {2}{0}", DateTime.Now, ex));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        // obtiene los inicios de secion de los usuarios 
        [HttpPost]
        public ActionResult getUsrsLogin(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getUsrsLoginBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\ErrAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar los inicios de sesion usuarios: {2}{0}", DateTime.Now, ex));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getUsrsLoginGfr(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getUsrsLoginGrfBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\ErrAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar los inicios de sesion usuarios: {2}{0}", DateTime.Now, ex));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        [HttpPost]
        public ActionResult userLoginAlta(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.userLoginAltaBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\ErrAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al dar de alta un usuario: {2}{0}", DateTime.Now, ex));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult actualizarBajaUser(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.actualizarBajaUserBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\ErrAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado actualizar/eliminar un usuario: {2}{0}", DateTime.Now, ex));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        [HttpPost]
        public ActionResult getPedidos(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = null;
                ISession s = null;
                clsSQLDirectosService sqldir = null;
                List<GEN.ETY.clsRutaModel> li = new List<GEN.ETY.clsRutaModel>();
                 clConexionBLL conexion = new clConexionBLL();
                //obtener rutas por compañia planta
                 u = new UnitOfWorkNH("DSN="+id.paramSrv+";UID=sicogas;PWD=imponente;");
                 s = u._sessionFactory.OpenSession();
                 sqldir = new clsSQLDirectosService(s);
                 id.paramCia = "15";
                 li = conexion.getRutasByCiaPla(sqldir,id);


                 u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                 s = u._sessionFactory.OpenSession();
                 sqldir = new clsSQLDirectosService(s);
               
                return Json(conexion.getPedidosBLL(sqldir, id,li));
                //
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar los pedidos de: {2}{0}{1}", DateTime.Now, ex.Message, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        [HttpPost]
        public ActionResult getIngrMod(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getIngrModBLL( sqldir,  id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al  ingresos de modulo: {2}{0}{1}", DateTime.Now, ex.Message, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        // envia un correo con una solicitud de registro
        [HttpPost]
        public ActionResult emailSolicitud(string id)
        {
            try
            {
                clConexionBLL registros = new clConexionBLL();
                List<string> correos = new List<string>();
                List<string> copias = new List<string>();

                correos.Add("haleman@gasexpressnieto.com.mx");
                StringBuilder CuerpoCorreo = new StringBuilder("");

                string[] valores = id.Split('/');

                // crear el cuerpo del correo
                CuerpoCorreo.Clear();
                CuerpoCorreo.Append(" <center><H1>SOLICITUD DE USUARIO DE PLATAFORMA ANALYZER </H1></center>");
                CuerpoCorreo.Append("<table border=\"1\" style=\"width:100% ;background-color:lightgrey\">");
                CuerpoCorreo.Append("  <tr>");
                CuerpoCorreo.Append("  <th>RUBRO</th>");
                CuerpoCorreo.Append(" <th>VALOR</th>");
                CuerpoCorreo.Append("</tr>");
                CuerpoCorreo.Append("<tr>" + "<td><center>SERVIDOR</center></td><td><center>" + valores[0] + "</center></td>" + "</tr>");
                CuerpoCorreo.Append("<tr>" + "<td><center>USUARIO</center></td><td><center>" + valores[1] + "</center></td>" + "</tr>");
                CuerpoCorreo.Append("<tr>" + "<td><center>CONTRASEÑA</center></td><td><center>" + valores[2] + "</center></td>" + "</tr>");
                CuerpoCorreo.Append("<tr>" + "<td><center>CORREO</center></td><td><center>" + valores[3] + "</center></td>" + "</tr>");
                
                CuerpoCorreo.Append("<tr>" + "<td><center>NOMBRE</center></td><td><center>" + valores[5] + "</center></td>" + "</tr>");
               
                CuerpoCorreo.Append(" </table>");

                return Json(registros.enviarCorreo("SOLICITUD DE USUARIO ANALYZER", correos, CuerpoCorreo.ToString(), copias, "Solicitud enviada con exito, el administrador se pondra en contacto con usted en cuanto su usuario este listo"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult getUbiCtesWhatsApp(clParametros id)
        {
            try
            {

                clsConexionMySQL111BLL conexion = new clsConexionMySQL111BLL();
                return Json(conexion.getUbiCtesWhatsApp(id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al  consultar cliente de whats app: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        [HttpPost]
        public ActionResult getPedCtesWhatsApp(clParametros id)
        {
            try
            {

                clsConexionMySQL111BLL conexion = new clsConexionMySQL111BLL();
                return Json(conexion.getPedCtesWhatsApp(id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al  consultar cliente de whats app: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        [HttpPost]
        public ActionResult getPagosQR(clParametros id)
        {
            try
            {

                clsConexionMySQL111BLL conexion = new clsConexionMySQL111BLL();
                return Json(conexion.getPagosQr(id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al  consultar pagos Qr: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

       

        
        #endregion

        #region [GERENTES]
        // obtiene las lecturas del dia  de los almacenes por servidor 
        [HttpPost]
        public ActionResult getLecturas(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=" + id.paramSrv + ";UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.getLecturaAlmacenesBLL(sqldir));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar lecturas de almacenes: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }


        // Obtiene informacion correspondiente a cuentas por cobrar 
        [HttpPost]
        public ActionResult CxC(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=" + id.paramSrv + ";UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clsGerentesBLL conexion = new clsGerentesBLL();              
                        return Json(conexion.getVtaNtaBLL(sqldir, id));               
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar lecturas de almacenes: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        // Obtiene informacion correspondiente a cuentas por cobrar 
        [HttpPost]
        public ActionResult MovAnt(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=" + id.paramSrv + ";UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clsGerentesBLL conexion = new clsGerentesBLL();
                return Json(conexion.getMovAntBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al consultar lecturas de almacenes: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        // consulta un reporte sobre los pedidos del dia
        [HttpPost]
        public ActionResult tblPed(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=" + id.paramSrv + ";UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
              
                clsGerentesBLL conexion = new clsGerentesBLL();
                return Json(conexion.GetreportesEstadosBLL(s));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al obtener estado de pedidos: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }
        //Optiene los pendientes por ruta 
        [HttpPost]
        public ActionResult pedPenXRut(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=" + id.paramSrv + ";UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);

                clsGerentesBLL conexion = new clsGerentesBLL();
                return Json(conexion.pedPenXRutBLL(sqldir,id));
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al obtener estado de pedidos por ruta: {2}{0}{1}", DateTime.Now, ex, id.paramSrv+" "+id.paramRuta));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        // obtiene las notas para modulo de Histograma
        public ActionResult getNotasHistograma(clParametros id)
        {

            try
            {
            if (id.paramRuta == null)
            {
                DateTime fecha1, fecha2, fechatemp;

                fechatemp = DateTime.ParseExact(id.fecha + "-01 12:00:00", "yyyy-MM-dd HH:mm:ss",
                                       System.Globalization.CultureInfo.InvariantCulture);
                if (id.paramString1.Equals("actual"))
                {
                    fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
                    if (fechatemp.Month == 12)
                    {
                        fecha2 = new DateTime(fechatemp.Year + 1, 1, 1).AddDays(-1);
                    }
                    else
                        fecha2 = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1);
                    id.fechaI = fecha1;
                    // id.fechaF = fecha2;
                    id.fechaF = fecha2;
                }
                else
                {
                    fecha1 = new DateTime(fechatemp.Year - 1, fechatemp.Month, 1);
                    if (fechatemp.Month == 12)
                    {
                        fecha2 = new DateTime(fechatemp.Year, 1, 1).AddDays(-1);
                    }
                    else

                        fecha2 = new DateTime(fechatemp.Year - 1, fechatemp.Month + 1, 1).AddDays(-1);
                    id.fechaI = fecha1;
                    // id.fechaF = fecha2;
                    id.fechaF = fecha2;
                }

            }

            UnitOfWorkNH u = new UnitOfWorkNH("DSN=" + id.paramSrv + ";UID=sicogas;PWD=imponente;");
            ISession s = u._sessionFactory.OpenSession();
            clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
            clsGerentesBLL conexion = new clsGerentesBLL();
            List<clsNotasVta> listnotas = conexion.getNotas(sqldir, id);
            return Json(listnotas);
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }


        public ActionResult Cartera( clParametros id)
        {
            UnitOfWorkNH u;
            ISession s;
            Decimal notasCred = 0;
            Decimal descuento = 0;
            try
            {

                GEN.ETY.Cartera.clsGrupoCartera cartera = new GEN.ETY.Cartera.clsGrupoCartera();
                //agregar cache
                  var cache = MemoryCache.Default;
                  if (cache.Get(id.paramSrv.Trim() + id.fechaI.Year + "_" + id.fechaI.Month) == null)
                   {
                       u = new UnitOfWorkNH("DSN=genctral;UID=sicogas;PWD=imponente;");
                    //u = new UnitOfWorkNH("DSN=genctral;UID=root;PWD=gint230;");
                    s = u._sessionFactory.OpenSession();

                    clsFilter fil = new clsFilter();
                    fil.Server = id.paramSrv.Trim();
                    fil.Anio = id.fechaI.Year;
                    fil.Mes = id.fechaI.Month;
                   

                    clsPanelCobranzaBLL bllPanelCartera = new clsPanelCobranzaBLL();

                    var resFull = bllPanelCartera.grupoCarteraBll(fil, u, s);
                    s.Dispose();

                    // se optienen los depositos bancarios, credito, cobranza directo del servidor de sicogas
                    u = new UnitOfWorkNH("DSN=" + id.paramSrv.Trim() + ";UID=sicogas;PWD=imponente;");
                    s = u._sessionFactory.OpenSession();
                    clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                    clsGerentesBLL conexion = new clsGerentesBLL();


                    // se optienen los depositos bancarios, venta acomulada de sicogas
                    var depBan = conexion.getDepBanBLL(sqldir,id);
                    // se optienen  credito, cobranza directo del servidor de sicogas
                    var cobCredAcom = conexion.CobranzaCreditoNtasCred_Acomulado(sqldir, id);

                    String [] depVta = depBan.ToString().Split(',');
                    String[] credCobrNtasCrd = cobCredAcom.Split('_');
                    notasCred =Decimal.Parse(credCobrNtasCrd[2]);
                    descuento = Decimal.Parse(credCobrNtasCrd[3]);

                    s.Dispose();
                    if (resFull.carteraMes!=null)
                    {
                        resFull.carteraMes.DepositoBancario = Decimal.Parse(depVta[0]);
                        resFull.carteraMes.VentasAcumuladoMes = Decimal.Parse(depVta[1]);
                        resFull.carteraMes.CréditoAcumuladoMes = Decimal.Parse(credCobrNtasCrd[0]);
                        resFull.carteraMes.CobranzaAcumuladoMes = Decimal.Parse(credCobrNtasCrd[1]);

                    }else
                    {
                        resFull.carteraMes = new GEN.ETY.Cartera.clsCart_MesModel();
                        resFull.carteraMes.DepositoBancario = Decimal.Parse(depVta[0]);
                        resFull.carteraMes.VentasAcumuladoMes = Decimal.Parse(depVta[1]);
                        resFull.carteraMes.CréditoAcumuladoMes = Decimal.Parse(credCobrNtasCrd[0]);
                        resFull.carteraMes.CobranzaAcumuladoMes = Decimal.Parse(credCobrNtasCrd[1]);
                    
                    }
               
                    // ordenar datos 
                    resFull.carteraMesUso = resFull.carteraMesUso.OrderBy(x => x.Stotal_cmuso).ToList();
                    resFull.carteraUsosSinMovimiento = resFull.carteraUsosSinMovimiento.OrderBy(x => x.Stotal_cmusmov).ToList();

                        //
                        var cachePolicty = new CacheItemPolicy();
                        cachePolicty.AbsoluteExpiration = DateTime.Now.AddSeconds(10800);


                        cache.Add(id.paramSrv.Trim() + id.fechaI.Year + "_" + id.fechaI.Month, resFull, cachePolicty);
                        cartera = resFull;
                  
                }
                else
                {
                    // se retorna la infomacion guardada en la cache a excepcion de la informacion consultada de sicogas 
                    var resFull = (GEN.ETY.Cartera.clsGrupoCartera)cache.Get(id.paramSrv.Trim() + id.fechaI.Year + "_" + id.fechaI.Month);

                     // se optienen los depositos bancarios, credito, cobranza directo del servidor de sicogas
                     u = new UnitOfWorkNH("DSN=" + id.paramSrv.Trim() + ";UID=sicogas;PWD=imponente;");
                     s = u._sessionFactory.OpenSession();
                     clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                     clsGerentesBLL conexion = new clsGerentesBLL();


                     // se optienen los depositos bancarios, venta acomulada de sicogas
                     var depBan = conexion.getDepBanBLL(sqldir,id);
                     // se optienen  credito, cobranza, ntas de credito directo del servidor de sicogas
                     var cobCredAcom = conexion.CobranzaCreditoNtasCred_Acomulado(sqldir, id);

                     String[] depVta = depBan.ToString().Split(',');
                     String[] credCobrNtasCrd = cobCredAcom.Split('_');
                     notasCred = Decimal.Parse(credCobrNtasCrd[2]);
                     descuento = Decimal.Parse(credCobrNtasCrd[3]);
                     s.Dispose();
                     if (resFull.carteraMes != null)
                     {
                         resFull.carteraMes.DepositoBancario = Decimal.Parse(depVta[0]);
                         resFull.carteraMes.VentasAcumuladoMes = Decimal.Parse(depVta[1]);
                         resFull.carteraMes.CréditoAcumuladoMes = Decimal.Parse(credCobrNtasCrd[0]);
                         resFull.carteraMes.CobranzaAcumuladoMes = Decimal.Parse(credCobrNtasCrd[1]);

                     }
                     else
                     {
                         resFull.carteraMes = new GEN.ETY.Cartera.clsCart_MesModel();
                         resFull.carteraMes.DepositoBancario = Decimal.Parse(depVta[0]);
                         resFull.carteraMes.VentasAcumuladoMes = Decimal.Parse(depVta[1]);
                         resFull.carteraMes.CréditoAcumuladoMes = Decimal.Parse(credCobrNtasCrd[0]);
                         resFull.carteraMes.CobranzaAcumuladoMes = Decimal.Parse(credCobrNtasCrd[1]);

                     }

                     cartera = resFull;
                }

                  List<Object> final = new List<object>();
                  final.Add(cartera);
                  final.Add(notasCred);
                  final.Add(descuento);
                  return Json(final);
            }
            catch (Exception ex)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Generado al obtener  la cartera: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(ex.Message);
            }
           
           
        }

        #endregion 

        /// <summary>
        /// metodo especial para el requerimiento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult todoslosMunicipios(clParametros id)
        {
            try
            {
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                ISession s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                return Json(conexion.todasLasColoniasBLL(sqldir, id));
            }
            catch (Exception ex)
            {
                throw new Exception("error", ex);
            }
        }

        [HttpPost]
        public ActionResult getHistMediciones(clParametros id)
        {
            ISession s = null;
            try
            {
                List<Object> litsObj = new List<Object>();
                UnitOfWorkNH u = new UnitOfWorkNH("DSN=Consolid;UID=sicogas;PWD=imponente;");
                 s = u._sessionFactory.OpenSession();
                clsSQLDirectosService sqldir = new clsSQLDirectosService(s);
                clConexionBLL conexion = new clConexionBLL();
                clsConexionUbicoBLL conexionUb = new clsConexionUbicoBLL();
                litsObj.Add(conexion.getHistMediciones(sqldir, id));
                litsObj.Add(conexionUb.getPedidosAppXidDom(id));
                s.Dispose();

                return Json(litsObj);
            }
            catch (Exception ex)
            {
                if (s!=null)
                {
                    s.Dispose();
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\LogAnr.txt", true))
                {
                    file.WriteLine(string.Format("Error al consultar mediciones historicas: {2}{0}{1}", DateTime.Now, ex, id.paramSrv));
                }
                throw new Exception(string.Format("respuesta: {0}{1}", ex.Message, DateTime.Now));
                // throw new Exception("error", ex);
            }
        }

        #region [getCooKies]
        public string GetSesUrs()
        {
            string strUsr = string.Empty;
            try
            {
                strUsr = Session["usr"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["usrCookie"];
                if (c != null)
                {
                    strUsr = c.Value;
                }
            }
            return strUsr;
        }

        public string GetSesServ()
        {
            string strSrv = string.Empty;
            try
            {
                strSrv = Session["DSN"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["servCookie"];
                if (c != null)
                {
                    strSrv = c.Value;
                }
            }
            return strSrv;
        }

        public string GetSesRol()
        {
            string strSrv = string.Empty;
            try
            {
                strSrv = Session["rol"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["rolCookie"];
                if (c != null)
                {
                    strSrv = c.Value;
                }
            }
            return strSrv;
        }
        public string GetSesPwd()
        {
            string strPwd = string.Empty;
            try
            {
                strPwd = Session["pwd"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["pwdCookie"];
                if (c != null)
                {
                    strPwd = c.Value;
                }
            }
            return strPwd;
        }

        

        public string GetSesCia()
        {
            string strPwd = string.Empty;
            try
            {
                strPwd = Session["cia"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["ciaCookie"];
                if (c != null)
                {
                    strPwd = c.Value;
                }
            }
            return strPwd;
        }
        public string GetSesPla()
        {
            string strPwd = string.Empty;
            try
            {
                strPwd = Session["pla"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["plaCookie"];
                if (c != null)
                {
                    strPwd = c.Value;
                }
            }
            return strPwd;
        }

         public string GetSesPlas()
        {
            string strPwd = string.Empty;
            try
            {
                strPwd = Session["pla_anr"].ToString();
            }
            catch (Exception ex)
            {
                var c = ControllerContext.HttpContext.Request.Cookies["pla_anrCookie"];
                if (c != null)
                {
                    strPwd = c.Value;
                }
            }
            return strPwd;
        }
        #endregion

        #region [EquiposComputo]



        #endregion


        /// <summary>
        /// Con este método se logra que cuándo por medio de un AJAX se haga una petición y la vuelta sea tipo JSON
        /// podamos traer la máxima cantidad de datos sin restricción. 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="contentType"></param>
        /// <param name="contentEncoding"></param>
        /// <param name="behavior"></param>
        /// <returns></returns>
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }
    }
}
