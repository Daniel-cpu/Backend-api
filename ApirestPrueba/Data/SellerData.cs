using ApirestPrueba.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ApirestPrueba.Data
{
    public class SellerData
    {
        public static bool InsertarSeller(Seller oSeller)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("insertar_seller", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODE", oSeller.CODE);
                cmd.Parameters.AddWithValue("@NAME", oSeller.NAME);
                cmd.Parameters.AddWithValue("@LAST_NAME", oSeller.LAST_NAME);
                cmd.Parameters.AddWithValue("@DOCUMENT", oSeller.DOCUMENT);
                cmd.Parameters.AddWithValue("@CITY_ID", oSeller.CITY_ID);

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
        public static bool ModificarSeller(Seller oSeller)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("modificar_seller", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CODE", oSeller.CODE);
                cmd.Parameters.AddWithValue("@NAME", oSeller.NAME);
                cmd.Parameters.AddWithValue("@LAST_NAME", oSeller.LAST_NAME);
                cmd.Parameters.AddWithValue("@DOCUMENT", oSeller.DOCUMENT);
                cmd.Parameters.AddWithValue("@CITY_ID", oSeller.CITY_ID);

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
        public static List<Seller> LeerSeller()
        {
            List<Seller> oListaSeller = new List<Seller>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("leer_seller", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaSeller.Add(new Seller()
                            {
                                CODE = Convert.ToInt32(dr["CODE"]),
                                NAME = Convert.ToString(dr["NAME"]),
                                LAST_NAME = Convert.ToString(dr["LAST_NAME"]),
                                DOCUMENT = Convert.ToString(dr["DOCUMENT"]),
                                CITY_ID = Convert.ToInt32(dr["CITY_ID"])
                            });

                        }
                    }
                    return oListaSeller;
                }
                catch (Exception ex)
                {
                    return oListaSeller;
                }
            }

        }
        public static Seller ObtenerSeller(int Code)
        {
            Seller oSeller = new Seller();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("obtener_seller", oConexion);
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
                            oSeller = new Seller()
                            {
                                CODE = Convert.ToInt32(dr["CODE"]),
                                NAME = Convert.ToString(dr["NAME"]),
                                LAST_NAME = Convert.ToString(dr["LAST_NAME"]),
                                DOCUMENT = Convert.ToString(dr["DOCUMENT"]),
                                CITY_ID = Convert.ToInt32(dr["CITY_ID"])


                            };

                        }
                    }
                    return oSeller;
                }
                catch (Exception ex)
                {
                    return oSeller;
                }
            }

        }
        public static bool EliminarSeller(int Code)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("eliminar_seller", oConexion);
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