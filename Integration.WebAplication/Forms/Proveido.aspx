<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Proveido.aspx.vb" Inherits="Forms_Proveido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Proveido</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table id="Table1" width="550" align="center" border="0">
        <tr>
            <td class="RepCabLeft" style="width: 130px">
                Fecha
            </td>
            <td class="RepDetLeft">
                <asp:Label ID="lblfecha" runat="server" Width="247px" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 130px" class="RepCabLeft">
                Item
            </td>
            <td class="RepDetLeft">
                <asp:Label ID="lblItem" runat="server" Font-Bold="False" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="RepCabLeft" style="width: 130px">
                <asp:Label ID="lblTipoDocumento" runat="server" Font-Bold="True"></asp:Label>
            </td>
            <td class="RepDetLeft">
                <asp:Label ID="lblNumero" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 130px" class="RepCabLeft">
                De
            </td>
            <td class="RepDetLeft">
                <asp:Label ID="lblremitente" runat="server" Width="400px" Font-Names="Verdana" Font-Size="8pt"></asp:Label><br />
                <asp:Label ID="lblUORemite" runat="server" Width="400px" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 130px" class="RepCabLeft">
                para
            </td>
            <td class="RepDetLeft">
                <asp:Label ID="lbldestino" runat="server" Width="400px" Font-Names="Verdana" Font-Size="8pt"></asp:Label><asp:Label
                    ID="lblUO" runat="server" Width="400px" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="RepCabLeft" style="width: 130px">
                asunto
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="RepDetLeft" colspan="2">
                <asp:Label ID="lblasunto" runat="server" Width="536px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="RepCabLeft" style="width: 130px">
                detalle
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="RepDetLeft" colspan="2">
                <asp:Label ID="lbldetalle" runat="server" Width="536px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="RepCabLeft" style="width: 130px">
                observación
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="RepDetLeft" colspan="2">
                <asp:Label ID="lblobservacion" runat="server" Width="536px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="RepCabLeft" style="width: 130px; height: 20px">
                cc
            </td>
            <td style="height: 20px">
            </td>
        </tr>
        <tr>
            <td class="RepDetLeft" colspan="2">
                <asp:Label ID="lblCopias" runat="server" Width="536px" Height="3px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 34px" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <font face="Courier New" size="2">
                    <p align="center" style="text-align: left">
                        <strong></strong>&nbsp;</p>
                </font>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <font face="Courier New" size="2">
                    <p align="center" style="text-align: left">
                        <strong></strong>&nbsp;</p>
                </font>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <font face="Courier New" size="2">
                    <p align="center" style="text-align: left">
                        <strong></strong>&nbsp;</p>
                </font>
            </td>
        </tr>
        <tr>
            <td valign="top" colspan="2">
                <p>
                    <font face="Courier New" size="2"><strong></strong></font>&nbsp;</p>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right" valign="top">
                <asp:LinkButton ID="lnkProveido" runat="server">Enviar Proveido</asp:LinkButton>
                <asp:Button ID="btnProveido" runat="server" Text="Proveido" CssClass="ButtonSimple" />&nbsp;<asp:Button
                    ID="btnImprimir" runat="server" Text="Imprimir" CssClass="ButtonSimple" />
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top">
                <asp:Panel ID="pnlProveido" runat="server" Height="50px" Visible="False" Width="125px">
                    <table>
                        <tr>
                            <td align="center" bgcolor="#35a2e7" style="background-color: #003333">
                                <font face="Verdana" color="#ffffff">Enviar Proveido</font>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table id="Table2" width="550" border="0">
                                    <tr>
                                        <td align="center" colspan="2">
                                            <font face="Verdana" size="2"><strong>
                                                <asp:TextBox ID="txtDestino" runat="server" Width="288px"></asp:TextBox><asp:DataGrid
                                                    ID="dgNombre2" runat="server" Width="288px" Height="70px" PageSize="4" AutoGenerateColumns="False"
                                                    ShowHeader="False" BorderColor="White" GridLines="None" Font-Names="Courier New"
                                                    BackColor="White" Font-Size="8pt">
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
                                        <td style="width: 276px; text-align: left;" align="right">
                                            <asp:DropDownList ID="cboInstDestino" runat="server" Width="233px" Height="24px"
                                                Font-Size="XX-Small" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:DropDownList ID="cboAreaDestino" runat="server" Width="233px" Font-Size="XX-Small">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblPerRecibe" runat="server" Visible="False" Width="84px"></asp:Label>
                                            <asp:Label ID="lblPerRemite" runat="server" Width="79px"></asp:Label><br />
                                            <strong><span style="font-size: 10pt">Observación</span></strong>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btnCopias" runat="server" Text="Copias" CssClass="ButtonSimple" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Width="543px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblDocCodigo" runat="server" Visible="False"></asp:Label><asp:Label
                                    ID="lblCodPerDestino" runat="server" Visible="False"></asp:Label><asp:Button ID="btnGrabar"
                                        runat="server" Width="110px" Enabled="False" Text="Grabar" CssClass="ButtonSimple">
                                    </asp:Button>&nbsp;<asp:Button ID="btncerrar" runat="server" Width="110px" Text="Cerrar"
                                        CssClass="ButtonSimple"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
