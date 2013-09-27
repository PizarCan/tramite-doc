<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="contenedoriframe.aspx.vb" Inherits="ExportarPDF.contenedoriframe" %>
<%
    Dim url As String = Request.Form("url")
    Dim width As String = Request.Form("width")
    Dim height As String = Request.Form("height")
    Dim variables As String = Request.Form("cadenavariables")
%>
<!DOCTYPE>

<html lang="es">
<head>
    <title></title>
    <script type="text/javascript">
        //var t = new Date(); $('#myIframe').html((new Date().getTime() - t.getTime())); --no borrar marco, contabiliza tiempo carga
        $('#marco').load(function () {
            Ra_LimpiarDiv('myIframe');
        });
    </script>
</head>
<body>
    <form action="<%=url %>" method="post" target="marco" id="formid">
       <input type="hidden" name="txtFrameVar" id="txtFrameVar" value="<%=variables%>" />
    </form>
    <div id="myIframe"></div>
    <iframe id="marco" name="marco" width="<%=width %>" height="<%=height %>"></iframe>
    <script type="text/javascript">
        progressbar('myIframe', 'Espere un momento por favor...');
        $("#formid").submit();
    </script>
</body>
</html>
