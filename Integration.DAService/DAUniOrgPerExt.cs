﻿using System;
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
        public IList<BE_Res_UniOrgPerExt> ObtenerUniOrgBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {
            BE_Res_UniOrgPerExt Item = new BE_Res_UniOrgPerExt();
            var lista = new List<BE_Res_UniOrgPerExt>();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_UniOrgBycPerCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_UniOrgPerExt();
                                Item.cIntDescripcion = dr.GetString(dr.GetOrdinal("cIntDescripcion")).Trim();
                                Item.nUniOrgCodigo = dr.GetInt32(dr.GetOrdinal("nUniOrgCodigo"));
                                lista.Add(Item);
                                //dr.NextResult();
                            }
                            dr.Close();
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


        public IList<BE_Res_UniOrgPerExt> ObtenerInstitucionesBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {
            BE_Res_UniOrgPerExt Item = new BE_Res_UniOrgPerExt();
            var lista = new List<BE_Res_UniOrgPerExt>();

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
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_UniOrgPerExt();
                                Item.cPerCodigo = dr.GetString(dr.GetOrdinal("cPerCodigo")).Trim();
                                Item.cPernombre = dr.GetString(dr.GetOrdinal("cPerNombre"));
                                lista.Add(Item);
                                //dr.NextResult();
                            }
                            dr.Close();
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

        public IList<BE_Res_UniOrgPerExt> ObtenerAreaByPersonaInstitucion(BE_Req_UniOrgPerExt Request)
        {
            BE_Res_UniOrgPerExt Item = new BE_Res_UniOrgPerExt();
            var lista = new List<BE_Res_UniOrgPerExt>();

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
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_UniOrgPerExt();
                                Item.cIntDescripcion = dr.GetString(dr.GetOrdinal("cIntDescripcion")).Trim();
                                Item.nUniOrgCodigo = dr.GetInt32(dr.GetOrdinal("nUniOrgCodigo"));
                                lista.Add(Item);
                            }
                            dr.Close();
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