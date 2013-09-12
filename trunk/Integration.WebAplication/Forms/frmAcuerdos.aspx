<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAcuerdos.aspx.vb" Inherits="Forms_frmAcuerdos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Acuerdo de Directorio</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="font-size: 10px; width: 650px; font-family: verdana">
            <tr>
                <td colspan="4">
                    <strong>OFICIO Nº </strong>
                    <asp:Label ID="lblOfiNumero" runat="server"></asp:Label>&nbsp;
                    <hr style="width: 205px" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    Fecha de Sesión:
                    <asp:Label ID="lblAcuNumero" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>De</strong></td>
                <td style="text-align: left">
                    <asp:Label ID="lblRemite" runat="server"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>Para</strong></td>
                <td style="text-align: left">
                    <asp:Label ID="lblDestino" runat="server"></asp:Label></td>
                <td style="text-align: left">
                    &nbsp;<asp:Label ID="lblPerDesCodigo" runat="server" ForeColor="#FFFFFF"></asp:Label></td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>Fecha Rec</strong></td>
                <td style="text-align: left">
                    <asp:Label ID="lblFecRegistro" runat="server"></asp:Label></td>
                <td>
                    <strong>Fecha Cumpimiento</strong></td>
                <td style="text-align: left">
                    <asp:Label ID="lblFecCumplimiento" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblcDocCodigo" runat="server" ForeColor="#FFFFFF"></asp:Label></td>
                <td>
                </td>
                <td style="text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>Asunto</strong></td>
                <td style="text-align: left">
                    <asp:Label ID="lblAsunto" runat="server"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                </td>
                <td style="text-align: left">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>Detalle</strong></td>
                <td style="text-align: left">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 70px">
                </td>
                <td colspan="3" style="text-align: justify">
                    <asp:Label ID="lblContenido" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 70px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <strong>AVANCES A LA FECHA<br />
                    </strong>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: justify">
                    <asp:GridView ID="gvAvance" runat="server" AutoGenerateColumns="False" BackColor="White"
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
                        GridLines="Vertical" Width="646px">
                        <FooterStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField DataField="dDocTraFec" HeaderText="Fecha" />
                            <asp:BoundField DataField="cCarObs" HeaderText="Detalle" />
                            <asp:BoundField DataField="nPercent" HeaderText="Avance (%)" />
                            <asp:TemplateField HeaderText="Archivo">
                                <ItemTemplate>
                                    &nbsp;<asp:HyperLink ID="Link" runat="server" NavigateUrl='<%# "DocInternos/"  & Eval("Link") %>'
                                        Text='<%# LinkTexto(Eval("LinkTexto")) %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="background-color: gainsboro; height: 14px;">
                    <strong>Total Avence : </strong>
                    <asp:Label ID="lblTotAvance" runat="server" Font-Bold="True"></asp:Label><strong> %</strong></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right">
                    <asp:MultiView ID="mvAcuerdo" runat="server">
                        <asp:View ID="vewSustentar" runat="server">
            <table style="font-size: 10px; width: 650px; font-family: verdana" id="">
                <tr>
                    <td colspan="4" style="text-align: center">
                        <strong>
                            <br />
                        SUSTENTACIÓN </strong>
                        <br/>
                    </td>
                </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>A la Fecha</strong></td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtFecha" runat="server" BorderStyle="Ridge"></asp:TextBox>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtFecha"
                        Display="Dynamic" ErrorMessage="Fecha no Válida" MaximumValue="3000/01/01" MinimumValue="2008/01/01"
                        SetFocusOnError="True" Type="Date" ValidationGroup="Avance"></asp:RangeValidator></td>
                <td style="font-weight: bold; color: #000000">
                </td>
            </tr>
            <tr style="font-weight: bold; color: #000000">
                <td style="width: 70px; text-align: left">
                    % Avance</td>
                <td colspan="2" style="text-align: left">
                    <asp:TextBox ID="txtAvance" runat="server" BorderStyle="Ridge"></asp:TextBox><span
                        style="color: #ff0000"> </span>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtAvance"
                        Display="Dynamic" ErrorMessage="Número no Valido" MaximumValue="100" MinimumValue="1"
                        SetFocusOnError="True" Type="Integer" ValidationGroup="Avance"></asp:RangeValidator></td>
                <td style="color: #000000">
                </td>
            </tr>
            <tr style="color: #000000">
                <td style="width: 70px; text-align: left">
                    <strong>Descrición</strong></td>
                <td colspan="3" style="text-align: left">
                    <asp:TextBox ID="txtDescripcion" runat="server" BorderStyle="Ridge" Height="90px"
                        MaxLength="512" TextMode="MultiLine" Width="563px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 70px; text-align: left">
                    <strong>Archivo(<span style="color: #ff0000">*</span>)</strong></td>
                <td colspan="3" style="text-align: left">
                    <asp:FileUpload ID="fleArchivo" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion"
                        Display="Dynamic" ErrorMessage="No hay Descripción" ValidationGroup="Avance"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: left">
                    <strong>(<span style="color: #ff0033">*</span>)</strong> Sólo Archivos Comprimidos
                    no mayor de <strong>4M</strong></td>
            </tr>
            <tr>
                <td style="width: 70px">
                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" ValidationGroup="Avance" CssClass="BUTTON" /><asp:Button
                        ID="btnCerrar" runat="server" CssClass="BUTTON" Text="Cerrar" /></td>
                <td style="text-align: left">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 70px">
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblError" runat="server"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
                        </asp:View>
                    </asp:MultiView>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right">
                    <strong>
                    </strong>
                </td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
