<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/PageMaster.master" Inherits="IntegrationWebAplication.Forms_frmAcuDirectorio" Title="ACUERDOS DE DIRECTORIO" Codebehind="frmAcuDirectorio.aspx.vb" %>

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
            <td align="center" class="CeldaInformacion">
                Acuerdos de Directorio
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left" class="CeldaEtiqueta">
                Periodo Actual 2013
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left">
                <table border="0" cellpadding="0" cellspacing="0" style="font-size: 8pt; width: 615px;
                    font-family: verdana">
                    <tr>
                        <td>
                            <img src="../Imagenes/Completo.png" alt="" />
                        </td>
                        <td>
                            Ejecutado
                        </td>
                        <td>
                            <img src="../Imagenes/Avance.gif" alt="" />
                        </td>
                        <td>
                            Hay Avance
                        </td>
                        <td>
                            <img height="16" src="../Imagenes/FoldercloseB.gif" alt="" />&nbsp;
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
            </td>
        </tr>
        <tr>
            <td align="center" style="text-align: left; height: 152px;">
                <asp:GridView ID="gvAcuerdos" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                    Font-Size="8pt" Width="615px" DataKeyNames="cDocCodigo">
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
                    <SelectedRowStyle CssClass="CeldaInformacion" />
                    <HeaderStyle Font-Size="Smaller" CssClass="CabeceraGrid" />
                </asp:GridView>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
        <tr>
            <td align="center">
            </td>
        </tr>
    </table>
</asp:Content>
