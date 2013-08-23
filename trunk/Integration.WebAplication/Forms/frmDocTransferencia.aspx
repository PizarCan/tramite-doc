<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmDocTransferencia.aspx.vb" Inherits="Forms_frmDocTransferencia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transferencia de Documentos</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 700px">
            <tr>
                <td class="CabeceraTabla" colspan="4">
                    Transferencia de Documentos</td>
            </tr>
            <tr>
                <td class="CeldaEtiqueta">
                    Buscar persona Origen</td>
                <td>
                    <asp:TextBox ID="txtPerOrigen" runat="server" Width="200px"></asp:TextBox>
                    <asp:GridView ID="gvPerOrigen" runat="server" AutoGenerateColumns="False" DataKeyNames="cPerCodigo,Nombre"
                        ShowHeader="False" Width="250px">
                        <RowStyle CssClass="FilaGrid" />
                        <Columns>
                            <asp:ButtonField CommandName="Select" DataTextField="Nombre" />
                        </Columns>
                        <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    </asp:GridView>
                    <asp:Label ID="lblPerOriCodigo" runat="server" Visible="False"></asp:Label></td>
                <td class="CeldaEtiqueta">
                    Unidad Organizacional</td>
                <td>
                    <asp:DropDownList ID="cboOrigen" runat="server" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td class="CeldaEtiqueta">
                    Buscar persona Destino</td>
                <td>
                    <asp:TextBox ID="txtPerDestino" runat="server" Width="200px"></asp:TextBox>
                    <asp:GridView ID="gvPerDestino" runat="server" AutoGenerateColumns="False" DataKeyNames="cPerCodigo,Nombre"
                        ShowHeader="False" Width="250px">
                        <RowStyle CssClass="FilaGrid" />
                        <Columns>
                            <asp:ButtonField CommandName="Select" DataTextField="Nombre" />
                        </Columns>
                        <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    </asp:GridView>
                    <asp:Label ID="lblPerDesCodigo" runat="server" Visible="False"></asp:Label></td>
                <td class="CeldaEtiqueta">
                    Unidad Organizacional</td>
                <td>
                    <asp:DropDownList ID="cboDestino" runat="server" Width="200px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="Button1" runat="server" Height="0px" Text="Button" Width="0px" />
                    <asp:Button ID="btnCargar" runat="server" CssClass="Boton" Text="Cargar" /><asp:Button ID="btnGrabar" runat="server" CssClass="Boton" Text="Transferir" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:GridView ID="gvDetalle" runat="server">
                        <RowStyle CssClass="FilaGrid" />
                        <HeaderStyle CssClass="CabeceraGrid" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblError" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
