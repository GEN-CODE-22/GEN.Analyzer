using GEN.DAL.NH;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GENAnalizerWebETY;
using GENAnalizerWebETY.Gerenrete.ETY;
using System.Data;
using Newtonsoft.Json;
using NHibernate;

namespace GENAnalizerWebDAL
{
  public  class clsGerentesDAL
  {

      #region [CUENTAS POR COBRAR]
      
      public List<clsCuentasXCobrar> getVtaNtaDAL(clsSQLDirectosService sqldir, clParametros param)
      {
          try
          {
              IList il;
              List<clsCuentasXCobrar> li = new List<clsCuentasXCobrar>();
              String qry = "";
              switch (param.paramString1.Trim())
              {
                  case "ventaNotaVenta":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                            "   FROM mov_cxc, cliente  " +
                            "   WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "'  " +
                            "     AND sta_mcxc = 'A'  " +
                            "     AND (tip_mcxc = '01' OR tip_mcxc >= '11' AND tip_mcxc <= '47')  " +
                            "     AND tpm_mcxc = '01'  and cte_mcxc=num_cte  GROUP BY 1,2";
                      break;
                  case "ChequeDevuelto":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                           "   FROM mov_cxc, cliente  " +
                            "  WHERE fec_mcxc >=  '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <='" + sqldir.GetFechaValidaServer(param.fechaF) + "' "+
                            "    AND sta_mcxc = 'A' "+
                            "    AND tip_mcxc = '03'"+
                            "    AND tpm_mcxc = '03'  and cte_mcxc=num_cte  GROUP BY 1,2  ";

                      break;

                  case "AntisiposIngresados":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                             "   FROM mov_cxc, cliente  " +
                               "   WHERE fec_mcxc >='" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "'  "+
                               "    AND sta_mcxc = 'A' "+
                               "     AND tpm_mcxc = '53'  and cte_mcxc=num_cte GROUP BY 1,2";

                      break;
                  case "ValesdeAccord":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                                      "   FROM mov_cxc, cliente  " +
                                       " WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' "+
                                       " AND sta_mcxc = 'A' "+
                                       " AND tip_mcxc = '09' "+
                                       " AND tpm_mcxc = '09' and cte_mcxc=num_cte  GROUP BY 1,2";

                      break;
                      
                  case "Cobrnzacrédito":
                      qry = "   SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                           "   FROM mov_cxc, cliente  " +
                            "  WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' "+
                            "    AND sta_mcxc = 'A' "+
                            "    AND (tpm_mcxc = '50' OR tpm_mcxc = '51' OR tpm_mcxc = '55' OR tpm_mcxc = '56' OR tpm_mcxc = '58' ) and cte_mcxc=num_cte   GROUP BY 1,2;";

                      break;
                  case "NotasCreditoCredito":
                      qry = " SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                          "   FROM mov_cxc, cliente  " +
                           "   WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <='" + sqldir.GetFechaValidaServer(param.fechaF) + "' " +
                           "   AND sta_mcxc = 'A' "+
                           "   AND (tpm_mcxc = '52' OR tpm_mcxc = '98')  and cte_mcxc=num_cte GROUP BY 1,2";


                      break;
                  case "ChequeDevueltoCobrados":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc " +
                              "   FROM mov_cxc, cliente  " +
                              " WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' " +
                              " AND sta_mcxc = 'A' "+
                              " AND tip_mcxc = '03' "+
                              " AND tpm_mcxc >= '50' and cte_mcxc=num_cte  GROUP BY 1,2";


                      break;
                  case "CobranzaComisiones":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                           "   FROM mov_cxc, cliente  " +
                            "  WHERE fec_mcxc >=  '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <='" + sqldir.GetFechaValidaServer(param.fechaF) + "' "+
                            "  AND sta_mcxc = 'A' "+
                            "  AND tpm_mcxc = '60' and cte_mcxc=num_cte  GROUP BY 1,2";


                      break;
                  case "CobranzaIntereses":
                      qry = "  SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc " +
                            "   FROM mov_cxc, cliente  " +
                            "  WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <='" + sqldir.GetFechaValidaServer(param.fechaF) + "' "+
                            "  AND sta_mcxc = 'A' "+
                            "  AND tpm_mcxc = '61' and cte_mcxc=num_cte  GROUP BY 1,2 ";
                      break;
                  case "CobranzaPagoBienes":
                      qry = "  SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc  " +
                             " FROM mov_cxc "+
                             " WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' " +
                             " AND sta_mcxc = 'A' "+
                             " AND tpm_mcxc = '62' and cte_mcxc=num_cte  GROUP BY 1,2 ";

                      break;
                  case "CobranzaDonaciones":
                      qry = "SELECT razsoc_cte, cte_mcxc, sum(imp_mcxc) imp_mcxc " +
                           "   FROM mov_cxc, cliente  " +
                            "  WHERE fec_mcxc >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mcxc <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' " +
                            "    AND sta_mcxc = 'A' " +
                            "    AND tpm_mcxc = '63' and cte_mcxc=num_cte  GROUP BY 1,2 ";


                      break;
              }
              

             

              il = sqldir.GetDataFromSicoBySQL(qry);
              DataTable dt = (DataTable)il[0];
              string JSONresult = JsonConvert.SerializeObject(dt);
              li = JsonConvert.DeserializeObject<List<clsCuentasXCobrar>>(JSONresult);

              if (li == null)
                  return new List<clsCuentasXCobrar>();


              return li;


          }
          catch (Exception ex)
          {

              throw;
          }

      }
      #endregion

