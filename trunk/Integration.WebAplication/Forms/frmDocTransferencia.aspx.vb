﻿Imports Integration.BE.Persona
Imports System.Data
Imports Integration.BL
Imports Integration.DAConfiguration
Imports Integration.BE.TraDoc

Partial Class Forms_frmDocTransferencia
    Inherits System.Web.UI.Page

    Protected Sub txtPerOrigen_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerOrigen.TextChanged

        Dim PerRelacion As String = "1,2,14"
        Dim Clase As New clsConfiguration
        Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPer As BL_Persona = New BL_Persona()

        Dim Rs As DataTable
        ReqPer.cPerApellido = Clase.DBTilde(txtPerOrigen.Text)
        ReqPer.cPerRelTipo = PerRelacion
        Rs = ObjPer.ListaPeronas_BycPerApellido_cPerRelTipo(ReqPer)
        If Rs.Rows.Count > 0 Then
            gvPerOrigen.DataSource = Rs.DefaultView
            gvPerOrigen.DataBind()
        Else
            Response.Write("No se encontraron coincidencias")
        End If
        gvPerOrigen.Visible = True

        lblPerOriCodigo.Text = String.Empty
    End Sub

    Protected Sub gvPerOrigen_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerOrigen.SelectedIndexChanged
        txtPerOrigen.Text = gvPerOrigen.SelectedDataKey.Values("Nombre")
        lblPerOriCodigo.Text = gvPerOrigen.SelectedDataKey.Values("cPerCodigo")

        Dim Rs As New DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()

        ReqTraDoc.iOpcion = 21
        ReqTraDoc.cPerCodigo = Session(lblPerOriCodigo.Text.Trim)
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboOrigen.DataValueField = "nUniOrgCodigo"
        cboOrigen.DataTextField = "cIntDescripcion"
        cboOrigen.DataSource = Rs.DefaultView
        cboOrigen.DataBind()

        gvPerOrigen.DataSource = Nothing
        gvPerOrigen.DataBind()
        gvPerOrigen.Visible = False

    End Sub

    Protected Sub txtPerDestino_TextChanged(sender As Object, e As System.EventArgs) Handles txtPerDestino.TextChanged
        Dim PerRelacion As String = "1,2,14"
        Dim Clase As New clsConfiguration
        Dim ReqPer As BE_Req_Persona = New BE_Req_Persona()
        Dim ObjPer As BL_Persona = New BL_Persona()

        Dim Rs As DataTable
        ReqPer.cPerApellido = Clase.DBTilde(txtPerDestino.Text)
        ReqPer.cPerRelTipo = PerRelacion
        Rs = ObjPer.ListaPeronas_BycPerApellido_cPerRelTipo(ReqPer)
        If Rs.Rows.Count > 0 Then
            gvPerDestino.DataSource = Rs.DefaultView
            gvPerDestino.DataBind()
        Else
            Response.Write("No se encontraron coincidencias")
        End If
        gvPerDestino.Visible = True

        lblPerDesCodigo.Text = String.Empty
    End Sub

    Protected Sub gvPerDestino_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles gvPerDestino.SelectedIndexChanged
        txtPerDestino.Text = gvPerDestino.SelectedDataKey.Values("Nombre")
        lblPerDesCodigo.Text = gvPerDestino.SelectedDataKey.Values("cPerCodigo")


        Dim Rs As New DataTable

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()

        ReqTraDoc.iOpcion = 21
        ReqTraDoc.cPerCodigo = Session(lblPerDesCodigo.Text.Trim)
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)

        cboDestino.DataValueField = "nUniOrgCodigo"
        cboDestino.DataTextField = "cIntDescripcion"
        cboDestino.DataSource = Rs.DefaultView
        cboDestino.DataBind()


        gvPerDestino.DataSource = Nothing
        gvPerDestino.DataBind()
        gvPerDestino.Visible = False
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        Dim Clase As New clsConfiguration
        Dim objBLDoc As BL_Documento = New BL_Documento()

        Dim cDocCodigo = Clase.objGeneraCodDoc(objBLDoc.getFechaActual)


        Dim dDocFecha As String = Format(Date.Now, "MM/dd/yyyy HH:mm:ss")
        Dim cDocObs As String = "Transferencia de Documentos TD"
        clsInsert.objInsertDocumento(cDocCodigo, dDocFecha, cDocObs, TramiteDocumentario.DocTipo.gnDocTransferencia, 1, MyTrans, Cn)
        clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransOrigen, lblPerOriCodigo.Text.Trim, 1, 1, MyTrans, Cn)
        clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransDestino, lblPerDesCodigo.Text.Trim, 1, 1, MyTrans, Cn)
        clsInsert.objInsertDocPersona(cDocCodigo, TramiteDocumentario.DocPerTipo.gDocPerTipTransUsuario, Session("PerCodigo"), 1, 1, MyTrans, Cn)

        clsInsert.objInsertDocUniOrg(cDocCodigo, cboOrigen.SelectedValue, TramiteDocumentario.DocPerTipo.gDocPerTipTransOrigen, 1, MyTrans, Cn)
        clsInsert.objInsertDocUniOrg(cDocCodigo, cboDestino.SelectedValue, TramiteDocumentario.DocPerTipo.gDocPerTipTransDestino, 1, MyTrans, Cn)


        btnCargar_Click(sender, e)

    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As System.EventArgs) Handles btnCargar.Click
        Try
            Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
            Dim dt As DataTable = clsTraDoc.Get_Per_Tranferencia(lblPerDesCodigo.Text.Trim)
            gvDetalle.DataSource = dt
            gvDetalle.DataBind()
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
End Class
