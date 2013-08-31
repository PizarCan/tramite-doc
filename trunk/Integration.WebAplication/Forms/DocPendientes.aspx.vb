
Partial Class Forms_DocPendientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Session("PerCodigo") = "6000007183"
        clsConsultasComunes.Ins_User_From_Login(Session("PerCodigo"))
        If Not Page.IsPostBack Then
            Try
                Using Cn As New SqlConnection(MiConexion)
                    Cn.Open()

                    Dim PrdActual As Integer
                    Dim Reader As SqlDataReader
                    Dim clsComunes As New clsConsultasComunes
                    Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                    Dim nActMes As Integer = Month(Date.Today)

                    Reader = clsComunes.ObjPeriodoActual(1, MyTrans, Cn)

                    If Reader.HasRows Then
                        Reader.Read()
                        PrdActual = Reader("nPrdCodigo")
                    End If
                    Reader.Close()

                    Reader = clsComunes.Get_Constante(1005, MyTrans, Cn)
                    cboFilMes.DataTextField = "cConDescripcion"
                    cboFilMes.DataValueField = "nConValor"
                    cboFilMes.DataSource = Reader
                    cboFilMes.DataBind()
                    Reader.Close()

                    cboFilMes.SelectedValue = nActMes

                    LoaderData_By_Periodo(Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, Cn), PrdActual, "6318,6319,6325", Val(cboFilMes.SelectedValue))

                    LoaderCombo()
                    MyTrans.Commit()
                End Using
                'AgregarAtributo()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If
    End Sub

    Protected Sub btngrabar_Click(sender As Object, e As System.EventArgs) Handles btngrabar.Click
        SaveEstado(gvDocEvaluar.Visible)
    End Sub

    Protected Sub dgDocDevueltos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dgDocDevueltos.SelectedIndexChanged
        Dim script As String
        Dim CodDocumento As String
        Dim TipDocumento As String
        Dim PerDesCodigo As String
        Dim PerRemCodigo As String
        CodDocumento = dgDocDevueltos.SelectedItem.Cells(2).Text
        TipDocumento = dgDocDevueltos.SelectedItem.Cells(3).Text
        PerDesCodigo = dgDocDevueltos.SelectedItem.Cells(4).Text
        PerRemCodigo = dgDocDevueltos.SelectedItem.Cells(5).Text
        script = "<script Language=JavaScript>window.open('ReenviarDoc.aspx?CodDocumento=" + CodDocumento + "&TipoDocumento=" + TipDocumento + "&DocumentoEstado=0&PerDesCodigo=" + PerDesCodigo + "&PerRemCodigo=" + PerRemCodigo + "','Detalle','scrollbars=yes,status=yes,height=550,width=660')</script>"
        Response.Write(script)
    End Sub

    Sub SaveEstado(ByVal withPeriodo As Boolean)
        'If withPeriodo = True Then
        saveGridView()
        'Else
        '    saveDataGrid()
        'End If
        Response.Redirect("DocPendientes.aspx")
    End Sub


    Sub saveGridView()
        Dim Row As GridViewRow
        Dim MyTrans As SqlTransaction
        Using cn As New SqlConnection(MiConexion)
            Dim clsTraDoc As New clsTraDoc
            Dim clsInsert As New clsInserciones
            Dim cDocCodigo As String
            Dim nMax As Integer
            Dim I As Integer
            Dim cPerDelCodigo() As String = Split(Session("cPerDelCodigo"), ",")
            Dim dFecha As DateTime = Date.Now
            Dim cFecha As String = Format(dFecha, "MM/dd/yyyy HH:mm:ss")

            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            MyTrans = cn.BeginTransaction
            Try

                For Each Row In gvDocEvaluar.Rows
                    Dim cbo As New DropDownList
                    Dim chk As New CheckBox
                    cbo = CType(Row.FindControl("cboEstado"), DropDownList)
                    chk = CType(Row.FindControl("chkMulDoc"), CheckBox)

                    cDocCodigo = gvDocEvaluar.DataKeys(Row.RowIndex).Item("cDocCodigo")

                    If Not cbo.SelectedValue = 0 Then
                        clsTraDoc.objModEstDocumento(cDocCodigo, _
                                                cbo.SelectedValue, gvDocEvaluar.DataKeys(Row.RowIndex).Item("CodPerDestino"), _
                                                Session("UOCodigo"), clsTraDoc.FecActual(MyTrans, cn), MyTrans, cn)
                    End If

                    If chk.Visible AndAlso chk.Checked Then
                        Dim Reader As SqlDataReader = clsTraDoc.Get_DocTratamiento_Max(cDocCodigo, MyTrans, cn)
                        While Reader.Read
                            nMax = Reader("Item")
                        End While
                        Reader.Close()

                        For I = 0 To cPerDelCodigo.Length - 1
                            clsInsert.objInsertDocTratamiento(cDocCodigo, nMax + I, 20, "DOCUMENTO LEIDO", 0, cPerDelCodigo(I), cFecha, MyTrans, cn)
                        Next
                    End If
                Next
                MyTrans.Commit()
            Catch x As Exception
                MyTrans.Rollback()
                Response.Write("<script languge 'javascript'> Alert (" & x.Message & ")</script>")
            End Try
        End Using

    End Sub

    Public Function BtnVisible(ByVal TipDocumento As Integer) As Boolean
        If TipDocumento = 8102 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub LoaderCombo()
        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using Cn As New SqlConnection(MiConexion)
            Try
                Cn.Open()
                Dim clsTraDoc As New clsTraDoc
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Rs As SqlDataReader = clsTraDoc.Get_Periodo_Administrativo(MyTrans, Cn)
                cboPeriodo.DataTextField = "cPrdDescripcion"
                cboPeriodo.DataValueField = "nPrdCodigo"
                cboPeriodo.DataSource = Rs
                cboPeriodo.DataBind()
                Rs.Close()
                MyTrans.Commit()
            Catch ex As Exception
                Throw
            End Try
        End Using
    End Sub

    Protected Sub btnGrabar2_Click(sender As Object, e As System.EventArgs) Handles btnGrabar2.Click
        Dim Row As GridViewRow
        Dim MyTrans As SqlTransaction
        Using cn As New SqlConnection(MiConexion)
            Dim Clase As New clsTraDoc
            Dim nDocPerEdiTipo As Integer
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            MyTrans = cn.BeginTransaction
            Try
                For Each Row In gvProDoc.Rows
                    Dim cbo As New DropDownList
                    cbo = CType(Row.FindControl("cboEstado"), DropDownList)
                    nDocPerEdiTipo = gvProDoc.DataKeys(Row.RowIndex).Values("nDocPerEdiTipo")

                    If Not cbo.SelectedValue = 0 Then
                        Clase.objModEstDocumento(gvProDoc.DataKeys(Row.RowIndex).Item("cDocCodigo"), cbo.SelectedValue, gvProDoc.DataKeys(Row.RowIndex).Item("cPerCodigo"), Session("UOCodigo"), Clase.FecActual(MyTrans, cn), MyTrans, cn, , nDocPerEdiTipo)
                    End If
                Next
                MyTrans.Commit()
            Catch x As Exception
                MyTrans.Rollback()
            End Try
        End Using
        Response.Redirect("DocPendientes.aspx")
    End Sub

    Protected Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged
        Dim MiConexion As String = TramiteDocumentario.MiConexion
        Using Cn As New SqlConnection(MiConexion)
            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                LoaderData_By_Periodo(Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, Cn), cboPeriodo.SelectedValue, "6318,6319,6325", Val(cboFilMes.SelectedValue))
            Catch ex As Exception
                Throw
            End Try
        End Using
    End Sub

    Sub LoaderGVAtributo()
        'Dim ArcRuta As String = "Aplicaciones:8082/DocInternos"
        Dim ArcName As String
        Dim ArchName As String
        Dim Row As GridViewRow
        Dim cDesRuta As String = String.Empty

        For Each Row In gvDocEvaluar.Rows
            Dim lnkButon As New LinkButton
            Dim imgArchivo As New ImageButton
            Dim imgArch As New ImageButton
            Dim PerRemCodigo As String = gvDocEvaluar.DataKeys(Row.RowIndex).Item("CodPerRemite")
            Dim PerDesCodigo As String = gvDocEvaluar.DataKeys(Row.RowIndex).Item("CodPerDestino")
            Dim DocTipo As Integer = gvDocEvaluar.DataKeys(Row.RowIndex).Item("nDocTipo")

            ArcName = gvDocEvaluar.DataKeys(Row.RowIndex).Values("Archivo")
            ArchName = gvDocEvaluar.DataKeys(Row.RowIndex).Values("Archiv")

            DesRuta(DocTipo, cDesRuta, ArcName, ArchName)

            lnkButon = CType(Row.FindControl("lnkDoc"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('Proveido.aspx?CodDocumento=" & gvDocEvaluar.DataKeys(Row.RowIndex).Values("cDocCodigo") & "&TipoDocumento=" & DocTipo & "&DocumentoEstado=0&PerRemCodigo=" & PerRemCodigo & "&PerDesCodigo=" & PerDesCodigo & "','Documentos'));"

            imgArchivo = CType(Row.FindControl("imgArchivo"), ImageButton)
            imgArch = CType(Row.FindControl("imgArch"), ImageButton)

            If Not ArcName Is String.Empty Then
                imgArchivo.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & cDesRuta & "&ArcName=" & ArcName & "','Documentos'));"
            Else
                imgArchivo.ImageUrl = "~\Imagenes\Stop.gif"
            End If

            If Not ArchName Is String.Empty Then
                imgArch.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & cDesRuta & "&ArcName=" & ArchName & "','Documentos'));"
            Else
                imgArch.ImageUrl = "~\Imagenes\Stop.gif"
            End If
        Next



        For Each Row In gvProDoc.Rows
            Dim lnkButon As New LinkButton
            Dim imgArchivo As New ImageButton
            Dim imgArch As New ImageButton
            'Dim PerRemCodigo As String = gvProveido.DataKeys(Row.RowIndex).Item("cPerCodigo")
            Dim DocTipo As Integer = gvProDoc.DataKeys(Row.RowIndex).Item("nDocTipo")
            ArcName = gvProDoc.DataKeys(Row.RowIndex).Values("Archivo")
            ArchName = gvProDoc.DataKeys(Row.RowIndex).Values("Archiv")

            DesRuta(DocTipo, cDesRuta, ArcName, ArchName)

            lnkButon = CType(Row.FindControl("lnkDoc"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('DocDellProveido.aspx?CodDocumento=" & gvProDoc.DataKeys(Row.RowIndex).Values("cDocCodigo") & "&Visible=0" & "','Documentos'));"

            imgArchivo = CType(Row.FindControl("imgArchivo"), ImageButton)
            imgArch = CType(Row.FindControl("imgArch"), ImageButton)
            If Not ArcName Is String.Empty Then
                imgArchivo.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & cDesRuta & "&ArcName=" & ArcName & "','Documentos'));"
            Else
                imgArchivo.ImageUrl = "~\Imagenes\Stop.gif"
            End If

            If Not ArchName Is String.Empty Then
                imgArch.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & cDesRuta & "&ArcName=" & ArchName & "','Documentos'));"
            Else
                imgArch.ImageUrl = "~\Imagenes\Stop.gif"
            End If
        Next


        For Each Row In gvCopias.Rows
            Dim lnkButon As New LinkButton
            Dim PerDesCodigo As String = gvCopias.DataKeys(Row.RowIndex).Item("CodPerDestino")
            Dim cPerCopCodigo As String = gvCopias.DataKeys(Row.RowIndex).Item("cPerCopCodigo")
            Dim DocTipo As Integer = gvCopias.DataKeys(Row.RowIndex).Item("nDocTipo")
            Dim imgArchivo As New ImageButton
            Dim imgArch As New ImageButton

            ArcName = gvCopias.DataKeys(Row.RowIndex).Values("Archivo")
            ArchName = gvCopias.DataKeys(Row.RowIndex).Values("Archiv")

            DesRuta(DocTipo, cDesRuta, ArcName, ArchName)

            lnkButon = CType(Row.FindControl("lnkDocumento"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('DetalleDocumento.aspx?CodDocumento=" & gvCopias.DataKeys(Row.RowIndex).Values("cDocCodigo") & "&TipoDocumento=" & DocTipo & "&DocumentoEstado=0&CodDestino=" & PerDesCodigo & "&cPerCopCodigo=" & cPerCopCodigo & "','Documentos'));"

            imgArchivo = CType(Row.FindControl("imgArchivo"), ImageButton)
            imgArch = CType(Row.FindControl("imgArch"), ImageButton)

            If Not ArcName Is String.Empty Then
                imgArchivo.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & cDesRuta & "&ArcName=" & ArcName & "','Documentos'));"
            Else
                imgArchivo.ImageUrl = "~\Imagenes\Stop.gif"
            End If

            If Not ArchName Is String.Empty Then
                imgArch.OnClientClick = "javascript:(abre('frmDonwFile.aspx?ArcRuta=" & cDesRuta & "&ArcName=" & ArchName & "','Documentos'));"
            Else
                imgArch.ImageUrl = "~\Imagenes\Stop.gif"
            End If
        Next

        For Each Row In gvDevDoc.Rows
            Dim lnkButon As New LinkButton
            Dim cDocCodigo As String = gvDevDoc.DataKeys(Row.RowIndex).Item("cDocCodigo")
            Dim PerDesCodigo As String = gvDevDoc.DataKeys(Row.RowIndex).Item("CodPerDestino")
            Dim PerRemCodigo As String = gvDevDoc.DataKeys(Row.RowIndex).Item("CodPerRemite")
            Dim DocTipo As Integer = gvDevDoc.DataKeys(Row.RowIndex).Item("nDocTipo")

            lnkButon = CType(Row.FindControl("lnkDocumento"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('ReenviarDoc.aspx?CodDocumento=" & cDocCodigo & "&TipoDocumento=" & DocTipo & "&DocumentoEstado=0&PerDesCodigo=" & PerDesCodigo & "&PerRemCodigo=" & PerRemCodigo & "','Detalle'));"
        Next
    End Sub
    Sub LoaderData_By_Periodo(ByVal cPerCodigo As String, ByVal nPrdCodigo As Integer, ByVal cDocEstado As String, ByVal nMesCodigo As Integer)

        Dim bDocTransferencia As Boolean = chkTransferencia.Checked
        Dim cUniOrgTransferencia As String = String.Empty


        If bDocTransferencia = True Then
            DocTransferencia(cPerCodigo, cUniOrgTransferencia)
        End If

        Using Cn As New SqlConnection(MiConexion)
            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim clsTraDoc As New clsTraDoc
                If nPrdCodigo = 0 Then nPrdCodigo = clsTraDoc.Get_AdmPeriodo_Actual(MyTrans, Cn)
                'Para los Documentos Pendientes

                Dim Reader As SqlDataReader


                Reader = clsTraDoc.Get_Doc_Pendientes_By_Periodo(cPerCodigo, cDocEstado, nPrdCodigo, MyTrans, Cn, nMesCodigo, cUniOrgTransferencia)
                gvDocEvaluar.DataSource = Reader
                gvDocEvaluar.DataBind()
                Reader.Close()

                'Para los Proveidos
                Reader = clsTraDoc.Get_Proveido_By_Periodo(cPerCodigo, nPrdCodigo, MyTrans, Cn, nMesCodigo, cUniOrgTransferencia)
                gvProDoc.DataSource = Reader
                gvProDoc.DataBind()
                Reader.Close()

                'Para Las Copias
                cDocEstado = "6318,6319,6320,6321,6322,6323,6324,6325,6326,6328"

                Reader = clsTraDoc.Get_DocInf_By_Periodo(cPerCodigo, nPrdCodigo, cDocEstado, "5,7", MyTrans, Cn, nMesCodigo, cUniOrgTransferencia)
                gvCopias.DataSource = Reader
                gvCopias.DataBind()
                Reader.Close()

                'DocDevueltos
                cDocEstado = "6324"
                Reader = clsTraDoc.Get_DocInf_By_Periodo(cPerCodigo, nPrdCodigo, cDocEstado, "1", MyTrans, Cn, , cUniOrgTransferencia)

                'dgDocDevueltos.DataSource = Reader
                'dgDocDevueltos.DataBind()

                gvDevDoc.DataSource = Reader
                gvDevDoc.DataBind()

                Reader.Close()

                LoaderEstados(MyTrans, Cn)
                LoaderGVAtributo()

                MyTrans.Commit()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
    End Sub
    Sub LoaderEstados(ByVal MyTrans As SqlTransaction, ByVal Cn As SqlConnection)
        Try
            Dim clsComunes As New clsConsultasComunes
            Dim Reader As SqlDataReader = clsComunes.objCargarConstante(1066, 4, 2, 63, , , , "6320,6321,6324,6328", MyTrans, Cn)
            Dim Dt As New DataTable
            Dim Row As GridViewRow

            Dt.Load(Reader)

            For Each Row In gvDocEvaluar.Rows
                Dim cbo As New DropDownList
                Dim chk As New CheckBox

                cbo = CType(Row.FindControl("cboEstado"), DropDownList)
                chk = CType(Row.FindControl("chkMulDoc"), CheckBox)

                cbo.DataTextField = "cConDescripcion"
                cbo.DataValueField = "nConValor"
                cbo.DataSource = Dt
                cbo.DataBind()

                cbo.Items.Insert(0, "Select")
                cbo.Items(0).Value = 0

                'Dim Item As New ListItem
                'If gvDocEvaluar.DataKeys(Row.DataItemIndex).Values("nDocTipo") = DocTipo.nDocInvestigacion And gvDocEvaluar.DataKeys(Row.DataItemIndex).Values("nUniOrgCodigo") <> UniOrg.nUniOrgInvestigacion Then
                '    For Each Item In cbo.Items
                '        If Item.Value = DocEstado.nDocEstAprobado Then cbo.Items.Remove(Item) : Exit For
                '    Next
                'End If

                Dim bEstado As Boolean = BtnVisible(gvDocEvaluar.DataKeys(Row.RowIndex).Item("nDocTipo"))
                cbo.Enabled = bEstado
                chk.Visible = Not bEstado

            Next

            Dt.Clear()

            Reader = clsComunes.objCargarConstante(1066, 4, 2, 63, , , , "6320,6321,6328", MyTrans, Cn)
            Dt.Load(Reader)

            For Each Row In gvProDoc.Rows
                Dim cbo As New DropDownList
                cbo = CType(Row.FindControl("cboEstado"), DropDownList)
                cbo.DataTextField = "cConDescripcion"
                cbo.DataValueField = "nConValor"
                cbo.DataSource = Dt
                cbo.DataBind()
                cbo.Items.Insert(0, "Select")
                cbo.Items(0).Value = 0

                'Dim Item As New ListItem
                'If gvProDoc.DataKeys(Row.DataItemIndex).Values("nDocTipo") = DocTipo.nDocInvestigacion And gvProDoc.DataKeys(Row.DataItemIndex).Values("nUniOrgCodigo") <> UniOrg.nUniOrgInvestigacion Then
                '    For Each Item In cbo.Items
                '        If Item.Value = DocEstado.nDocEstAprobado Then cbo.Items.Remove(Item) : Exit For
                '    Next
                'End If

                cbo.Enabled = BtnVisible(gvProDoc.DataKeys(Row.RowIndex).Item("nDocTipo"))
            Next

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Sub AgregarAtributo()
        Dim Row As GridViewRow
        For Each Row In gvCopias.Rows
            Dim lnkButon As New LinkButton

            lnkButon = CType(Row.FindControl("lnkDocumento"), LinkButton)
            lnkButon.OnClientClick = "javascript:(abre('DetalleDocumento.aspx?CodDocumento=" & gvCopias.DataKeys(Row.RowIndex).Values("cDocCodigo") & "&TipDocumento=1" & "','Silabo'));"

        Next
    End Sub


    Protected Sub chkDelegado_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkDelegado.CheckedChanged
        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)
            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                If chkDelegado.Checked = False Then
                    LoaderData_By_Periodo(Session("PerCodigo"), cboPeriodo.SelectedValue, "6318,6319,6325", Val(cboFilMes.SelectedValue))
                Else
                    LoaderData_By_Periodo(Get_User_AND_Delegado(Session("PerCodigo"), MyTrans, Cn), cboPeriodo.SelectedValue, "6318,6319,6325", Val(cboFilMes.SelectedValue))
                End If
                MyTrans.Commit()
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
    End Sub

    Protected Sub btnCopia_Click(sender As Object, e As System.EventArgs) Handles btnCopia.Click
        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)

            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Row As GridViewRow
                Dim cDocCodigo As String
                Dim cFecha As String
                Dim cPerDelCodigo() As String = Split(Session("cPerDelCodigo"), ",")
                Dim I As Integer
                Dim chkEstado As New CheckBox
                Dim clsTraDoc As New clsTraDoc
                Dim Reader As SqlDataReader
                Dim nMax As Integer

                Dim dFecha As DateTime = Date.Now

                cFecha = Format(dFecha, "MM/dd/yyyy HH:mm:ss")

                Dim clsInsert As New clsInserciones
                For Each Row In gvCopias.Rows
                    cDocCodigo = gvCopias.DataKeys(Row.RowIndex).Values("cDocCodigo")
                    chkEstado = CType(Row.FindControl("chkEstado"), CheckBox)

                    If chkEstado.Checked = True Then
                        Reader = clsTraDoc.Get_DocTratamiento_Max(cDocCodigo, MyTrans, Cn)
                        While Reader.Read
                            nMax = Reader("Item")
                        End While
                        Reader.Close()

                        For I = 0 To cPerDelCodigo.Length - 1
                            clsInsert.objInsertDocTratamiento(cDocCodigo, nMax + I, 10, "DOCUMENTO LEIDO", 0, cPerDelCodigo(I), cFecha, MyTrans, Cn)
                        Next
                    End If

                Next

                MyTrans.Commit()
                Response.Redirect("DocPendientes.aspx")
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using
    End Sub

    Protected Sub btnDocDevGrabar_Click(sender As Object, e As System.EventArgs) Handles btnDocDevGrabar.Click
        Using Cn As New SqlConnection(TramiteDocumentario.MiConexion)

            Try
                Cn.Open()
                Dim MyTrans As SqlTransaction = Cn.BeginTransaction
                Dim Row As GridViewRow
                Dim cDocCodigo As String
                Dim cFecha As String
                Dim cPerDelCodigo() As String = Split(Session("cPerDelCodigo"), ",")
                Dim I As Integer
                Dim chkEstado As New CheckBox
                Dim clsTraDoc As New clsTraDoc
                Dim Reader As SqlDataReader
                Dim nMax As Integer

                Dim dFecha As DateTime = Date.Now

                cFecha = Format(dFecha, "MM/dd/yyyy HH:mm:ss")

                Dim clsInsert As New clsInserciones
                For Each Row In gvDevDoc.Rows
                    cDocCodigo = gvDevDoc.DataKeys(Row.RowIndex).Values("cDocCodigo")
                    chkEstado = CType(Row.FindControl("chkEstado"), CheckBox)

                    If chkEstado.Checked = True Then
                        Reader = clsTraDoc.Get_DocTratamiento_Max(cDocCodigo, MyTrans, Cn)
                        While Reader.Read
                            nMax = Reader("Item")
                        End While
                        Reader.Close()

                        For I = 0 To cPerDelCodigo.Length - 1
                            clsInsert.objInsertDocTratamiento(cDocCodigo, nMax + I, 30, "DOCUMENTO ARCHIVADO", 0, cPerDelCodigo(I), cFecha, MyTrans, Cn)
                        Next
                    End If

                Next

                MyTrans.Commit()
                Response.Redirect("DocPendientes.aspx")
            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End Using

    End Sub

    Sub DesRuta(ByVal pnDocTipo As Long, ByRef cRuta As String, ByRef cArcNameOne As String, ByRef cArcNameTwo As String)
        Select Case pnDocTipo
            Case DocTipo.gnDocCurConvalidacion, DocTipo.gnDocCurMatRectificacion, DocTipo.gnDocCurMatReserva, DocTipo.gnDocSerVarios
                cRuta = RutTraOnLinRuta
                If Not cArcNameOne = String.Empty Then cArcNameOne = Right(cArcNameOne, Len(cArcNameOne) - 11)
                If Not cArcNameTwo = String.Empty Then cArcNameTwo = Right(cArcNameTwo, Len(cArcNameTwo) - 11)
            Case Else
                cRuta = RutDescarga
        End Select

    End Sub

    Protected Sub cboFilMes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboFilMes.SelectedIndexChanged
        cboPeriodo_SelectedIndexChanged(sender, e)
    End Sub

    Sub DocTransferencia(ByRef cPerCodigo As String, ByRef cUniOrgCodigo As String)
        Dim clsTraDoc As New clsTraDoc
        Dim dt As DataTable = clsTraDoc.Get_DocUniOrg_Transferencia(Session("PerCodigo"))
        Dim I As Integer

        cPerCodigo = String.Empty
        cUniOrgCodigo = String.Empty

        For I = 0 To dt.Rows.Count - 1
            cPerCodigo &= dt.Rows(I).Item("cPerCodigo") & ","
            cUniOrgCodigo &= dt.Rows(I).Item("nUniOrgCodigo") & ","
        Next

        If I > 0 Then
            cPerCodigo = Left(cPerCodigo, Len(cPerCodigo) - 1)
            cUniOrgCodigo = Left(cUniOrgCodigo, Len(cUniOrgCodigo) - 1)
        End If
    End Sub



    Protected Sub chkTransferencia_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkTransferencia.CheckedChanged
        chkDelegado_CheckedChanged(sender, e)
    End Sub
End Class
