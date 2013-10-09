Imports Integration.BE.UniOrgPerExt
Imports Integration.BL
Imports Integration.BE.Interface
Imports Integration.BE.PerUsuGruAcc

Public Class FrmRegArea
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("cPerCodigo") = "" Then
                Response.Redirect("~/login.aspx")
            Else
                CargarJerarquia()
                CargarEmpresa()
            End If
            
        End If
    End Sub

    Sub CargarEmpresa()
        Dim ReqUniOrgPerExt As New BE_Req_UniOrgPerExt()
        Dim BLUniOrgPerExt As New BL_UniOrgPerExt()
        Dim DtUniOrgPerExt As New DataTable()
        ReqUniOrgPerExt.cPerCodigo = Session("cPerCodigo")
        DtUniOrgPerExt = BLUniOrgPerExt.ObtenerInstitucionesBycPerCodigo(ReqUniOrgPerExt)
        If DtUniOrgPerExt.Rows.Count > 0 Then
            lblcPerJuridica.Text = DtUniOrgPerExt.Rows(0).Item("cPerCodigo")
        End If
    End Sub

    Sub CargarJerarquia()
        Dim ReqInterface As New BE_Req_Interface()
        Dim BLInterface As New BL_Interface()
        Dim DtInterface As New DataTable()

        ReqInterface.nIntClase = 1006
        DtInterface = BLInterface.getInterfaceBycIntJerarquia(ReqInterface)
        If DtInterface.Rows.Count > 0 Then
            GVInterface.DataSource = DtInterface
            GVInterface.DataBind()
            GVInterface.SelectRow(-1)
        End If
    End Sub


    Protected Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not GVInterface.SelectedRow Is Nothing Then
            PanelEditar.Visible = True
            Dim indice As Integer = GVInterface.SelectedRow.RowIndex
            If indice > -1 Then
                TxtnIntCodigo.Text = GVInterface.Rows(indice).Cells(1).Text
                TxtcIntJerarquia.Text = GVInterface.Rows(indice).Cells(3).Text
                TxtcIntNombre.Text = GVInterface.Rows(indice).Cells(4).Text
                TxtcIntDescripcion.Text = GVInterface.Rows(indice).Cells(5).Text
                lblopcion.Text = "E"
            End If
        End If
        
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As System.EventArgs) Handles btnGuardar.Click

        Dim ReqInterface As New BE_Req_Interface()
        Dim BLInterface As New BL_Interface()
        ReqInterface.nIntCodigo = TxtnIntCodigo.Text
        ReqInterface.nIntClase = 1006
        ReqInterface.cIntJerarquia = TxtcIntJerarquia.Text
        ReqInterface.cIntNombre = TxtcIntNombre.Text
        ReqInterface.cIntDescripcion = TxtcIntDescripcion.Text
        ReqInterface.nIntTipo = 1000

        If lblopcion.Text = "N" Then
            If BLInterface.InsInterface(ReqInterface) Then
                Dim ReqPerUsuGruAcc As New BE_Req_PerUsuGruAcc()
                Dim BLPerUsuGruAcc As New BL_PerUsuGruAcc()
                ReqPerUsuGruAcc.nObjTipo = 1006
                ReqPerUsuGruAcc.nObjCodigo = ReqInterface.nIntCodigo
                ReqPerUsuGruAcc.nSisGruTipo = 1004
                ReqPerUsuGruAcc.nSisGruCodigo = 1
                ReqPerUsuGruAcc.cPerCodigo = lblcPerJuridica.Text
                If BLPerUsuGruAcc.setPerUsuGruAcc(ReqPerUsuGruAcc) Then 
                    Response.Write("<script language='javascript'>alert('Se registro correctamente')</script>")
                Else
                    Response.Write("<script language='javascript'>alert('Hubo un error al registrar')</script>")
                End If
            Else
                Response.Write("<script language='javascript'>alert('Hubo un error al registrar')</script>")
            End If
        ElseIf lblopcion.Text = "E" Then
            If BLInterface.UpdInterface(ReqInterface) Then
                Response.Write("<script language='javascript'>alert('Se actualizó correctamente')</script>")
            Else
                Response.Write("<script language='javascript'>alert('Hubo un error al actualizar')</script>")
            End If
        End If

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As System.EventArgs) Handles btnNuevo.Click
        PanelEditar.Visible = True
        Dim ReqInterface As New BE_Req_Interface()
        Dim BLInterface As New BL_Interface()
        Dim ResInterface As New BE_Res_Interface()
        ReqInterface.nIntClase = 1006
        ResInterface = BLInterface.getNewCodigoInterface(ReqInterface)
        TxtnIntCodigo.Text = ResInterface.nIntCodigo
        TxtcIntJerarquia.Text = ""
        TxtcIntNombre.Text = ""
        TxtcIntDescripcion.Text = ""
        lblopcion.Text = "N"
        GVInterface.SelectRow(-1)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As System.EventArgs) Handles btnCancelar.Click
        lblopcion.Text = ""
        PanelEditar.Visible = False
        GVInterface.SelectRow(-1)
    End Sub

    Private Sub GVInterface_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GVInterface.SelectedIndexChanged
        If GVInterface.Rows.Count > 0 Then
            If Not GVInterface.SelectedRow Is Nothing Then
                Dim indice As Integer = GVInterface.SelectedRow.RowIndex
                If indice > -1 Then
                    TxtnIntCodigo.Text = GVInterface.Rows(indice).Cells(1).Text
                    TxtcIntJerarquia.Text = GVInterface.Rows(indice).Cells(3).Text
                    TxtcIntNombre.Text = GVInterface.Rows(indice).Cells(4).Text
                    TxtcIntDescripcion.Text = GVInterface.Rows(indice).Cells(5).Text
                    lblopcion.Text = "E"
                End If
            End If
        End If
    End Sub
End Class