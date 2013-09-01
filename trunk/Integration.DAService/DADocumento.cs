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

        public BE_Res_Documento getDocumentoBycDocNDoc_nDocTipo(BE_Req_Documento Request)
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
                        cm.CommandText = "sp_get_DocumentoBycDocNDoc_nDocTipo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cDocNDoc", Request.cDocNDoc);
                        cm.Parameters.AddWithValue("nDocTipo", Request.nDocTipo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cDocCodigo = dr.GetString(dr.GetOrdinal("cDocCodigo"));
                                Item.nDocTipoNum = dr.GetInt16(dr.GetOrdinal("nDocTipoNum"));
                                Item.cDocNDoc = dr.GetString(dr.GetOrdinal("cDocNDoc"));
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

        public BE_Res_Documento getTipoPersona(BE_Req_Documento Request)
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
                        cm.CommandText = "sp_get_TipoPersona";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cPerCodigo = dr.GetString(dr.GetOrdinal("cPerCodigo"));
                                Item.nAdministrativo = dr.GetInt32(dr.GetOrdinal("Administrativo"));
                                Item.nAlumno = dr.GetInt32(dr.GetOrdinal("Alumno"));
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

        public BE_Res_Documento getUltimoDocumentoBycPerCodigo(BE_Req_Documento Request)
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
                        cm.CommandText = "sp_get_UltimoDocumentoBycPerCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Item.cDocNDoc = dr.GetString(dr.GetOrdinal("cDocNDoc"));
                                Item.dDocFecha = dr.GetDateTime(dr.GetOrdinal("dDocFecha"));
                                Item.cPerApellido = dr.GetString(dr.GetOrdinal("cPerApellido"));
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

        public Boolean setDocumento(BE_Req_Documento Request)
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
                        cm.CommandText = "sp_set_Documento";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cDocCodigo", Request.cDocCodigo);
                        cm.Parameters.AddWithValue("dDocFecha", Request.dDocFecha);
                        cm.Parameters.AddWithValue("cDocObserv", Request.cDocObserv);
                        cm.Parameters.AddWithValue("nDocTipo", Request.nDocTipo);
                        cm.Parameters.AddWithValue("nDocEstado", Request.nDocEstado);
                        cm.Parameters.AddWithValue("cAsunto", Request.Asunto);
                        cm.Parameters.AddWithValue("cDetalle", Request.Detalle);
                        cm.Parameters.AddWithValue("dFechaIni", Request.dFechaIni);
                        cm.Parameters.AddWithValue("dFechaFin", Request.dFechaFin);
                        cm.Parameters.AddWithValue("cNumDocumento", Request.cDocNDoc);
                        cm.Parameters.AddWithValue("nPrdCodigo", Request.nPrdCodigo);
                        cm.Parameters.AddWithValue("cCodPerSolicita", Request.CodPerSolicita);
                        cm.Parameters.AddWithValue("nPerRelSolicita", Request.PerRelSolicita);
                        cm.Parameters.AddWithValue("nCodUORemite", Request.CodUORemite);
                        cm.Parameters.AddWithValue("nDocPerTipo", Request.nDocPerTipo);
                        cm.Parameters.AddWithValue("cCodPerRegistra", Request.CodPerRegistra);
                        cm.Parameters.AddWithValue("cCodPerRecibe", Request.CodPerRecibe);
                        cm.Parameters.AddWithValue("nCodUODestino", Request.CodUODestino);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                codigo = dr.GetString(dr.GetOrdinal("cDocCodigo")).ToString();
                            }
                        }

                        if (codigo.Equals(""))
                        {
                            Item = false;
                        }
                        else {
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

        public Boolean setCopiaDocumento(BE_Req_Documento Request)
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
                        cm.CommandText = "sp_set_CopiaDocumentoPersona";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cDocCodigo", Request.cDocCodigo);
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                codigo = dr.GetString(dr.GetOrdinal("cDocCodigo")).ToString();
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

        public DateTime getFechaActual()
        { 
            DateTime FechaActual = new DateTime();
            try
            {
                clsConection Obj = new clsConection();
                string Cadena = Obj.GetConexionString("Naylamp");

                using (SqlConnection cn = new SqlConnection(Cadena))
                {
                    cn.Open();

                    using (SqlCommand cm = new SqlCommand())
                    {
                        cm.CommandText = "sp_getFechaActual";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                FechaActual = dr.GetDateTime(dr.GetOrdinal("FechaActual"));
                            }
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return FechaActual;
        }

        public DataTable getDocPendientesConAcuerdo(BE_Req_Documento Request)
        {
            BE_Res_Documento Item = new BE_Res_Documento();
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
                        cm.CommandText = "sp_Get_DocPendientesConAcuerdo_BycPerCodigo";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("FiltroPersona", Request.FiltroPersona);
                        cm.Parameters.AddWithValue("FiltroFecha", Request.FiltroFecha);
                        cm.Parameters.AddWithValue("FecIni", Request.dFechaIni);
                        cm.Parameters.AddWithValue("FecFin", Request.dFechaFin);
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

        public DataTable getDocPendientes(BE_Req_Documento Request)
        {
            BE_Res_Documento Item = new BE_Res_Documento();
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
                        cm.CommandText = "sp_get_DocumentosPendientes_ByTipoDoc";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nDestEstado", Request.nDestEstado);
                        cm.Parameters.AddWithValue("cTipoDoc", Request.cTipoDoc);
                        cm.Parameters.AddWithValue("cDocEstado", Request.cDocEstado);
                        cm.Parameters.AddWithValue("cDocCodigo", Request.cDocCodigo);
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

        public DataTable  getDocInformacion(BE_Req_Documento Request)
        {
            BE_Res_Documento Item = new BE_Res_Documento();
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
                        cm.CommandText = "sp_get_DocInformacion";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("cPerDestCodigo", Request.cPerDestCodigo);
                        cm.Parameters.AddWithValue("cDocCodigo", Request.cDocCodigo);
                        cm.Parameters.AddWithValue("cDocPerTipo", Request.cDocPerTipo);
                        cm.Parameters.AddWithValue("cDocEstado", Request.cDocEstado);
                        cm.Parameters.AddWithValue("cDocConTipo", Request.cDocConTipo);
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

        public DataTable getPerCopias(BE_Req_Documento Request)
        {
            BE_Res_Documento Item = new BE_Res_Documento();
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
                        cm.CommandText = "sp_get_PerCopia";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("cDocCodigo", Request.cDocCodigo);
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
