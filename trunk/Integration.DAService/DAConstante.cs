using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Constante;
using Integration.Conection;

namespace Integration.DAService
{
    public class DAConstante
    {
        public IList<BE_Res_Constante> ListarConstantes(BE_Req_Constante Request)
        {
            BE_Res_Constante Item = new BE_Res_Constante();
            var lista = new List<BE_Res_Constante>();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_ListarConstante";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nConCodigo", Request.nConCodigo);
                        cm.Parameters.AddWithValue("nConValor", Request.nConValor);
                        cm.Parameters.AddWithValue("ConLeft", Request.ConLeft);
                        cm.Parameters.AddWithValue("ConValLeft", Request.ConValLeft);
                        cm.Parameters.AddWithValue("ConRight", Request.ConRight);
                        cm.Parameters.AddWithValue("ConValRight", Request.ConValRight);
                        cm.Parameters.AddWithValue("NotIn", Request.NotIn);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_Constante();
                                Item.nConValor = dr.GetInt32(dr.GetOrdinal("nConValor"));
                                Item.cConDescripcion = dr.GetString(dr.GetOrdinal("cConDescripcion")).Trim();
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

        public IList<BE_Res_Constante> Get_ConstantesBynConValor (BE_Req_Constante Request)
        {
            BE_Res_Constante Item = new BE_Res_Constante();
            var lista = new List<BE_Res_Constante>();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_Get_Constantes_BynConCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nConCodigo", Request.nConCodigo);
                        cm.Parameters.AddWithValue("cConValor", Request.cConValor);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_Constante();
                                Item.nConValor = dr.GetInt32(dr.GetOrdinal("nConValor"));
                                Item.cConDescripcion = dr.GetString(dr.GetOrdinal("cConDescripcion")).Trim();
                                Item.nConCodigo = dr.GetInt32(dr.GetOrdinal("nConCodigo"));
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
