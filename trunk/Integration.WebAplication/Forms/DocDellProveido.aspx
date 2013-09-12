<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DocDellProveido.aspx.vb" Inherits="Forms_DocDellProveido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle del Proveido</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="Table1" align="center" border="0" width="550">
            <tr>
                <td align="center" colspan="2"> </td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                    Fec. Emisión</td>
                <td class="RepDetLeft">
                    <asp:Label ID="lblFecEmision" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                    Fec. Prov.</td>
                <td class="RepDetLeft">
                    <asp:Label ID="lblfecha" runat="server" Width="200px"></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                            <asp:Label ID="lblTipoDocumento" runat="server"></asp:Label></td>
                <td class="RepDetLeft">
                    <asp:Label ID="lblNumero" runat="server" Width="250px"></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">Item</td>
                <td class="RepDetLeft"><asp:Label ID="lblItem" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">De</td>
                <td class="RepDetLeft"><asp:Label ID="lblremitente" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">Para
                </td>
                <td class="RepDetLeft">
                    <asp:Label ID="lbldestino" runat="server" Width="400px"></asp:Label><br />
                    <asp:Label ID="lblUO" runat="server" Width="400px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 130px" class="RepCabLeft">
                    asunto</td>
                <td></td>
            </tr>
            <tr>
                <td class="RepDetLeft" colspan="2">
                                <asp:Label ID="lblasunto" runat="server" Width="536px"></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                    detalle</td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="RepDetLeft" colspan="2">
                            <asp:Label ID="lbldetalle" runat="server" Width="536px" style="text-align: justify"></asp:Label><br />
                            <br/>
                </td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                            Observación</td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="RepDetLeft" colspan="2">
                                <asp:Label ID="lblobservacion" runat="server" Width="536px"></asp:Label></td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                    Proveído</td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="RepDetLeft" colspan="2">
                                <asp:Label ID="lblProveido" runat="server" Font-Bold="False" Width="536px"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td class="RepCabLeft" style="width: 130px">
                    Cc:</td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="RepDetLeft" colspan="2">
                    <asp:Label ID="lblCopias" runat="server" Width="536px"></asp:Label><br />
                </td>
            </tr>
            <tr>
                <td class="RepDetLeft" colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td valign="top" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2"> 
                    <strong>Enviar Proveido</strong></td>
            </tr>
            <tr>
                <td colspan="2">
                    <table id="Table2" border="0" width="550">
                        <tr>
                            <td align="center" colspan="2">
                                <font face="Verdana" size="2"><strong>
                                    <asp:TextBox ID="txtDestino" runat="server" Width="288px"></asp:TextBox><asp:DataGrid
                                        ID="dgNombre2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White"
                                        Font-Names="Courier New" Font-Size="8pt" GridLines="None" Height="56px" PageSize="4"
                                        ShowHeader="False" Width="288px" style="text-align: justify">
                                        <Columns>
                                            <asp:ButtonColumn CommandName="Select" DataTextField="Nombre" Text="Seleccionar"></asp:ButtonColumn>
                                            <asp:BoundColumn DataField="cPerCodigo" Visible="False"></asp:BoundColumn>
                                            <asp:BoundColumn DataField="Nombre" Visible="False"></asp:BoundColumn>
                                        </Columns>
                                        <PagerStyle PageButtonCount="3" Visible="False" />
                                    </asp:DataGrid></strong></font></td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 276px">
                                <asp:DropDownList ID="cboInstDestino" runat="server" AutoPostBack="True" Font-Size="9pt"
                                    Height="24px" Width="233px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                            <td>
                                <asp:DropDownList ID="cboAreaDestino" runat="server" Font-Size="9pt" Width="233px" Font-Names="Verdana">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2" style="height: 55px">
                                <asp:TextBox ID="txtProveido" runat="server" Height="48px" TextMode="MultiLine" Width="536px"></asp:TextBox></td>
                        </tr>
                    </table>
                    <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#C00000"></asp:Label>
                    <asp:Label ID="lblnDocPerEdiTipo" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                    <asp:Button
                            ID="btnGrabar" runat="server" Enabled="False" Text="Grabar" Width="110px" CssClass="ButtonSimple" />
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="ButtonSimple" />
                    <asp:Button
                                ID="btncerrar" runat="server" Text="Cerrar" Width="110px" CssClass="ButtonSimple" />&nbsp;
                    <asp:Label ID="lblPerRecibe" runat="server" Visible="False" Width="59px"></asp:Label>
                    <asp:Label
                        ID="lblCodPerDestino" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblDocCodigo" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
    
    </div>
    </form>

</body>
</html>
