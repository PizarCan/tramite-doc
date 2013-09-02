using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Integration.BE.TraDoc;
using Integration.Conection;
namespace Integration.DAService
{
    public class DATraDoc
    {

        public DataTable get_TraDoc_Procesos(BE_Req_TraDoc Request)
        {
            BE_Res_TraDoc Item = new BE_Res_TraDoc();
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
                        cm.Parameters.AddWithValue("iOpcion", Request.iOpcion);
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
                        cm.Parameters.AddWithValue("cDocEstado", Request.cDocEstado);
                        cm.Parameters.AddWithValue("nMesCodigo", Request.nMesCodigo);
                        cm.Parameters.AddWithValue("cUniOrgTransferencia", Request.cUniOrgTransferencia);
                        cm.Parameters.AddWithValue("cDocPerTipo", Request.cDocPerTipo);
                        cm.Parameters.AddWithValue("cFecIni", Request.cFecIni);
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
            //return Item;
            return Rs;
        }

    }
}
