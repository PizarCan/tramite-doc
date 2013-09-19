using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Persona;
using Integration.BL;
using Integration.DAService;
using System.Data;
using System.Data.SqlClient;

namespace Integration.BL
{
    public class BL_Persona
    {
        public DataTable ListaPeronas_BycPerApellido(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.ListaPersonas_BycPerApellido(Request);
        }
        public DataTable ListaPersonas_BycPerApellido_cPerRelTipo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.ListaPersonas_BycPerApellido_cPerRelTipo(Request);
        }
        public DataTable ListaPersona_BycPerCodigo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.ListaPersona_BycPerCodigo(Request);
        }
        public SqlDataReader DRListaPersonas_BycPerCodigo_cPerRelTipo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.DRListaPersonas_BycPerCodigo_cPerRelTipo(Request);
        }
        public SqlDataReader DRListaDelegados_BycPerCodigo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.DRListaDelegados_BycPerCodigo(Request);
        }
        public DataTable GetDelegados_BycPerCodigo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.GetDelegados_BycPerCodigo(Request);
        }
        public BE_Res_Persona getcPerCodigoNew()
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.getcPerCodigoNew();
        }
        public Boolean setPersona(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.setPersona(Request);
        }

        public string getDelegadoAnduser(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.getDelegadoAnduser(Request);
        }

        public Boolean setDelegado(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.setDelegado(Request);
        }

        public Boolean delDelegado(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.delDelegado(Request);
        }
        public Boolean InsPersonaArea(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.InsPersonaArea(Request);
        }
        public Boolean UpdPersonaArea(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.UpdPersonaArea(Request);
        }
        public DataTable GetDatosPersona_BycPerCodigo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.GetDatosPersona_BycPerCodigo(Request);
        }

    }
}
