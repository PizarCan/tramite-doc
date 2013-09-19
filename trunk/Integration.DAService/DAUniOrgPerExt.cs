using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.UniOrgPerExt;
using Integration.Conection;

namespace Integration.DAService
{
    public class DAUniOrgPerExt
    {
        public DataTable ObtenerUniOrgBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {
            //BE_Res_UniOrgPerExt Item = new BE_Res_UniOrgPerExt();
            // var lista = new List<BE_Res_UniOrgPerExt>();
            DataTable lista = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "SP_TraDoc_Procesos";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("Opcion", 19);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Clear();
                            //while (dr.Read())
                            //{
                            //    Item = new BE_Res_UniOrgPerExt();
                            //    Item.cIntDescripcion = dr.GetString(dr.GetOrdinal("cIntDescripcion")).Trim();
                            //    Item.nUniOrgCodigo = dr.GetInt32(dr.GetOrdinal("nUniOrgCodigo"));
                            //    lista.Add(Item);
                            //}
                            lista.Load(dr);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public DataTable ObtenerInstitucionesBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {
            DataTable lista = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_Instituciones_BycPerCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Load(dr);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public DataTable ObtenerAreaByPersonaInstitucion(BE_Req_UniOrgPerExt Request)
        {
             
            DataTable lista = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_ListaArea_ByPersona_Institucion";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("cUniCodigo", Request.cUniCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Load(dr);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public DataTable GetAreaByInstitucion(BE_Req_UniOrgPerExt Request)
        {
            DataTable lista = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_ListaAreaByInstitucion";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Load(dr);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public DataTable GetInstituciones()
        {
            DataTable lista = new DataTable();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_ListaInstituciones";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Load(dr);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }



    }
}
