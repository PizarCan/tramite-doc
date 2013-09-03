using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Documento;
using Integration.BL;
using Integration.DAService;
using System.Data;
using System.Data.SqlClient;

namespace Integration.BL
{
    public class BL_Documento
    {
        public BE_Res_Documento getCorrelativoBynDocTipo_nPrdCodigo(BE_Req_Documento Request)
        {

            DADocumento ObjCorrelativo = new DADocumento();
            return ObjCorrelativo.getCorrelativoBynDocTipo_nPrdCodigo(Request);

        }
        public BE_Res_Documento getDocumentoBycDocNDoc_nDocTipo(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocumentoBycDocNDoc_nDocTipo(Request);

        }
        public BE_Res_Documento getTipoPersona(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getTipoPersona(Request);

        }
        public BE_Res_Documento getUltimoDocumentoBycPerCodigo(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getUltimoDocumentoBycPerCodigo(Request);

        }
        public DateTime getFechaActual()
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getFechaActual();
        }
        public Boolean setDocumento(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocumento(Request);
        }
        public Boolean setCopiaDocumento(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setCopiaDocumento(Request);
        }
        public DataTable getDocPendientesConAcuerdo(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocPendientesConAcuerdo(Request);

        }
        public DataTable getDocPendientes(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocPendientes(Request);

        }
        public DataTable getDocInformacion(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocInformacion(Request);

        }
        public DataTable getPerCopias(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getPerCopias(Request);

        }
        public Boolean updEstadoDocumento(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.updEstadoDocumento(Request);
        }
        public Boolean setDocProProveido(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocProProveido(Request);
        }
        public Boolean setDocTratamiento(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocTratamiento(Request);
        }
        public DataTable getDocConAcuerdo(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocConAcuerdo(Request);

        }
        public DataTable getDocAcuerdoBySustentar(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocAcuerdoBySustentar(Request);

        }
        public DataTable getDocAcuerdoAvanceByPersona(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getDocAcuerdoAvanceByPersona(Request);

        }
        public Int32 getNumCorrelativoDocTratamiento(BE_Req_Documento Request)
        {

            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.getNumCorrelativoDocTratamiento(Request);

        }
        public Boolean setDocIdentifica(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocIdentifica(Request);
        }
        public Boolean setDocLink(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocLink(Request);
        }
        public Boolean setDocumentoTransf(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocumentoTransf(Request);
        }
        public Boolean setDocPersona(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocPersona(Request);
        }
        public Boolean setDocUniOrg(BE_Req_Documento Request)
        {
            DADocumento ObjDocumento = new DADocumento();
            return ObjDocumento.setDocUniOrg(Request);
        }
    }
}
