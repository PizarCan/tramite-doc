<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Forms_DelegarDocumentos" Codebehind="DelegarDocumentos.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="font-size: 10pt; width: 500px; font-family: Verdana" align =center>
            <tr>
                <td style="width: 100%; text-align: center" class="CeldaInformacion">
                    Delegar a otra Persona para que Tramite sus Documentos</td>
            </tr>
            <tr>
                <td align="left" style="width: 500px">
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 104px; text-align: center" class="CeldaEtiqueta">
                                Buscar Persona</td>
                            <td>
                                <asp:TextBox ID="txtBuscar" runat="server" Width="315px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:DataGrid ID="gvPersona" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="White" Font-Names="Courier New" Font-Size="8pt" GridLines="None"
                                    Height="56px" PageSize="4" ShowHeader="False" Width="318px">
                                    <PagerStyle PageButtonCount="3" Visible="False" />
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" VerticalAlign="Top" />
                                    <Columns>
                                        <asp:ButtonColumn CommandName="Select" DataTextField="Nombre" Text="Seleccionar"></asp:ButtonColumn>
                                        <asp:BoundColumn DataField="cPerCodigo" Visible="False"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Nombre" Visible="False"></asp:BoundColumn>
                                    </Columns>
                                </asp:DataGrid></td>
                        </tr>
                    </table>
                    <asp:Label ID="lblPerNombre" runat="server" Width="372px"></asp:Label>
                    <asp:Label ID="lblPerCodigo" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100%; text-align: center;">
                    <asp:GridView ID="gvDelegado" runat="server" AutoGenerateColumns="False" Width="490px" DataKeyNames="cPerParCodigo">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:TemplateField HeaderText="Eliminar">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEliminar" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="FilaGrid" />
                        <SelectedRowStyle CssClass="CeldaEtiqueta" />
                        <HeaderStyle CssClass="CabeceraGrid" />
                    </asp:GridView>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 100%" align="right">
                    <asp:Button ID="btnGrabar" runat="server" OnClick="btnGrabar_Click" Text="Grabar" CssClass="Boton" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="Boton"/>
                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="Boton" /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
