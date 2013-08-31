<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMisDocumentos.aspx.vb"
    Inherits="Forms_frmMisDocumentos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mis Documentos</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="TABLE3" align="center" border="0" cellpadding="0" cellspacing="0" class="cuadro"
            onclick="return TABLE3_onclick()" width="770">
            <tr>
                <td align="center" colspan="2">
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                        height="180" width="770">
                        <param name="_cx" value="20373">
                        <param name="_cy" value="4763">
                        <param name="FlashVars" value="">
                        <param name="Movie" value="CabTramite.swf">
                        <param name="Src" value="CabTramite.swf">
                        <param name="WMode" value="Window">
                        <param name="Play" value="-1">
                        <param name="Loop" value="-1">
                        <param name="Quality" value="High">
                        <param name="SAlign" value="">
                        <param name="Menu" value="-1">
                        <param name="Base" value="">
                        <param name="AllowScriptAccess" value="always">
                        <param name="Scale" value="ShowAll">
                        <param name="DeviceFont" value="0">
                        <param name="EmbedMovie" value="0">
                        <param name="BGColor" value="">
                        <param name="SWRemote" value="">
                        <param name="MovieData" value="">
                        <param name="SeamlessTabbing" value="1">
                        <param name="Profile" value="0">
                        <param name="ProfileAddress" value="">
                        <param name="ProfilePort" value="0">
                        <param name="AllowNetworking" value="all">
                        <embed height="180" src="CabTramite.swf" width="770"> </embed>
                    </object>
                </td>
            </tr>
            <tr>
                <td class="CabeceraTabla" colspan="2" width="770">
                </td>
            </tr>
            <tr>
                <td valign="top" width="150">
                    <table border="0" cellpadding="0" cellspacing="0" width="150">
                        <tr>
                            <td>
                                <%If Session("PerMesaPartes") = True Then%>
                                <!--#include file="mnuTramiteDoc2.html"-->
                                <%Else%>
                                <!--#include file="mnuTramiteDoc.html"-->
                                <%End If%>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 620px" valign="top">
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