      #region [MOVIMIENTOS DE ANTICIPO]

      public List<clsMovAnt> getMovAntDAL(clsSQLDirectosService sqldir, clParametros param)
      {
          try
          {
              IList il;
              List<clsMovAnt> li = new List<clsMovAnt>();
              String qry = "";
              switch (param.paramString1.Trim())
              {
                  case "AnticiposIngresados":
                      qry = "   SELECT razsoc_cte, cte_mant, sum(imp_mant) " +
                             " FROM mov_ant, cliente " +
                             " WHERE fec_mant >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mant <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' "+
                             " AND sta_mant = 'A' "+
                             " AND tpm_mant = '53' cte_mant=num_cte  GROUP BY 1,2 ";
                      break;
                  case "AnticiposAplicados":
                      qry = "   SELECT razsoc_cte, cte_mant, sum(imp_mant) " +
                            "  FROM mov_ant, cliente " +
                            "  WHERE fec_mant >= '" + sqldir.GetFechaValidaServer(param.fechaI) + "' AND fec_mant <= '" + sqldir.GetFechaValidaServer(param.fechaF) + "' " +
                            "    AND sta_mant = 'A' "+
                            "    AND tpm_mant = '99'  "+
                            "  cte_mant=num_cte  GROUP BY 1,2  ";

                      break;

              }




              il = sqldir.GetDataFromSicoBySQL(qry);
              DataTable dt = (DataTable)il[0];
              string JSONresult = JsonConvert.SerializeObject(dt);
              li = JsonConvert.DeserializeObject<List<clsMovAnt>>(JSONresult);

              if (li == null)
                  return new List<clsMovAnt>();


              return li;


          }
          catch (Exception)
          {

              throw;
          }

      }
     
  
      #endregion 
     
      #region [REPORTE DE ESTADO  DE PEDIDOS]
      public Object[] GetreportesEstadosDAL(ISession s)
      {
          clsTablarep reporte = new clsTablarep();
          return reporte.GetreportesEstados(s);

      }
      public List<clsPedidos> pedPenXRut(clsSQLDirectosService sqldir, clParametros param)
      {
          try
          {
              String query = " SELECT * " +
                         " FROM pedidos " +
                         " WHERE edo_ped = 'p' " +
                         "      AND tpdo_ped IN('L', 'A', 'P', 'W') " +
                         "      AND ruta_ped[1] IN('C', 'M') " +
                         "      AND tipo_ped IN('E', 'C') " +
                         "      AND fecsur_ped<= TODAY " +
                         "      AND num_ped IN( SELECT ped_enr FROM enruta WHERE edoreg_enr IN('0', 'P', 'O') AND ruta_enr[1] IN('C', 'M') ) " +
                         "      AND ruta_ped='" + param.paramRuta + "' " +
                         " ORDER BY 1";
              List<clsPedidos> li = new List<clsPedidos>();
              IList il = sqldir.GetDataFromSicoBySQL(query);
              DataTable dt = (DataTable)il[0];

              string JSONresult;
              if (dt != null && dt.Rows.Count > 0)
              {


                  JSONresult = JsonConvert.SerializeObject(dt);
                  li = JsonConvert.DeserializeObject<List<clsPedidos>>(JSONresult);


              }
              return li;
          }
          catch (Exception ex)
          {

              throw ex;
          }
          
      }

