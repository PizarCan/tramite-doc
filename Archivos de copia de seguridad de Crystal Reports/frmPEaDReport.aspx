﻿<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Reportes_frmPEaDReport" Codebehind="frmPEaDReport.aspx.vb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes PEaD</title>
</head>
<body leftmargin =0 topmargin =0>
<script language="JavaScript">
			<!--
    // Maximizar Ventana
    window.moveTo(0, 0);
    if (document.all) {
        top.window.resizeTo(screen.availWidth, screen.availHeight);
    }
    else if (document.layers || document.getElementById) {
        if (top.window.outerHeight < screen.availHeight || top.window.outerWidth < screen.availWidth) {
            top.window.outerHeight = screen.availHeight;
            top.window.outerWidth = screen.availWidth;
        }
    }
			//-->
		</script>
    <form id="form1" runat="server">
           <table align="center" border="0" style="font-size: 10pt; width: 780px; font-family: verdana">
            <tr>
                <td>
                     

                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Button ID="Button1" runat="server" Text="Imprimir" Width="88px" Visible="False" /><asp:Label
                        ID="lblError" runat="server" Width="256px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
