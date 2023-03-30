using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using GENAnalizerWebETY;
using System.Configuration;
using Newtonsoft.Json;
using System.Data;
using GENAnalizerWebETY.Ubiqo;

namespace GENAnalizerWebDAL
{
     public class clsConexionAnalizerUbiqo
    {
          #region [--INITIAL DELCARATIONS IN CLASS-]

        private SqlConnection _connectionObject;
        private SqlDataAdapter _adapterObject;
        private SqlCommand _commandObject;
        private SqlDataReader reader;
        private string _strConnextionString;

        #endregion

        #region [--STRUCT--]

        public struct StoredProcedureNames
        {
            public const string Getusers = "Getuserqry";
            public const string GetusersDash = "Getuserdash";
            public const string GetPolygonRoute = "queryGeoFence";
            public const string GetEventRI = "get_EventosRi505";
        }

        #endregion

        #region [--CLASS METHODS--]

        /// <summary>
        /// This method allow us to connect with the data base server
        /// </summary>
        /// <returns>string: In case there is an error</returns>
        public string Connect()
        {
            string stResult = string.Empty;

            try
            {

                if (!this._strConnextionString.Equals(string.Empty))
                {
                    this._connectionObject = new SqlConnection(this._strConnextionString);
                    this._connectionObject.Open();
                }

            }

            catch (Exception err)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\log\Log.txt", true))
                {
                    file.WriteLine(string.Format("Generado en el Intento de connection a MySql: {0}{1}", err, DateTime.Now));
                }
                stResult = "Ocurrió ún error";
                stResult += "<br/>";
                stResult += "Favor de reportar el error clsConexion-001";
            }
            return stResult;
        }

        /// <summary>
        /// This method closes the connection with the data base
        /// </summary>
        /// <returns>string: In case there is an error</returns>
        public string Close()
        {
            string strResult = string.Empty;

            try
            {
                //if (this._connectionObject.State == _ ConnectionState.Open)
                //{
                this._connectionObject.Close();
                this._connectionObject.Dispose();
                //}
            }
            catch (SqlException errMySql)
            {
                strResult = "Ocurrió ún error en la base de datos al intentar cerrar una conexión" + errMySql.ToString();
                strResult += "<br/>";
                strResult += "Favor de reportar el error clsConexion-002-BD";
            }
            catch (Exception err)
            {
                strResult = "Ocurrió ún error" + err.ToString();
                strResult += "<br/>";
                strResult += "Favor de reportar el error clsConexion-002";
            }
            return strResult;
        }
        #endregion

        #region [--DATA QUERY METHODS--]

