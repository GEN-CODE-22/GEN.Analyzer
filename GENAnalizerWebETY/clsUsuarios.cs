using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENAnalizerWebETY
{
   public class clsUsuarios
    {
       
       public  String id_usr { set; get; }
       public  String usr_usr { set; get; }
       public  String pwd_usr { set; get; }
       public String srv_usr { set; get; }
       public String fecha_secion { set; get; }
       public String hora_secion { set; get; }
       public int logeos { set; get; }      
       public string rol_usr { get; set; }
    }
}
