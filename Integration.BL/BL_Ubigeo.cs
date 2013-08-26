using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Ubigeo;
using Integration.BL;
using Integration.DAService;
using System.Data;
using System.Data.SqlClient;


namespace Integration.BL
{
    public class BL_Ubigeo
    {
        public DataTable getUbigeoBycUbiGeoCodigo(BE_Req_Ubigeo Request)
        {
            DAUbigeo ObjPersona = new DAUbigeo();
            return ObjPersona.getUbigeoBycUbiGeoCodigo(Request);
        }
    }
}
