<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Adm_Papeletas.aspx.vb" Inherits="Forms_Adm_Papeletas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aprobación de Papeletas RRHH</title>
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
                                <%if Session("PerMesaPartes") = true then%>
                                <!--#include file="mnuTramiteDoc2.html"-->
                                <%else%>
                                <!--#include file="mnuTramiteDoc.html"-->
                                <%end if%>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 620px" valign="top">
                    <table id="Table12" border="0" cellpadding="1" cellspacing="1" width="620">
                        <tr>
                            <td align="center" class="CeldaInformacion">
                                APROBACIÓN POR RRHH</td>
                        </tr>
                        <tr style="font-size: 10pt">
                            <td align="center">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr style="font-size: 10pt">
                            <td align="center">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
        <asp:GridView ID="GvPapRRhh" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4"
            DataKeyNames="cDocCodigo" GridLines="Horizontal" Width="600px">
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="cDocCodigo" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblcDocCodigo" runat="server" Text='<%# eval("cDocCodigo") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Motivo">
                    <ItemTemplate>
                        <asp:Label ID="lblmotivo" runat="server" CssClass="Contenido" Text='<%# eval("Motivo") %>'
                            Width="148px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripci&#243;n">
                    <ItemTemplate>
                        <asp:Label ID="lblDescripcion" runat="server" CssClass="Contenido" Height="45px"
                            Text='<%# eval("Descripcion") %>' Width="163px"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha y Hora de Salida">
                    <ItemTemplate>
                        <asp:Label ID="lblHoraSalida" runat="server" CssClass="Contenido" Height="37px" Text='<%# eval("dFecIni") %>'
                            Width="102px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha y Hora de Retorno">
                    <ItemTemplate>
                        <asp:Label ID="lblHoraRetorno" runat="server" CssClass="Contenido" Height="37px"
                            Text='<%# eval("dFecFin") %>' Width="102px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trabajador">
                    <ItemTemplate>
                        <asp:Label ID="lblPersona" runat="server" CssClass="Contenido" Height="34px" Text='<%# eval("Nombres") %>'
                            Width="129px"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:BoundField DataField="SR" HeaderText="CS/R">
                    <ItemStyle CssClass="Contenido" />
                    <HeaderStyle CssClass="Titulo" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Estado" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# eval("Estado") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="n" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblnDocCheck" runat="server" CssClass="Contenido" Text='<%# eval("nDocCheck") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAutorizacion" runat="server" Checked="True" AutoPostBack="True" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observaci&#243;n RRHH">
                    <ItemTemplate>
                        <asp:TextBox ID="txtObsRRHH" runat="server" Rows="5" Text='<%# eval("cObsRRHH") %>'
                            TextMode="MultiLine" Width="135px"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle CssClass="Titulo" />
                </asp:TemplateField>
            </Columns>
            <RowStyle CssClass="FilaGrid" BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle CssClass="CeldaEtiqueta" />
            <HeaderStyle CssClass="CabeceraGrid" />
        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <p align="center">
                                    &nbsp;<asp:Button ID="CmdAprobarRRhh" runat="server" CssClass="Boton" Text="Aprobar"
                                        Width="88px" />
                                    &nbsp;&nbsp;
                                    <asp:Button ID="CmdRechazar" runat="server" CssClass="Boton" Text="Rechazar"
                                        Width="88px" /></p>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
        <asp:Label ID="lbler2" runat="server" CssClass="FilaGrid"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>

</body>
</html>