      #endregion

      #region [REPORTE VENTA MES AÑO ANTERIOR]

      // consulta las notas para el modulo de gerente 
      public List<clsNotasVta> getNotas(clsSQLDirectosService sqldir, clParametros id)
      {
          try
          {
          String query;
          List<clsNotasVta> li = new List<clsNotasVta>();
          List<clsNotasVta> li2 = new List<clsNotasVta>();
          string ruta = "";
          if (id.paramRuta != null)
          {
              ruta = "and ruta_nvta= '" + id.paramRuta.Trim() + "'";
          }
          if (id.paramString1.Equals("actual"))
          {
              DateTime hoy = DateTime.Now;
              if (hoy.Month == id.fechaI.Month || hoy.AddMonths(-1).Month == id.fechaI.Month)
              {
                  if (id.paramRuta == null)
                  {
                     
                      query = "select * from nota_vta where fes_nvta >=  '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <= '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "' " + ruta + " ";
                  }
                  else
                  {
                      
                      query = "select nota_vta.*, movxnvta.gps_mnvta gps_nvta, movxnvta.hini_mnvta hini_mnvta from nota_vta, movxnvta where fes_nvta >=  '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <=  '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "' " + ruta + "   and cia_nvta = cia_mnvta and pla_nvta= pla_mnvta and fol_nvta= fol_mnvta and edo_nvta in ('S','A') ";
                  }

              }
              else
              {
                  if (id.paramRuta == null)
                  {
                     
                      query = "select * from hnota_vta where fes_nvta >=  '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <=  '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "' " + ruta + " ";
                  }
                  else
                  {
                     
                      query = "select hnota_vta.*, movxnvta.gps_mnvta gps_nvta, movxnvta.hini_mnvta hini_mnvta from nota_vta, movxnvta where fes_nvta >= '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <=  '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "' " + ruta + "    and cia_nvta = cia_mnvta and pla_nvta= pla_mnvta and fol_nvta= fol_mnvta edo_nvta in ('S','A')";
                  }
              }
          }
          else
          {
              if (id.paramRuta == null)
              {
                  
                  query = "select * from hnota_vta where fes_nvta >=  '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <=  '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "'  " + ruta + "";
              }
              else
              {
                 
                  query = "select hnota_vta.*, movxnvta.gps_mnvta gps_nvta, movxnvta.hini_mnvta hini_mnvta from nota_vta, movxnvta where fes_nvta >=  '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <=  '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "'  " + ruta + "    and cia_nvta = cia_mnvta and pla_nvta= pla_mnvta and fol_nvta= fol_mnvta edo_nvta in ('S','A')";
              }
          }
          IList il = sqldir.GetDataFromSicoBySQL(query);
          DataTable dt = (DataTable)il[0];

          string JSONresult;
          if (dt != null && dt.Rows.Count > 0)
          {


              JSONresult = JsonConvert.SerializeObject(dt);
              li = JsonConvert.DeserializeObject<List<clsNotasVta>>(JSONresult);


          }
          if (id.paramRuta == null)
          {
              if (query.Contains("hnota_vta"))
              {
                  //query = "select * from hnota_vta where fes_nvta >=  TO_DATE('" + id.fechaI.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and fes_nvta <=  TO_DATE('" + id.fechaF.ToString("yyyy-MM-dd") + " 00:00', '%Y-%m-%d %H:%M') and edo_nvta='C'  and cia_nvta = '" + id.paramCia.Trim() + "' and pla_nvta='" + id.paramPla.Trim() + "'  " + ruta + " ";
                  query = "select * from hnota_vta where fes_nvta >=  '" + sqldir.GetFechaValidaServer(id.fechaI).Trim() + "' and fes_nvta <=  '" + sqldir.GetFechaValidaServer(id.fechaF).Trim() + "' and edo_nvta='C'    " + ruta + " ";
                  IList il2 = sqldir.GetDataFromSicoBySQL(query);
                  DataTable dt2 = (DataTable)il2[0];

                  string JSONresult2;
                  if (dt2 != null && dt2.Rows.Count > 0)
                  {


                      JSONresult2 = JsonConvert.SerializeObject(dt2);
                      li2 = JsonConvert.DeserializeObject<List<clsNotasVta>>(JSONresult2);
                      li.AddRange(li2);

                  }
              }
          }
          return li;


          }
          catch (Exception ex)
          {
              List<clsNotasVta> li = new List<clsNotasVta>();
              li = new List<clsNotasVta>();
              return li;
          }

      }
      #endregion


