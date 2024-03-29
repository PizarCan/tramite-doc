﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.BE.Persona
{
    public class BE_Req_Persona
    {
        public string cPerApellido { get; set; }
        public string cPerNombre { get; set; }
        public int nPerRelTipo { get; set; }
        public string cPerRelTipo { get; set; }
        public string cUbiGeoCodigo { get; set; }
        public int nPerTipo { get; set; }
        public string cPerCodigo { get; set; }
        public string cPerParCodigo { get; set; }
        public int nPerParTipo { get; set; }

        #region InsPersona
            public int nPerIdeTipo { get; set; }
            public string cPerDomDireccion { get; set; }
            public string cPerIdeNumero { get; set; }
            public int nUbigeoCodigo { get; set; }
            public int nUniOrgCodigo { get; set; }
        #endregion

        #region UpdPersona
            public int nPerDirCodigo { get; set; }
        #endregion

    }
}
