<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Consultas.aspx.vb" Inherits="Forms_Consultas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consultas</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table class="cuadro" cellSpacing="0" cellPadding="0" width="770" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" class="Cabecera">
                        <img src="../Imagenes/CabeceraAU.png" />Trámite Documentario</td>
				</tr>
				<tr>
					<td width="770" bgColor="#7ac930" colSpan="2" class="CabeceraTabla">
						
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="150">
						<table cellSpacing="0" cellPadding="0" width="150" border="0">
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
                        <asp:LoginStatus ID="LoginStatus1" runat="server" />
					</td>
					<td vAlign="top" width="620">
						<table id="Table12" cellSpacing="1" cellPadding="1" width="620" border="0">
							<tr>
								<td align="center">
									<P class="CeldaInformacion">Cosultas de Documentos</P>
												<table width="615" border="0">
													<tr>
                                                        <td style="height: 24px; text-align: left;" class="CeldaEtiqueta">
                                                            Tipo</td>
														<td style="height: 24px">
                                                            <asp:DropDownList ID="cboTipDoc" runat="server" Width="183px">
                                                            </asp:DropDownList></td>
														<td style="height: 24px; text-align: left" class="CeldaEtiqueta">
                                                            Periodo</td>
                                                        <td style="height: 24px">
                                                            <span style="font-size: 10pt">
                                                            <asp:DropDownList ID="cboPeriodo" runat="server" Width="77px">
                                                            </asp:DropDownList></span></td>
													</tr>
													<tr>
                                                        <td valign="top" style="text-align: left" class="CeldaEtiqueta">
                                                            <asp:radiobutton id="rbtPerRemite" runat="server" GroupName="Busqueda" Text="Remite" ></asp:radiobutton><asp:RadioButton ID="rbtPerDestino" runat="server" GroupName="Busqueda" Text="Destino" /></td>
														<td vAlign="top"><asp:textbox id="txtPerRemite" runat="server" Width="183px" ></asp:textbox><asp:datagrid id="dgNombre" runat="server" Width="230px" PageSize="4" AutoGenerateColumns="False"
																		ShowHeader="False" GridLines="None" Height="56px">
																		<Columns>
																			<asp:ButtonColumn Text="Seleccionar" DataTextField="Nombre" CommandName="Select"></asp:ButtonColumn>
																			<asp:BoundColumn Visible="False" DataField="cPerCodigo"></asp:BoundColumn>
																			<asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
																		</Columns>
																		<PagerStyle Visible="False" PageButtonCount="3"></PagerStyle>
                                                            <ItemStyle CssClass="FilaGrid" />
																	</asp:datagrid></td>
														<td vAlign="top" class="CeldaEtiqueta">
                                                            Mes</td>
                                                        <td style="text-align: left" valign="top">
                                                            <asp:DropDownList ID="cboFilMes" runat="server" Width="77px">
                                                            </asp:DropDownList></td>
													</tr>
                                                    <tr>
                                                        <td valign="top" style="text-align: left" class="CeldaEtiqueta">
                                                            <asp:RadioButton ID="rbtItem" runat="server" GroupName="Busqueda" Text="Item" Checked="True" /><asp:radiobutton id="rbtAsunto" runat="server" GroupName="Busqueda" Text="Asunto"></asp:radiobutton><asp:radiobutton id="rbtNumDocumneto" runat="server" Width="38px" GroupName="Busqueda" Text="Nº"></asp:radiobutton></td>
                                                        <td valign="top">
                                                            <asp:textbox id="txtAsunto" runat="server" Width="183px" Font-Size="XX-Small"></asp:textbox></td>
                                                        <td valign="top">
                                                        </td>
                                                        <td style="text-align: right" valign="top">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            &nbsp;</td>
                                                        <td valign="top">
                                                            </td>
                                                        <td valign="top">
                                                        </td>
                                                        <td style="text-align: right" valign="top">
                                                        </td>
                                                    </tr>
													<tr>
                                                        <td align="right" colspan="1" style="text-align: left">
                                                            &nbsp;</td>
                                                        <td align="right" colspan="3" style="text-align: right">
                                                            <asp:label id="lblPerRemiteCodigo" runat="server" Width="101px" Visible="False"></asp:label><asp:button id="Button1" runat="server" Width="0px" Text="Button" Height="0px"></asp:button><asp:button id="btnBuscar" runat="server" Width="130px" Text="Buscar" CssClass="Boton"></asp:button>
                                                            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="Boton" /></td>
													</tr>
												</table>
                                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="11pt"
                                        ForeColor="#0000FF"></asp:Label></td>
							</tr>
						</table>
                        </td>
				</tr>
                <tr>
                    <td colspan="2" valign="top">
                        <asp:datagrid id="dgBuscar" runat="server" Width="772px" Font-Size="9px" AutoGenerateColumns="False"
														Font-Names="Verdana">
														<HeaderStyle Font-Size="10pt" Font-Names="Verdana" ForeColor="White" CssClass="CabeceraGrid"></HeaderStyle>
														<Columns>
                                                            <asp:BoundColumn DataField="Item" HeaderText="N&#186;_Reg."></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="DocTipo" HeaderText="Tipo_Doc."></asp:BoundColumn>
															<asp:ButtonColumn Text="Seleccionar" DataTextField="cDocNDoc" HeaderText="N&#186;_Doc." CommandName="Select"></asp:ButtonColumn>
                                                            <asp:BoundColumn DataField="Asunto" HeaderText="Asunto"></asp:BoundColumn>
															<asp:BoundColumn DataField="PerRemite" HeaderText="Remitente"></asp:BoundColumn>
															<asp:BoundColumn DataField="dFechaIni" HeaderText="Fecha"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="cDocCodigo" HeaderText="DocCodigo"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PerRecibe" HeaderText="Destino"></asp:BoundColumn>
                                                            <asp:BoundColumn DataField="PerDerivado" HeaderText="Derivado"></asp:BoundColumn>
														</Columns>
                                                <SelectedItemStyle CssClass="CeldaEtiqueta" />
                                                <ItemStyle CssClass="FilaGrid" />
													</asp:datagrid>
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
                        <asp:Label ID="lblError" runat="server"></asp:Label></td>
                    <td valign="top" width="620">
										<asp:label id="lblUltimoDoc" runat="server" Width="608px"></asp:label></td>
                </tr>
			</table>
		</form>

</body>
</html>
