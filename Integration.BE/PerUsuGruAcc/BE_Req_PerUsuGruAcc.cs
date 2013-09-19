using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.BE.PerUsuGruAcc
{
    public class BE_Req_PerUsuGruAcc
    {
        public string cPerCodigo { get; set; }
        public int nSisGruTipo { get; set; }
        public int nObjTipo { get; set; }
        public int nSisGruCodigo { get; set; }
        public int nObjCodigo { get; set; }
    }
}
