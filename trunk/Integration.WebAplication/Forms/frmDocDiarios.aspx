<%@ Page Language="VB" AutoEventWireup="false" Inherits="IntegrationWebAplication.Forms_frmDocDiarios"
    CodeBehind="frmDocDiarios.aspx.vb" %>

 

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" 
namespace="CrystalDecisions.Web" tagprefix="CR" %>

 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Documentos Diarios</title>
    <link href="../Styles/Estilous.css" rel="stylesheet" type="text/css" />
    

</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table cellpadding="0" cellspacing="0" style="font-size: 10pt; width: 900px; font-family: verdana">
            <tr>
                <td colspan="2" class="Titulo">
                    Documentos Registrados
                </td>
            </tr>
            <tr>
                <td style="width: 150px; text-align: left;">
                    Seleccione el día
                </td>
                <td style="width: 630px">
                </td>
            </tr>
            <tr>
                <td style="width: 150px; text-align: left;" valign="top">
                    <table cellpadding="0" cellspacing="0" style="width: 150px">
                        <tr>
                            <td>
                                <asp:Calendar ID="cldFecha" runat="server" BackColor="White" BorderColor="#999999"
                                    CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                                    ForeColor="Black" Height="184px" Width="150px">
                                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                    <SelectorStyle BackColor="#CCCCCC" />
                                    <WeekendDayStyle BackColor="Silver" />
                                    <OtherMonthDayStyle ForeColor="Gray" />
                                    <NextPrevStyle VerticalAlign="Bottom" />
                                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                    <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                </asp:Calendar>
                                Fecha
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtFecha" runat="server" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="btnBuscar" name="btnBuscar" runat="server" Text="Buscar" Width="88px" />
                                <input type="button" name="btnBus" id="btnBus" value="Buscar Rep" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 12px">
                                <asp:LinkButton ID="LinkButton1" runat="server">Otro</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton ID="lnkCerrar" runat="server" Width="155px">Cerrar</asp:LinkButton>
                </td>
                <td style="width: 450px" align="left" valign="top">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
                    
                        EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False" HasCrystalLogo="False"
                        HasGotoPageButton="False" HasSearchButton="False" HasToggleGroupTreeButton="False"
                        ReuseParameterValuesOnRefresh="True" Height="50px"   Width="350px"  
                         EnableDrillDown="False"  ToolPanelView="None" /> 
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 150px; text-align: left;">
                </td>
                <td style="width: 750px; text-align: left;">
                    <asp:Label ID="lblError" Width="650px" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 150px">
                </td>
                <td style="width: 750px">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
