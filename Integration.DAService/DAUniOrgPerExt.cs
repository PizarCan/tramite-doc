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


    }
}
