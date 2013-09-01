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
        public DataTable ListaPersonas_BycPerApellido(BE_Req_Persona Request)
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
                        cm.CommandText = "sp_ListaPersonas_BycPerApellido";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerApellido", Request.cPerApellido);
                        cm.Parameters.AddWithValue("cPerNombre", Request.cPerNombre);
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

        public BE_Res_Persona getcPerCodigoNew()
        {
            BE_Res_Persona Item = new BE_Res_Persona();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_cPerCodigoNew";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cPerCodigo = dr.GetString(dr.GetOrdinal("cPerCodigoNew"));
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

        public Boolean setPersona(BE_Req_Persona Request)
        {
            Boolean Item = new Boolean();
            string codigo = "";
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_set_Persona";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("cPerApellido", Request.cPerApellido);
                        cm.Parameters.AddWithValue("cPerNombre", Request.cPerNombre);
                        cm.Parameters.AddWithValue("nPerTipo", Request.nPerTipo);
                        cm.Parameters.AddWithValue("cUbiGeoCodigo", Request.cUbiGeoCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                codigo = dr.GetString(dr.GetOrdinal("cPerCodigo")).ToString();
                            }
                        }

                        if (codigo.Equals(""))
                        {
                            Item = false;
                        }
                        else
                        {
                            Item = true;
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

        public string getDelegadoAnduser(BE_Req_Persona Request)
        {
            string codigo = "";
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_get_UserAndDelegado";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                codigo = dr.GetString(dr.GetOrdinal("cPerCodigo")).ToString();
                            }
                            if (codigo.Equals(""))
                            {
                                codigo = Request.cPerCodigo;
                            }
                            else
                            {
                                codigo += Request.cPerCodigo;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigo;

        }

        public Boolean setDelegado(BE_Req_Persona Request)
        {
            Boolean Item = new Boolean();
            string cPerParCodigo = "";
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_set_Delegado";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@PerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("@Parentesco", Request.nPerParTipo);
                        cm.Parameters.AddWithValue("@DelCodigo", Request.cPerParCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                cPerParCodigo = dr.GetString(dr.GetOrdinal("cPerParCodigo")).ToString();
                            }
                        }

                        if (cPerParCodigo.Equals(""))
                        {
                            Item = false;
                        }
                        else
                        {
                            Item = true;
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

        public Boolean delDelegado(BE_Req_Persona Request)
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
                        cm.CommandText = "sp_del_Delegado";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("@cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("@nPerParTipo", Request.nPerParTipo);
                        cm.Parameters.AddWithValue("@cPerParCodigo", Request.cPerParCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        { 
                            Item = true;
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
