using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Constante;
using Integration.BL;
using Integration.DAService;

namespace Integration.BL
{
    public class BL_Constante
    {
        public IList<BE_Res_Constante> ListarConstantes(BE_Req_Constante Request)
        {

            DAConstante ObjConstantes = new DAConstante();
            return ObjConstantes.ListarConstantes(Request);

        }
    }
}
