<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Forms_frmAcuAsociar" Codebehind="frmAcuAsociar.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table border="0" cellpadding="0" style="font-size: 10px; width: 450px; font-family: verdana">
            <tr>
                <td colspan="3" style="text-align: center">
                    <strong><span style="font-size: 10pt">Asociar Oficios con Acuerdo</span></strong></td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <strong>Oficio</strong></td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtNumDocumento" runat="server" Width="150px"></asp:TextBox></td>
                <td style="text-align: right">
                    <asp:Button ID="txtBuscar" runat="server" Text="Buscar" Width="120px" CssClass="BUTTON" /></td>
            </tr>
            <tr>
                <td style="text-align: left">
                </td>
                <td colspan="2">
                    <asp:GridView ID="gvAcuerdos" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="391px" DataKeyNames="cDocCodigo,cPerCodigo">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="Documento" HeaderText="N&#186; Documento" />
                            <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                            <asp:BoundField DataField="Acuerdo" HeaderText="Acuerdo" />
                            <asp:TemplateField HeaderText="/">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEstado" runat="server" Checked='<%# With_Acuerdo(Eval("Acuerdo")) %>' Enabled='<%# Not With_Acuerdo(Eval("Acuerdo")) %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle BackColor="#E3EAEB" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <strong>Acuerdo</strong></td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtAcuerdo" runat="server" Width="150px"></asp:TextBox></td>
                <td style="text-align: right">
                    </td>
            </tr>
            <tr>
                <td style="text-align: left">
                    <strong>Fecha</strong></td>
                <td style="text-align: left">
                    <asp:TextBox ID="txtFecAcuerdo" runat="server" Width="150px"></asp:TextBox></td>
                <td style="text-align: right">
                    <asp:Button ID="txtAsociar" runat="server" Text="Asociar" Width="120px" CssClass="BUTTON" ValidationGroup="Acuerdos" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: left">
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFecAcuerdo"
                        Display="Dynamic" ErrorMessage="Fecha Incorrecta" MaximumValue="300/01/01" MinimumValue="2008/01/01"
                        ValidationGroup="Acuerdos"></asp:RangeValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAcuerdo"
                        Display="Dynamic" ErrorMessage="Falta Acuerdo" ValidationGroup="Acuerdos"></asp:RequiredFieldValidator></td>
                <td style="text-align: right">
                    <asp:Button ID="txtNuevo" runat="server" Text="Nuevo" Width="60px" CssClass="BUTTON" /><asp:Button ID="txtSalir" runat="server" Text="Salir" Width="60px" CssClass="BUTTON" /></td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="2" style="text-align: left">
                    <asp:Label ID="lblError" runat="server"></asp:Label></td>
            </tr>
        </table>
    
    </div>
    </form>

</body>
</html>
