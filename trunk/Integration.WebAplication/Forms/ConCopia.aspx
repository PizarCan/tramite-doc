<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ConCopia.aspx.vb" Inherits="Forms_ConCopia" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ConCopia</title>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="420" align="center" border="0">
				<TR>
					<TD align="center" bgColor="#35a2e7">
						<P><FONT size="2" color="#ffffff">Agregar Copias</FONT></P>
					</TD>
				</TR>
				<TR>
					<TD align="left"><FONT face="Courier New" size="2">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="420" align="center" border="0">
								<TR>
									<TD style="WIDTH: 97px" vAlign="top"><FONT size="2">Persona</FONT></TD>
									<TD><asp:textbox id="txtDestino" runat="server" Font-Size="XX-Small" Width="300px"></asp:textbox><asp:datagrid id="dgNombre2" runat="server" Font-Size="8pt" Width="300px" Height="56px" BackColor="White"
											Font-Names="Courier New" GridLines="None" BorderColor="White" ShowHeader="False" AutoGenerateColumns="False" PageSize="4">
											<Columns>
												<asp:ButtonColumn Text="Seleccionar" DataTextField="Nombre" CommandName="Select"></asp:ButtonColumn>
												<asp:BoundColumn Visible="False" DataField="cPerCodigo"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
											</Columns>
											<PagerStyle Visible="False" PageButtonCount="3"></PagerStyle>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 97px"><FONT size="2">Universidad</FONT></TD>
									<TD><FONT size="2"><asp:dropdownlist id="cboInstDestino" runat="server" Font-Size="XX-Small" Width="300px" Height="24px"
												AutoPostBack="True"></asp:dropdownlist></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 97px"><FONT size="2">Área</FONT></TD>
									<TD><FONT size="2"><asp:dropdownlist id="cboAreaDestino" runat="server" Font-Size="XX-Small" Width="300px"></asp:dropdownlist></FONT></TD>
								</TR>
							</TABLE>
						</FONT><FONT face="Courier New" size="2">
                            <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" /><asp:button id="btnAgregarCopia" runat="server" Width="200px" Text="Agregar Copia"></asp:button><asp:button id="btnQuitarCopia" runat="server" Width="200px" Text="Quitar Copia"></asp:button></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px"><FONT face="Courier" size="2"><asp:listbox id="lstCopias" runat="server" Font-Size="XX-Small" Width="400px" Height="104px"></asp:listbox></FONT></TD>
				</TR>
				<TR>
					<TD><asp:button id="btnConfirmar" runat="server" Width="200px" Text="Grabar"></asp:button><asp:button id="btnCerrar" runat="server" Width="200px" Text="Cerrar"></asp:button></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>

</body>
</html>
