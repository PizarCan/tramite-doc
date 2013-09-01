﻿using System;
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
        public DataTable ListaPeronas_BycPerApellido_cPerRelTipo(BE_Req_Persona Request)
        {
            DAPersona ObjPersona = new DAPersona();
            return ObjPersona.ListaPersonas_BycPerCodigo_cPerRelTipo(Request);
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
    }
}
