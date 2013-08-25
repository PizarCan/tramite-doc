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
            return ObjPersona.ListaPersonas_BycPerCodigo(Request);
        }
        public DataTable ListaPeronas_BycPerApellido_cPerRelTipo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.ListaPersonas_BycPerCodigo_cPerRelTipo(Request);
        }
    }
}
