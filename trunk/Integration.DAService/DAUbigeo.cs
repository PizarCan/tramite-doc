using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Ubigeo;
using Integration.Conection;

namespace Integration.DAService
{
    public class DAUbigeo
    {
        public DataTable getUbigeoBycUbiGeoCodigo(BE_Req_Ubigeo Request)
        {
            DataTable Rs = new DataTable();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_getUbigeoBycUbiGeoCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cUbiGeoCodigo", Request.cUbiGeoCodigo);
                        cm.Connection = cn;

                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            Rs.Load(dr);
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Rs;
        
        }

    }
}
