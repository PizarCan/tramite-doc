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
        public int nUniOrgCodigo { get; set; }

        public int nEleCodigo { get; set; }
        public int nCarCodigo { get; set; }
        public string cCarObs { get; set; }
        public float nPercent { get; set; }
        public DateTime dDocTraFec { get; set; }
        public int nDocTipoNum { get; set; }

        #region DocPersona
        public int nPerRelacion { get; set; }

        #endregion


        #region DocLink
        public int nDocLinNum { get; set; }
        public string cDocLinUrl { get; set; }
        public int nDocLinTipo { get; set; }
        public int nDocLinGrupo { get; set; }
        #endregion

        #region DocUniOrg
        public int nDocUniOrgTipo { get; set; }
        public int nDocUniOrgEstado { get; set; }
        #endregion

        #region DocMotivo
        public int nDocMotivo { get; set; }
        public int nDocMotTipo { get; set; }
        #endregion

        #region DocPeriodo
        public int nPrdIni { get; set; }
        public int nPrdFin { get; set; }
        #endregion

        #region DocRef
        public string cDocRefCodigo { get; set; }
        #endregion
    }
}
