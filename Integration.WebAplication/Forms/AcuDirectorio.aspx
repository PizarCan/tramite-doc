<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AcuDirectorio.aspx.vb" Inherits="Forms_AcuDirectorio" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DocPendientes</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table class="cuadro" cellSpacing="0" cellPadding="0" width="770" align="center" border="0">
				<tr>
					<td align="center" colSpan="2" class="Cabecera">
                        <img src="../Imagenes/CabeceraAU.png" />Trámite Documentario</td>
				</tr>
				<tr>
					<td width="770" colSpan="2" class="CabeceraTabla">
						
					</td>
				</tr>
				<tr>
					<td valign="top" width="150">
						<table cellSpacing="0" cellPadding="0" width="150" border="0">
							<tr>
								<td style="height: 19px">
									<%if Session("PerMesaPartes") = true then%>
									<!--#include file="mnuTramiteDoc2.html"-->
									<%else%>
									<!--#include file="mnuTramiteDoc.html"-->
									<%end if%>
								</td>
							</tr>
						</table>
					</td>
					<td vAlign="top" width="620">
						<table id="Table12" cellSpacing="1" cellPadding="1" width="620" border="0">
							<tr>
								<td align="center" class="CeldaInformacion">
									Acuerdos de Directorio
								</td>
							</tr>
                            <tr>
                                <td align="center" style="text-align: left" class="CeldaEtiqueta">
                                    Periodo Actual 2009</td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left">
                                    <table border="0" cellpadding="0" cellspacing="0" style="font-size: 8pt; width: 615px;
                                        font-family: verdana">
                                        <tr>
                                            <td>
                                                <img src="../Imagenes/Completo.png" /></td>
                                            <td>
                                                Ejecutado</td>
                                            <td>
                                                <img src="../Imagenes/Avance.gif" /></td>
                                            <td>
                                                Hay Avance</td>
                                            <td>
                                                <img height="16" src="../Imagenes/FoldercloseB.gif" />&nbsp;</td>
                                            <td>
                                                A tiempo sin avance</td>
                                            <td>
                                                <img src="../Imagenes/Infraccion.png" /></td>
                                            <td>
                                                Fuera de tiempo y sin Avance</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="text-align: left; height: 152px;">
                                    <asp:GridView ID="gvAcuerdos" runat="server" AutoGenerateColumns="False"
                                        Font-Names="Verdana" Font-Size="8pt" Width="615px" DataKeyNames="cDocCodigo">
                                        <Columns>
                                            <asp:TemplateField HeaderText="N&#186; Documento">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbnNumDocumento" runat="server" Text='<%# Eval("cDocNDoc") %>' CommandName ="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                                            <asp:BoundField DataField="FecRegistro" HeaderText="F.Registro" />
                                            <asp:TemplateField HeaderText="F. Sesi&#243;n">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lBnNumAcuerdo" runat="server" Text='<%# Eval("NumAcuerdo")%>' CommandName="Select"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="FecCumplimiento" HeaderText="F.Cumplimiento" />
                                            <asp:TemplateField HeaderText="Estado">
                                                <ItemTemplate>
                                                    <table style="width: 34px">
                                                        <tr>
                                                            <td>
                                                    <asp:Image ID="imgEstado" runat="server" ImageUrl='<%# AvaGrafico(Eval("TotPorcentaje"),Eval("DiaDiferencia")) %>' /></td>
                                                            <td>
                                                                <asp:Label ID="lblPorcentaje" runat="server" Font-Names="Verdana" Font-Size="7pt"
                                                                    Text='<%# Eval("TotPorcentaje") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="FilaGrid" />
                                        <SelectedRowStyle CssClass="CeldaInformacion" />
                                        <HeaderStyle Font-Size="Smaller" CssClass="CabeceraGrid" />
                                    </asp:GridView>
                                    <asp:Label ID="lblError" runat="server"></asp:Label></td>
                            </tr>
							<tr>
								<td align="center"></td>
							</tr>
							<tr>
								<td align="center"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>

</body>
</html>
