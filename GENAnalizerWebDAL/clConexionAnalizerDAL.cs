using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using Newtonsoft.Json;
using NHibernate;
using GENAnalizerWebETY;
using GEN.DAL.NH.Connection;
using GEN.DAL.NH;
using GENAnalizerWebETY.MySQL31;
using GENAnalizerWebETY.Consolidacion;
using GEN.ETY.Filter;


namespace GENAnalizerWebDAL
{
   public class clConexionAnalizerDAL
    {
       // optiene las geocercas de un o de los servidores 
       public List<clGeocercas> Geocercas(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               IList il;
               List<clGeocercas> li = new List<clGeocercas>();
               if (id.paramSrv.Trim().Equals("Admin"))
                   il = sqldir.GetDataFromSicoBySQL("select * from geocercas;");
               else
                   il = sqldir.GetDataFromSicoBySQL("select * from geocercas where srv_geo='" + id.paramSrv + "';");              
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clGeocercas>>(JSONresult);
               li = li.OrderBy(o => o.srv_geo).ToList();
               return li;


           }
           catch (Exception)
           {
               
               throw;
           }
          
       }
       //verifica que el usuario exista y permite el acceso
       public clsRespuesta userLogin(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               clsUsuariosAnr usr = new clsUsuariosAnr();

               
                usr.usr_usr = id.paramUsr.Trim();
                usr.pwd_usr = EncriptaPassLeve(id.paramPwd.Trim());

                clsUsuarios user_anr = new clsUsuarios();
                List<clsUsuarios> li_usrAnr = new List<clsUsuarios>();
                List<GEN.ETY.clsUsuarioModel> li = new List<GEN.ETY.clsUsuarioModel>();
                List<GEN.ETY.clsPlantaModel> liPla = new List<GEN.ETY.clsPlantaModel>();
                GEN.ETY.clsUsuarioModel user = new GEN.ETY.clsUsuarioModel();
                clsUsuarios user_ = new clsUsuarios();
                List<Object> objsReturn = new List<object>();
                clsRespuesta respueta = new clsRespuesta();





               //Consultar Listado de plantas
                UnitOfWorkNH u_;
                clsSQLDirectosService sqldir_ = null;
                ISession s_;
                u_ = new UnitOfWorkNH("DSN="+id.paramSrv.Trim()+";UID=sicogas;PWD=imponente;");
                s_ = u_._sessionFactory.OpenSession();
                sqldir_ = new clsSQLDirectosService(s_);
                clsPlantaService plantas = new clsPlantaService(sqldir_.Session);
                liPla = plantas.List(new clsFilter() { Cia="15"});

                if (id.paramSrv.Equals("Celaya"))
                {
                    liPla.RemoveAt(0);
                }



                if (id.paramUsr.Trim().ToLower().Equals("administrador") && id.paramPwd.Trim().ToLower().Equals("admingroup")  )
                {
                    IList ilPla = null;
                    string JSONresultPla = string.Empty;
                    DataTable dtPla = null;

                       // user_anr.id_usr =
                       //user_anr.usr_usr =
                       //user_anr.pwd_usr =
                       user_anr.srv_usr =id.paramSrv.Trim();
                       //user_anr.pla_usr =
                       user_anr.nom_usr = "Administrador";
                       //user_anr.fecha_secion =
                       //user_anr.hora_secion =
                       //user_anr.logeos =
                       user_anr.rol_usr = "Administrador";


                   // 
                    //user.Nom_ucve = "Administrador";
                    //user.Tip_ucve = "Administrador";
                    //user.Cia_ucve = "";
                    //user.Lada_ucve = "";
                    //user.Pas_ucve = "admingroup";
                    //user.Pla_ucve = "";
                    //user.Tpu_ucve = "Administrador";
                    //user.Usr_ucve = "Administrador";

                    //objsReturn.Add(user);
                    //objsReturn.Add(liPla);
                    //respueta.ObjetReturn = objsReturn;
                    //respueta.iconMessage = "success";
                    //return respueta;
                       for (int i = 0; i < liPla.Count; i++)
                       {
                           user_anr.pla_usr += liPla[i].Cve_pla.Trim()+",";
                       }
                    
                }

                String query = "select * from usr_anr where usr_usr='" + id.paramUsr.Trim() + "' and pwd_usr='" + id.paramPwd.Trim() + "' and srv_usr='"+id.paramSrv.Trim()+"'";
                IList il = sqldir.GetDataFromSicoBySQL(query);
                //IList il = sqldir.GetDataFromSicoBySQL("select * from usr_cve where usr_ucve='" + id.paramUsr.Trim() + "' and pas_ucve='" + EncriptaPassLeve(id.paramPwd.Trim()) + "'");
                DataTable dt = (DataTable)il[0];

                       string JSONresult;
                       if (dt != null && dt.Rows.Count > 0)
                       {                          
                           JSONresult = JsonConvert.SerializeObject(dt);
                           li_usrAnr = JsonConvert.DeserializeObject<List<clsUsuarios>>(JSONresult);
                           if (li_usrAnr.Count == 1)
                           {
                               user_anr = li_usrAnr[0];
                               //IList ilPla = null;
                               //string JSONresultPla = string.Empty;
                               //DataTable dtPla = null;
                               //if (id.paramSrv.Equals("Celaya"))
                               //    liPla = plantas.List(new clsFilter { Cia="15"});
                               //else
                               //    liPla = plantas.List(new clsFilter());
                               
                               
                               //if(!li[0].Tpu_ucve.Equals("GG"))
                               //{
                               //    liPla = liPla.Where(x => x.Cve_pla == user.Pla_ucve && x.Cia_pla.Cve_cia == user.Cia_ucve).ToList();
                               //}
                               

                           }
                        
                       }

                       objsReturn.Add(user_anr);
                       objsReturn.Add(liPla);
                       respueta.ObjetReturn = objsReturn;
                       respueta.iconMessage = "success";
                       return respueta;
                       respueta.iconMessage = "info";
                       respueta.MesajeReturn="Usuario no encontrado";

              
                   return respueta ;
               
              
              
           }
           catch (Exception)
           {

               throw;
           }

       }

       /// <summary>
       /// Método para encriptar un password de forma sencilla
       /// </summary>
       /// <param name="textoPlano">string: texto plano que se va a encriptar</param>
       /// <returns>string: El password encriptado</returns>
       public static string EncriptaPassLeve(string textoPlano)
       {
           string pwdEncriptado = "";

           for (int intCicloPalabra = 0; intCicloPalabra < textoPlano.Length; intCicloPalabra++)
           {
               int letraConvertida = (int)textoPlano.ToCharArray(intCicloPalabra, 1)[0];
               if (letraConvertida > 0 && letraConvertida < 128)
               {
                   letraConvertida += 128;
               }

               char letraResultado = (char)letraConvertida;
               pwdEncriptado += letraResultado;

           }

           return pwdEncriptado;
       }
       // consulta las notas de venta de uno o varios servidores 
       public List<clsNotas_con> getNotas(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
             //Validar rango de fechas para optimizar las consultas.
               String query = "";
               if (id.fechaI.Year==id.fechaF.Year)
               {
               // Consulta sobre el mismo año
               query = "select *, WEEKDAY(fep_nvta) dia_semana, WEEKDAY(fes_nvta) dia_semana_sur from notas_"+id.fechaI.Year.ToString()+"c where srv_nvta in (" + id.paramSrv + ") and fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and tiprut_nvta <> 'B'";

               }
               else
               {

                 // Validar si es de dos años difertes realizar una union 
                   if (id.fechaF.Year-id.fechaI.Year==1)
                   {
                       query = "select *, WEEKDAY(fep_nvta) dia_semana, WEEKDAY(fes_nvta) dia_semana_sur from notas_"+id.fechaI.Year.ToString()+"c where srv_nvta in (" + id.paramSrv + ") and fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and tiprut_nvta <> 'B'"+
                               " union select *, WEEKDAY(fep_nvta) dia_semana, WEEKDAY(fes_nvta) dia_semana_sur from notas_" + id.fechaF.Year.ToString() + "c where srv_nvta in (" + id.paramSrv + ") and fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and tiprut_nvta <> 'B'";
                   }
                   else
                   {
                       //Si son mas de dos años consultar con la vista 
                       query = "select *, WEEKDAY(fep_nvta) dia_semana, WEEKDAY(fes_nvta) dia_semana_sur from notas_con where srv_nvta in (" + id.paramSrv + ") and fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and tiprut_nvta <> 'B'";                  
                   }
                
               }
               
               



               List<clsNotas_con> li = new List<clsNotas_con>();
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               string JSONresult;
               if (il!=null)
               {

                   JSONresult = JsonConvert.SerializeObject(dt);
                   li = JsonConvert.DeserializeObject<List<clsNotas_con>>(JSONresult);

                   //li = (from dr in dt.AsEnumerable()
                   //      select new clsNotas_con
                   //      {
                   //          srv_nvta = dr[0].ToString(),
                   //          fol_nvta = dr[1].ToString(),
                   //          ffis_nvta = dr[2].ToString(),
                   //          cia_nvta = dr[3].ToString(),
                   //          pla_nvta = dr[4].ToString(),
                   //          ped_nvta = dr[5].ToString(),
                   //          numcte_nvta = dr[6].ToString(),
                   //          numtqe_nvta = dr[7].ToString(),
                   //          ruta_nvta = dr[8].ToString(),
                   //          tip_nvta = dr[9].ToString(),
                   //          tiprut_nvta = dr[10].ToString(),
                   //          uso_nvta = dr[11].ToString(),
                   //          fep_nvta = dr[12].ToString(),
                   //          fes_nvta = dr[13].ToString(),
                   //          fliq_nvta = dr[14].ToString(),
                   //          edo_nvta = dr[15].ToString(),
                   //          tpa_nvta = dr[16].ToString(),
                   //          nept_nvta = dr[17].ToString(),
                   //          tlts_nvta = dr[18].ToString(),
                   //          tprd_nvta = dr[19].ToString(),
                   //          pru_nvta = dr[20].ToString(),
                   //          impt_nvta = dr[21].ToString(),
                   //          tpdo_nvta = dr[22].ToString(),
                   //          asiste_nvta = dr[23].ToString(),
                   //          impasi_nvta = dr[24].ToString(),
                   //          gps_nvta = dr[25].ToString(),
                   //          gpe_nvta = dr[26].ToString(),
                   //          eco_nvta = dr[27].ToString(),
                   //          fhs_nvta = dr[28].ToString(),
                   //          chf_nvta = dr[29].ToString(),
                   //          dia_semana = dr[30].ToString(),
                   //          dia_semana_sur = dr[31].ToString()
                   //      }).ToList();  
               }
               else
               {
                   li = new List<clsNotas_con>();
               }


               return li;


           }
           catch (Exception ex)
           {
               List<clsNotas_con> li = new List<clsNotas_con>();
               li = new List<clsNotas_con>();
               return li;
           }

       }
       // consulta las notas de venta de uno o varios servidores 
       public List<clsNotas_con> getNotasCarb(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsNotas_con> li = new List<clsNotas_con>();
               String query = "select *, WEEKDAY(fep_nvta) dia_semana, WEEKDAY(fes_nvta) dia_semana_sur from notas_con where srv_nvta in ('" + id.paramSrv.ToLower() + "') and fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and tiprut_nvta = 'B'";
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               String JSONresult;
               if (il != null)
               {

                   JSONresult = JsonConvert.SerializeObject(dt);
                   li = JsonConvert.DeserializeObject<List<clsNotas_con>>(JSONresult);

                   //li = (from dr in dt.AsEnumerable()
                   //      select new clsNotas_con
                   //      {
                   //          srv_nvta = dr[0].ToString(),
                   //          fol_nvta = dr[1].ToString(),
                   //          ffis_nvta = dr[2].ToString(),
                   //          cia_nvta = dr[3].ToString(),
                   //          pla_nvta = dr[4].ToString(),
                   //          ped_nvta = dr[5].ToString(),
                   //          numcte_nvta = dr[6].ToString(),
                   //          numtqe_nvta = dr[7].ToString(),
                   //          ruta_nvta = dr[8].ToString(),
                   //          tip_nvta = dr[9].ToString(),
                   //          tiprut_nvta = dr[10].ToString(),
                   //          uso_nvta = dr[11].ToString(),
                   //          fep_nvta = dr[12].ToString(),
                   //          fes_nvta = dr[13].ToString(),
                   //          fliq_nvta = dr[14].ToString(),
                   //          edo_nvta = dr[15].ToString(),
                   //          tpa_nvta = dr[16].ToString(),
                   //          nept_nvta = dr[17].ToString(),
                   //          tlts_nvta = dr[18].ToString(),
                   //          tprd_nvta = dr[19].ToString(),
                   //          pru_nvta = dr[20].ToString(),
                   //          impt_nvta = dr[21].ToString(),
                   //          tpdo_nvta = dr[22].ToString(),
                   //          asiste_nvta = dr[23].ToString(),
                   //          impasi_nvta = dr[24].ToString(),
                   //          gps_nvta = dr[25].ToString(),
                   //          gpe_nvta = dr[26].ToString(),
                   //          eco_nvta = dr[27].ToString(),
                   //          fhs_nvta = dr[28].ToString(),
                   //          chf_nvta = dr[29].ToString(),
                   //          dia_semana = dr[30].ToString(),
                   //          dia_semana_sur = dr[31].ToString()
                   //      }).ToList();
               }
               else
               {
                   li = new List<clsNotas_con>();
               }



               return li;


           }
           catch (Exception ex)
           {
               List<clsNotas_con> li = new List<clsNotas_con>();
               li = new List<clsNotas_con>();
               return li;
           }

       }
       // obtiene las notas  de clientes espesificos 
       public List<clsNotas_con> getNotascte(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsNotas_con> li = new List<clsNotas_con>();
               String query = "select *, WEEKDAY(fep_nvta) dia_semana, WEEKDAY(fes_nvta) dia_semana_sur from notas_con where srv_nvta in (" + id.paramSrv + ")  and pla_nvta in (" + id.paramPla.Trim() + ") and  fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') ";
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               String JSONresult;
               if (il != null)
               {
                   JSONresult = JsonConvert.SerializeObject(dt);
                   li = JsonConvert.DeserializeObject<List<clsNotas_con>>(JSONresult);

                   //li = (from dr in dt.AsEnumerable()
                   //      select new clsNotas_con
                   //      {
                   //          srv_nvta = dr[0].ToString(),
                   //          fol_nvta = dr[1].ToString(),
                   //          ffis_nvta = dr[2].ToString(),
                   //          cia_nvta = dr[3].ToString(),
                   //          pla_nvta = dr[4].ToString(),
                   //          ped_nvta = dr[5].ToString(),
                   //          numcte_nvta = dr[6].ToString(),
                   //          numtqe_nvta = dr[7].ToString(),
                   //          ruta_nvta = dr[8].ToString(),
                   //          tip_nvta = dr[9].ToString(),
                   //          tiprut_nvta = dr[10].ToString(),
                   //          uso_nvta = dr[11].ToString(),
                   //          fep_nvta = dr[12].ToString(),
                   //          fes_nvta = dr[13].ToString(),
                   //          fliq_nvta = dr[14].ToString(),
                   //          edo_nvta = dr[15].ToString(),
                   //          tpa_nvta = dr[16].ToString(),
                   //          nept_nvta = dr[17].ToString(),
                   //          tlts_nvta = dr[18].ToString(),
                   //          tprd_nvta = dr[19].ToString(),
                   //          pru_nvta = dr[20].ToString(),
                   //          impt_nvta = dr[21].ToString(),
                   //          tpdo_nvta = dr[22].ToString(),
                   //          asiste_nvta = dr[23].ToString(),
                   //          impasi_nvta = dr[24].ToString(),
                   //          gps_nvta = dr[25].ToString(),
                   //          gpe_nvta = dr[26].ToString(),
                   //          eco_nvta = dr[27].ToString(),
                   //          fhs_nvta = dr[28].ToString(),
                   //          chf_nvta = dr[29].ToString(),
                   //          dia_semana = dr[30].ToString(),
                   //          dia_semana_sur = dr[31].ToString()
                   //      }).ToList();
               }
               else
               {
                   li = new List<clsNotas_con>();
               }



               //if ()
               //{

               //}

               //string JSONresult = JsonConvert.SerializeObject(dt);

               //li = JsonConvert.DeserializeObject<List<clsNotas_con>>(JSONresult);
               return li;


           }
           catch (Exception ex)
           {
               List<clsNotas_con> li = new List<clsNotas_con>();
               li = new List<clsNotas_con>();
               return li;
           }

       }
       //obtiene las liquidas
       public List<clsLiquida> getLiquidas(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsLiquida> li = new List<clsLiquida>();
               String query = "select * from tliqs  where srv_eru in (" + id.paramSrv + ") and fec_eru >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fec_eru <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M')";
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               if (il != null)
               {
                   li = (from dr in dt.AsEnumerable()
                         select new clsLiquida
                         {
                             srv_eru = dr[0].ToString(),
                             fec_eru = dr[1].ToString(),
                             cia_eru  = dr[2].ToString(),
                             pla_eru = dr[3].ToString(),
                             rut_eru = dr[4].ToString(),
                             fliq_eru = dr[5].ToString(),
                             uni_eru = dr[6].ToString(),
                             chf_erup = dr[7].ToString()                                      
                         }).ToList();
               }
               else
               {
                   li = new List<clsLiquida>();
               }

               return li;


           }
           catch (Exception ex)
           {
               List<clsLiquida> li = new List<clsLiquida>();
               li = new List<clsLiquida>();
               return li;
           }

       }
       //obtiene la fecha de la ultima recopilacion de informacion de las notas de venta
       public List<clsLiquida> geUltimaFechaCopiado(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsLiquida> li = new List<clsLiquida>();
               String query = "SELECT MAX (fes_nvta) fes_nvta  from notas_2023c where srv_nvta in ('" + id.paramSrv + "')";
               //String query = " select srv_cop, max(fec_cop) fecha from ctrl_coP  where srv_cop='"+id.paramSrv+"' group by 1";
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               if (il != null)
               {
                   li = (from dr in dt.AsEnumerable()
                         select new clsLiquida
                         {
                             //srv_eru = dr[0].ToString(),
                             //fec_eru = dr[1].ToString(),
                             //srv_eru = dr[0].ToString(),
                             fec_eru = dr[0].ToString(),
                             
                         }).ToList();
               }
               else
               {
                   li = new List<clsLiquida>();
               }

               return li;


           }
           catch (Exception ex)
           {
               List<clsLiquida> li = new List<clsLiquida>();
               li = new List<clsLiquida>();
               return li;
           }

       }
       // consulta las coincidencias de busqueda de una colonia 
       public List<clsColoniaGeo> getColonia(clsSQLDirectosService sqldir, clParametros id)
       {
           String[] ids = id.paramString1.Split(',');
           try
           {
               IList il;
               List<clsColoniaGeo> li = new List<clsColoniaGeo>();             
               il = sqldir.GetDataFromSicoBySQL("select * from colonia_geo where sett_name like '%"+id.paramDescrip+"%' and st_name='"+id.paramEdo+"' and idcol_geo>="+ids[0]+" and idcol_geo<="+ids[1]+";");
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clsColoniaGeo>>(JSONresult);               
               return li;


           }
           catch (Exception)
           {

               throw;
           }
          

       }
       // consulta los municipios de un estado 
       public List<clsColoniaGeo> getMunicipios(clsSQLDirectosService sqldir, clParametros id)
       {
           String[] ids = id.paramString1.Split(',');
           try
           {
               IList il;
               String query = "select st_name, mun_name from colonia_geo where st_name='" + id.paramEdo + "' and idcol_geo>=" + ids[0] + " and idcol_geo<=" + ids[1] + "  group by 1,2;";
               List<clsColoniaGeo> li = new List<clsColoniaGeo>();
               il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clsColoniaGeo>>(JSONresult);
               return li;


           }
           catch (Exception)
           {

               throw;
           }


       }
       // cconsulta los indices maximos y minimos de las colonias por estado de la informacion del inegi
       public List<clsColoniaGeo> getEstadosIndex(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               IList il;
               List<clsColoniaGeo> li = new List<clsColoniaGeo>();
               il = sqldir.GetDataFromSicoBySQL("select * from colIndex_geo;");
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clsColoniaGeo>>(JSONresult);
               return li;


           }
           catch (Exception)
           {

               throw;
           }


       }
       // guarda un poligon libre en la base de datos 
       public String saveFreePoligon(clsSQLDirectosService sqldir,clGeocercas poligono )
       {
           try
           {
               String script = "insert into geocercas (cia_geo,pla_geo,nom_geo,tip_geo,rutas_geo,turno_geo,color_geo,hraini_geo,hrafin_geo,fecam_geo,puntos_geo,edo_geo,tipuni_geo,srv_geo) " +
               "values ('"+poligono.cia_geo+"'," +
                        " '"+poligono.pla_geo+"'," +
                        " '"+poligono.nom_geo+"'," +
                        " '"+poligono.tip_geo+"'," +
                        " '"+poligono.rutas_geo+"'," +
                        " '"+poligono.turno_geo+"'," +
                        " '"+poligono.color_geo+"' , " +
                        " '"+poligono.hraini_geo+"' , " +
                        " '"+poligono.hrafin_geo+"' , " +
                        " '"+poligono.fecam_geo+" ', " +
                        " '"+poligono.puntos_geo+"' , " +
                        " '"+poligono.edo_geo+"' , " +
                        " '"+poligono.tipuni_geo + "' , " +
                        " '"+poligono.srv_geo+"');";
               String result = "";
               result = sqldir.GetExisteDatoEnSicogas(script).ToString();

               if (String.IsNullOrEmpty(result))
               {
                   return "Poligono Guardado correctamente";
               }

               return result.Trim(); ;



           }
           catch (Exception ex)
           {

               if (ex.Message.Contains("duplicate value in a UNIQUE INDEX"))
               {
                   return "Nombre de Poligono duplicado";
               
               }else
               {
                   return ex.Message;
               }
           }

       }

       // consulta los poligonos dibujados por los usuarios
       public List<clGeocercas> getPoligonosLibres(clsSQLDirectosService sqldir,clGeocercas id)
       {
           try
           {
               IList il;
               List<clGeocercas> li = new List<clGeocercas>();              
               il = sqldir.GetDataFromSicoBySQL("select * from geocercas where srv_geo='" + id.srv_geo + "' and rutas_geo='"+id.rutas_geo+"' and pla_geo='"+id.pla_geo+"';");
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clGeocercas>>(JSONresult);
               if ( li!=null)
               {
                   li = li.OrderBy(o => o.srv_geo).ToList();
               }else
               {
                   li = new List<clGeocercas>();   

               }
               
              
               return li;


           }
           catch (Exception)
           {

               throw;
           }

       }
       // guarda un poligon libre en la base de datos 
       public String deleteFreePoligon(clsSQLDirectosService sqldir, clGeocercas poligono)
       {
           try
           {
               String script = " delete from geocercas where tip_geo='PoligonoLib' and pla_geo='"+poligono.pla_geo+"' and  srv_geo='"+poligono.srv_geo.Trim()+"' and nom_geo='"+poligono.nom_geo.Trim()+"';";
              
               String result = "";
               result = sqldir.GetExisteDatoEnSicogas(script).ToString();

               if (String.IsNullOrEmpty(result))
               {
                   return "Poligono Eliminado correctamente";
               }

               return result.Trim(); ;



           }
           catch (Exception ex)
           {

             return ex.Message;
               
           }

       }

       /// consulta todas las colonias 
       public List<clsColoniaGeo> todasLasColonias(clsSQLDirectosService sqldir, clParametros id)
       {
           
           try
           {
               
               IList il;
               List<clsColoniaGeo> li = new List<clsColoniaGeo>();
               List<clsColoniaGeo> li2 = new List<clsColoniaGeo>();
               il = sqldir.GetDataFromSicoBySQL("select rowid, * from municip_geo where cve_ent='" + id.paramString1 + "' order by nom_mun, oid_1 ;");
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clsColoniaGeo>>(JSONresult);

               for (int i = 0; i < li.Count; i++)
               {
                   li[i].geometry = li[i].geometry.Substring(0,li[i].geometry.Length-1);
               }
          
               
               return li;


           }
           catch (Exception ex)
           {

               throw;
           }


       }
       // obiene las colonias por municipio
       public List<clsColoniaGeo> getColoniaXmun(clsSQLDirectosService sqldir, clsColoniaGeo col)
       {
       
           try
           {
               IList il;
               List<clsColoniaGeo> li = new List<clsColoniaGeo>();
               il = sqldir.GetDataFromSicoBySQL("select * from colonia_geo where  st_name='" + col.edo_geo + "' and mun_name='"+col.mun_name+"' and idcol_geo>=" + col.min_ind + " and idcol_geo<=" + col.max_ind + ";");
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clsColoniaGeo>>(JSONresult);
               return li;


           }
           catch (Exception)
           {

               throw;
           }


       }

       // obtiene los usuarios de la base de datos
       public List<clsUsuarios> getUsrs(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsUsuarios> li = new List<clsUsuarios>();
               String query = "select distinct usr_anr from logmod_anr";
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               if (il != null)
               {
                   li = (from dr in dt.AsEnumerable()
                         select new clsUsuarios
                         {
                             id_usr = "",
                             usr_usr = dr[0].ToString(),
                             pwd_usr = "",
                             srv_usr = "",
                             rol_usr = "",
                         }).ToList();
               }
               else
               {
                   li = new List<clsUsuarios>();
               }
               return li;


           }
           catch (Exception ex)
           {
               List<clsUsuarios> li = new List<clsUsuarios>();
         
               return li;
           }

       }
       // obtiene los inicios de sesion de los usuarios
       public List<clsUsuarios> getUsrsLogin(clsSQLDirectosService sqldir, clParametros id)
       {
           //Ingreso de sesion: fecha  19/08/2019 12:22:55 p. m.  usuario UsrNieto servidor Queretar
           try
           {
               List<clsUsuarios> li = new List<clsUsuarios>();


               string[] lines = System.IO.File.ReadAllLines(@"C:\log\LoginAnlizer.txt");
               string[] infoLogin;
               foreach (string line in lines)
               {
                   if (line.Contains(id.paramUsr))
                   {
                       infoLogin = line.Split(' ');

                       clsUsuarios sesion = new clsUsuarios();
                       sesion.fecha_secion= infoLogin[5].Trim();
                       sesion.hora_secion = infoLogin[6].Trim() + infoLogin[7].Trim()+".m";
                       li.Add(sesion);


                   }
               }


               return li;


           }
           catch (Exception ex)
           {
               List<clsUsuarios> li = new List<clsUsuarios>();

               return li;
           }

       }
       // Obtiene un conjunto de inicios de secion de un intervalo de fechas
       public List<clsUsuarios> getUsrsLoginGfr(clsSQLDirectosService sqldir, clParametros id)
       {
           //Ingreso de sesion: fecha  19/08/2019 12:22:55 p. m.  usuario UsrNieto servidor Queretar
           try
           {
               

               List<clsUsuarios> li = new List<clsUsuarios>();
               List<clsUsuarios> li2 = new List<clsUsuarios>();
               DateTime fecha;

               string[] lines = System.IO.File.ReadAllLines(@"C:\log\LoginAnlizer.txt");
               string[] infoLogin;
               string[] valores_fecha;
               foreach (string line in lines)
               {
                   infoLogin = line.Split(' ');
                   valores_fecha = infoLogin[5].Split('/');
                   fecha = new DateTime(Int32.Parse(valores_fecha[2]), Int32.Parse(valores_fecha[1]), Int32.Parse(valores_fecha[0]));
                   if (((DateTime.Compare(fecha,id.fechaI)>0 ||DateTime.Compare(fecha,id.fechaI)==0)) &(DateTime.Compare(fecha,id.fechaF)<0 ||DateTime.Compare(fecha,id.fechaF)==0))
                   {
                       clsUsuarios sesion = new clsUsuarios();
                       sesion.usr_usr=infoLogin[10].Trim();
                       li.Add(sesion);
                   }
               }
               bool existe = false;
               String user_acual = "";
               for (int i = 0; i < li.Count; i++)
               {
                   user_acual = li[i].usr_usr.Trim();
                   for (int j  = 0; j < li2.Count; j ++)
                   {
                       if (li[i].usr_usr.Trim().Equals(li2[j].usr_usr.Trim()))
                       {
                           existe = true;  
                       }
                       
                   }
                   if (!existe)
                   {
                       li2.Add(li[i]);
                       
                   }
                   existe = false;
                   
               }

               for (int i = 0; i < li2.Count; i++)
               {
                   li2[i].logeos = 0;
                   for (int j = 0; j < li.Count; j++)
                   {
                       if (li2[i].usr_usr.Trim().Equals(li[j].usr_usr.Trim()))
                       {
                           li2[i].logeos++;
                       }
                   }
                   
               }

               return li2;



           }
           catch (Exception ex)
           {
               List<clsUsuarios> li = new List<clsUsuarios>();
               return li;
           }

       }
       //Da de alta un nuevo usuario
       public String userLoginAlta(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               String result = "";
               result = sqldir.GetExisteDatoEnSicogas("select count(*) from usr_anr where usr_usr='" + id.paramUsr + "' and pwd_usr='" + id.paramPwd + "'").ToString();

               if (Int32.Parse(result)>0)
               {
                   return "Ya existe un usuario con ese nombre de usuario y contraseña.";  
               }else
               {
                   result = sqldir.GetExisteDatoEnSicogas("Insert into usr_anr (usr_usr,pwd_usr,srv_usr, rol_usr) values ('" + id.paramUsr + "','" + id.paramPwd + "','" + id.paramSrv + "','" + id.paramString1 + "')").ToString();
                   return "Se ha insertado correctamente el registro.";
               }
           }
           catch (Exception)
           {

               throw;
           }

       }
       //Eliminia  o da de un registro de un usuario
       public String actualizarBajaUser(clsSQLDirectosService sqldir, clParametros id)
       {
           String[] valores = id.paramString1.Split('/');
           String query = "";

           switch (valores[0].Trim())
           {
               case "Actualizar":
                   query = "update usr_anr set usr_usr='" + valores[2].Trim() + "', pwd_usr='" + valores[3].Trim() + "' , rol_usr='" + valores[4].Trim() + "' where id_usr=" + valores[1].Trim() + " ";
                   break;
               case "Baja":
                   query = "delete from usr_anr where id_usr="+valores[1].Trim();
                   break;
               default:
                   break;
           }

           try
           {
               String result = "";
               result = sqldir.GetExisteDatoEnSicogas(query).ToString();

               switch (valores[0].Trim())
               {
                   case "Actualizar":
                       result = sqldir.GetExisteDatoEnSicogas("select count(*) from usr_anr where usr_usr='" + valores[2].Trim() + "' and  pwd_usr='" + valores[3].Trim() + "' and id_usr=" + valores[1].Trim()+ " ").ToString();
                       if (Int32.Parse(result)==1)
                       {
                           return "Se actualizo correctamente el registro.";  
                       }
                       else
                       {
                           return "Problemas al actualizar.";
                       }
                       break;
                   case "Baja":
                      result = sqldir.GetExisteDatoEnSicogas("select count(*) from usr_anr where  id_usr=" + valores[1].Trim()+ " ").ToString();
                       if (Int32.Parse(result)==0)
                       {
                           return "Se elimino correctamente el registro.";  
                       }
                       else
                       {
                           return "Problemas al eliminar.";
                       }
                       break;
                       break;
                   default:
                       break;
               }



               
              

               return result.Trim(); 



           }
           catch (Exception)
           {

               throw;
           }

       }

       // consulta las notas de venta de uno o varios servidores 
       public List<clsPedidos> getPedidos(clsSQLDirectosService sqldir, clParametros id, List<GEN.ETY.clsRutaModel> listaRutas)
       {
           try
           {
                String inRutas = "";

               for (int i = 0; i < listaRutas.Count; i++)
               {
                   if (i==listaRutas.Count-1)
                       inRutas += "'" + listaRutas[i].Cve_rut + "'";
                   else
                       inRutas += "'"+listaRutas[i].Cve_rut+"',";
               }
               List<clsPedidos> li = new List<clsPedidos>();

               String query = "";
               if (id.fechaI.Year == id.fechaF.Year)
               {
                   // Consulta sobre el mismo año
                   query = "select *, WEEKDAY(fhrp_ped) dia_ped, WEEKDAY(fecrsur_ped) dia_sur_can from pedidos_" + id.fechaI.Year.ToString() + "c where srv_ped in ('" + id.paramSrv.ToLower() + "') and fecrsur_ped >= TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fecrsur_ped <= TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and ruta_ped in (" + inRutas + ")";// and tpdo_ped <> 'C'";
           
               }
               else
               {

                   // Validar si es de dos años difertes realizar una union 
                   if (id.fechaF.Year - id.fechaI.Year == 1)
                   {
                       query = "select *, WEEKDAY(fhrp_ped) dia_ped, WEEKDAY(fecrsur_ped) dia_sur_can from pedidos_" + id.fechaI.Year.ToString() + "c where srv_ped in ('" + id.paramSrv.ToLower() + "') and fecrsur_ped >= TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fecrsur_ped <= TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and ruta_ped in (" + inRutas + ") "+
                               " union select *, WEEKDAY(fhrp_ped) dia_ped, WEEKDAY(fecrsur_ped) dia_sur_can from pedidos_" + id.fechaF.Year.ToString() + "c where srv_ped in ('" + id.paramSrv.ToLower() + "') and fecrsur_ped >= TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fecrsur_ped <= TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and ruta_ped in (" + inRutas + ")";// and tpdo_ped <> 'C'";
           
                   }
                   else
                   {
                       //Si son mas de dos años consultar con la vista 
                       query = "select *, WEEKDAY(fhrp_ped) dia_ped, WEEKDAY(fecrsur_ped) dia_sur_can from pedidos_con where srv_ped in ('" + id.paramSrv.ToLower() + "') and fecrsur_ped >= TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fecrsur_ped <= TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and ruta_ped in (" + inRutas + ")";// and tpdo_ped <> 'C'";
                   }

               } 





            //String query = "select *, WEEKDAY(fhrp_ped) dia_ped, WEEKDAY(fecrsur_ped) dia_sur_can from pedidos_con where srv_ped in ('" + id.paramSrv.ToLower() + "') and fecrsur_ped >= '" + sqldir.GetFechaValidaServer(id.fechaI) +"' and fecrsur_ped <= '" + sqldir.GetFechaValidaServer(id.fechaF)+"' and ruta_ped in ("+inRutas+")";// and tpdo_ped <> 'C'";
               
            Console.WriteLine("Se creo la el script");
            IList il = sqldir.GetDataFromSicoBySQL(query);
            Console.WriteLine("Se ejecuto el script la el script");
            DataTable dt = (DataTable)il[0];

            string JSONresult;
            if (dt != null && dt.Rows.Count > 0)
            {
                JSONresult = JsonConvert.SerializeObject(dt);
                li = JsonConvert.DeserializeObject<List<clsPedidos>>(JSONresult);
            }
            
            
               //if (il != null)
               //{
               //    li = (from dr in dt.AsEnumerable()
               //          select new clsPedidos
               //          {
               //              //srv_nvta = dr[0].ToString(),
               //             srv_ped = dr[0].ToString(),
               //             num_ped = dr[1].ToString(),
               //             fhr_ped = dr[2].ToString(),
               //             tipo_ped = dr[3].ToString(),
               //             numcte_ped = dr[4].ToString(),
               //             lada_ped = dr[5].ToString(),
               //             tel_ped = dr[6].ToString(),
               //             numtqe_ped = dr[7].ToString(),
               //             ruta_ped = dr[8].ToString(),
               //             observ_ped = dr[9].ToString(),
               //             fecsur_ped = dr[10].ToString(),
               //             edo_ped = dr[11].ToString(),
               //             usr_ped = dr[12].ToString(),
               //             edotx_ped = dr[13].ToString(),
               //             fhtx_ped = dr[14].ToString(),
               //             usrtx_ped = dr[15].ToString(),
               //             fecrsur_ped = dr[16].ToString(),
               //             usrcan_ped = dr[17].ToString(),
               //             motcan_ped = dr[18].ToString(),
               //             nmod_ped = dr[19].ToString(),
               //             fhrp_ped = dr[20].ToString(),
               //             usrrp_ped = dr[21].ToString(),
               //             nmtx_ped = dr[22].ToString(),
               //             fhptx_ped = dr[23].ToString(),
               //             usrtp_ped = dr[24].ToString(),
               //             tmcan_ped = dr[25].ToString(),
               //             horrsur_ped = dr[26].ToString(),
               //             tpdo_ped = dr[27].ToString(),
               //             kgsu_ped = dr[28].ToString(),
               //             c20k_ped = dr[29].ToString(),
               //             c30k_ped = dr[30].ToString(),
               //             c45k_ped = dr[31].ToString(),

               //              dia_ped = dr[32].ToString(),
               //             dia_sur_can = dr[33].ToString(),
               //          }).ToList();
               //}
               //else
               //{
               //    li = new List<clsPedidos>();
               //}

            Console.WriteLine("Tamaño de la lista "+li.Count);

            // calcular los tiempos en los que tardo un servicio.
            DateTime fped;
               DateTime fsur;
               String[] valoresFechaPedido;
               String[] valoresFP;
               String[] valoresHP;
               for (int i = 0; i < li.Count; i++)
               {
                // CREAR FECHA DE PEDIDO
                Console.WriteLine(" line 1030 Fecha de pedido" + li[i].fhrp_ped);
                valoresFechaPedido = li[i].fhrp_ped.Split(' ');
               

                   valoresFP = valoresFechaPedido[0].ToString().Split('/');                   
                   valoresHP = valoresFechaPedido[1].ToString().Split(':');
                   valoresHP[0] = determinaTurno(valoresFechaPedido, valoresHP);
                   fped = new DateTime(Int32.Parse(valoresFP[2]), Int32.Parse(valoresFP[1]), Int32.Parse(valoresFP[0]), Int32.Parse(valoresHP[0]), Int32.Parse(valoresHP[1]), Int32.Parse(valoresHP[2]));
                   // CREAR FECHA DE SURTIDO 
                   valoresFechaPedido = li[i].fecrsur_ped.Split(' ');
                   valoresFP = valoresFechaPedido[0].ToString().Split('/');
                   valoresHP = li[i].horrsur_ped.ToString().Split(':');
                   fsur = new DateTime(Int32.Parse(valoresFP[2]), Int32.Parse(valoresFP[1]), Int32.Parse(valoresFP[0]), Int32.Parse(valoresHP[0]), Int32.Parse(valoresHP[1]), 0);

                   TimeSpan interval = fsur - fped;

                   //Console.WriteLine(interval.Minutes +" Minutos ");

                   //Obtener dias
                   //1440
                   decimal dias = interval.Minutes / 1440;
                   li[i].dias_ate = interval.Days.ToString();//(interval.Minutes / 1440).ToString();//(Math.Truncate(dias)) + "";
                   // Obtener horas
                   int minutosToHours = interval.Minutes % 1440;

                   decimal horas = minutosToHours / 60;
                   li[i].hrs_ate = interval.Hours.ToString();//(minutosToHours / 60).ToString(); //(Math.Truncate(horas)) + "";

                   //Obtener minutos
                   li[i].min_ate = interval.Minutes.ToString();//(minutosToHours % 60).ToString();

                   Console.WriteLine(fped.ToString()+" --> "+fsur.ToString()+ "      Dias :" + li[i].dias_ate + " horas: " + li[i].hrs_ate + " Min: " + li[i].min_ate);
               }
               return li;

        }
           catch (Exception ex)
           {
                Console.WriteLine(ex.Message+ "  "+ex.InnerException+" ");
               throw  new Exception(ex.Message);
        //List<clsPedidos> li = new List<clsPedidos>();
        //li = new List<clsPedidos>();
        //return li;
    }

}

       public List<GEN.ETY.clsRutaModel> getRutasByCiaPla(clsSQLDirectosService sqldir, clParametros id)
       {
            List<GEN.ETY.clsRutaModel> li = new List<GEN.ETY.clsRutaModel>();
           try
           {
              
               
               clsRutaService rutasService = new clsRutaService(sqldir.Session);
               String[] arrPla = id.paramPla.Split(',');
               foreach (var item in arrPla)
               {
                   if (!String.IsNullOrWhiteSpace(item))
                   {
                       li.AddRange(  rutasService.List(new GEN.ETY.Filter.clsFilter() { Cia = id.paramCia, Branch = item.Trim() }));
                   }
               }
              
               
               return li;

           }
           catch (Exception ex)
           {
              
               return li;
           }

       }
       private String determinaTurno(String[] fecha, String [] hora)
       {
           if (fecha[2].Contains("p"))
	         {
		 
	
           switch(hora[0])
               {
                                 
                   case "01":
                       return "13";
               break;
               
                   case "02":
               return "14";
               break;
                   case "03":
               return "15";
               break;
                   case "04":
               return "16";
               break;
                   case "05":
               return "17";
               break;
                   case "06":
               return "18";
               break;
                   case "07":
               return "19";
               break;
                   case "08":
               return "20";
               break;
                   case "09":
               return "21";
               break;
                   case "10":
               return "22";
               break;
                   case "11":
               return "23";
               break;
                    
             

               default:
                   return hora[0];


               }
           return hora[0];
               }
           else
           {
               return hora[0];
           }
       }


       // inserta un registro en la base de datos declarando en que modulo ha ingresado el usuario

       public void ingresoModulo(clsSQLDirectosService sqldir, clParametros id)
       {        
           try
           {
               sqldir.GetExisteDatoEnSicogas("Insert into logmod_anr  values ('" + id.paramString1 + "', today ,'" + DateTime.Now + "','" + id.paramUsr + "','" + id.paramSrv + "')").ToString();                 
              
           }
           catch (Exception)
           {

               throw;
           }
       }

       //obtiene los ingresos  de los usuarios a los modulos 
       public List<clsIngresosModulos> getIngrMod(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsIngresosModulos> li = new List<clsIngresosModulos>();
               String query = "select * from logmod_anr where fec_anr  >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fec_anr <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M')";
               IList il = sqldir.GetDataFromSicoBySQL(query);
               DataTable dt = (DataTable)il[0];
               if (il != null)
               {
                   li = (from dr in dt.AsEnumerable()
                         select new clsIngresosModulos
                         {
                             mod_anr = dr[0].ToString(),
                             fec_anr = dr[1].ToString(),
                             fh_anr = dr[2].ToString(),
                             usr_anr = dr[3].ToString(),
                             ser_anr = dr[4].ToString(),
                            tiemUltLog=""

                             
                         }).ToList();
               }
               else
               {
                   li = new List<clsIngresosModulos>();
               }

               return li;


           }
           catch (Exception ex)
           {
               List<clsIngresosModulos> li = new List<clsIngresosModulos>();
               li = new List<clsIngresosModulos>();
               return li;
           }

       }

       // consulta de mediciones historicas
       public List<clsLec_med> getHistMediciones(clsSQLDirectosService sqldir, clParametros id)
       {
           try
           {
               List<clsLec_med> ls = new List<clsLec_med>();
               String query = "select  * from lec_med where iddom_mdr in (" + id.paramString1.Substring(0, id.paramString1.Length - 1) + ") and feclec_mdr>='" + sqldir.GetFechaValidaServer(id.fechaI) + "' and feclec_mdr<='" + sqldir.GetFechaValidaServer(id.fechaF) + "' order by iddom_mdr, feclec_mdr";
               IList il = sqldir.GetDataFromSicoBySQL(query);

               DataTable dt = (DataTable)il[0];
              
               string JSONresult;
               if (dt != null && dt.Rows.Count > 0)
               {
                   JSONresult = JsonConvert.SerializeObject(dt);
                   ls = JsonConvert.DeserializeObject<List<clsLec_med>>(JSONresult);
               }
               
               return ls;


           }
           catch (Exception ex)
           {
               List<clsLec_med> li = new List<clsLec_med>();            
               return li;
           }

       }

        #region [metodos para modulo de gerenntes]

   
       public List<clsInv> getLecturaAlmacenes(clsSQLDirectosService sqldir)
       {
           try
           {
               IList il;
               List<clsInv> li = new List<clsInv>();
               String qry = "select descr_alm,  sec_almd,porc_inv_fis,  inv_fis_lts, inv_fis_kgs, cap_lts, alm_fis.tipo_alm, alm_fis.uso_alm " +
                                                "from alm_fis, almacen " +
                                                "where fecha_inv_fis='" + sqldir.GetFechaValidaServer(DateTime.Now.AddDays(-1)) + "' " +
                                                "and cve_alm_gral=cve_alm and catego_alm=cve_catego";
               //String qry = "select descr_alm,  sec_almd,porc_inv_fis,  inv_fis_lts, inv_fis_kgs, cap_lts, alm_fis.tipo_alm, alm_fis.uso_alm " +
               //                                "from alm_fis, almacen " +
               //                                "where fecha_inv_fis='2020-04-01' " +
               //                                "and cve_alm_gral=cve_alm";
               
               il = sqldir.GetDataFromSicoBySQL(qry);
               DataTable dt = (DataTable)il[0];
               string JSONresult = JsonConvert.SerializeObject(dt);
               li = JsonConvert.DeserializeObject<List<clsInv>>(JSONresult);
               if (li != null)
               {
                   li = li.OrderBy(o => o.descr_alm).ToList();
               }
               else
               {
                   li = new List<clsInv>();

               }


               return li;


           }
           catch (Exception)
           {

               throw;
           }

       }
        #endregion


    }
}