        public List<clsDatosAppCliente> infoAppCliente( clParametros param)
        {
            List<clsDatosAppCliente> appsClientes = new List<clsDatosAppCliente>();
            string query = " select TD.Dispositivo as Dispositivo,  [coordenada].Lat as Latitud, [coordenada].Long as Longitud,  PU.asistencia as Asistencia, PU.id_usuario as Id , case when  D.id_tipo_servicio_default='1' " +
                                                                                                                                                                   " then 'Cilindro' " +
                                                                                                                                                                   " else " +
                                                                                                                                                                   " 'Estacionario' " +
                                                                                                                                                                   " end 'ServicioDefault' , D.es_principal, " +
                            " nombre+' '+apellidos as Nombre,telefono_principal,calle,colonia,numero, D.Id as Id_domicilio	" +
                           " from Cat_TipoDispositivo TD, Dat_PerfilesUsuarios PU,Dat_Domicilios D " +
                           " where TD.id=PU.id_dispositivo " +
                           " and  D.id_usuario=PU.id_usuario " +
                           " and fecha_registro >='"+param.fechaI.ToString("yyyy-MM-dd 00:00:00")+"'   and fecha_registro<= '"+param.fechaF.ToString("yyyy-MM-dd 23:59:59")+"' "+
                           " --and D.es_principal=1; ";

            string strResult = string.Empty;


            try
            {
                Connect();

                if (strResult.Equals(string.Empty))
                {
                    this._commandObject = new SqlCommand(query, this._connectionObject);
                    reader = this._commandObject.ExecuteReader();
                    while (reader.Read())
                    {                   
                        clsDatosAppCliente appcliente= new clsDatosAppCliente();
                        appcliente.Id = reader["Id"].ToString();
                        appcliente.Pedidos = "0";
                        appcliente.Dispositivo = reader["dispositivo"].ToString();
                        appcliente.Latitud = reader["Latitud"].ToString();
                        appcliente.Longitud = reader["Longitud"].ToString();
                        appcliente.Asistencia = reader["Asistencia"].ToString();
                        appcliente.ServicioDefault = reader["ServicioDefault"].ToString();
                        appcliente.principal = reader["es_principal"].ToString();
                        appcliente.telefono_principal = reader["telefono_principal"].ToString();
                        appcliente.calle = reader["calle"].ToString();
                        appcliente.colonia = reader["colonia"].ToString();
                        appcliente.numero = reader["numero"].ToString();
                        appcliente.Id_domicilio = reader["Id_domicilio"].ToString();
                        
                        appcliente.Nombre = reader["Nombre"].ToString();
                        appsClientes.Add(appcliente);
                        
                    } 
                    query = "select id_usuario , count (*) as 'numPedidos' from Dat_PedidosActuales "+
	                        " group by id_usuario";
                    this._commandObject = new SqlCommand(query, this._connectionObject);
                    reader.Close();
                    reader = this._commandObject.ExecuteReader();
                    while (reader.Read())
                    {
                        for (int i = 0; i < appsClientes.Count; i++)
                        {
                            if (appsClientes[i].Id.Trim().Equals(reader["id_usuario"].ToString().Trim()))
                            {
                                appsClientes[i].Pedidos = reader["numPedidos"].ToString();
                                break;
                            }
                          
                        }
                    }

                    query = "select  count (*) as 'descargas' from Dat_PerfilesUsuarios ";
                           
                    this._commandObject = new SqlCommand(query, this._connectionObject);
                    reader.Close();
                    reader = this._commandObject.ExecuteReader();
                    //while (reader.Read())
                    //{
                        //for (int i = 0; i < appsClientes.Count; i++)
                        //{
                        //    if (appsClientes[i].Id.Trim().Equals(reader["id_usuario"].ToString().Trim()))
                        //    {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        appsClientes[0].descargas = reader["descargas"].ToString();
                    }

                    reader.Close();           //break;
                        //    }

                        //}
                    //}


                    this._connectionObject.Close();
                    return appsClientes;


                }
            }
            catch (SqlException errMySql)
            {                            
                Console.WriteLine("mensajeMySql " + errMySql.Message);
                this._connectionObject.Close();
            }
            catch (Exception err)
            {               
                Console.WriteLine("mensaje programa " + err.Message);
                this._connectionObject.Close();
            }
            finally
            {

            }

