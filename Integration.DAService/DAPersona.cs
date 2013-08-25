using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.Persona;
using Integration.Conection;

namespace Integration.DAService
{
    public class DAPersona
    {
        public DataTable ListaPersonas_BycPerCodigo(BE_Req_Persona Request)
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
                        cm.CommandText = "sp_ListaPersonas_BycPerCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerApellido", Request.cPerApellido);
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

        public DataTable ListaPersonas_BycPerCodigo_cPerRelTipo(BE_Req_Persona Request)
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
                        cm.CommandText = "sp_ListaPersonas_BycPerCodigo_cPerRelacion";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerApellido", Request.cPerApellido);
                        cm.Parameters.AddWithValue("cPerRelTipo", Request.cPerRelTipo);
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
