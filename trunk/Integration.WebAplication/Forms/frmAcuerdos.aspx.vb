Imports Integration.BE.Documento
Imports Integration.BL
Imports System.Data
Imports System.IO
Imports Integration.DAConfiguration

Partial Class Forms_frmAcuerdos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoaderData()
            If Request.QueryString("Tipo") = 1 Then
                mvAcuerdo.ActiveViewIndex = -1
            Else
                mvAcuerdo.ActiveViewIndex = 0
            End If
        End If
    End Sub

    Sub LoaderData()


        Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento
        Dim ObjDoc As BL_Documento = New BL_Documento
        ReqDoc.cDocCodigo = Request.QueryString("cDocCodigo")
        ReqDoc.cPerCodigo = Request.QueryString("cPerCodigo")
        'ReqDoc.cPerCodigo = Session("cPerCodigo")

        Dim dt As New DataTable
        dt = ObjDoc.getDocAcuerdoBySustentar(ReqDoc)

        For x As Integer = 0 To dt.Rows.Count - 1

            lblRemite.Text = dt.Rows(x).Item("PerRemite")
            lblDestino.Text = dt.Rows(x).Item("PerDestino")
            lblOfiNumero.Text = dt.Rows(x).Item("NumDocumento")
            lblFecRegistro.Text = dt.Rows(x).Item("FecRegistro")
            lblFecCumplimiento.Text = dt.Rows(x).Item("FecCumplimiento")
            lblAsunto.Text = dt.Rows(x).Item("Asunto")
            lblContenido.Text = dt.Rows(x).Item("Detalle")
            lblAcuNumero.Text = dt.Rows(x).Item("NumAcuerdo")
            lblPerDesCodigo.Text = dt.Rows(x).Item("PerDesCodigo")
            lblcDocCodigo.Text = dt.Rows(x).Item("cDocCodigo")
        Next

        dt.Clear()
        ReqDoc.cPerCodigo = lblPerDesCodigo.Text.Trim

        dt = ObjDoc.getDocAcuerdoAvanceByPersona(ReqDoc)
        gvAvance.DataSource = dt
        gvAvance.DataBind()
        dt.Clear()

        dt = ObjDoc.getDocAcuerdoAvanceByPersona(ReqDoc)
        For x As Integer = 0 To dt.Rows.Count - 1
            lblTotAvance.Text = dt.Rows(x).Item("TotPorcentaje")
        Next
        dt.Clear()
        If lblTotAvance.Text = "" Then lblTotAvance.Text = "0"
        txtFecha.Text = Date.Now.Date
        txtAvance.Text = 100
        txtDescripcion.Focus()
    End Sub
    Public Function LinkTexto(ByVal Texto As String) As String
        If Texto = "No" Then
            Return ""
        Else
            Return Texto
        End If
    End Function


    Protected Sub btnGrabar_Click(sender As Object, e As System.EventArgs) Handles btnGrabar.Click
        If Not txtAvance.Text.Trim Is String.Empty AndAlso Not txtFecha.Text.Trim Is String.Empty AndAlso Not txtDescripcion.Text.Trim Is String.Empty Then
            If Val(lblTotAvance.Text) + Val(txtAvance.Text) <= 100 Then
                Dim cDocCodigo As String = Request.QueryString("cDocCodigo")
                Dim cPerDestino As String = lblPerDesCodigo.Text
                Dim Fecha As Date = txtFecha.Text
                Dim EjeFecha As String = Format(Fecha, "MM/dd/yyyy")

                Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
                Dim ObjDoc As BL_Documento = New BL_Documento()
                ReqDoc.cDocCodigo = cDocCodigo
                ReqDoc.cPerCodigo = cPerDestino
                Dim Correlativo As Integer = ObjDoc.getNumCorrelativoDocTratamiento(ReqDoc)

                ReqDoc.nEleCodigo = Correlativo
                ReqDoc.nCarCodigo = 2
                ReqDoc.cCarObs = txtDescripcion.Text.Trim
                ReqDoc.nPercent = Val(txtAvance.Text)
                ReqDoc.dDocTraFec = Fecha

                If Not ObjDoc.setDocTratamiento(ReqDoc) Then
                    Exit Sub
                End If


                If fleArchivo.HasFile Then
                    Dim SW As Boolean = obj_UpFiles(fleArchivo, modTraDoc.RutDoc & cPerDestino, Replace(fleArchivo.FileName, " ", ""))
                    If SW = False Then
                        ReqDoc.cDocCodigo = cDocCodigo
                        ReqDoc.nDocLinNum = Correlativo
                        ReqDoc.cDocLinUrl = Replace(fleArchivo.FileName, " ", "")
                        ReqDoc.nDocLinTipo = 2
                        ReqDoc.nDocLinGrupo = 1
                        If Not ObjDoc.setDocLink(ReqDoc) Then lblError.Text = "Error"

                    Else
                        lblError.Text = "El Nombre de Archivo ya existe, cámbie el nombre del archivo"
                        Exit Sub
                    End If
                End If

                LoaderData()
                txtDescripcion.Text = String.Empty
                txtDescripcion.Focus()
            Else
                lblError.Text = "Total del Avance a superado el 100%"
            End If
        End If
    End Sub

    Protected Sub btnCerrar_Click(sender As Object, e As System.EventArgs) Handles btnCerrar.Click
        Response.Write("<script language=javascript>window.close()</script>")
    End Sub



    Public Function obj_UpFiles(ByVal FleArchivo As FileUpload, ByVal ImgRuta As String, Optional ByVal NewFileName As String = "") As Boolean

        Try
            Dim Exist As Boolean
            Dim RutNewFileName As String = ImgRuta
            System.IO.Directory.CreateDirectory(ImgRuta)

            If NewFileName <> String.Empty Then
                ImgRuta += "\" & NewFileName
            Else
                ImgRuta += "\" & Path.GetFileName(FleArchivo.FileName)
            End If

            If FleArchivo.HasFile Then

                If System.IO.File.Exists(ImgRuta) = False Then

                    If NewFileName = String.Empty Then
                        FleArchivo.PostedFile.SaveAs(ImgRuta)
                    Else
                        FleArchivo.PostedFile.SaveAs(RutNewFileName & "\" & NewFileName)
                    End If

                    Exist = False
                Else
                    Exist = True
                End If
            End If
            Return Exist
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
