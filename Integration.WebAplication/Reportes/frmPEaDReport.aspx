﻿<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Reportes_frmPEaDReport"
    CodeBehind="frmPEaDReport.aspx.vb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reportes</title>
</head>
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
<body>
    <form id="form1" runat="server">
    <table align="center" border="0" style="font-size: 10pt; width: 780px; font-family: verdana">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" HasCrystalLogo="False"
                    HasGotoPageButton="False" HasSearchButton="False" HasToggleGroupTreeButton="False"
                    ReuseParameterValuesOnRefresh="True" Height="50px" Width="350px" EnableDrillDown="False" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Button ID="Button1" runat="server" Text="Imprimir" Width="88px" Visible="False" /><asp:Label
                    ID="lblError" runat="server" Width="256px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
