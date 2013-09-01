using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.TraDoc;
using Integration.BL;
using Integration.DAService;
using System.Data;
using System.Data.SqlClient;

namespace Integration.BL
{
    public class BL_TraDoc
    {

        public DataTable get_TraDoc_Procesos(BE_Req_TraDoc Request)
        {
            DATraDoc ObjTraDoc = new DATraDoc();
            return ObjTraDoc.get_TraDoc_Procesos(Request);
        }
    }
}
