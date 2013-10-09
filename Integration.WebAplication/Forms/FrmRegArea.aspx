<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/PageMaster.master"
    CodeBehind="FrmRegArea.aspx.vb" Inherits="IntegrationWebAplication.FrmRegArea" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <table>
        <tr>
            <td colspan="2">
                Mantenedor de Jerarquia de Instituciones
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Auto">
                    <asp:GridView ID="GVInterface" Font-Names="Verdana" Font-Size="8pt" runat="server"
                        AutoGenerateColumns="False" GridLines="Horizontal" ShowHeader="true" AutoGenerateSelectButton="True">
                        <Columns>
                            <asp:BoundField DataField="nIntCodigo" HeaderText="Codigo" />
                            <asp:BoundField DataField="nIntClase" HeaderText="Clase" Visible="false" />
                            <asp:BoundField DataField="cIntJerarquia" HeaderText="Jerarquia" />
                            <asp:BoundField DataField="cIntNombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="cIntDescripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="nIntTipo" HeaderText="Tipo" Visible="false" />
                        </Columns>
                        <SelectedRowStyle Font-Bold="True" BackColor="#CCFFFF" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
                <asp:Button ID="btnEditar" runat="server" Text="Editar" />
                <asp:Label ID="lblopcion" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lblcPerJuridica" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <asp:Panel ID="PanelEditar" runat="server" Visible="false">
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    nIntCodigo
                </td>
                <td>
                    <asp:TextBox ID="TxtnIntCodigo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    cIntJerarquia
                </td>
                <td>
                    <asp:TextBox ID="TxtcIntJerarquia" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    cIntNombre
                </td>
                <td>
                    <asp:TextBox ID="TxtcIntNombre" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    cIntDescripcion
                </td>
                <td>
                    <asp:TextBox ID="TxtcIntDescripcion" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </asp:Panel>
    </table>
</asp:Content>
