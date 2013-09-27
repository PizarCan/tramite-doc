<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="reportes.aspx.vb" Inherits="ExportarPDF.reportes" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html lang="es">
<head id="Head1" runat="server">
    <title>Reportes TRILCE</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:HiddenField ID="hf_tiporeporte" runat="server" />
    
        <asp:HiddenField ID="hf_valores" runat="server" />
    
    </div>
    </form>
</body>
</html>
