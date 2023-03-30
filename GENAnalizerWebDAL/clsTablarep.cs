using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using GEN.DAL.NH;
using GEN.DAL.NH.Connection;
using System.Data;
using Newtonsoft.Json;
using NHibernate;

namespace GENAnalizerWebDAL
{
    public class clsTablarep
    {
        public string Tipo_serv { get; set; }
        public string Tipo_pedido { get; set; }
        public string Fecha_rep { get; set; }
        public string Ruta_rep { get; set; }
        public int Cantidad { get; set; }

        public string TipServ
        {
            get
            {
                string strRes = string.Empty;
                switch (this.Tipo_serv)
                {
                    case "C":
                        strRes = "CILINDRO";
                        break;
                    case "E":
                        strRes = "ESTACIONARIO";
                        break;
                    case "B":
                        strRes = "CARBURACION";
                        break;
                }
                return strRes;
            }
        }

        public string TipPed
        {
            get
            {
                string strRes = string.Empty;
                switch (this.Tipo_pedido)
                {
                    case "C":
                        strRes = "CALLE";
                        break;
                    case "L":
                        strRes = "CALLCENTER";
                        break;
                    case "A":
                        strRes = "APLICACION";
                        break;
                    case "S":
                        strRes = "PROG_X_SIS";
                        break;
                    case "P":
                        strRes = "PROACTIVA";
                        break;
                    case "W":
                        strRes = "WHATSAPP";
                        break;
                }
                return strRes;
            }
        }


        public Object[] GetreportesEstados(ISession s)
        {
            var tabPendGral = this.GetReportePendientesCanceladosGralyDet(s, "PENDGRAL");
            var tabCanGral = this.GetReportePendientesCanceladosGralyDet(s, "CANGRAL");
            var tabPendDet = this.GetReportePendientesCanceladosGralyDet(s, "PENDXRUT");
            var tabCanDet = this.GetReportePendientesCanceladosGralyDet(s, "CANXRUT");

            Object[] consultas = new Object[8]; // 2 bloques de 2 datos
            consultas[0] = "PENDGRAL";
            consultas[1] = (List<clsTablarep>)tabPendGral;
            consultas[2] = "CANGRAL";
            consultas[3] = (List<clsTablarep>)tabCanGral;
            consultas[4] = "PENDXRUT";
            consultas[5] = (List<clsTablarep>)tabPendDet;
            consultas[6] = "CANXRUT";
            consultas[7] = (List<clsTablarep>)tabCanDet;

            //List<clsTablarep> reportesConcentrados = new List<clsTablarep>();
            //reportesConcentrados.AddRange((List<clsTablarep>)tabPendGral);
            //reportesConcentrados.AddRange((List<clsTablarep>)tabCanGral);
            //reportesConcentrados.AddRange((List<clsTablarep>)tabPendDet);
            //reportesConcentrados.AddRange((List<clsTablarep>)tabCanDet);

            return consultas;

        }



        public List<clsTablarep> GetReportePendientesCanceladosGralyDet(ISession s, string qry)
        {
            List<clsTablarep> ls = new List<clsTablarep>();
            try
            {
                if (DateTime.Now.Hour >= 3)
                {
                    if (s != null)
                    {
                        var dtNow = DateTime.Now;
                        //Para controlar que solo en la primer notificación consulte el día anterior
                        if (DateTime.Now.Hour < 12)
                            dtNow = dtNow.AddDays(-1);
                        clsSQLDirectosService sqlDir = new clsSQLDirectosService(s);
                        string fec = sqlDir.GetFechaValidaServer(dtNow);
                        var il = sqlDir.GetDataFromSicoBySQL(ReturnSQLStatements(qry, fec));
                        DataTable dt = (DataTable)il[0];
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string JSONresult;
                            JSONresult = JsonConvert.SerializeObject(dt);
                            ls = JsonConvert.DeserializeObject<List<clsTablarep>>(JSONresult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // RegLog("GetReportePendientesCanceladosGralyDet --> " + qry, ex.ToString());
            }
            return ls;
        }

        /// <summary>
        /// Regresa los enunciados Sql para las operaciones deseadas
        /// </summary>
        /// <param name="SqlOp">Tipo de operacion {PENDGRAL, CANGRAL, PENDXRUT, CANXRUT}</param>
        /// <param name="fec">fecha parseada en el formato del server</param>
        /// <returns></returns>
        private string ReturnSQLStatements(string SqlOp, string fec)
        {
            string sqlReturn = string.Empty;
            switch (SqlOp)
            {
                case "PENDGRAL":
                    sqlReturn = " SELECT tipo_ped as Tipo_serv, tpdo_ped as Tipo_pedido, count(*) as Cantidad " +
                                " FROM pedidos WHERE edo_ped = 'p' " +
                                "   AND tpdo_ped IN('L', 'A', 'P', 'W') " +
                                "   AND ruta_ped[1] IN('C', 'M') " +
                                "   AND tipo_ped IN('E', 'C') " +
                                "   AND fecsur_ped<= TODAY " +
                                "   AND num_ped IN( SELECT ped_enr FROM enruta WHERE edoreg_enr IN('0', 'P', 'O') AND ruta_enr[1] IN('C', 'M') ) " +
                                "   GROUP BY 1,2 " +
                                "   ORDER BY 1,2;";
                    break;
                case "CANGRAL":
                    sqlReturn = " SELECT tipo_ped as Tipo_serv, tpdo_ped as Tipo_pedido,fecrsur_ped as Fecha_rep,  count(*) as Cantidad " +
                                " FROM pedidos WHERE edo_ped='C' " +
                                "   AND tpdo_ped IN('L', 'A', 'P', 'W') " +
                                "   AND ruta_ped[1] IN('C', 'M') " +
                                "   AND tipo_ped IN('E', 'C') " +
                                "   AND fecrsur_ped>='" + fec + "' " +
                                "   GROUP BY 1,2,3 " +
                                "   ORDER BY 3,1,2;";
                    break;
                case "PENDXRUT":
                    sqlReturn = " SELECT ruta_ped as Ruta_rep, count(*) as Cantidad " +
                                " FROM pedidos WHERE edo_ped = 'p' " +
                                "   AND tpdo_ped IN('L', 'A', 'P', 'W') " +
                                "   AND ruta_ped[1] IN('C', 'M') " +
                                "   AND tipo_ped IN('E', 'C') " +
                                "   AND fecsur_ped<= TODAY " +
                                "   AND num_ped IN( SELECT ped_enr FROM enruta WHERE edoreg_enr IN('0', 'P', 'O') AND ruta_enr[1] IN('C', 'M') ) " +
                                "   GROUP BY 1 " +
                                "   ORDER BY 1;";
                    break;
                case "CANXRUT":
                    sqlReturn = " SELECT ruta_ped as Ruta_rep, fecrsur_ped as Fecha_rep,  count(*) as Cantidad " +
                                " FROM pedidos WHERE edo_ped='C' " +
                                "   AND tpdo_ped IN('L', 'A', 'P', 'W') " +
                                "   AND ruta_ped[1] IN('C', 'M') " +
                                "   AND tipo_ped IN('E', 'C') " +
                                "   AND fecrsur_ped>='" + fec + "' " +
                                "   GROUP BY 1,2 " +
                                "   ORDER BY 2,1;";
                    break;
                default:
                    break;
            }
            return sqlReturn;
        }


        //Llamadas al métodos
        
    }
}