      #region [cartera]

      public String getDepBan(clsSQLDirectosService sqldir, clParametros id)
      {
          try
          {
              // depositos vancarios
              /*String qry = "SELECT SUM(itot_dep) suma" +
                      " FROM caja_dep " +
                      " WHERE MONTH(fec_dep)=MONTH(TODAY) " +
                      " AND YEAR(fec_dep)=YEAR(TODAY)";*/
              String qry = "SELECT  SUM(epo_tote) FROM E_posaj WHERE MONTH(epo_fec)= "+id.fechaI.Month+" AND YEAR(epo_fec)= "+id.fechaI.Year;
              
              var res = sqldir.GetExisteDatoEnSicogas(qry);
              // venta acomulada
              String qry2 = "SELECT SUM(epo_totcm) FROM E_posaj WHERE  MONTH(epo_fec) =  " + id.fechaI.Month + " AND YEAR(epo_fec) = " + id.fechaI.Year;
              var res2 = sqldir.GetExisteDatoEnSicogas(qry2);
              if (res.ToString().Length<=0)
              {
                  res = "0";
              }
              if (res2.ToString().Length <= 0)
              {
                  res2 = "0";
              }
              res = res.ToString() + "," + res2.ToString();
              return res.ToString();
          }
          catch (Exception ex)
          {

              return "0";
          }
         

      }

      public String CobranzaCreditoNtasCred_Acomulado(clsSQLDirectosService sqldir, clParametros id)
      {
          try
          {

              String qry = "Select sum(epo_vcre) as CreditoAcumulado from e_posaj where YEAR(epo_fec)=" + id.fechaI.Year + " AND  MONTH(epo_fec)=" + id.fechaI.Month;
              var res = sqldir.GetExisteDatoEnSicogas(qry);
              qry = "Select  sum(epo_cobr) as CobranzaAcumulado from e_posaj where YEAR(epo_fec)=" + id.fechaI.Year + " AND  MONTH(epo_fec)=" + id.fechaI.Month;
              var res2 = sqldir.GetExisteDatoEnSicogas(qry);
              qry = "SELECT SUM(epo_cnoc) FROM e_posaj WHERE MONTH(epo_fec)=" + id.fechaI.Month + " AND YEAR(epo_fec)=" + id.fechaI.Year;
              var res3 = sqldir.GetExisteDatoEnSicogas(qry);
              qry = "SELECT SUM(ede_desc) AS descuentos FROM e_descuentos WHERE YEAR(ede_fec)=" + id.fechaI.Year+" AND MONTH(ede_fec)=" + id.fechaI.Month;
              var res4 = sqldir.GetExisteDatoEnSicogas(qry);

              if (res.ToString().Length<=0)
              {
                  res = "0";
              }
              if (res2.ToString().Length <= 0)
              {
                  res2 = "0";
              }
              if (res3.ToString().Length <= 0)
              {
                  res3 = "0";
              }
              if (res4.ToString().Length <= 0)
              {
                  res4 = "0";
              }
              String resFinal = (res.ToString() + "_" + res2.ToString() + "_" + res3.ToString() + "_" + res4.ToString());
              return resFinal;
          }
          catch (Exception ex)
          {

              return "0_0_0_0";
          }


      }

      #endregion
  }
}
