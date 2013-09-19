<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmRegistrarPersona.aspx.vb"
    Inherits="Forms_frmRegistrarPersona" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>REGISTRAR PERSONA</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table style="width: 650px; height: 134px" cellspacing="0" cellpadding="0" align="center"
        border="0">
        <tr>
            <td colspan="3" align="center" style="width: 524px" class="CabeceraTabla">
                <font face="Verdana">REGISTRO&nbsp;DE PERSONAL POR ÁREA<br />
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
                <div style="width: 508px; height: 100px; overflow: auto">
                    <asp:DataGrid ID="dgNombre" runat="server" Width="440px" Height="56px" Font-Size="8pt"
                        BackColor="White" Font-Names="Courier New" GridLines="None" BorderColor="White"
                        ShowHeader="False" AutoGenerateColumns="False" PageSize="4">
                        <Columns>
                            <asp:ButtonColumn Text="Seleccionar" DataTextField="Nombre" CommandName="Select">
                            </asp:ButtonColumn>
                            <asp:BoundColumn Visible="false" DataField="cPerCodigo"></asp:BoundColumn>
                            <asp:BoundColumn Visible="false" DataField="Nombre"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Departamento"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Provincia"></asp:BoundColumn>
                        </Columns>
                        <PagerStyle Visible="False" PageButtonCount="3"></PagerStyle>
                    </asp:DataGrid>
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
            <td style="width: 131px; height: 24px;" align="left" class="CeldaEtiqueta">
                Tipo Persona
            </td>
            <td style="width: 364px; height: 18px" align="left" colspan="3">
                <asp:DropDownList ID="cboTipoPersona" runat="server" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 24px;" align="left" class="CeldaEtiqueta">
                Apellidos
            </td>
            <td align="left" colspan="3" style="width: 364px; height: 24px;">
                <asp:TextBox ID="txtApellido" runat="server" Width="368px"></asp:TextBox><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 18px" align="left" class="CeldaEtiqueta">
                Nombre / Razón Social
            </td>
            <td style="width: 364px; height: 18px" align="left" colspan="3">
                <asp:TextBox ID="txtNombre" runat="server" Width="368px"></asp:TextBox><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 18px" align="left" class="CeldaEtiqueta">
                Tipo Documento
            </td>
            <td style="width: 364px; height: 18px" align="left" colspan="3">
                <asp:DropDownList ID="cboDocumento" runat="server" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 18px" align="left" class="CeldaEtiqueta">
                Número Documento
            </td>
            <td style="width: 364px; height: 18px" align="left" colspan="3">
                <asp:TextBox ID="txtNroDoc" runat="server" Width="150px"></asp:TextBox><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 18px" align="left" class="CeldaEtiqueta">
                Dirección
            </td>
            <td style="width: 364px; height: 18px" align="left" colspan="3">
                <asp:TextBox ID="txtDireccion" runat="server" Width="368px"></asp:TextBox><font face="Verdana"></font>
            </td>
        </tr>
        <tr>
            <td style="width: 131px; height: 16px" align="left" class="CeldaEtiqueta">
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
            <td style="width: 131px; height: 16px" align="left" class="CeldaEtiqueta">
                Institución y&nbsp; Área
            </td>
            <td style="height: 15px; text-align: left;" align="left" colspan="2">
                <asp:DropDownList ID="ddlInst" runat="server" Width="180px" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;
                <asp:DropDownList ID="ddlArea" runat="server" Width="180px">
                </asp:DropDownList>
                <font face="Verdana"></font><font face="Verdana"></font>
            </td>
        </tr>
        <tr><td></td><td>
            <asp:Label ID="lblCodSeleccionado" runat="server"></asp:Label>
            <asp:Label ID="lblnPerDirCodigo" runat="server"></asp:Label>
            </td></tr>
        <tr>
            <td style="width: 131px" align="left">
            </td>
            <td style="width: 189px; text-align: left;" align="right">
                <asp:Button ID="btnGrabar" runat="server" Width="110px" Text="Grabar" CssClass="Boton">
                </asp:Button><asp:Button ID="btnLimpiar" runat="server" Width="110px" Text="Limpiar" CssClass="Boton">
                </asp:Button><font face="Verdana"></font>
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
