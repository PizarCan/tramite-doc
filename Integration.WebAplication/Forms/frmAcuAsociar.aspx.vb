Imports Integration.BE.Documento
Imports Integration.BL
Imports System.Data

Partial Class Forms_frmAcuAsociar
    Inherits System.Web.UI.Page

    Protected Sub txtBuscar_Click(sender As Object, e As System.EventArgs) Handles txtBuscar.Click
        Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
        Dim ObjDoc As BL_Documento = New BL_Documento()
        Dim Rs As New DataTable
        ReqDoc.cDocNDoc = txtNumDocumento.Text.Trim
        Rs = ObjDoc.getDocConAcuerdo(ReqDoc)
        gvAcuerdos.DataSource = Rs
        gvAcuerdos.DataBind()
        Rs.Clear()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtFecAcuerdo.Text = Date.Now.Date
    End Sub

    Public Function With_Acuerdo(ByVal Acuerdo As String) As Boolean
        If Not Acuerdo Is String.Empty Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub txtAsociar_Click(sender As Object, e As System.EventArgs) Handles txtAsociar.Click
        If Not txtAcuerdo.Text Is String.Empty AndAlso gvAcuerdos.Rows.Count > 0 Then
            Dim Row As GridViewRow
            Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
            Dim ObjDoc As BL_Documento = New BL_Documento()


            For Each Row In gvAcuerdos.Rows
                Dim chk As New CheckBox
                chk = CType(Row.FindControl("chkEstado"), CheckBox)
                If chk.Enabled AndAlso chk.Checked Then
                    ReqDoc.cDocCodigo = gvAcuerdos.DataKeys(Row.RowIndex).Values("cDocCodigo")
                    ReqDoc.cPerCodigo = gvAcuerdos.DataKeys(Row.RowIndex).Values("cPerCodigo")
                    ReqDoc.nDocTipoNum = 2
                    ReqDoc.cDocNDoc = txtAcuerdo.Text.Trim
                    If Not ObjDoc.setDocIdentifica(ReqDoc) Then Exit For

                    Dim FecTratamiento As Date = txtFecAcuerdo.Text
                    Dim Fecha As String = Format(FecTratamiento, "MM/dd/yyyy")

                    ReqDoc.nEleCodigo = 1
                    ReqDoc.nCarCodigo = 1
                    ReqDoc.cCarObs = ""
                    ReqDoc.nPercent = 0
                    ReqDoc.dDocTraFec = Fecha


                    If Not ObjDoc.setDocTratamiento(ReqDoc) Then Exit For

                    txtBuscar_Click(sender, e)

                End If
            Next

        Else
            lblError.Text = "Faltan Datos"
        End If
    End Sub
End Class
