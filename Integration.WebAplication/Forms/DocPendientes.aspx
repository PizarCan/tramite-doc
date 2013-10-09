<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_DocPendientes" Title="DOCUMENTOS PENDIENTES" Codebehind="DocPendientes.aspx.vb" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
<script language="Javascript" type="text/javascript">

    function abre(url, Nombre) {
        window.open(url, Nombre, "width=665,height=600,scrollbars=yes,Left=20,Top=20;");
    }
    </script>
</asp:Content> 
<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <table id="Table12" cellspacing="1" cellpadding="1" width="620" border="0">
        <tr>
            <td align="center" class="CeldaInformacion">
                Documentos por Evaluar
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left" class="CeldaEtiqueta">
                Periodo:
                <asp:DropDownList ID="cboPeriodo" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <asp:CheckBox ID="chkDelegado" runat="server" AutoPostBack="True" Checked="True"
                    Text="Con Delegación" />
                Mes:
                <asp:DropDownList ID="cboFilMes" runat="server" AutoPostBack="True" Width="77px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" class="CeldaEtiqueta" style="text-align: left">
                <asp:CheckBox ID="chkTransferencia" runat="server" Text="Documentos de Transferencia"
                    AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvDocEvaluar" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                    Font-Size="8pt" Width="614px" DataKeyNames="cDocCodigo,CodPerDestino,nDocTipo,CodPerRemite,Archivo,Archiv,nUniOrgCodigo">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:TemplateField HeaderText="N&#186; Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"
                            HtmlEncode="False" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="cboEstado" runat="server">
                                </asp:DropDownList>
                                <asp:CheckBox ID="chkMulDoc" runat="server" Visible="False" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderImageUrl="~/Imagenes/Descargas.gif">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgArchivo" runat="server" AlternateText="No" ImageUrl="~/Imagenes/Descargar.gif"
                                    ToolTip="Descargar Archivo" />
                            </ItemTemplate>
                        </asp:TemplateField> 
                    </Columns>
                    <RowStyle CssClass="FilaGrid" />
                    <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    <HeaderStyle CssClass="CabeceraGrid" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <p align="center">
                    <asp:Button ID="btngrabar" runat="server" Width="88px" Text="Grabar" CssClass="Boton">
                    </asp:Button></p>
            </td>
        </tr>
        <tr>
            <td align="center" class="SubTitle">
                <strong><font size="2">Documentos Proveidos</font></strong>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvProDoc" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                    Font-Size="8pt" Width="614px" DataKeyNames="cDocCodigo,cPerCodigo,nDocTipo,Archivo,Archiv,nUniOrgCodigo,nDocPerEdiTipo">
                    <RowStyle CssClass="FilaGrid" />
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:TemplateField HeaderText="N&#186; Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"
                            HtmlEncode="False" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:DropDownList ID="cboEstado" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderImageUrl="~/Imagenes/Descargas.gif">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgArchivo" runat="server" AlternateText="No" ImageUrl="~/Imagenes/Descargar.gif"
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
            <td align="center">
                <asp:Button ID="btnGrabar2" runat="server" Width="88px" Text="Grabar" CssClass="Boton">
                </asp:Button>
            </td>
        </tr>
        <tr>
            <td align="center" class="SubTitle">
                <strong><font size="2">Documentos Solo Lectura</font></strong>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvCopias" runat="server" AutoGenerateColumns="False" DataKeyNames="cDocCodigo,CodPerDestino,nDocTipo,Archivo,Archiv,cPerCopCodigo"
                    Font-Names="Verdana" Font-Size="8pt" Width="614px">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:TemplateField HeaderText="N&#186;-Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDocumento" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="DocTipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                        <asp:BoundField DataField="dFechaIni" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}"
                            HtmlEncode="False" />
                        <asp:TemplateField HeaderImageUrl="~/Imagenes/Descargas.gif">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgArchivo" runat="server" AlternateText="No" ImageUrl="~/Imagenes/Descargar.gif"
                                    ToolTip="Descargar Archivo" />
                            </ItemTemplate>
                        </asp:TemplateField> 
                        <asp:TemplateField HeaderText="/">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEstado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="FilaGrid" />
                    <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    <HeaderStyle CssClass="CabeceraGrid" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnCopia" runat="server" CssClass="Boton" Text="Grabar" Width="88px" />
            </td>
        </tr>
        <tr>
            <td align="center" class="SubTitle">
                <font size="2"><strong>Documentos Devueltos</strong></font>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:DataGrid ID="dgDocDevueltos" runat="server" Font-Names="Courier New" Font-Size="10pt"
                    Width="408px" AutoGenerateColumns="False">
                    <HeaderStyle Font-Names="Verdana" CssClass="CabeceraGrid"></HeaderStyle>
                    <Columns>
                        <asp:BoundColumn DataField="cDocNDoc" HeaderText="Documento"></asp:BoundColumn>
                        <asp:ButtonColumn Text="Select" HeaderText="Ver Detalle" CommandName="Select"></asp:ButtonColumn>
                        <asp:BoundColumn Visible="False" DataField="cDocCodigo" HeaderText="DocCodigo"></asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="nDocTipo" HeaderText="TipoDocumento">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="CodPerDestino" HeaderText="CodPerDestino">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="CodPerRemite" HeaderText="CodPerRemite">
                        </asp:BoundColumn>
                    </Columns>
                    <SelectedItemStyle CssClass="CeldaEtiqueta" />
                    <ItemStyle CssClass="FilaGrid" />
                </asp:DataGrid>
                <asp:GridView ID="gvDevDoc" runat="server" AutoGenerateColumns="False" DataKeyNames="cDocCodigo,nDocTipo,CodPerDestino,CodPerRemite"
                    Font-Names="Verdana" Font-Size="8pt" Width="614px">
                    <RowStyle CssClass="FilaGrid" />
                    <Columns>
                        <asp:TemplateField HeaderText="N&#186;-Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDocumento" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                        <asp:TemplateField HeaderText="/">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkEstado" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    <HeaderStyle CssClass="CabeceraGrid" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnDocDevGrabar" runat="server" CssClass="Boton" Text="Grabar" Width="88px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
