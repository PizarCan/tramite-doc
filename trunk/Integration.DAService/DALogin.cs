using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Login;
using Integration.Conection;

namespace Integration.DAService
{
    public class DALogin
    {
        public BE_Res_Login ValidaterUser(BE_Req_Login Request)
        {
            BE_Res_Login Item = new BE_Res_Login();
         try
        { 
             clsConection Obj = new clsConection();
             string Cadena = Obj.GetConexionString("Naylamp");
             
             using (SqlConnection cn = new SqlConnection(Cadena))
             {
                 cn.Open();

                using (SqlCommand cm = new SqlCommand())
                {
                    cm.CommandText = "sp_User_Validate";
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("cPerUsuCodigo",Request.cPerUsuCodigo);
                    cm.Parameters.AddWithValue("cPerUsuClave",Request.cPerUsuClave);
                    cm.Connection = cn;
                     using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cPerCodigo = dr.GetString(dr.GetOrdinal("cPerCodigo")).Trim();
                                Item.cPerApellido = dr.GetString(dr.GetOrdinal("cPerApellido"));
                                Item.cPerNombre= dr.GetString(dr.GetOrdinal("cPerNombre"));
                                Item.cPerAlias = dr.GetString(dr.GetOrdinal("Alias"));
                                Item.cPerKey = dr.GetString(dr.GetOrdinal("cPerKey"));
                            }
                        }

                }
             }

        }
        catch (Exception )
        {
            throw ;
        }
        return Item;
        }

    }
}
