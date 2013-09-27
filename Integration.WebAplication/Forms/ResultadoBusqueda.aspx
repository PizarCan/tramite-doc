<%@ Page Language="VB" AutoEventWireup="false"
    Inherits="IntegrationWebAplication.Forms_ResultadoBusqueda" Codebehind="ResultadoBusqueda.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ResultadoBusqueda</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table width="600" border="0">
        <tr>
            <td colspan="2" style="text-align: center">
                <span style="font-size: 8pt; font-family: Courier New">Resultado de la Búsqueda</span>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <span style="font-size: 10pt"><span style="font-family: Courier New"><strong>Fecha:</strong></span></span><asp:Label
                    ID="lblfecha" runat="server" Width="100px" Style="text-align: right" Font-Names="Courier New"
                    Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: left">
                <span style="font-size: 10pt"><span style="font-family: Courier New"></span></span>
                &nbsp;<strong> </strong>
            </td>
        </tr>
        <tr>
            <td>
                <strong><span style="font-size: 10pt; font-family: Courier New">
                    <asp:Label ID="lblTipoDocumento" runat="server"></asp:Label></span></strong>
            </td>
            <td>
                <span style="font-size: 10pt; font-family: Courier New"><strong></strong>
                    <asp:Label ID="lblNumero" runat="server" Font-Bold="False" Font-Names="Courier New"
                        Font-Size="X-Small"></asp:Label></span>
            </td>
        </tr>
        <tr>
            <td>
                <font face="Courier New" size="2"><strong>De</strong></font>
            </td>
            <td>
                <font face="Courier New" size="2">
                    <asp:Label ID="lblremitente" runat="server" Width="530px"></asp:Label></font>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <font face="Courier New"><font size="2"><strong>Para</strong></font></font>
            </td>
            <td>
                <font face="Courier New" size="2">
                    <asp:Label ID="lbldestino" runat="server" Width="530px"></asp:Label></font>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right" style="text-align: left">
                <asp:Label ID="lblProveido" runat="server" Font-Names="Courier New" Font-Size="8pt"
                    Style="text-align: justify" Width="280px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <strong><span style="font-size: 10pt; font-family: Courier New">Asunto</span></strong>
            </td>
            <td align="right" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right" style="text-align: left">
                <asp:Label ID="lblasunto" runat="server" Width="536px" Height="40px" Style="text-align: justify"
                    Font-Names="Courier New" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <strong><span style="font-size: 10pt; font-family: Courier New">Detalle</span></strong>
            </td>
            <td align="right">
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right" style="text-align: left">
                <asp:Label ID="lbldetalle" runat="server" Width="536px" Height="40px" Style="text-align: justify"
                    Font-Names="Courier New" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <strong><span style="font-size: 10pt; font-family: Courier New">Observación</span></strong>
            </td>
            <td align="right" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right" style="text-align: left">
                <asp:Label ID="lblobservacion" runat="server" Width="536px" Height="40px" Font-Names="Courier New"
                    Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <strong><span style="font-size: 10pt; font-family: Courier New">Cc:</span></strong>
            </td>
            <td align="right" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right" style="text-align: left">
                <asp:Label ID="lblCopias" runat="server" Width="536px" Height="3px" Font-Names="Courier New"
                    Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top">
            </td>
            <td align="right" style="text-align: right">
                <asp:Button ID="btncerrar" runat="server" Width="82px" Text="Cerrar"></asp:Button>
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
