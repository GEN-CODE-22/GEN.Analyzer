using GENAnalizerWebETY.MySQL31;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENAnalizerWebDAL
{
  public  class clsConexionMySQL31
    {
        //Optiene un listado de usuarios de inicio de sesion
        /// Metodo utilizado en proyecto ANALYZER
        /// Hecho por Hector Aleman Pineda
        /// Fecha: 2021-09-14
        /// Email: haleman@gasexpressnieto.com.mx
        /// Fecha de modificaicon: 2021-09-14
        /// <returns>List<clsUsuariosAnr> </returns>
        /// 
        public List<clsUsuariosAnr> getUsrAnr(clsUsuariosAnr usr)
        {
            MySqlConnection _connectionObject = null;
            MySqlDataAdapter _adapterObject;
            MySqlCommand _commandObject = null;
            MySqlDataReader _reader;
            string _strConnextionString;
            List<clsUsuariosAnr> ls = new List<clsUsuariosAnr>();
            try
            {
                _strConnextionString = ConfigurationManager.ConnectionStrings["MySql31_Analyzer"].ToString();
                _connectionObject = new MySqlConnection(_strConnextionString);
                _connectionObject.Open();
                if (_connectionObject.State.ToString().Equals("Open"))
                {
                    _commandObject = new MySqlCommand("SELECT * FROM analyzer.usuarios where usr_usr='" + usr.usr_usr.ToUpper().Trim() + "' and pwd_usr='" + usr.pwd_usr.ToUpper().Trim() + "' ", _connectionObject);
                   
                    _reader = _commandObject.ExecuteReader();
                    if (_reader.HasRows)
                    {


                        DataTable dt = new DataTable();
                        dt.Columns.Clear();
                        List<string> encabezados = new List<string>();
                        List<string> encabezadosAux = new List<string>();
                        for (int i = 0; i < _reader.FieldCount; i++)
                        {
                            encabezadosAux = encabezados.Where(x => x.StartsWith(_reader.GetName(i))).ToList<String>();
                            if (encabezadosAux.Count <= 0)
                            {
                                dt.Columns.Add(_reader.GetName(i));
                            }
                            encabezados.Add(_reader.GetName(i));
                            encabezadosAux.Clear();
                        }
                        dt.Load(_reader);
                        string JSONresult = JsonConvert.SerializeObject(dt);
                        ls = JsonConvert.DeserializeObject<List<clsUsuariosAnr>>(JSONresult);

                    }
                }

            }
            catch (Exception ex)
            {

                _connectionObject.Dispose();
                _connectionObject.Close();
            }

            _connectionObject.Dispose();
            _connectionObject.Close();
            return ls;

        }

        //Actualiza el registro de un usuarrio
        /// Metodo utilizado en proyecto ANALYZER
        /// Hecho por Hector Aleman Pineda
        /// Fecha: 2021-09-15
        /// Email: haleman@gasexpressnieto.com.mx
        /// Fecha de modificaicon: 2021-09-15
        /// <returns>List<clsUsuariosAnr> </returns>
        /// 
        public clsUsuariosAnr uptUsrAnr(clsUsuariosAnr usr)
        {
            MySqlConnection _connectionObject = null;
            MySqlDataAdapter _adapterObject;
            MySqlCommand _commandObject = null;
            MySqlDataReader _reader;
            string _strConnextionString;
            List<clsUsuariosAnr> ls = new List<clsUsuariosAnr>();
            try
            {
                _strConnextionString = ConfigurationManager.ConnectionStrings["MySql31_Analyzer"].ToString();
                _connectionObject = new MySqlConnection(_strConnextionString);
                _connectionObject.Open();
                if (_connectionObject.State.ToString().Equals("Open"))
                {
                    _commandObject = new MySqlCommand("Update analyzer.usuarios set cia_usr='"+usr.cia_usr+"', pla_usr='"+usr.pla_usr+"' where id_usr="+usr.id_usr+"; ", _connectionObject);

                    if (!(_commandObject.ExecuteNonQuery()>=1))
                    {
                        usr = new clsUsuariosAnr();
                    }
                    
                   
                }

            }
            catch (Exception ex)
            {

                _connectionObject.Dispose();
                _connectionObject.Close();
            }

            _connectionObject.Dispose();
            _connectionObject.Close();
            return  usr;

        }

        // Obtiene el registro de un equipo de computo
        /// Metodo utilizado en proyecto ANALYZER
        /// Hecho por Hector Aleman Pineda
        /// Fecha: 2022-06-21
        /// Email: haleman@gasexpressnieto.com.mx
        /// Fecha de modificaicon: 2022-06-21
        /// <returns>List<clsUsuariosAnr> </returns>
        /// 
        public clsEquipoComputo GetEpoCom(string ip)
        {
            MySqlConnection _connectionObject = null;
            MySqlDataAdapter _adapterObject;
            MySqlCommand _commandObject = null;
            MySqlDataReader _reader;
            string _strConnextionString;
            List<clsEquipoComputo> ls = new List<clsEquipoComputo>();
            try
            {
                _strConnextionString = ConfigurationManager.ConnectionStrings["MySql31_EquiposComputo"].ToString();
                _connectionObject = new MySqlConnection(_strConnextionString);
                _connectionObject.Open();
                if (_connectionObject.State.ToString().Equals("Open"))
                {
                    _commandObject = new MySqlCommand("SELECT * FROM equipos_computo.pc_s where ip_pc='"+ip.Trim()+"';", _connectionObject);

                    _reader = _commandObject.ExecuteReader();
                    if (_reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Clear();
                        List<string> encabezados = new List<string>();
                        List<string> encabezadosAux = new List<string>();
                        for (int i = 0; i < _reader.FieldCount; i++)
                        {
                            encabezadosAux = encabezados.Where(x => x.StartsWith(_reader.GetName(i))).ToList<String>();
                            if (encabezadosAux.Count <= 0)
                            {
                                dt.Columns.Add(_reader.GetName(i));
                            }
                            encabezados.Add(_reader.GetName(i));
                            encabezadosAux.Clear();
                        }
                        dt.Load(_reader);
                        string JSONresult = JsonConvert.SerializeObject(dt);
                        ls = JsonConvert.DeserializeObject<List<clsEquipoComputo>>(JSONresult);

                    }
                }

            }
            catch (Exception ex)
            {

                _connectionObject.Dispose();
                _connectionObject.Close();
            }

            _connectionObject.Dispose();
            _connectionObject.Close();
            if (ls.Count>0)
            {
                return ls[0];
            }
            else
            {
                return new clsEquipoComputo();
            }

        }
    }
}
