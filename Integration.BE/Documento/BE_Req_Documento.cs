using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Integration.BE.Documento
{
    public class BE_Req_Documento
    {
        public string cPerCodigo { get; set; }
        public int nPrdCodigo { get; set; }
        public int nDocTipo { get; set; }
        public string cDocNDoc { get; set; }
        public string cDocCodigo { get; set; }
        public DateTime dDocFecha { get; set; }
        public string cDocObserv { get; set; }
        public int nDocEstado { get; set; }
        public string Asunto { get; set; }
        public string Detalle { get; set; }
        public DateTime dFechaIni { get; set; }
        public DateTime dFechaFin { get; set; }
        public string CodPerSolicita { get; set; }
        public int PerRelSolicita { get; set; }
        public int CodUORemite { get; set; }
        public int nDocPerTipo { get; set; }
        public string CodPerRegistra { get; set; }
        public string CodPerRecibe { get; set; }
        public int CodUODestino { get; set; }

        public int FiltroPersona { get; set; }
        public int FiltroFecha { get; set; }
        public string cTipoDoc { get; set; }
        public string cDocEstado { get; set; }
        public int nDestEstado { get; set; }
        public string cPerDestCodigo { get; set; }
        public string cDocPerTipo { get; set; }
        public string cDocConTipo { get; set; }

    }
}
