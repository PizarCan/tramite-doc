using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.BE.TraDoc
{
    public class BE_Res_TraDoc
    {

        public string cPerCodigo { get; set; }
        public string cNumero { get; set; }
        public string cDocCodigo { get; set; }
        public int nDocTipoNum { get; set; }
        public string cDocNDoc { get; set; }
        public DateTime FechaActual { get; set; }
        public DateTime dDocFecha { get; set; }
        public string cPerApellido { get; set; }
        public DateTime dFechaIni { get; set; }
        public string PerRemite { get; set; }
        public string PerRecibe { get; set; }
        public string Asunto { get; set; }
        public int UORemCodigo { get; set; }
        public int UORecTipo { get; set; }
        public int UORemTipo { get; set; }
        public string DocTipo { get; set; }
        public string Archivo { get; set; }
        public string Archiv { get; set; }
        public string DocEstado { get; set; }
    }
}
