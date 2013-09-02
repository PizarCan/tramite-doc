using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Constante;
using Integration.BL;
using Integration.DAService;
using System.Data;

namespace Integration.BL
{
    public class BL_Constante
    {
        public DataTable ListarConstantes(BE_Req_Constante Request)
        {

            DAConstante ObjConstantes = new DAConstante();
            return ObjConstantes.ListarConstantes(Request);

        }

        public IList<BE_Res_Constante> Get_ConstantesBynConValor(BE_Req_Constante Request)
        {

            DAConstante ObjConstantes = new DAConstante();
            return ObjConstantes.Get_ConstantesBynConValor(Request);

        }

        public DataTable GetConstante(BE_Req_Constante Request)
        {
            DAConstante ObjConstantes = new DAConstante();
            return ObjConstantes.GetConstante(Request);
        }
    }
}