            return appsClientes;
        }

        public List<clsDatosAppCliente> infoConsumoCliente(clParametros param)
        {
            List<clsDatosAppCliente> appsClientes = new List<clsDatosAppCliente>();
            string query = "select TD.Dispositivo as Dispositivo,  [coordenada].Lat as Latitud, [coordenada].Long as Longitud,  PU.asistencia as Asistencia, PU.id_usuario as Id , case when  D.id_tipo_servicio_default='1' " +
                                                                                                                                                                   " then 'Cilindro' " +
                                                                                                                                                                   " else " +
                                                                                                                                                                   " 'Estacionario' " +
                                                                                                                                                                   " end 'ServicioDefault' , D.es_principal, " +
                          " nombre+' '+apellidos as Nombre,telefono_principal,calle,colonia,numero	,ruta,	total consumo, D.Id as Id_domicilio, DPA.folio_sicogas, fecha_surtido, DCP.compania, DCP.planta , DPA.costo_asistencia, DPA.id_metodo_pago" +
                          " from Cat_TipoDispositivo TD, Dat_PerfilesUsuarios PU,Dat_Domicilios D, Dat_PedidosActuales DPA, Dat_Companias_Plantas DCP " +
                          " where TD.id=PU.id_dispositivo " +
                          " and  D.id=DPA.id_domicilio " +
                          " and DPA.id_usuario= PU.id_usuario " +
                          " and id_estatus_pedido=50 "+
                          " and DCP.id= DPA.id_compania " +
                          " and total >=" + param.paramString1  +
                          " and DCP.server_app='" + param.paramSrv + "' " +
                          " and DPA.fecha_pedido >='" + param.fechaI.ToString("yyyy-MM-dd 00:00:00") + "'   and  DPA.fecha_pedido<= '" + param.fechaF.ToString("yyyy-MM-dd 23:59:59") + "' ";
                            if (!String.IsNullOrWhiteSpace(param.paramRuta))
                            {
                                query += " and ruta like '%" + param.paramRuta + "%' ";
                            }
                            if (!String.IsNullOrWhiteSpace(param.paramCia) && !String.IsNullOrWhiteSpace(param.paramPla))
                            {
                                query += " and DCP.compania='" + param.paramCia + "' "; 
                                query += " and DCP.planta='" + param.paramPla + "' ";
                            }

                            //query += " group by   TD.Dispositivo,  [coordenada].Lat, [coordenada].Long,  PU.asistencia , PU.id_usuario  ,   D.id_tipo_servicio_default, D.es_principal,nombre+' '+apellidos,telefono_principal,calle,colonia,numero,ruta " +
                            //         " having sum(total)>=" + param.paramString1+ " "; 

            string strResult = string.Empty;


            try
            {
                Connect();

                if (strResult.Equals(string.Empty))
                {
                    this._commandObject = new SqlCommand(query, this._connectionObject);
                    reader = this._commandObject.ExecuteReader();
                    while (reader.Read())
                    {
                        clsDatosAppCliente appcliente = new clsDatosAppCliente();
                        appcliente.Id = reader["Id"].ToString();
                        appcliente.Pedidos = "0";
                        appcliente.Dispositivo = reader["dispositivo"].ToString();
                        appcliente.Latitud = reader["Latitud"].ToString();
                        appcliente.Longitud = reader["Longitud"].ToString();
                        appcliente.Asistencia = reader["Asistencia"].ToString();
                        appcliente.ServicioDefault = reader["ServicioDefault"].ToString();
                        appcliente.principal = reader["es_principal"].ToString();
                        appcliente.telefono_principal = reader["telefono_principal"].ToString();
                        appcliente.calle = reader["calle"].ToString();
                        appcliente.colonia = reader["colonia"].ToString();
                        appcliente.numero = reader["numero"].ToString();
                        appcliente.consumo = reader["consumo"].ToString();
                        appcliente.ruta = reader["ruta"].ToString();
                        appcliente.Nombre = reader["Nombre"].ToString();
                        appcliente.Pedidos = "1";
                        appcliente.Id_domicilio = reader["Id_domicilio"].ToString();
                        appcliente.folio_sicogas = reader["folio_sicogas"].ToString();
                        appcliente.fecha_surtido = reader["fecha_surtido"].ToString();
                        appcliente.compania= reader["compania"].ToString();
                        appcliente.planta = reader["planta"].ToString();
                        appcliente.costo_asistencia = reader["costo_asistencia"].ToString();
                        appcliente.id_metodo_pago = reader["id_metodo_pago"].ToString();
                        appsClientes.Add(appcliente);

                    }
                   
               

                   

                    reader.Close();          
                

                    this._connectionObject.Close();
                    return appsClientes;


                }
            }
            catch (SqlException errMySql)
            {
                Console.WriteLine("mensajeMySql " + errMySql.Message);
                this._connectionObject.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("mensaje programa " + err.Message);
                this._connectionObject.Close();
            }
            finally
            {

            }

            return appsClientes;
        }

        public List<clsDatosAppCliente> infoPedidosCliente(String idCliente)
        {
            List<clsDatosAppCliente> appsClientes = new List<clsDatosAppCliente>();
            string query = " select DPA.nombre_recibe as 'Nombre', DPA.fecha_envio as 'Fecha_Pedido',  CEP.estatus as 'Estado_Pedido', DPA.telefono_contacto as 'Telefono', DPA.fecha_surtido as 'Fecha_Surtido', DCP.ruta as 'ruta', DPA.total  consumo" +
                            " from Dat_PedidosActuales DPA,Cat_EstatusPedidos CEP, Dat_Companias_Plantas DCP  " +
                            " where id_usuario='"+idCliente+"'  " +
                            " and DPA.id_estatus_pedido=CEP.id  " +
                            " and DCP.id=DPA.id_compania  order by DPA.fecha_envio asc ";

            string strResult = string.Empty;


            try
            {
                Connect();

                if (strResult.Equals(string.Empty))
                {
                    this._commandObject = new SqlCommand(query, this._connectionObject);
                    reader = this._commandObject.ExecuteReader();
                    while (reader.Read())
                    {
                        clsDatosAppCliente appcliente = new clsDatosAppCliente();
                        appcliente.Nombre = reader["Nombre"].ToString();
                        appcliente.Fecha_Pedido = reader["Fecha_Pedido"].ToString();
                        appcliente.Estado_Pedido = reader["Estado_Pedido"].ToString();
                        appcliente.Telefono = reader["Telefono"].ToString();
                        appcliente.Fecha_Surtido = reader["Fecha_Surtido"].ToString();
                        appcliente.ruta = reader["ruta"].ToString();
                        appcliente.consumo = reader["consumo"].ToString();
                        appsClientes.Add(appcliente);

                    }
                   

                    this._connectionObject.Close();
                    return appsClientes;


                }
            }
            catch (SqlException errMySql)
            {
                Console.WriteLine("mensajeMySql " + errMySql.Message);
                this._connectionObject.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine("mensaje programa " + err.Message);
                this._connectionObject.Close();
            }
            finally
            {

            }

            return appsClientes;
        }

        public List<clsDat_Pedidos_Actuales> getPedidosAppXidDom(clParametros param)
        {
            List<clsDat_Pedidos_Actuales> li = new List<clsDat_Pedidos_Actuales>();
            string query = "SELECT * "+
                           "  FROM [GasExpressNieto].[dbo].[Dat_PedidosActuales] "+ 
                           "   where "+
                           "   id_domicilio in (" + param.paramString1.Substring(0, param.paramString1.Length-1) + ")  " +
                           "   and fecha_surtido >='" + param.fechaI.ToString("yyyy-MM-dd") + "' and fecha_surtido<='" + param.fechaF.ToString("yyyy-MM-dd") + "' and id_estatus_pedido=50 " +
                           "   union  "+
                           "   SELECT * "+
                           "   FROM [GasExpressNieto].[dbo].[Dat_PedidosActuales_Perf] "+ 
                           "   where "+
                           "   id_domicilio in (" + param.paramString1.Substring(0, param.paramString1.Length - 1) + ") " +
                           "   and fecha_surtido >='" + param.fechaI.ToString("yyyy-MM-dd") + "' and fecha_surtido<='" + param.fechaF.ToString("yyyy-MM-dd") + "'  and id_estatus_pedido=50;";
            

            string strResult = string.Empty;


            try
            {
                Connect();

                if (strResult.Equals(string.Empty))
                {
                    this._commandObject = new SqlCommand(query, this._connectionObject);
                    reader = this._commandObject.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Columns.Clear();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dt.Columns.Add(reader.GetName(i));
                    }
                    dt.Load(reader);
                    string JSONresult = JsonConvert.SerializeObject(dt);
                    li = JsonConvert.DeserializeObject<List<clsDat_Pedidos_Actuales>>(JSONresult);
                    reader.Close();
                    this._connectionObject.Close();
                    return li;
                }
            }
            catch (SqlException errMySql)
            {
                
                this._connectionObject.Close();
            }
            catch (Exception err)
            {
                
                this._connectionObject.Close();
            }
            finally
            {

            }

            return li;
        }
    
        #endregion

        #region [--CLASS CONSTRUCTOR--]

        /// <summary>
        /// class constructor for the class
        /// </summary>

        public clsConexionAnalizerUbiqo()
        {
            try
            {
                this._strConnextionString = ConfigurationManager.AppSettings["SQLServerUbiqo"].ToString(); ;
                //ConfigurationManager.AppSettings["MysqlConnVariaciones"].ToString();
                //string cadena = (ConfigurationManager.AppSettings["csCentralDB"]).ToString();
                //Console.WriteLine("cadena de conexion"+this._strConnextionString);
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("cadena de conexion" + this._strConnextionString);
            }
        }

        #endregion
    }
}
