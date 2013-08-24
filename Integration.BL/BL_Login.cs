using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Integration.BE.Login;
using Integration.BL;
using Integration.DAService;
namespace Integration.BL
{
    public class BL_Login
    {
        public BE_Res_Login ValidateUser(BE_Req_Login Request)
        { 
            
            DALogin ObjLogin = new DALogin();
            return ObjLogin.ValidaterUser(Request);
            
        }
        public Boolean ValidaInicioSesion(BE_Req_Login Request)
        {
            DALogin ObjLogin = new DALogin();
            return ObjLogin.ValidaInicioSesion(Request);
        }

    }
}
