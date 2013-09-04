<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegDocumento.aspx.vb" Inherits="Forms_RegDocumento" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v12.2, Version=12.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registrar un documento</title>
    <script language="jscript">
        function clickButton() {
        }   
    </script>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
    <table class="cuadro" cellspacing="0" cellpadding="0" width="770" align="center"
        border="0">
        <tr>
            <td align="center" colspan="2">
                <object codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                    height="180" width="770" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000">
                    <param name="_cx" value="20373" />
                    <param name="_cy" value="4763" />
                    <param name="FlashVars" value="" />
                    <param name="Movie" value="CabTramite.swf" />
                    <param name="Src" value="CabTramite.swf" />
                    <param name="WMode" value="Window" />
                    <param name="Play" value="-1" />
                    <param name="Loop" value="-1" />
                    <param name="Quality" value="High" />
                    <param name="SAlign" value="" />
                    <param name="Menu" value="-1" />
                    <param name="Base" value="" />
                    <param name="AllowScriptAccess" value="always" />
                    <param name="Scale" value="ShowAll" />
                    <param name="DeviceFont" value="0" />
                    <param name="EmbedMovie" value="0" />
                    <param name="BGColor" value="" />
                    <param name="SWRemote" value="" />
                    <param name="MovieData" value="" />
                    <param name="SeamlessTabbing" value="1" />
                    <param name="Profile" value="0" />
                    <param name="ProfileAddress" value="" />
                    <param name="ProfilePort" value="0" />
                    <param name="AllowNetworking" value="all" />
                    <embed src="CabTramite.swf" width="770" height="180"> </embed>
                </object>
            </td>
        </tr>
        <tr>
            <td width="770" colspan="2" class="CabeceraTabla">
            </td>
        </tr>
        <tr>
            <td valign="top" width="150">
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr>
                        <td> 
                            <%
                                Response.WriteFile("mnuTramiteDoc2.html")
                             %>
                        </td>
                    </tr>
                </table>
            </td>
            <td valign="top" width="620">
                <table id="Table1" cellspacing="1" cellpadding="1" width="620" border="0">
                    <tr>
                        <td align="center" class="CeldaInformacion">
                            MESA DE PARTES
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table width="615" border="0">
                                <tr>
                                    <td class="CeldaEtiqueta">
                                        <asp:Label ID="lblusuario" runat="server" Width="304px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboUO" runat="server" Width="296px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px">
                            <table width="615" border="0">
                                <tr>
                                    <td style="width: 375px" class="CeldaEtiqueta">
                                        Registro de Documentos
                                    </td>
                                    <td style="width: 193px" class="CeldaEtiqueta">
                                        Tipo de Documento:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboTipDoc" runat="server" Width="192px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 136px" class="CeldaEtiqueta">
                                        Numero:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNumDocumento" runat="server" Width="122px"></asp:TextBox>
                                    </td>
                                    <td class="CeldaEtiqueta">
                                        Fecha:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecha" runat="server" Width="112px"></asp:TextBox><asp:CompareValidator
                                            ID="CompareValidator1" runat="server" ValueToCompare="2006/01/01" Operator="GreaterThan"
                                            ControlToValidate="txtFecha" Type="Date" Display="Dynamic" ErrorMessage="CompareValidator">Fecha Incorrecta</asp:CompareValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" Width="0px" Text="'"></asp:Button><asp:Button
                                            ID="btnCrearPersona" runat="server" Width="70px" Text="Persona" Visible="False"
                                            CssClass="Boton"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Persona Que Envía:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNombre" runat="server" Width="288px"></asp:TextBox>
                                        <asp:DataGrid
                                            ID="dgNombre" runat="server" Width="440px" Height="56px" Font-Size="8pt" BackColor="White"
                                            Font-Names="Courier New" GridLines="None" BorderColor="White" ShowHeader="False"
                                            AutoGenerateColumns="False" PageSize="4">
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
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPerRemite" runat="server" Width="288px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Persona&nbsp; Destino:
                                    </td>
                                    <td>
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
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta">
                                        Institución:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboInstDestino" runat="server" Width="233px" AutoPostBack="True"
                                            Height="24px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="cboAreaDestino" runat="server" Width="233px" 
                                            Height="24px" Font-Size="X-Small">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="lblCodPerDestino" runat="server" Visible="False"></asp:Label><asp:Label
                                ID="lblCodPerRemite" runat="server" Visible="False"></asp:Label><asp:Label ID="lblCodPerRegistra"
                                    runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0">
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Asunto:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsunto" runat="server" Width="408px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Detalle:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDetalle" runat="server" Width="408px" Height="68px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Observación:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtObservacion" runat="server" Width="408px" Height="42px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="width: 616px; height: 25px" border="0">
                                <tr>
                                    <td align="left" width="135">
                                        <asp:Button ID="btnImprimir" runat="server" Text="Doc. Diarios" CssClass="Boton" />
                                        <asp:Button ID="Button3" runat="server" Width="0px" Text="'" Visible="False"></asp:Button>
                                    </td>
                                    <td style="width: 103px">
                                        <asp:Button ID="btnNuevo" TabIndex="1" runat="server" Width="110px" Text="Nuevo"
                                            Enabled="false" CssClass="Boton"></asp:Button>
                                    </td>
                                    <td style="width: 81px">
                                        <asp:Button ID="btnGrabar" runat="server" Width="110px" Text="Grabar" Enabled="False"
                                            CssClass="Boton"></asp:Button>
                                    </td>
                                    <td style="width: 81px">
                                        <asp:Button ID="btnCancelar" runat="server" Width="110px" Text="Cancelar" CssClass="Boton">
                                        </asp:Button>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnConCopia" runat="server" Width="120px" Text="Con Copia a :" Height="23px"
                                            Enabled="true" CssClass="Boton"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
