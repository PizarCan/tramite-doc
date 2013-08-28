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

        public DataTable getBuscaDocumentos(BE_Req_Documento Request)
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
                        cm.CommandText = "SP_TraDoc_Procesos";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.AddWithValue("Opcion", 1);
                        cm.Parameters.AddWithValue("cPerCodigo", Request.cPerCodigo);
                        cm.Parameters.AddWithValue("nPerRemFiltro", Request.nPerRemFiltro);
                        cm.Parameters.AddWithValue("nPerRecFiltro", Request.nPerRecFiltro);
                        cm.Parameters.AddWithValue("nDocNumFiltro", Request.nDocNumFiltro);
                        cm.Parameters.AddWithValue("cDocNDoc", Request.cDocNDoc);
                        cm.Parameters.AddWithValue("nItemFiltro", Request.nItemFiltro);
                        cm.Parameters.AddWithValue("nAsuFiltro", Request.nAsuFiltro);
                        cm.Parameters.AddWithValue("cDocConContenido", Request.cDocConContenido);
                        cm.Parameters.AddWithValue("nPrdCodigo", Request.nPrdCodigo);
                        cm.Parameters.AddWithValue("nDocTipo", Request.nDocTipo);
                        cm.Parameters.AddWithValue("nFilMes", Request.nFilMes);
                        cm.Parameters.AddWithValue("cInvPerCodigo", Request.cInvPerCodigo);
                        cm.Connection = cn;
                        using (SqlDataReader dr = cm.ExecuteReader())
                        {
                            //while (dr.Read())
                            //{
                                //Item.cDocNDoc = dr.GetString(dr.GetOrdinal("cDocNDoc"));
                                //Item.cDocCodigo = dr.GetString(dr.GetOrdinal("cDocCodigo"));
                                //Item.dFechaIni = dr.GetDateTime(dr.GetOrdinal("dFechaIni"));
                                //Item.dDocFecha = dr.GetDateTime(dr.GetOrdinal("DocFecha"));
                                //Item.PerRemite = dr.GetString(dr.GetOrdinal("PerRemite"));
                                //Item.PerRecibe = dr.GetString(dr.GetOrdinal("PerRecibe"));
                                //Item.Asunto = dr.GetString(dr.GetOrdinal("Asunto"));
                                //Item.UORemCodigo = dr.GetInt32(dr.GetOrdinal("UORemCodigo"));
                                //Item.UORecTipo = dr.GetInt32(dr.GetOrdinal("UORecTipo"));
                                //Item.UORemTipo = dr.GetInt32(dr.GetOrdinal("UORemTipo"));
                                //Item.DocTipo = dr.GetString(dr.GetOrdinal("DocTipo"));
                                //Item.Archivo = dr.GetString(dr.GetOrdinal("Archivo"));
                                //Item.Archiv = dr.GetString(dr.GetOrdinal("Archiv"));
                                //Item.DocEstado = dr.GetString(dr.GetOrdinal("DocEstado"));
                            //}
                            Rs.Load(dr);
                        }

                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            //return Item;
            return Rs;
        }

    }
}
