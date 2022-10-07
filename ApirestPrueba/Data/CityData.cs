using ApirestPrueba.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApirestPrueba.Data
{
    public class CityData
    {
        public static bool Insertar(City oCity)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("insertar_city", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODE", oCity.CODE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", oCity.DESCRIPTION);

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
        public static bool Modificar(City oCity)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("modificar_city", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODE", oCity.CODE);
                cmd.Parameters.AddWithValue("@DESCRIPTION", oCity.DESCRIPTION);

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
        public static List<City> Leer()
        {
            List<City> oListaCity = new List<City>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("leer_city", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaCity.Add(new City()
                            {
                                CODE = Convert.ToInt32(dr["CODE"]),
                                DESCRIPTION = Convert.ToString(dr["DESCRIPTION"])


                            });

                        }
                    }
                    return oListaCity;
                }
                catch (Exception ex)
                {
                    return oListaCity;
                }
            }

        }
        public static City Obtener(int Code)
        {
            City oCity = new City();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("obtener_city", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODE", Code);
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCity = new City()
                            {
                                CODE = Convert.ToInt32(dr["CODE"]),
                                DESCRIPTION = Convert.ToString(dr["DESCRIPTION"])


                            };

                        }
                    }
                    return oCity;
                }
                catch (Exception ex)
                {
                    return oCity;
                }
            }

        }
        public static bool Eliminar(int Code)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar_city", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODE", Code);

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