<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegDocArea.aspx.vb" Inherits="Forms_RegDocArea" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trámite Documentario</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top: 0">
    <form id="Form1" method="post" runat="server">
    <table class="cuadro" cellspacing="0" cellpadding="0" width="770" align="center">
        <tr>
            <td align="left" colspan="2" class="Cabecera">
                <img src="../Imagenes/CabeceraAU.png" />
                Trámite Documentario
            </td>
        </tr>
        <tr>
            <td width="770" bgcolor="#7ac930" colspan="2" class="CabeceraTabla" style="height: 20px">
            </td>
        </tr>
        <tr>
            <td valign="top" width="150">
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr>
                        <td>
                            <!--#include file="mnuTramiteDoc.html"-->
                        </td>
                    </tr>
                </table>
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
            </td>
            <td align="justify" width="620">
                <table id="Table1" cellspacing="1" cellpadding="1" width="620" border="0">
                    <tr>
                        <td align="center" style="width: 619px">
                            <table width="620" cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2" class="CeldaInformacion">
                                        Envio de Documentos
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 206px" class="CeldaEtiqueta">
                                        <asp:CheckBox ID="chkDelegado" runat="server" AutoPostBack="True" Font-Names="Verdana"
                                            Font-Size="8pt" Text="Enviar por Delegación" Width="205px" />
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="cboDelegado" runat="server" AutoPostBack="True" Font-Names="Verdana"
                                            Font-Size="8pt">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px; height: 111px;">
                            <table width="620" border="0">
                                <tr>
                                    <td class="CeldaEtiqueta" style="width: 301px; height: 21px">
                                        Usuario
                                    </td>
                                    <td style="height: 21px; text-align: right">
                                        <asp:Label ID="lblusuario" runat="server" Width="304px" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta" style="width: 301px; height: 21px">
                                        Area
                                    </td>
                                    <td style="height: 21px; text-align: right">
                                        <asp:DropDownList ID="cboUniOrgP" runat="server" Width="296px" Font-Names="Verdana"
                                            Font-Size="8pt" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta" style="width: 301px; height: 21px">
                                        dependencias
                                    </td>
                                    <td style="height: 21px; text-align: right">
                                        <asp:DropDownList ID="cboUO" runat="server" Width="296px" Font-Names="Verdana" Font-Size="8pt"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 301px; height: 21px;">
                                        <font size="2"></font>
                                    </td>
                                    <td style="text-align: right; height: 21px;">
                                        <font size="2"></font>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="pnlAcuerdo" runat="server" Visible="False">
                                <table border="0" style="font-size: 8px; font-family: verdana;" width="620">
                                    <tr>
                                        <td bgcolor="#336666" class="CeldaEtiqueta" style="width: 208px">
                                            <asp:CheckBox ID="chkAcuerdo" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                Text="Acuerdo Directorio" Width="205px" />
                                        </td>
                                        <td style="height: 26px">
                                            <asp:TextBox ID="txtAcuerdo" runat="server" Width="126px"></asp:TextBox>
                                        </td>
                                        <td bgcolor="#336666" class="CeldaEtiqueta">
                                            Fecha Cumplimiento
                                        </td>
                                        <td style="font-size: 8px; height: 26px; text-align: right;">
                                            <asp:TextBox ID="txtFecAcuerdo" runat="server" Width="126px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 208px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td style="text-align: right">
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/frmAcuAsociar.aspx"
                                                Target="_blank">Asociar Acuerdos</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFecAcuerdo"
                                    ErrorMessage="Fecha Incorrecta" MaximumValue="3000/01/01" MinimumValue="2008/01/01"
                                    Type="Date" Width="192px"></asp:RangeValidator></asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 43px; width: 619px;">
                            <table width="620">
                                <tr>
                                    <td class="CeldaEtiqueta" style="width: 277px">
                                        Tipo de Documento:
                                    </td>
                                    <td style="width: 375px">
                                        <asp:DropDownList ID="cboTipDoc" runat="server" Width="201px" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 91px" align="right">
                                        <asp:Button ID="Button2" runat="server" Text="Button" Width="0px" />
                                        <asp:Button ID="btnDelegar" runat="server" Text="Delegar" Width="75px" CssClass="Boton" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta" style="width: 277px">
                                        Mail institucional:
                                    </td>
                                    <td style="width: 375px">
                                        <asp:Label ID="lblMail" runat="server" Font-Names="Verdana" Font-Size="8pt"></asp:Label>
                                    </td>
                                    <td align="right" style="width: 91px">
                                        <asp:Button ID="btnRegMail" runat="server" CssClass="Boton" Text="Actualizar" Width="75px" />
                                    </td>
                                </tr>
                            </table>
                            <asp:MultiView ID="mvMail" runat="server">
                                <asp:View ID="vewMail" runat="server">
                                    <table style="width: 500px">
                                        <tr>
                                            <td class="CeldaInformacion" colspan="2">
                                                Actualización de mail institucional
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="CeldaEtiqueta">
                                                Mail :
                                            </td>
                                            <td class="FilaGrid">
                                                <asp:TextBox ID="txtPerMail" runat="server" Width="400px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: center">
                                                <asp:Button ID="btnMaiGrabar" runat="server" CssClass="Boton" Text="Grabar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <table width="620">
                                <tr>
                                    <td style="width: 277px" class="CeldaEtiqueta">
                                        Numero:
                                    </td>
                                    <td style="width: 178px">
                                        <asp:TextBox ID="txtNumDocumento" runat="server" Width="170px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="CeldaEtiqueta" style="width: 115px">
                                        Fecha:
                                    </td>
                                    <td style="text-align: right; width: 126px;">
                                        <asp:TextBox ID="txtFecha" runat="server" Width="112px"></asp:TextBox><asp:CompareValidator
                                            ID="CompareValidator1" runat="server" ErrorMessage="CompareValidator" Display="Dynamic"
                                            Type="Date" ControlToValidate="txtFecha" Operator="GreaterThan" ValueToCompare="2006/01/01">Fecha Incorrecta</asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <asp:MultiView ID="MVRRHH" runat="server">
                                <asp:View ID="VewRRHH" runat="server">
                                    <table style="width: 600px">
                                        <tr>
                                            <td class="CeldaEtiqueta">
                                                Tipo
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="cboRRHHTipo" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                    Width="460px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="CeldaEtiqueta">
                                                Motivo
                                            </td>
                                            <td colspan="3">
                                                <asp:DropDownList ID="cboRRHHMotivo" runat="server" Font-Names="Verdana" Font-Size="8pt"
                                                    Width="460px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="CeldaEtiqueta">
                                                F. Inicio.
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRRHHFecIni" runat="server" Width="80px"></asp:TextBox><asp:DropDownList
                                                    ID="cboRRHHHorIni" runat="server" Width="39px">
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                                :<asp:DropDownList ID="cboRRHHMinIni" runat="server" Width="39px">
                                                    <asp:ListItem Value="00">00</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td class="CeldaEtiqueta">
                                                F. Fin.
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRRHHFecFin" runat="server" Width="80px"></asp:TextBox><asp:DropDownList
                                                    ID="cboRRHHHorFin" runat="server" Width="39px">
                                                    <asp:ListItem Value="07">07</asp:ListItem>
                                                    <asp:ListItem Value="08">08</asp:ListItem>
                                                    <asp:ListItem Value="09">09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                </asp:DropDownList>
                                                :<asp:DropDownList ID="cboRRHHMinFin" runat="server" Width="39px">
                                                    <asp:ListItem Value="00">00</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>40</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="Comparevalidator2" runat="server" ControlToValidate="txtRRHHFecIni"
                                                    Display="Dynamic" ErrorMessage="CompareValidator" Operator="GreaterThan" Type="Date"
                                                    ValueToCompare="2006/01/01">Fecha Incorrecta</asp:CompareValidator>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="Comparevalidator3" runat="server" ControlToValidate="txtRRHHFecFin"
                                                    Display="Dynamic" ErrorMessage="CompareValidator" Operator="GreaterThan" Type="Date"
                                                    ValueToCompare="2006/01/01">Fecha Incorrecta</asp:CompareValidator>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:View>
                            </asp:MultiView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <table border="0">
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Persona&nbsp; Destino:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDestino" runat="server" Width="288px"></asp:TextBox>
                                        <asp:DropDownList ID="cboNumero" runat="server" Width="52px" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:DataGrid ID="dgNombre2" runat="server" Width="288px" PageSize="4" AutoGenerateColumns="False"
                                            ShowHeader="False" BorderColor="White" GridLines="None" Font-Names="Courier New"
                                            BackColor="White" Font-Size="8pt" Height="56px">
                                            <Columns>
                                                <asp:ButtonColumn Text="Seleccionar" DataTextField="Nombre" CommandName="Select">
                                                </asp:ButtonColumn>
                                                <asp:BoundColumn Visible="False" DataField="cPerCodigo"></asp:BoundColumn>
                                                <asp:BoundColumn Visible="False" DataField="Nombre"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="Numero"></asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle Visible="False" PageButtonCount="3"></PagerStyle>
                                        </asp:DataGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta">
                                        Institución:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="cboInstDestino" runat="server" Width="233px" AutoPostBack="True"
                                            Font-Size="XX-Small" Height="24px">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="cboAreaDestino" runat="server" Width="233px" Font-Size="XX-Small">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:MultiView ID="MV" runat="server">
                                            <asp:View ID="vew" runat="server">
                                                <table style="width: 460px">
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">
                                                            <asp:DropDownList ID="cboGrupo" runat="server" Height="24px" Visible="False" Width="300px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center">
                                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="Boton" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="gvDestino" runat="server" Width="460px" Font-Names="Verdana" Font-Size="9pt"
                                                                AutoGenerateColumns="False" ShowHeader="False">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chk" runat="server" Checked="True" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="PerApellido" />
                                                                    <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("PerCodigo","{0}") %>' Width="113px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Area" />
                                                                    <asp:TemplateField Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("AreCodigo","{0}") %>' Width="95px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView><br />
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <table border="0">
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Asunto:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtAsunto" runat="server" Width="408px" Height="40px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Detalle:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDetalle" runat="server" Width="408px" Height="68px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Observación:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtObservacion" runat="server" Width="408px" Height="42px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta" width="135">
                                        Doc. Referencia
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDocReferencia" runat="server"></asp:TextBox><asp:Button ID="btnDocBuscar"
                                            runat="server" CssClass="Boton" Text="Buscar" />
                                        <asp:CheckBoxList ID="chkDocRef" runat="server" AutoPostBack="True" CssClass="FilaGrid">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="CeldaEtiqueta" width="135">
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDocRefCodigo" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="135" class="CeldaEtiqueta">
                                        Adjuntar Archivo :
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="fleDoc" runat="server" CssClass="Boton" Width="201px" />
                                        <asp:FileUpload ID="fleDocu" runat="server" CssClass="Boton" Width="201px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span style="font-size: 8pt"><span style="color: #ff0000">(*)</span> Sólo Archivos comprimidos
                                            no mayor de 4M</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="CeldaInformacion">
                                        <asp:LinkButton ID="lnkCopia" runat="server">Agregar Copias</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:MultiView ID="mvCopia" runat="server">
                                            <asp:View ID="vewCopia" runat="server">
                                                <table style="width: 608px">
                                                    <tr>
                                                        <td class="CeldaEtiqueta">
                                                            Destino
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPerCopia" runat="server" Width="311px"></asp:TextBox>
                                                            <asp:GridView ID="gvCopia" runat="server" DataKeyNames="cPerCodigo,Nombre" Width="310px"
                                                                AutoGenerateColumns="False" ShowHeader="False">
                                                                <RowStyle CssClass="FilaGrid" />
                                                                <Columns>
                                                                    <asp:ButtonField DataTextField="Nombre" CommandName="Select" />
                                                                </Columns>
                                                                <SelectedRowStyle CssClass="CeldaEtiqueta" />
                                                            </asp:GridView>
                                                            <asp:Label ID="lblPerCopia" runat="server" Font-Names="Verdana" Font-Size="9pt"></asp:Label>
                                                            <asp:Label ID="lblPerCopCodigo" runat="server" Font-Names="Verdana" Font-Size="9pt"
                                                                Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CeldaEtiqueta">
                                                            Institución
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cboInsCopia" runat="server" Width="313px" AutoPostBack="True"
                                                                Font-Size="XX-Small" Height="24px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="CeldaEtiqueta">
                                                            Área
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="cboAreCopia" runat="server" Width="313px" Font-Size="XX-Small">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnCopAgregar" runat="server" Text="Agregar" CssClass="Boton" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:GridView ID="gvConCopia" runat="server" Width="464px" Font-Names="Verdana" Font-Size="9pt"
                                                                AutoGenerateColumns="False" ShowHeader="False" DataKeyNames="cPerCodigo,AreCodigo">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chk" runat="server" Checked="True" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="cPerApellido" />
                                                                    <asp:BoundField DataField="Area" />
                                                                </Columns>
                                                                <RowStyle CssClass="FilaGrid" />
                                                                <SelectedRowStyle CssClass="CeldaEtiqueta" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <span style="font-size: 8pt"><span style="color: red"></span></span>
                                    </td>
                                </tr>
                            </table>
                            <font size="2"></font>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <table style="width: 616px; height: 25px" border="0">
                                <tr>
                                    <td width="135">
                                        <asp:Button ID="Button1" runat="server" Width="0px" Text="Button"></asp:Button>
                                    </td>
                                    <td style="width: 103px">
                                        <asp:Button ID="btnNuevo" TabIndex="1" runat="server" Width="110px" Text="Nuevo"
                                            Enabled="False" CssClass="Boton"></asp:Button>
                                    </td>
                                    <td style="width: 81px">
                                        <asp:Button ID="btnGrabar" runat="server" Width="110px" Text="Grabar" Enabled="False"
                                            Font-Underline="True" CssClass="Boton"></asp:Button>
                                    </td>
                                    <td style="width: 81px">
                                        <asp:Button ID="btnCancelar" runat="server" Width="110px" Text="Cancelar" CssClass="Boton">
                                        </asp:Button>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnConCopia" runat="server" Width="120px" Text="Con Copia a :" Enabled="False"
                                            CssClass="Boton" Visible="False"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="10pt"
                                ForeColor="#FF0066"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 619px">
                            <asp:Label ID="lblCodPerRemite" runat="server" Visible="False"></asp:Label><asp:Label
                                ID="lblCodPerDestino" runat="server" Visible="False"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
