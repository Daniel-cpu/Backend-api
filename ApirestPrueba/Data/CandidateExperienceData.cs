using ApirestPrueba.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApirestPrueba.Data
{
    public class CandidateExperienceData
    {
        public static bool InsertarCandidateExperience(CandidateExperience oCandidateExperience)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("InsertCandidateExperience", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcandidateexperience", oCandidateExperience.IDCANDIDATEEXPERIENCE);
                cmd.Parameters.AddWithValue("@idcandidate", oCandidateExperience.IDCANDIDATE);
                cmd.Parameters.AddWithValue("@company", oCandidateExperience.COMPANY);
                cmd.Parameters.AddWithValue("@job", oCandidateExperience.JOB);
                cmd.Parameters.AddWithValue("@description", oCandidateExperience.DESCRIPTION);
                cmd.Parameters.AddWithValue("@salary", oCandidateExperience.SALARY);
                cmd.Parameters.AddWithValue("@begindate", oCandidateExperience.BEGINDATE.ToUniversalTime());
                cmd.Parameters.AddWithValue("@enddate", oCandidateExperience.ENDDATE.ToUniversalTime());



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
        public static bool ModificarCandidateExperience(CandidateExperience oCandidateExperience)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("ModifyCandidateExpreience", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcandidateexperience", oCandidateExperience.IDCANDIDATEEXPERIENCE);
                cmd.Parameters.AddWithValue("@idcandidate", oCandidateExperience.IDCANDIDATE);
                cmd.Parameters.AddWithValue("@company", oCandidateExperience.COMPANY);
                cmd.Parameters.AddWithValue("@job", oCandidateExperience.JOB);
                cmd.Parameters.AddWithValue("@description", oCandidateExperience.DESCRIPTION);
                cmd.Parameters.AddWithValue("@salary", oCandidateExperience.SALARY);
                cmd.Parameters.AddWithValue("@begindate", oCandidateExperience.BEGINDATE);
                cmd.Parameters.AddWithValue("@enddate", oCandidateExperience.ENDDATE);
             

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
        public static List<CandidateExperience> ReadCandidateExperience()
        {
            List<CandidateExperience> oCandidateExperience = new List<CandidateExperience>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("read_candidateExperience", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCandidateExperience.Add(new CandidateExperience()
                            {
                                IDCANDIDATEEXPERIENCE = Convert.ToInt32(dr["idcandidateexperience"]),
                                IDCANDIDATE = Convert.ToInt32(dr["idcandidate"]),
                                COMPANY = Convert.ToString(dr["company"]),
                                JOB = Convert.ToString(dr["job"]),
                                DESCRIPTION = Convert.ToString(dr["description"]),
                                SALARY = Convert.ToInt32(dr["salary"]),
                                BEGINDATE = Convert.ToDateTime(dr["begindate"]),
                                ENDDATE = Convert.ToDateTime(dr["enddate"]),
                                INSERTDATE = (dr["insertdate"] != DBNull.Value) ? Convert.ToDateTime(dr["insertdate"]) : DateTime.MinValue,
                                MODIFYDATE = (dr["modifydate"] != DBNull.Value) ? Convert.ToDateTime(dr["modifydate"]) : DateTime.MinValue
                            });

                        }
                    }
                    return oCandidateExperience;
                }
                catch (Exception ex)
                {
                    string error = "Error: " + ex.Message;
                    return oCandidateExperience;
                }
            }

        }
        public static CandidateExperience ObtenerCandidateExperience(int idcandidateexperience)
        {
            CandidateExperience oCandidateExperience = new CandidateExperience();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("SeacrhCandidateExperience", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcandidateexperience", idcandidateexperience);
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCandidateExperience = new CandidateExperience()
                            {
                                IDCANDIDATEEXPERIENCE = Convert.ToInt32(dr["idcandidateexperience"]),
                                IDCANDIDATE = Convert.ToInt32(dr["idcandidate"]),
                                COMPANY = Convert.ToString(dr["company"]),
                                JOB = Convert.ToString(dr["job"]),
                                DESCRIPTION = Convert.ToString(dr["description"]),
                                SALARY = Convert.ToInt32(dr["salary"]),
                                BEGINDATE = Convert.ToDateTime(dr["begindate"]),
                                ENDDATE = Convert.ToDateTime(dr["enddate"]),
                                INSERTDATE = (dr["insertdate"] != DBNull.Value) ? Convert.ToDateTime(dr["insertdate"]) : DateTime.MinValue,
                                MODIFYDATE = (dr["modifydate"] != DBNull.Value) ? Convert.ToDateTime(dr["modifydate"]) : DateTime.MinValue


                            };

                        }
                    }
                    return oCandidateExperience;
                }
                catch (Exception ex)
                {
                    string error = "Error: " + ex.Message;
                    return oCandidateExperience;
                }
            }

        }
        public static bool EliminarCandidateExperience(int idcandidateexperience)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("DeleteCandidateExperience", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcandidateexperience", idcandidateexperience);

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
   

    }
}