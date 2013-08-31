
Partial Class Forms_frmAcuerdos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
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
        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using Cn As New SqlConnection(MiConexion)
            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
                Dim cDocCodigo As String = Request.QueryString("cDocCodigo")
                Dim Reader As SqlDataReader = clsTraDoc.Get_Acuerdo_By_Sustentar(cDocCodigo, Session("PerCodigo"), MyTrans, Cn)

                While Reader.Read
                    lblRemite.Text = Reader("PerRemite")
                    lblDestino.Text = Reader("PerDestino")
                    lblOfiNumero.Text = Reader("NumDocumento")
                    lblFecRegistro.Text = Reader("FecRegistro")
                    lblFecCumplimiento.Text = Reader("FecCumplimiento")
                    lblAsunto.Text = Reader("Asunto")
                    lblContenido.Text = Reader("Detalle")
                    lblAcuNumero.Text = Reader("NumAcuerdo")
                    lblPerDesCodigo.Text = Reader("PerDesCodigo")
                    lblcDocCodigo.Text = Reader("cDocCodigo")
                End While
                Reader.Close()
                Reader = clsTraDoc.Get_Acuerdo_Anvance_By_Persona(cDocCodigo, lblPerDesCodigo.Text.Trim, MyTrans, Cn)
                gvAvance.DataSource = Reader
                gvAvance.DataBind()
                Reader.Close()

                Reader = clsTraDoc.Get_Acuerdo_Anvance_By_Persona(cDocCodigo, lblPerDesCodigo.Text.Trim, MyTrans, Cn)
                While Reader.Read
                    lblTotAvance.Text = Reader("TotPorcentaje")
                    Exit While
                End While
                Reader.Close()

                txtFecha.Text = Date.Now.Date
                txtAvance.Text = 100
                txtDescripcion.Focus()
                MyTrans.Commit()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
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
                Dim MiConexion As String = TramiteDocumentario.MiConexion
                Using Cn As New SqlConnection(MiConexion)
                    Try
                        Cn.Open()
                        Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                        Dim clsInsert As New clsInserciones
                        Dim clsTraDoc As New TramiteDocumentario.clsTraDoc
                        Dim clsManejador As New clsManejadorDatos
                        Dim cDocCodigo As String = Request.QueryString("cDocCodigo")
                        Dim cPerDestino As String = lblPerDesCodigo.Text
                        Dim Fecha As Date = txtFecha.Text
                        Dim EjeFecha As String = Format(Fecha, "MM/dd/yyyy")
                        Dim Correlativo As Integer = clsTraDoc.Get_NumCorrelativo_From_DocTratamiento(cDocCodigo, _
                                                    cPerDestino, MyTrans, Cn)

                        clsInsert.objInsertDocTratamiento(cDocCodigo, Correlativo, 2, txtDescripcion.Text.Trim, _
                                                            Val(txtAvance.Text), cPerDestino, EjeFecha, MyTrans, Cn)

                        'clsInsert.objInsertDocFecTramite(cDocCodigo, EjeFecha, EjeFecha, Correlativo, MyTrans, Cn)

                        If fleArchivo.HasFile Then
                            Dim SW As Boolean = clsManejador.obj_UpFiles(fleArchivo, TramiteDocumentario.Rutas.RutDoc & cPerDestino, Replace(fleArchivo.FileName, " ", ""))
                            If SW = False Then
                                'Dim DocLinMax As Integer = clsTraDoc.Get_Max_DocLink(cDocCodigo, 2, MyTrans, Cn)
                                clsInsert.objInsertDocLink(cDocCodigo, Correlativo, Replace(fleArchivo.FileName, " ", ""), 2, MyTrans, Cn, 1)
                            Else
                                lblError.Text = "El Nombre de Archivo ya existe, cámbie el nombre del archivo"
                                MyTrans.Rollback()
                                Exit Sub
                            End If
                        End If

                        MyTrans.Commit()
                    Catch ex As Exception
                        lblError.Text = ex.Message
                    End Try
                End Using
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
End Class
