using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GENAnalizerWebDAL
{
   public class clsSendMail
    {
       public string EnvioDeEmail(String asunto, List<String> correos, String cuerpo, List<String> copias, String msgRespuesta)
       {
           string resultado = "";
           try
           {
               /*******************Enviando correos de notificacion*********************************/

               /*Definiendo una instancia de MailMessage*/
               MailMessage email = new MailMessage();
               //email.To.Add(new MailAddress("ocoronilla@gasexpressnieto.com.mx"));
               //email.From = new MailAddress("ocoronilla@gasexpressnieto.com.mx");
               //email.To.Add("ocoronilla@gasexpressnieto.com.mx");
               for (int i = 0; i < correos.Count; i++)
               {
                   email.To.Add(correos[i]);
               }

               email.Subject = asunto + "  " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ";
               email.Body = cuerpo;
               //"Cualquier contenido en <b>HTML</b> para enviarlo por correo electrónico.";
               email.BodyEncoding = System.Text.Encoding.UTF8;
               email.IsBodyHtml = true;// =
               email.Priority = MailPriority.Normal;
               email.From = new MailAddress("preciosgen@webmail.nieto.com.mx");

               /*Definiendo una instancia de SmtpClient*********************************************/
               SmtpClient smtp = new SmtpClient();
               //smtp.Host = "192.168.0.121";
               smtp.Host = "172.16.1.169";
               smtp.Port = 25;
               smtp.EnableSsl.Equals(false);// = FALSE;
               smtp.UseDefaultCredentials.Equals(false);// = FALSE;
               smtp.Credentials = new NetworkCredential("preciosgen@webmail.nieto.com.mx", "C0$to.345Qro");

               string output = null;

               /***************Enviando el Correo**************************************************/
               try
               {
                   smtp.Send(email);
                   email.Dispose();
                   output = msgRespuesta;
               }
               catch (Exception ex)
               {
                   output = "Error al mandar la solicitud " + ex.Message;
               }
               //Console.WriteLine(output);
               resultado = output;
               /***********************************************************************************/
               //*/
           }
           catch (Exception)
           {
               throw;
           }
           return resultado;
       }


    }
}
