using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Integration.BL;
using Integration.Conection;
using Integration.BE.Login;


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string User = txtUser.Text;
        string Pass = txtPass.Text;
        clsCrypt ObjEncrypt = new clsCrypt();
        BE_Req_Login Request = new BE_Req_Login();
        BE_Res_Login Response = new BE_Res_Login();
        BL_Login objBl = new BL_Login();

        Pass = ObjEncrypt.EncryptByCode(User, Pass);
        Request.cPerUsuCodigo = User;
        Request.cPerUsuClave = Pass;
        Response = objBl.ValidateUser(Request);
        if (Response.cPerCodigo==null)
        {
            lblError.Text = "Usuario y/o Clave Incorrecto.!!";
        }
        else { 
            lblError.Text= "Bienvenido Sr." + Response.cPerAlias;
        }
    }
}