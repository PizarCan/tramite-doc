using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.UniOrgPerExt;
using Integration.BL;
using Integration.DAService;
using System.Data;
using System.Data.SqlClient;

namespace Integration.BL
{
    public class BL_UniOrgPerExt
    {
        public DataTable ObtenerUniOrgBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {

            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerUniOrgBycPerCodigo(Request);
        }
        public DataTable ObtenerInstitucionesBycPerCodigo(BE_Req_UniOrgPerExt Request)
        {

            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerInstitucionesBycPerCodigo(Request);
        }
        public DataTable ObtenerAreaByPersonaInstitucion(BE_Req_UniOrgPerExt Request)
        {

            DAUniOrgPerExt UniOrgPersona = new DAUniOrgPerExt();
            return UniOrgPersona.ObtenerAreaByPersonaInstitucion(Request);
        }
    }
}
