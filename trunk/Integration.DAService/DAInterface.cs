using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Interface;
using Integration.Conection;


namespace Integration.DAService
{
    public class DAInterface
    {

        public BE_Res_Interface getInterface(BE_Req_Interface Request)
        {
            BE_Res_Interface Item = new BE_Res_Interface();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_Interface";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nIntClase", Request.nIntClase);
                        cm.Parameters.AddWithValue("nIntCodigo", Request.nIntCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.nIntClase = dr.GetInt32(dr.GetOrdinal("nIntClase"));
                                Item.nIntCodigo = dr.GetInt32(dr.GetOrdinal("nIntCodigo"));
                                Item.nIntTipo = dr.GetInt32(dr.GetOrdinal("nIntTipo"));
                                Item.cIntDescripcion = dr.GetString(dr.GetOrdinal("cIntDescripcion"));
                                Item.cIntJerarquia = dr.GetString(dr.GetOrdinal("cIntJerarquia"));
                                Item.cIntNombre = dr.GetString(dr.GetOrdinal("cIntNombre"));
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
