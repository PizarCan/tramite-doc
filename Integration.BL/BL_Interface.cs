using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Interface;
using Integration.BL;
using Integration.DAService;

namespace Integration.BL
{
    public class BL_Interface
    {
        public BE_Res_Interface getInterface(BE_Req_Interface Request)
        {
            DAInterface ObjConstantes = new DAInterface();
            return ObjConstantes.getInterface(Request);

        }
    }
}
