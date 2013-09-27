<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_RegDocumento" Title="MESA DE PARTES" Codebehind="RegDocumento.aspx.vb" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script language="jscript">
        function clickButton() {
        }   
    </script>
</asp:Content>
<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
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
                            <asp:DropDownList ID="cboAreaDestino" runat="server" Width="233px" Height="24px"
                                Font-Size="X-Small">
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
</asp:Content>
