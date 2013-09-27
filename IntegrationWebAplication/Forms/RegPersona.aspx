<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Forms_RegPersona" Codebehind="RegPersona.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>REGISTRAR PERSONA</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table style="width: 650px; height: 134px" cellspacing="0" cellpadding="0" align="center"
        border="0">
        <tr>
            <td colspan="3" align="center" style="width: 524px" class="CabeceraTabla">
                <font face="Verdana">REGISTRO&nbsp;DE PERSONA</font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px" align="left" class="CeldaInformacion">
                Tipo de Persona
            </td>
            <td align="left" colspan="3" style="width: 500px" class="CeldaBorder">
                <asp:DropDownList ID="cboPerTipo" runat="server" Width="187px">
                    <asp:ListItem Value="2">Jur&#237;dica</asp:ListItem>
                </asp:DropDownList>
                <font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 131px" class="CeldaInformacion">
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
                <div style="width: 508px; height: 100px; overflow: auto">
                    <asp:GridView ID="gvPersona" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        Width="487px" AutoGenerateColumns="False" ShowHeader="False">
                        <Columns>
                            <asp:BoundField DataField="cPerCodigo" />
                            <asp:BoundField DataField="Nombre" />
                            <asp:BoundField DataField="Departamento" />
                            <asp:BoundField DataField="Provincia" />
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="4" style="height: 24px; text-align: justify;">
                <span style="color: #ff0000; font-family: Verdana"><strong>Antes de realizar un nuevo
                    registro, por favor verificar si la persona ya existe.</strong></span>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 24px;" align="left" class="CeldaInformacion">
                Apellido
            </td>
            <td align="left" colspan="3" style="width: 364px; height: 24px;">
                <asp:TextBox ID="txtApellido" runat="server" Width="368px"></asp:TextBox><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 18px" align="left" class="CeldaInformacion">
                Nombre
            </td>
            <td style="width: 364px; height: 18px" align="left" colspan="3">
                <asp:TextBox ID="txtNombre" runat="server" Width="368px"></asp:TextBox><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 16px" align="left" class="CeldaInformacion">
                Ubigeo
            </td>
            <td style="height: 15px; text-align: left;" align="left" colspan="2">
                <asp:DropDownList ID="cboRegion" runat="server" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="cboProvincia" runat="server" Width="180px">
                </asp:DropDownList>
                <font face="Verdana"></font><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px" align="left">
            </td>
            <td style="width: 189px; text-align: left;" align="right">
                <asp:Button ID="btnGrabar" runat="server" Width="110px" Text="Grabar" CssClass="Boton">
                </asp:Button>
                <asp:Button ID="btnCancelar" runat="server" Width="110px" Text="Cancelar" CssClass="Boton">
                </asp:Button><font face="Verdana"></font>
            </td>
            <td align="left" style="width: 179px">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 131px">
            </td>
            <td align="right" colspan="2" style="text-align: left">
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                    ForeColor="#FF0066" Width="361px"></asp:Label>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
