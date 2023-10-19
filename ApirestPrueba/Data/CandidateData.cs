using ApirestPrueba.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ApirestPrueba.Data
{
    public class CandidateData    { 
        public static bool Insertar(candidates oCandidate)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion)) // SE CREA CONEXIÓN CON LA DB
            {
                SqlCommand cmd = new SqlCommand("InsertCandidate", oConexion);//SE CREA UN OBJETO DE TIPO SqlCommand "cmd" QUE EJECUTA EL PROCEDIMIENTO ALMACENADO InsertCandidate
                cmd.CommandType = CommandType.StoredProcedure;// SE ESPECIFICA EL TIPO DE CONSULTA SQL EN ESTE CASO UN PROCEDIMIENTO ALMACENADO
                cmd.Parameters.AddWithValue("@id_candidate", oCandidate.ID_CANDIDATE);//SE REALIZA EL LLANADO DE LOS DATOS EN LAS VARIABLES SQL ATRA VEZ DE UN OBJETO DE TIPO oCandidate QUE HACE REFERENCIA AL MODELO DE LA TABLA Candidate
                cmd.Parameters.AddWithValue("@name", oCandidate.NAME);
                cmd.Parameters.AddWithValue("@surname", oCandidate.SURNAME);
                cmd.Parameters.AddWithValue("@birthdate", oCandidate.BIRTHDATE.ToUniversalTime());
                cmd.Parameters.AddWithValue("@email", oCandidate.EMAIL);
               


                try// SE REALIZA EL TRY CATCH PARA EL MANEJO ADECUAD DE LAS EXPECEPCIONES PRESENTADAS EN LA CONSULTA
                {
                    oConexion.Open(); //SE ESTABLE CONEXIÓN CON LA DB
                    cmd.ExecuteNonQuery(); // SE EJECUTA LA CONSULTA
                    return true;// SI LA CONSULTA ES EXITOSA DEVULEVE UN TRUE 
                }
                catch (Exception ex) // SE CAPTURA EXCEPTION DE LA EJECUCIÓN DE LA CONSULTA
                {
                    string error = "Error: " + ex.Message; // SE AGREGA EXTRING CON LA INFORMACIÓN DE LA EXPECIÓN 
                    return false;// SI LA CONSULTA ES EXITOSA DEVULEVE UN FALSE 
                }
            }

        }
        public static bool Modificar(candidates oCandidate)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("ModifyCandidate", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_candidate", oCandidate.ID_CANDIDATE);
                cmd.Parameters.AddWithValue("@name", oCandidate.NAME);
                cmd.Parameters.AddWithValue("@surname", oCandidate.SURNAME);
                cmd.Parameters.AddWithValue("@birthdate", oCandidate.BIRTHDATE.ToUniversalTime());
                cmd.Parameters.AddWithValue("@email", oCandidate.EMAIL);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    string error = "Error: " + ex.Message;
                    return false;
                }
            }

        }
        public static List<candidates> Leer() //SE GENERA UNA CLASE PUBLICA Y ESTATICA
        {
            List<candidates> oListaCandidates = new List<candidates>();// SE CREA NUESTRO OBJETO DE TIPO LISTA BASADI
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("read_candidate", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaCandidates.Add(new candidates()
                            {

                                ID_CANDIDATE = Convert.ToInt32(dr["idcandidate"]),
                                NAME = Convert.ToString(dr["name"]),
                                SURNAME = Convert.ToString(dr["surname"]),
                                BIRTHDATE = Convert.ToDateTime(dr["birthdate"]),
                                EMAIL = Convert.ToString(dr["email"]),
                                INSERTDATE = (dr["insertdate"] != DBNull.Value) ? Convert.ToDateTime(dr["insertdate"]) : DateTime.MinValue,
                                MODIFYDATE = (dr["modifydate"] != DBNull.Value) ? Convert.ToDateTime(dr["modifydate"]) : DateTime.MinValue



                            }); 

                        }
                    }
                    return oListaCandidates;
                }
                catch (Exception ex)
                {
                    string error ="Error: " + ex.Message;
                    return oListaCandidates;
                }
            }

        }
        public static candidates Obtener(int id_candidate)
        {
            candidates oCandidate = new candidates();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("SearchCandidate", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_candidate", id_candidate);
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCandidate = new candidates()
                            {

                                ID_CANDIDATE = Convert.ToInt32(dr["idcandidate"]),
                                NAME = Convert.ToString(dr["name"]),
                                SURNAME = Convert.ToString(dr["surname"]),
                                BIRTHDATE = Convert.ToDateTime(dr["birthdate"]),
                                EMAIL = Convert.ToString(dr["email"]),
                                INSERTDATE = (dr["insertdate"] != DBNull.Value) ? Convert.ToDateTime(dr["insertdate"]) : DateTime.MinValue,
                                MODIFYDATE = (dr["modifydate"] != DBNull.Value) ? Convert.ToDateTime(dr["modifydate"]) : DateTime.MinValue


                            };

                        }
                    }
                    return oCandidate;
                }
                catch (Exception ex)
                {
                    return oCandidate;
                }
            }

        }
        public static bool Eliminar(int id_candidate)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("DeleteCandidate", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_candidate", id_candidate);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }
}