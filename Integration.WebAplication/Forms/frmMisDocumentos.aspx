<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_frmMisDocumentos" Title="DOCUMENTOS ENVIADOS" Codebehind="frmMisDocumentos.aspx.vb" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content> 
<asp:Content ID="contenido" ContentPlaceHolderID="contenido" runat="server">
    <table id="Table12" border="0" cellpadding="1" cellspacing="1" width="620">
        <tr>
            <td align="center" class="CeldaInformacion">
                Documentos enviados
            </td>
        </tr>
        <tr>
            <td align="center" class="CeldaEtiqueta" style="text-align: left">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvDocEnviado" runat="server" AutoGenerateColumns="False" DataKeyNames="cDocCodigo,CodPerDestino,nDocTipo,CodPerRemite,Archivo,Archiv"
                    Font-Names="Verdana" Font-Size="8pt" Width="614px">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:TemplateField HeaderText="N&#186; Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                        <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                            HtmlEncode="False" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
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
                    &nbsp;</p>
            </td>
        </tr>
        <tr>
            <td align="center" class="CeldaInformacion">
                <strong><font size="2">Documentos reci<span style="font-size: 14px">b</span>idos</font></strong>
            </td>
        </tr>
        <tr>
            <td align="center" class="CeldaEtiqueta">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:GridView ID="gvDocRecibido" runat="server" AutoGenerateColumns="False" DataKeyNames="cDocCodigo,CodPerDestino,nDocTipo,CodPerRemite,Archivo,Archiv"
                    Font-Names="Verdana" Font-Size="8pt" Width="614px">
                    <Columns>
                        <asp:BoundField DataField="Item" HeaderText="Item" />
                        <asp:TemplateField HeaderText="N&#186; Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                        <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                            HtmlEncode="False" />
                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
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
                    <RowStyle CssClass="FilaGrid" />
                    <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    <HeaderStyle CssClass="CabeceraGrid" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" class="SubTitle">
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="SubTitle">
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
