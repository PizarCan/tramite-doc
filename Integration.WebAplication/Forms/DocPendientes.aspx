<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DocPendientes.aspx.vb" Inherits="Forms_DocPendientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doc Pendientes</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table class="cuadro" cellSpacing="0" cellPadding="0" width="770" align="center" border="0" id="TABLE3" >
				<tr>
					<td align="center" colSpan="2" class="Cabecera">
                        <img src="../Imagenes/CabeceraAU.png" />Trámite Documentario</td>
				</tr>
				<tr>
					<td width="770" colSpan="2" class="CabeceraTabla">
						
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="150">
						<table cellSpacing="0" cellPadding="0" width="150" border="0">
							<tr>
								<td>
									<%if Session("PerMesaPartes") = true then
									        Response.WriteFile("mnuTramiteDoc2.html")
									else
									        Response.WriteFile("mnuTramiteDoc.html")
									 End If%>
								</td>
							</tr>
						</table>
                        <asp:LoginStatus ID="LoginStatus1" runat="server" />
					</td>
					<td vAlign="top" style="width: 620px">
						<table id="Table12" cellSpacing="1" cellPadding="1" width="620" border="0">
							<tr>
								<td align="center" class="CeldaInformacion">
									Documentos por Evaluar</td>
							</tr>
                            <tr>
                                <td align="center" style="text-align: left" class="CeldaEtiqueta">
                                    Periodo:
                                        <asp:DropDownList ID="cboPeriodo" runat="server" AutoPostBack="True">
                                        </asp:DropDownList>
                                    <asp:CheckBox ID="chkDelegado" runat="server" AutoPostBack="True" Checked="True" Text="Con Delegación" />
                                    Mes:
                                    <asp:DropDownList ID="cboFilMes" runat="server" AutoPostBack="True" Width="77px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="center" class="CeldaEtiqueta" style="text-align: left">
                                    <asp:CheckBox ID="chkTransferencia" runat="server" Text="Documentos de Transferencia" AutoPostBack="True" /></td>
                            </tr>
							<tr>
								<td align="center">
                                    <asp:GridView ID="gvDocEvaluar" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="8pt" Width="614px" DataKeyNames="cDocCodigo,CodPerDestino,nDocTipo,CodPerRemite,Archivo,Archiv,nUniOrgCodigo">
                                        <Columns>
                                            <asp:BoundField DataField="Item" HeaderText="Item" />
                                            <asp:TemplateField HeaderText="N&#186; Documento">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
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
									<P align="center"><asp:button id="btngrabar" runat="server" Width="88px" Text="Grabar" CssClass="Boton"></asp:button></P>
								</td>
							</tr>
							<tr>
								<td align="center" class="SubTitle"><STRONG><FONT size="2">Documentos Proveidos</FONT></STRONG>
								</td>
							</tr>
							<tr>
								<td align="center">
									<asp:GridView ID="gvProDoc" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="8pt" Width="614px" DataKeyNames="cDocCodigo,cPerCodigo,nDocTipo,Archivo,Archiv,nUniOrgCodigo,nDocPerEdiTipo">
                                        <RowStyle CssClass="FilaGrid" />
                                        <Columns>
                                            <asp:BoundField DataField="Item" HeaderText="Item" />
                                            <asp:TemplateField HeaderText="N&#186; Documento">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDoc" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
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
								<td align="center"><asp:button id="btnGrabar2" runat="server" Width="88px" Text="Grabar" CssClass="Boton"></asp:button></td>
							</tr>
							<tr>
								<td align="center" class="SubTitle"><STRONG><FONT size="2">Documentos Solo Lectura</FONT></STRONG>
								</td>
							</tr>
                            <tr>
                                <td align="center">
                                    <asp:GridView ID="gvCopias" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="cDocCodigo,CodPerDestino,nDocTipo,Archivo,Archiv,cPerCopCodigo" Font-Names="Verdana" Font-Size="8pt" Width="614px">
                                        <Columns>
                                            <asp:BoundField DataField="Item" HeaderText="Item" />
                                            <asp:TemplateField HeaderText="N&#186;-Documento">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDocumento" runat="server" Text='<%# Eval("cDocNDoc") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DocTipo" HeaderText="Tipo" />
                                            <asp:BoundField DataField="Detalle" HeaderText="Asunto" />
                                            <asp:BoundField DataField="dFechaIni" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False" />
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
                                    <asp:Button ID="btnCopia" runat="server" CssClass="Boton" Text="Grabar" Width="88px" /></td>
                            </tr>
							<tr>
								<td align="center" class="SubTitle"><FONT size="2"><STRONG>Documentos Devueltos</STRONG></FONT>
								</td>
							</tr>
							<tr>
								<td align="center"><asp:datagrid id="dgDocDevueltos" runat="server" Font-Names="Courier New" Font-Size="10pt" Width="408px" AutoGenerateColumns="False">
										<HeaderStyle Font-Names="Verdana" CssClass="CabeceraGrid"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="cDocNDoc" HeaderText="Documento"></asp:BoundColumn>
											<asp:ButtonColumn Text="Select" HeaderText="Ver Detalle" CommandName="Select"></asp:ButtonColumn>
											<asp:BoundColumn Visible="False" DataField="cDocCodigo" HeaderText="DocCodigo"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="nDocTipo" HeaderText="TipoDocumento"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CodPerDestino" HeaderText="CodPerDestino"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CodPerRemite" HeaderText="CodPerRemite"></asp:BoundColumn>
										</Columns>
                                    <SelectedItemStyle CssClass="CeldaEtiqueta" />
                                    <ItemStyle CssClass="FilaGrid" />
									</asp:datagrid>
                                    <asp:GridView ID="gvDevDoc" runat="server" AutoGenerateColumns="False"
                                        DataKeyNames="cDocCodigo,nDocTipo,CodPerDestino,CodPerRemite" Font-Names="Verdana" Font-Size="8pt" Width="614px">
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
                                    <asp:Button ID="btnDocDevGrabar" runat="server" CssClass="Boton" Text="Grabar" Width="88px" /></td>
                            </tr>
							<tr>
								<td>
                                    <asp:Label ID="lblError" runat="server"></asp:Label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>

</body>
</html>
