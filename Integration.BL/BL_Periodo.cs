﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Periodo;
using Integration.BL;
using Integration.DAService;

namespace Integration.BL
{
    public class BL_Periodo
    {
        public BE_Res_Periodo get_PeriodoActual_ByActividad(BE_Req_Periodo Request)
        {
            DAPeriodo ObjPeriodo = new DAPeriodo();
            return ObjPeriodo.get_PeriodoActual_ByActividad(Request);
        }
    }
}