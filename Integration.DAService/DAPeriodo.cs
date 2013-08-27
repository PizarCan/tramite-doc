using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Periodo;
using Integration.Conection;

namespace Integration.DAService
{
    public class DAPeriodo
    {
        public BE_Res_Periodo get_PeriodoActual_ByActividad(BE_Req_Periodo Request)
        {
            BE_Res_Periodo Item = new BE_Res_Periodo();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_PeriodoActual_ByActividad";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nPrdActividad", Request.nPrdActividad);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cPrdDescripcion = dr.GetString(dr.GetOrdinal("cPrdDescripcion")).Trim();
                                Item.nPrdCodigo = dr.GetInt32(dr.GetOrdinal("nPrdCodigo"));
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

        public DataTable GetPeriodosByActividad(BE_Req_Periodo Request)
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
                        cm.CommandText = "sp_get_PeriodosByActividad";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("nPrdActividad", Request.nPrdActividad);
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
