<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_frmRegistrarPermisos" Title="ASIGNACIÓN DE PERMISOS" Codebehind="frmRegistrarPermisos.aspx.vb" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script language="jscript" type="text/javascript">
        function clickButton() {
        }   
    </script>
</asp:Content> 
<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <table style="width: 650px; height: 134px" cellspacing="0" cellpadding="0" align="center"
        border="0">
        <tr>
            <td colspan="3" align="center" style="width: 524px" class="CabeceraTabla">
                <font face="Verdana">ASIGNACIÓN DE PERMISOS<br />
                </font>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 131px" class="CeldaEtiqueta">
                Buscar Persona
            </td>
            <td align="left" colspan="3" style="width: 364px">
                <asp:TextBox ID="txtBuscar" runat="server" Width="305px"></asp:TextBox><asp:Button
                    ID="btnBuscar" runat="server" Text="Buscar" Width="56px" CssClass="Boton" />
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 131px">
            </td>
            <td align="left" colspan="3" style="width: 364px">
                <div style="width: 508px; height: 150px; overflow: auto">
                    <asp:DataGrid ID="dgNombre" runat="server" Width="440px" Height="56px" Font-Size="8pt"
                        BackColor="White" Font-Names="Courier New" GridLines="None" BorderColor="White"
                        ShowHeader="False" AutoGenerateColumns="False" PageSize="4">
                        <Columns>
                            <asp:ButtonColumn Text="Seleccionar" DataTextField="Nombre" CommandName="Select">
                            </asp:ButtonColumn>
                            <asp:BoundColumn Visible="False" DataField="cPerCodigo"></asp:BoundColumn>
                            <asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Departamento"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Provincia"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" PageButtonCount="3"></PagerStyle>
                    </asp:DataGrid>
                    <br />
                    <asp:TextBox ID="txtPersona" runat="server" Width="288px"></asp:TextBox>
                    <asp:Label ID="lblCodPersona" runat="server" Visible="False"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" colspan="3" style="width: 364px">
                <asp:GridView ID="gvPermisos" Font-Names="Verdana" Font-Size="8pt" runat="server"
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAsigna" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="nIntCodigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="cIntDescripcion" HeaderText="Descripción" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="width: 131px" align="left">
            </td>
            <td style="width: 189px; text-align: left;" align="right">
                <asp:Button ID="btnGrabar" runat="server" Width="110px" Text="Grabar" CssClass="Boton">
                </asp:Button><font face="Verdana"></font>
            </td>
        </tr>
    </table>
</asp:Content>
