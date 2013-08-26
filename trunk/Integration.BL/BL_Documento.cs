using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Documento;
using Integration.BL;
using Integration.DAService;

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

    }
}
