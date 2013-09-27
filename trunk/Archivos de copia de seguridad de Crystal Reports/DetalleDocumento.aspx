<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Forms_DetalleDocumento" Codebehind="DetalleDocumento.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Detalle Documento</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="550" align="center" border="0">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<P><FONT face="Courier New" size="2"><STRONG></STRONG></FONT>&nbsp;</P>
						<P><FONT face="Courier New" size="2">
								<asp:label id="lblTipoDocumento" runat="server" Font-Bold="True"></asp:label>&nbsp;
                            <strong>Nº </strong>
                            <asp:Label ID="lblDocNumero" runat="server" Font-Names="Courier" Font-Size="8pt"></asp:Label>&nbsp;
                            <STRONG>Fecha:
								<asp:label id="lblfecha" runat="server" Font-Bold="False"></asp:label></STRONG>
								</FONT></P>
						</TD>
				</TR>
                <tr>
                    <td>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                    </td>
                </tr>
				<TR>
					<TD><FONT face="Courier New" size="2"><STRONG>De&nbsp;&nbsp; :</STRONG></FONT><FONT face="Courier New" size="2">
							<asp:label id="lblremitente" runat="server" Width="480px"></asp:label></FONT></TD>
				</TR>
                <tr>
                    <td>
                        <strong><span style="font-size: 10pt; font-family: Courier New">Para :</span></strong><FONT face="Courier New" size="2">
								<asp:label id="lbldestino" runat="server" Width="480px"></asp:label></font></td>
                </tr>
				<TR>
					<TD style="HEIGHT: 34px">
						<P><FONT face="Courier New" size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;<asp:label id="lblUO" runat="server" Width="480px"></asp:label></FONT></P>
						<P><FONT face="Courier New" size="2">&nbsp;</FONT>&nbsp;</P>
						</TD>
				</TR>
				<TR>
					<TD><FONT face="Courier New" size="2">
							<p align="left"><STRONG>Asunto</STRONG>
							</p>
							<p align="justify"><asp:label id="lblasunto" runat="server" Width="536px" Height="40px"></asp:label></p>
						</FONT>
					</TD>
				</TR>
				<TR>
					<TD><FONT face="Courier New" size="2">
							<p><STRONG>Detalle</STRONG></p>
							<p align="justify"><asp:label id="lbldetalle" runat="server" Width="536px" Height="40px"></asp:label></p>
						</FONT>
					</TD>
				</TR>
				<tr>
					<td><FONT face="Courier New" size="2">
							<p><STRONG>Observación</STRONG></p>
							<p align="justify"><asp:label id="lblobservacion" runat="server" Width="536px" Height="40px"></asp:label></p>
						</FONT>
					</td>
				</tr>
				<TR>
					<TD vAlign="top">
						<P><FONT face="Courier New" size="2"><STRONG>Cc:</STRONG></FONT></P>
						<P><FONT face="Courier New" size="2"><asp:label id="lblCopias" runat="server" Width="536px" Height="3px"></asp:label></FONT></P>
						</TD>
				</TR>
                <tr>
                    <td valign="top">
                        <asp:LinkButton ID="lnkReferencia" runat="server" Visible="False"></asp:LinkButton>
                        <asp:Label ID="lblRefCodigo" runat="server" Visible="False"></asp:Label></td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:MultiView ID="mVewReferencia" runat="server" Visible="False">
                            <asp:View ID="vewReferencia" runat="server">
                                <table style="width: 540px">
                                    <tr>
                                        <td style="width: 160px">
                                            Nº</td>
                                        <td>
                                            <asp:Label ID="lblRefNumero" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 160px">
                                            Asunto</td>
                                        <td>
                                            <asp:Label ID="lblRefAsunto" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 160px">
                                            Detalle</td>
                                        <td>
                                            <asp:Label ID="lblRefDetalle" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 160px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView></td>
                </tr>
				<TR>
					<TD align="right"><asp:button id="btncerrar" runat="server" Width="82px" Text="Cerrar"></asp:button></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
