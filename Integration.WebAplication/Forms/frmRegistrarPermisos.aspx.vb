Imports System.Data.SqlClient
Imports System.Data
Imports Integration.Conection
Imports Integration.BL
Imports Integration.BE.Interface
Imports Integration.BE.Persona
Imports Integration.BE.PerUsuGruAcc
Imports System.Collections.Generic

Partial Class Forms_frmRegistrarPermisos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MostrarPermisos()
        End If

    End Sub

    Sub MostrarPermisos()
        Dim ReqPer As BE_Req_Interface = New BE_Req_Interface()
        Dim ObjPer As BL_Interface = New BL_Interface()
        Dim Data As DataTable = New DataTable()
        ReqPer.nIntClase = 1001
        ReqPer.cIntJerarquia = "65"
        Data = ObjPer.getInterfaceBycIntJerarquia(ReqPer)
        gvPermisos.DataSource = Data
        gvPermisos.DataBind()

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As System.EventArgs) Handles btnBuscar.Click
        BuscarPersona()
    End Sub

    Sub BuscarPersona()
        If txtBuscar.Text.Trim.Length > 3 Then
            Dim Clase As New clsConfiguraciones
            Dim Request As BE_Req_Persona = New BE_Req_Persona()
            Dim objBL As BL_Persona = New BL_Persona()
            Dim Rs As DataTable = New DataTable()
            Request.cPerApellido = Clase.DBTilde(txtBuscar.Text)
            Rs = objBL.ListaPeronas_BycPerApellido(Request)
            If Rs.Rows.Count > 0 Then
                txtPersona.Text = ""
                MostrarPermisos()
                dgNombre.DataSource = Rs
                dgNombre.DataBind()
                Ocultar(False)
                If Rs.Rows.Count = 1 Then
                    txtPersona.Text = dgNombre.Items(0).Cells(2).Text
                    lblCodPersona.Text = dgNombre.Items(0).Cells(1).Text
                    CargarPermisos(lblCodPersona.Text)
                    Ocultar(True)
                End If
            Else
                Response.Write("No Hay Registros")
            End If
        End If
    End Sub

    Protected Sub dgNombre_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgNombre.SelectedIndexChanged
        txtPersona.Text = dgNombre.SelectedItem.Cells(2).Text
        lblCodPersona.Text = dgNombre.SelectedItem.Cells(1).Text
        CargarPermisos(lblCodPersona.Text)
        Ocultar(True)
    End Sub
    Sub Ocultar(ByVal Valor As Boolean)
        If Valor = True Then
            dgNombre.Visible = False
        Else
            dgNombre.Visible = True
        End If
    End Sub
    Sub CargarPermisos(ByVal Codigo As String)
        Dim ObjPU As BL_PerUsuGruAcc = New BL_PerUsuGruAcc()
        Dim ReqPermisos As BE_Req_PerUsuGruAcc = New BE_Req_PerUsuGruAcc()
        Dim ListaPermisos As New List(Of BE_Res_PerUsuGruAcc)
        ReqPermisos.cPerCodigo = Codigo
        ReqPermisos.nObjTipo = 1001
        ReqPermisos.nSisGruTipo = 1004
        ListaPermisos = ObjPU.obtenerPermisos(ReqPermisos)
        If ListaPermisos.Count > 0 Then
            For Each ResPermisos As BE_Res_PerUsuGruAcc In ListaPermisos
                For i As Integer = 0 To gvPermisos.Rows.Count - 1
                    If ResPermisos.nIntCodigo = gvPermisos.Rows(i).Cells(1).Text Then
                        CType(Me.gvPermisos.Rows(i).Cells(0).FindControl("chkAsigna"), CheckBox).Checked = True
                    End If
                Next
            Next
        End If
    End Sub

    Protected Sub txtBuscar_TextChanged(sender As Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        If txtBuscar.Text.Trim.Length > 3 Then
            BuscarPersona()
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        Dim ReqPerUsuGruAcc As BE_Req_PerUsuGruAcc = New BE_Req_PerUsuGruAcc()
        Dim ObjPerUsuGruAcc As BL_PerUsuGruAcc = New BL_PerUsuGruAcc()

        ReqPerUsuGruAcc.cPerCodigo = lblCodPersona.Text
        ReqPerUsuGruAcc.nObjTipo = 1001
        ReqPerUsuGruAcc.nSisGruTipo = 1004
        If ObjPerUsuGruAcc.delPerUsuGruAcc(ReqPerUsuGruAcc) Then
            ReqPerUsuGruAcc.nSisGruCodigo = 1
            For i As Integer = 0 To gvPermisos.Rows.Count - 1
                If CType(Me.gvPermisos.Rows(i).Cells(0).FindControl("chkAsigna"), CheckBox).Checked Then
                    ReqPerUsuGruAcc.nObjCodigo = gvPermisos.Rows(i).Cells(1).Text
                    If Not ObjPerUsuGruAcc.setPerUsuGruAcc(ReqPerUsuGruAcc) Then
                        Exit Sub
                    End If
                End If
            Next
        End If
    End Sub
End Class