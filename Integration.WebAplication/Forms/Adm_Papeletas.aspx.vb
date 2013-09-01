Imports System.Data
Imports System.Data.SqlClient

Partial Class Forms_Adm_Papeletas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Papeletas_RRhh()
        End If
    End Sub

    Sub Papeletas_RRhh()
        'Dim Clase As New TramiteDocumentario.clsTraDoc
        'Dim reader As SqlDataReader
        'Dim dt As New DataTable
        'Dim Row As DataRow
        'Dim table As New DataTable
        'Dim MyTrans As SqlTransaction

        'reader = Clase.Get_Papeletas_AtenRRhh(Session("PerCodigo"), MyTrans, cn)
        'If reader.HasRows Then
        '    dt.Columns.Add("cDocCodigo")
        '    dt.Columns.Add("Motivo")
        '    dt.Columns.Add("Descripcion")
        '    dt.Columns.Add("dFecIni")
        '    dt.Columns.Add("dFecFin")
        '    dt.Columns.Add("Nombres")
        '    dt.Columns.Add("SR")
        '    dt.Columns.Add("Estado")
        '    dt.Columns.Add("nDocSubCheck")
        '    dt.Columns.Add("nDocCheck")
        '    dt.Columns.Add("cObsRRHH")
        '    While reader.Read
        '        Row = dt.NewRow
        '        Row("cDocCodigo") = reader.Item("cDocCodigo")
        '        Row("Motivo") = reader.Item("Motivo")
        '        Row("Descripcion") = reader.Item("Descripcion")
        '        Row("dFecIni") = reader.Item("dFecIni")
        '        Row("dFecFin") = reader.Item("dFecFin")
        '        Row("Nombres") = reader.Item("Nombres")
        '        Row("SR") = reader.Item("SR")
        '        Row("Estado") = reader.Item("Estado")
        '        Row("nDocSubCheck") = reader.Item("nDocSubCheck")
        '        Row("nDocCheck") = reader.Item("nDocCheck")
        '        Row("cObsRRHH") = reader.Item("cObsRRHH")
        '        '*************************************************
        '        dt.Rows.Add(Row)
        '    End While
        '    table = dt
        '    GvPapRRhh.DataSource = table
        '    GvPapRRhh.DataBind()
        '    '********************************
        '    CmdAprobarRRhh.Visible = True
        '    '********************************
        '    Call cargarCheck()
        'Else
        '    CmdAprobarRRhh.Visible = False
        'End If
  
    End Sub
    Sub cargarCheck()
        'Dim row As GridViewRow
        'Dim lblnDocCheck As New Label
        'Dim chkAutorizacion As New CheckBox
        'Dim txtObsRRHH As New TextBox
        'Dim DPLEstado As New DropDownList
        'For Each row In GvPapRRhh.Rows
        '    lblnDocCheck = row.FindControl("lblnDocCheck")
        '    chkAutorizacion = row.FindControl("chkAutorizacion")
        '    txtObsRRHH = row.FindControl("txtObsRRHH")
        '    If lblnDocCheck.Text = "1" Then
        '        chkAutorizacion.Enabled = False
        '        txtObsRRHH.Enabled = False
        '    ElseIf lblnDocCheck.Text = "2" Then
        '        chkAutorizacion.Enabled = False
        '        txtObsRRHH.Enabled = False
        '    Else
        '        chkAutorizacion.Enabled = True
        '        txtObsRRHH.Enabled = True
        '    End If
        'Next
    End Sub

    Protected Sub CmdAprobarRRhh_Click(sender As Object, e As System.EventArgs) Handles CmdAprobarRRhh.Click
        Estado_PapeletasRRHH(1)
    End Sub

    Sub Estado_PapeletasRRHH(ByVal Estado As Integer)
        'Dim lblcDocCodigo As Label
        'Dim chkAutorizacion As CheckBox
        'Dim txtObsRRHH As TextBox
        'Dim Row As GridViewRow
        'Dim MyTrans As SqlTransaction

        'Using cn As New SqlConnection(TramiteDocumentario.MiConexion)
        '    Try
        '        cn.Open()
        '        MyTrans = cn.BeginTransaction
        '        For Each Row In GvPapRRhh.Rows
        '            lblcDocCodigo = Row.FindControl("lblcDocCodigo")
        '            chkAutorizacion = Row.FindControl("chkAutorizacion")
        '            txtObsRRHH = Row.FindControl("txtObsRRHH")
        '            If chkAutorizacion.Enabled = True Then
        '                If chkAutorizacion.Checked = True Then
        '                    Dim clsInsert As New clsInserciones
        '                    clsInsert.Upd_AprobacionRRhh(lblcDocCodigo.Text, Session("PerCodigo"), Estado, txtObsRRHH.Text, MyTrans, cn)
        '                    lbler2.Text = "se registro correctamente"
        '                    clsInsert = Nothing
        '                    chkAutorizacion.Checked = False
        '                End If
        '            End If
        '        Next
        '        MyTrans.Commit()
        '    Catch ex As Exception
        '        Response.Write(ex.Message)
        '    End Try
        'End Using
        'Call Papeletas_RRhh()
    End Sub

    Protected Sub CmdRechazar_Click(sender As Object, e As System.EventArgs) Handles CmdRechazar.Click
        Estado_PapeletasRRHH(2)
    End Sub
End Class
