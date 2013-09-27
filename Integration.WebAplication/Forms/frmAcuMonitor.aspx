<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_frmAcuMonitor" Title="MONITOR DE ACUERDOS DE DIRECTORIO" Codebehind="frmAcuMonitor.aspx.vb" %>

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
            <td align="center" style="height: 14px">
                <p class="CeldaInformacion">
                    Monitor de Acuerdos de Direcctorio</p>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                <span style="font-size: 10pt"></span>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: right">
                <table cellpadding="0" cellspacing="0" style="font-size: 10px; width: 615px; font-family: verdana">
                    <tr>
                        <td>
                            <asp:RadioButton ID="rbnUsuario" runat="server" Font-Bold="True" GroupName="Filtro"
                                Text="Por Usuario" Checked="True" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td colspan="2">
                            <asp:RadioButton ID="rbnFecha" runat="server" Font-Bold="True" GroupName="Filtro"
                                Text="Por Fecha" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table border="0" cellpadding="0" cellspacing="0" class="L" style="width: 280px">
                                <tr>
                                    <td style="text-align: left">
                                        <div style="width: 333px; height: 25px; text-align: left">
                                            <asp:TextBox ID="txtBuscar" runat="server" Width="250px"></asp:TextBox>
                                            <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" CssClass="Boton"
                                                Height="22px" OnClick="btnBuscar_Click" Text="Buscar" Width="70px" /></div>
                                        <asp:Label ID="lblPersona" runat="server" Font-Bold="True" ForeColor="#0000CC" Font-Names="Verdana"
                                            Font-Size="8pt"></asp:Label>
                                        <asp:Label ID="lblcPerCodigo" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                            Visible="False"></asp:Label>
                                        <asp:Label ID="lblArea" runat="server" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <div align="left" style="overflow: auto; width: 349px; height: 46px">
                                            <asp:GridView ID="gvPersona" runat="server" AutoGenerateColumns="False" DataKeyNames="cPerCodigo"
                                                OnSelectedIndexChanged="gvPersona_SelectedIndexChanged" ShowHeader="False" Width="330px">
                                                <Columns>
                                                    <asp:CommandField SelectText="Select" ShowSelectButton="True">
                                                        <ControlStyle CssClass="FilaEnlace" />
                                                    </asp:CommandField>
                                                    <asp:BoundField DataField="Nombre">
                                                        <ControlStyle CssClass="Select" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Area" />
                                                </Columns>
                                                <RowStyle CssClass="FilaGrid" />
                                                <SelectedRowStyle CssClass="CeldaEtiqueta" />
                                                <HeaderStyle CssClass="CabeceraGrid" />
                                            </asp:GridView>
                                        </div>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td colspan="2" valign="top">
                            <table cellpadding="0" cellspacing="0" style="font-size: 10px; width: 180px; font-family: verdana">
                                <tr>
                                    <td style="width: 54px">
                                        Fec. Ini
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecIni" runat="server" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 54px">
                                        Fec. Fin
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFecFin" runat="server" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFecIni"
                                ErrorMessage="RangeValidator" MaximumValue="3000/01/01" MinimumValue="2008/01/01"
                                Type="Date" ValidationGroup="Filtro"></asp:RangeValidator>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtFecFin"
                                ErrorMessage="RangeValidator" MaximumValue="3000/01/01" MinimumValue="2008/01/01"
                                Type="Date" ValidationGroup="Filtro"></asp:RangeValidator>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" style="font-size: 8pt; width: 615px;
                    font-family: verdana">
                    <tr>
                        <td>
                            <img src="../Imagenes/Completo.png" />
                        </td>
                        <td>
                            Ejecutado
                        </td>
                        <td>
                            <img src="../Imagenes/Avance.gif" />
                        </td>
                        <td>
                            Hay Avance
                        </td>
                        <td>
                            &nbsp;<img src="../Imagenes/FolderCloseB.gif" />
                        </td>
                        <td>
                            A tiempo sin avance
                        </td>
                        <td>
                            <img src="../Imagenes/Infraccion.png" />
                        </td>
                        <td>
                            Fuera de tiempo y sin Avance
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnMostrar" runat="server" Text="Mostrar" ValidationGroup="Filtro"
                    Width="108px" CssClass="Boton"  /><asp:Button ID="btnImprimir" runat="server" CssClass="Boton"
                        Text="Imprimir" />
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left; height: 152px;">
                <asp:GridView ID="gvAcuerdos" runat="server" AutoGenerateColumns="False" Font-Size="8pt"
                    Width="615px" DataKeyNames="cDocCodigo" CssClass="FilaGrid">
                    <Columns>
                        <asp:TemplateField HeaderText="N&#186; Documento">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbnNumDocumento" runat="server" Text='<%# Eval("cDocNDoc") %>'
                                    CommandName="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Asunto" HeaderText="Asunto" />
                        <asp:BoundField DataField="FecRegistro" HeaderText="F.Registro" />
                        <asp:TemplateField HeaderText="F. Sesi&#243;n">
                            <ItemTemplate>
                                <asp:LinkButton ID="lBnNumAcuerdo" runat="server" Text='<%# Eval("NumAcuerdo")%>'
                                    CommandName="Select"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="FecCumplimiento" HeaderText="F.Cumplimiento" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <table style="width: 34px">
                                    <tr>
                                        <td>
                                            <asp:Image ID="imgEstado" runat="server" ImageUrl='<%# AvaGrafico(Eval("TotPorcentaje"),Eval("DiaDiferencia")) %>' />
                                        </td>
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
                    <SelectedRowStyle CssClass="CeldaEtiqueta" />
                    <HeaderStyle CssClass="CabeceraGrid" />
                </asp:GridView>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
</asp:Content>
