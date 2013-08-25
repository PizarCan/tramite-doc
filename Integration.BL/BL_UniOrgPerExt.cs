using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.UniOrgPerExt;
using Integration.BL;
using Integration.DAService;

namespace Integration.BL
{
    public class BL_UniOrgPerExt
    {
        public IList<BE_Res_UniOrgPerExt> ObtenerUniOrgBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {

            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerUniOrgBycPerCodigo(Request);
        }
        public IList<BE_Res_UniOrgPerExt> ObtenerInstitucionesBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {

            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerInstitucionesBycPerCodigo(Request);
        }
        public IList<BE_Res_UniOrgPerExt> ObtenerAreaByPersonaInstitucion(BE_Req_UniOrgPerExt Request)
        {

            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerAreaByPersonaInstitucion(Request);
        }
    }
}
