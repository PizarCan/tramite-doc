using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Documento;
using Integration.Conection;

namespace Integration.DAService
{
    public class DADocumento
    {
        public BE_Res_Documento getCorrelativoBynDocTipo_nPrdCodigo(BE_Req_Documento Request)
        {
            BE_Res_Documento Item = new BE_Res_Documento();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_CorrelativoByPeriodo_nDocTipo_cPerCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nPrdCodigo", Request.nPrdCodigo);
                        cm.Parameters.AddWithValue("nDocTipo", Request.nDocTipo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cNumero = dr.GetString(dr.GetOrdinal("Num"));
                            }
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
