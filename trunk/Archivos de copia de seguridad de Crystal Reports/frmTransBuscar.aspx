<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_frmTransBuscar" Title="CONSULTA DE DOCUMENTOS" Codebehind="frmTransBuscar.aspx.vb" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script language="jscript" type="text/javascript">
        function clickButton() {
        }   
    </script>
</asp:Content>
<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <table id="Table12" border="0" cellpadding="1" cellspacing="1" width="620">
        <tr>
            <td align="center">
                <p class="CeldaInformacion">
                    Cosultas de Documentos</p>
                <table border="0" width="615">
                    <tr>
                        <td class="CeldaEtiqueta" style="height: 24px; text-align: left">
                            Tipo
                        </td>
                        <td style="height: 24px">
                            <asp:DropDownList ID="cboTipDoc" runat="server" Width="183px">
                            </asp:DropDownList>
                        </td>
                        <td class="CeldaEtiqueta" style="height: 24px; text-align: left">
                            Periodo
                        </td>
                        <td style="height: 24px">
                            <span style="font-size: 10pt">
                                <asp:DropDownList ID="cboPeriodo" runat="server" Width="77px">
                                </asp:DropDownList>
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaEtiqueta" style="text-align: left" valign="top">
                            <asp:RadioButton ID="rbtPerRemite" runat="server" GroupName="Busqueda" Text="Remite" /><asp:RadioButton
                                ID="rbtPerDestino" runat="server" GroupName="Busqueda" Text="Destino" />
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtPerRemite" runat="server" Width="183px"></asp:TextBox><asp:DataGrid
                                ID="dgNombre" runat="server" AutoGenerateColumns="False" GridLines="None" Height="56px"
                                PageSize="4" ShowHeader="False" Width="230px">
                                <Columns>
                                    <asp:ButtonColumn CommandName="Select" DataTextField="Nombre" Text="Seleccionar">
                                    </asp:ButtonColumn>
                                    <asp:BoundColumn DataField="cPerCodigo" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Nombre" Visible="False"></asp:BoundColumn>
                                </Columns>
                                <PagerStyle PageButtonCount="3" Visible="False" />
                                <ItemStyle CssClass="FilaGrid" />
                            </asp:DataGrid>
                        </td>
                        <td class="CeldaEtiqueta" valign="top">
                            Mes
                        </td>
                        <td style="text-align: left" valign="top">
                            <asp:DropDownList ID="cboFilMes" runat="server" Width="77px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="CeldaEtiqueta" style="text-align: left" valign="top">
                            <asp:RadioButton ID="rbtItem" runat="server" Checked="True" GroupName="Busqueda"
                                Text="Item" /><asp:RadioButton ID="rbtAsunto" runat="server" GroupName="Busqueda"
                                    Text="Asunto" /><asp:RadioButton ID="rbtNumDocumneto" runat="server" GroupName="Busqueda"
                                        Text="Nº" Width="38px" />
                        </td>
                        <td valign="top">
                            <asp:TextBox ID="txtAsunto" runat="server" Font-Size="XX-Small" Width="183px"></asp:TextBox>
                        </td>
                        <td valign="top">
                        </td>
                        <td style="text-align: right" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                        <td valign="top">
                        </td>
                        <td valign="top">
                        </td>
                        <td style="text-align: right" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="1" style="text-align: left">
                            &nbsp;
                        </td>
                        <td align="right" colspan="3" style="text-align: right">
                            <asp:Label ID="lblPerRemiteCodigo" runat="server" Visible="False" Width="101px"></asp:Label><asp:Button
                                ID="Button1" runat="server" Height="0px" Text="Button" Width="0px" /><asp:Button
                                    ID="btnBuscar" runat="server" CssClass="Boton" Text="Buscar" Width="130px" />
                            <asp:Button ID="btnImprimir" runat="server" CssClass="Boton" Text="Imprimir" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                    ForeColor="#0000FF"></asp:Label>
            </td>
        </tr>
    </table>
    </td> </tr>
    <tr>
        <td colspan="2" valign="top">
            <asp:DataGrid ID="dgBuscar" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                Font-Size="9px" Width="772px">
                <HeaderStyle CssClass="CabeceraGrid" Font-Names="Verdana" Font-Size="10pt" ForeColor="White" />
                <Columns>
                    <asp:BoundColumn DataField="Item" HeaderText="N&#186;_Reg."></asp:BoundColumn>
                    <asp:BoundColumn DataField="DocTipo" HeaderText="Tipo_Doc."></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="Select" DataTextField="cDocNDoc" HeaderText="N&#186;_Doc."
                        Text="Seleccionar"></asp:ButtonColumn>
                    <asp:BoundColumn DataField="Asunto" HeaderText="Asunto"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PerRemite" HeaderText="Remitente"></asp:BoundColumn>
                    <asp:BoundColumn DataField="dFechaIni" HeaderText="Fecha"></asp:BoundColumn>
                    <asp:BoundColumn DataField="cDocCodigo" HeaderText="DocCodigo" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PerRecibe" HeaderText="Destino"></asp:BoundColumn>
                    <asp:BoundColumn DataField="PerDerivado" HeaderText="Derivado"></asp:BoundColumn>
                </Columns>
                <SelectedItemStyle CssClass="CeldaEtiqueta" />
                <ItemStyle CssClass="FilaGrid" />
            </asp:DataGrid>
            <asp:GridView ID="gvConsultas" runat="server" AutoGenerateColumns="False" DataKeyNames="cDocCodigo,Archivo,Archiv"
                Font-Names="Verdana" Font-Size="8pt" Width="772px">
                <RowStyle CssClass="FilaGrid" />
                <Columns>
                    <asp:BoundField DataField="Item" HeaderText="Item" />
                    <asp:BoundField DataField="DocTipo" HeaderText="Tipo" />
                    <asp:TemplateField HeaderText="N&#186; Documento">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                    <asp:BoundField DataField="PerRemite" HeaderText="Remite" />
                    <asp:BoundField DataField="dFechaIni" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                        HtmlEncode="False" />
                    <asp:BoundField DataField="PerRecibe" HeaderText="Destino" />
                    <asp:BoundField DataField="PerDerivado" HeaderText="Derivado" />
                    <asp:BoundField DataField="DocEstado" HeaderText="Estado" />
                    <asp:TemplateField HeaderImageUrl="~/Imagenes/Descargas.gif">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgArchivo" runat="server" AlternateText="No" ImageUrl="~/Imagenes/Descargar.gif"
                                ToolTip="Descargar Archivo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderImageUrl="~/Imagenes/Descargas.gif">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgArch" runat="server" AlternateText="No" ImageUrl="~/Imagenes/Descargar.gif"
                                ToolTip="Descargar Archivo" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle CssClass="CeldaEtiqueta" />
                <HeaderStyle CssClass="CabeceraGrid" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td valign="top" width="150">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td valign="top" width="620">
            <asp:Label ID="lblUltimoDoc" runat="server" Width="608px"></asp:Label>
        </td>
    </tr>
    </table>
</asp:Content>
