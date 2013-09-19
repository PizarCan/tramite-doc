using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.PerUsuGruAcc;
using Integration.Conection;

namespace Integration.DAService
{
    public class DAPerUsuGruAcc
    {
        public IList<BE_Res_PerUsuGruAcc> ObtenerPermisos(BE_Req_PerUsuGruAcc Request)
        {
            BE_Res_PerUsuGruAcc Item = new BE_Res_PerUsuGruAcc();
            var lista = new List<BE_Res_PerUsuGruAcc>();

            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "spTD_Obtener_Permisos";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nSisGruTipo", Request.nSisGruTipo);
                        cm.Parameters.AddWithValue("nObjTipo", Request.nObjTipo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            lista.Clear();
                            while (dr.Read())
                            {
                                Item = new BE_Res_PerUsuGruAcc();
                                Item.cPerCodigo = dr.GetString(dr.GetOrdinal("cPerCodigo")).Trim();
                                Item.cIntNombre = dr.GetString(dr.GetOrdinal("cIntNombre")).Trim();
                                Item.nIntCodigo = dr.GetInt32(dr.GetOrdinal("nIntCodigo"));
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

        public Boolean setPerUsuGruAcc(BE_Req_PerUsuGruAcc Request)
        {
            Boolean Item = new Boolean();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_set_PerUsuGruAcc";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nSisGruTipo", Request.nSisGruTipo);
                        cm.Parameters.AddWithValue("nObjTipo", Request.nObjTipo);
                        cm.Parameters.AddWithValue("nObjCodigo", Request.nObjCodigo);
                        cm.Parameters.AddWithValue("nSisGruCodigo", Request.nSisGruCodigo);
                        cm.Connection = cn;
                        if (cm.ExecuteNonQuery() > 0)
                        {
                            Item = true;
                        }
                        else
                        {
                            Item = false;
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Item;
        }


        public Boolean delPerUsuGruAcc(BE_Req_PerUsuGruAcc Request)
        {
            Boolean Item = new Boolean();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_del_PerUsuGruAcc";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nObjTipo", Request.nObjTipo);
                        cm.Parameters.AddWithValue("nSisGruTipo", Request.nSisGruTipo);
                        cm.Connection = cn;
                        if (cm.ExecuteNonQuery() >= 0)
                        {
                            Item = true;
                        }
                        else
                        {
                            Item = false;
                        }


                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return Item;
        }


    }
}
