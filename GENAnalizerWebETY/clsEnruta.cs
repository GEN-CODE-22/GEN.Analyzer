using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENAnalizerWebETY
{
   public class clsEnruta
    {
      
           public string Ruta_enr { get; set; }
           public string Numcte_enr { get; set; }
           public string Nom_enr { get; set; }
           public string Prc_enr { get; set; }
           public string Fol_enr { get; set; }
           public string Eco_enr { get; set; }
           public string Dir_enr { get; set; }
           public int RecCel_enr { get; set; }
           public string Golpe_enr { get; set; }
           public decimal? Ltssur_enr { get; set; }
           public decimal? Totvta_enr { get; set; }
           public string Ubicte_enr { get; set; }
           public string Fecate_enr { get; set; }
           public string Obser_enr { get; set; }
           public string Mens_enr { get; set; }
           public string Fecsur_ped { get; set; }
           public string fhtx_ped { get; set; }
           public string Edoreg_enr { get; set; }
           public int? Ped_enr { get; set; }
           public int? Tippgo_enr { get; set; }
           // public string fecate_enr { get; set; }
           public string asiste_enr { get; set; }
           public string fhrp_ped { get; set; }
           public bool fecha_hoy { get; set; }

           //propiedades tomadas de la tabla pedidos;
           public string ruta_ped { get; set; }
           public string motcan_ped { get; set; }

           public string estatus { get; set; }
           //{
           //    get
           //    {
           //        string est = "";

           //        switch (this.Edoreg_enr.Trim())
           //                {
           //                 case "0":
           //                 est="LISTO P/ENVIAR";
           //                break;
           //                  case "":
           //                break;
           //                }
           //        return est;
           //    }
           //}



       
    }
}
