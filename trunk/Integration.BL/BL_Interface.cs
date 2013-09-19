using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Interface;
using Integration.BL;
using Integration.DAService;
using System.Data;
using System.Data.SqlClient;


namespace Integration.BL
{
    public class BL_Interface
    {
        public BE_Res_Interface getInterface(BE_Req_Interface Request)
        {
            DAInterface ObjInterface = new DAInterface();
            return ObjInterface.getInterface(Request);

        }
        public DataTable getInterfaceBycIntJerarquia(BE_Req_Interface Request)
        {
            DAInterface ObjInterface = new DAInterface();
            return ObjInterface.getInterfaceBycIntJerarquia(Request);

        }
    }
}
