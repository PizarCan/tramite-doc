using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.PerUsuGruAcc;
using Integration.BL;
using Integration.DAService;

namespace Integration.BL
{
    public class BL_PerUsuGruAcc
    {
        public IList<BE_Res_PerUsuGruAcc> obtenerPermisos(BE_Req_PerUsuGruAcc Request)
        {

            DAPerUsuGruAcc ObjPermisos = new DAPerUsuGruAcc();
            return ObjPermisos.ObtenerPermisos(Request);

        }
        public Boolean setPerUsuGruAcc (BE_Req_PerUsuGruAcc Request)
        {

            DAPerUsuGruAcc ObjPermisos = new DAPerUsuGruAcc();
            return ObjPermisos.setPerUsuGruAcc(Request);

        }
        public Boolean delPerUsuGruAcc (BE_Req_PerUsuGruAcc Request)
        {

            DAPerUsuGruAcc ObjPermisos = new DAPerUsuGruAcc();
            return ObjPermisos.delPerUsuGruAcc(Request);

        }
    }
}
