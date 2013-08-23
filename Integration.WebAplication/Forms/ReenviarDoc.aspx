<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ReenviarDoc.aspx.vb" Inherits="Forms_ReenviarDoc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ReenviarDoc</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table id="Table1" cellspacing="1" cellpadding="1" width="550" align="center" border="0">
        <tr>
            <td align="center" bgcolor="#35a2e7">
                <font color="#ffffff">Detalle del Documento</font>
            </td>
        </tr>
        <tr>
            <td>
                <p>
                    <font face="Courier New" size="2"><strong>Tipo de Documento :</strong> </font><font
                        face="Courier New" size="2">
                        <asp:Label ID="lblTipoDocumento" runat="server" Width="136px">Label</asp:Label><strong>Fecha:</strong>
                        <asp:Label ID="lblfecha" runat="server" Width="144px">Label</asp:Label></font></p>
            </td>
        </tr>
        <tr>
            <td>
                <font face="Courier New" size="2"><strong>De&nbsp;&nbsp; :</strong></font><font face="Courier New"
                    size="2">
                    <asp:Label ID="lblremitente" runat="server" Width="480px">Label</asp:Label></font>
            </td>
        </tr>
        <tr>
            <td style="height: 34px">
                <p>
                    <font face="Courier New"><font size="2"><strong>Para :</strong></font></font><font
                        face="Courier New" size="2">
                        <asp:Label ID="lbldestino" runat="server" Width="480px">Label</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<asp:Label
                            ID="lblUO" runat="server" Width="480px">Label</asp:Label></font><font face="Courier New"
                                size="2"></font></p>
            </td>
        </tr>
        <tr>
            <td>
                <font face="Courier New" size="2">
                    <p align="center">
                        <strong>Asunto</strong>
                    </p>
                    <p align="justify">
                        <asp:Label ID="lblasunto" runat="server" Width="536px" Height="40px">Label</asp:Label></p>
                </font>
            </td>
        </tr>
        <tr>
            <td>
                <font face="Courier New" size="2">
                    <p align="center">
                        <strong>Detalle</strong></p>
                    <p align="justify">
                        <asp:Label ID="lbldetalle" runat="server" Width="536px" Height="40px">Label</asp:Label></p>
                </font>
            </td>
        </tr>
        <tr>
            <td>
                <font face="Courier New" size="2">
                    <p align="center">
                        <strong>Observación</strong></p>
                    <p align="justify">
                        <asp:Label ID="lblobservacion" runat="server" Width="536px" Height="40px">Label</asp:Label></p>
                </font>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <p>
                    <font face="Courier New" size="2"><strong>Cc:</strong></font></p>
                <p>
                    &nbsp;<font face="Courier New" size="2"><asp:Label ID="lblCopias" runat="server"
                        Width="536px" Height="3px"></asp:Label></font></p>
            </td>
        </tr>
        <tr>
            <td align="center" bgcolor="#35a2e7">
                <font face="Verdana" color="#ffffff">Nuevo Destino</font>
            </td>
        </tr>
        <tr>
            <td>
                <table width="550" border="0">
                    <tr>
                        <td align="center" colspan="2">
                            <font face="Verdana" size="2"><strong>
                                <asp:TextBox ID="txtDestino" runat="server" Width="288px"></asp:TextBox><asp:DataGrid
                                    ID="dgNombre2" runat="server" Width="288px" Height="56px" Font-Size="8pt" BackColor="White"
                                    Font-Names="Courier New" GridLines="None" BorderColor="White" ShowHeader="False"
                                    AutoGenerateColumns="False" PageSize="4">
                                    <Columns>
                                        <asp:ButtonColumn Text="Seleccionar" DataTextField="Nombre" CommandName="Select">
                                        </asp:ButtonColumn>
                                        <asp:BoundColumn Visible="False" DataField="cPerCodigo"></asp:BoundColumn>
                                        <asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
                                    </Columns>
                                    <PagerStyle Visible="False" PageButtonCount="3"></PagerStyle>
                                </asp:DataGrid></strong></font>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 276px" align="right">
                            <asp:DropDownList ID="cboInstDestino" runat="server" Width="233px" Height="24px"
                                Font-Size="XX-Small" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="cboAreaDestino" runat="server" Width="233px" Font-Size="XX-Small">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblDocCodigo" runat="server" Visible="False"></asp:Label><asp:Label
                    ID="lblCodPerDestino" runat="server" Visible="False"></asp:Label><asp:Button ID="btnGrabar"
                        runat="server" Width="110px" Text="Grabar" Enabled="False"></asp:Button><asp:Button
                            ID="btncerrar" runat="server" Width="110px" Text="Cerrar"></asp:Button>
            </td>
        </tr>
    </table>
    &nbsp;
    </form>
</body>
</html>
