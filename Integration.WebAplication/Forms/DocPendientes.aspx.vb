Imports Integration.BE.Periodo
Imports Integration.BL
Imports System.Data
Imports Integration.BE.Constante
Imports Integration.BE.Persona
Imports Integration.BE.TraDoc
Imports Integration.BE.Documento
Imports Integration.DAConfiguration

Partial Class Forms_DocPendientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Session("cPerCodigo") Is Nothing Then
            Response.Redirect("~/login.aspx")
        End If
        If Not Page.IsPostBack Then
            Dim PrdActual As Integer
            Dim nActMes As Integer = Month(Date.Today)

            Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
            Dim objBL As BL_Periodo = New BL_Periodo()
            Dim ResPeriodo As BE_Res_Periodo = New BE_Res_Periodo()
            ReqPeriodo.nPrdActividad = 1
            ResPeriodo = objBL.get_PeriodoActual_ByActividad(ReqPeriodo)
            PrdActual = ResPeriodo.nPrdCodigo

            Dim ReqConstante As BE_Req_Constante = New BE_Req_Constante()
            Dim ObjConst As BL_Constante = New BL_Constante()
            Dim Rs As DataTable = New DataTable()
            ReqConstante.nConCodigo = 1005
            Rs = ObjConst.GetConstante(ReqConstante)
            cboFilMes.DataTextField = "cConDescripcion"
            cboFilMes.DataValueField = "nConValor"
            cboFilMes.DataSource = Rs
            cboFilMes.DataBind()

            cboFilMes.SelectedValue = nActMes

            Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
            ReqPersona.cPerCodigo = Session("cPerCodigo")
            Dim ObjPer As BL_Persona = New BL_Persona()

            LoaderData_By_Periodo(ObjPer.getDelegadoAnduser(ReqPersona), PrdActual, "6318,6319,6325", Val(cboFilMes.SelectedValue))

            LoaderCombo()
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
        saveGridView()
        Response.Redirect("DocPendientes.aspx")
    End Sub


    Sub saveGridView()

        Dim Row As GridViewRow
        Dim cDocCodigo As String
        Dim cFecha As String
        Dim cPerDelCodigo() As String = Split(Session("cPerDelCodigo"), ",")
        Dim I As Integer
        Dim chkEstado As New CheckBox
        Dim nMax As Integer

        Dim dFecha As DateTime = Date.Now
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc()
        Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
        Dim ObjDoc As BL_Documento = New BL_Documento()
        Dim Rs As DataTable

        cFecha = Format(dFecha, "MM/dd/yyyy HH:mm:ss")

        For Each Row In gvDocEvaluar.Rows
            Dim cbo As New DropDownList
            Dim chk As New CheckBox
            cbo = CType(Row.FindControl("cboEstado"), DropDownList)
            chk = CType(Row.FindControl("chkMulDoc"), CheckBox)

            cDocCodigo = gvDocEvaluar.DataKeys(Row.RowIndex).Item("cDocCodigo")

            If Not cbo.SelectedValue = 0 Then
                ReqDoc.cDocCodigo = cDocCodigo
                ReqDoc.nDocEstado = cbo.SelectedValue
                ReqDoc.cPerCodigo = gvDocEvaluar.DataKeys(Row.RowIndex).Item("CodPerDestino")
                ReqDoc.cDocObserv = ""
                ReqDoc.nDocPerTipo = 1006
                If Not ObjDoc.updEstadoDocumento(ReqDoc) Then Exit Sub
            End If


            If chk.Visible AndAlso chk.Checked Then
                ReqTraDoc.iOpcion = 11
                ReqTraDoc.cDocEstado = cDocCodigo
                Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
                For x As Integer = 0 To Rs.Rows.Count - 1
                    nMax = Rs.Rows(x).Item(1)
                Next
                Rs.Clear()

                ReqDoc.cDocCodigo = cDocCodigo
                ReqDoc.nCarCodigo = 20
                ReqDoc.cCarObs = "DOCUMENTO LEIDO"
                ReqDoc.nPercent = 0
                ReqDoc.dDocTraFec = cFecha
                For I = 0 To cPerDelCodigo.Length - 1
                    ReqDoc.nEleCodigo = nMax + I
                    ReqDoc.cPerCodigo = cPerDelCodigo(I)
                    If Not ObjDoc.setDocTratamiento(ReqDoc) Then Exit For
                Next

            End If
        Next


    End Sub

    Public Function BtnVisible(ByVal TipDocumento As Integer) As Boolean
        If TipDocumento = 8102 Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub LoaderCombo()
        Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
        Dim BLPeriodo As BL_Periodo = New BL_Periodo()
        Dim Rs As DataTable = New DataTable

        ReqPeriodo.nPrdActividad = 1
        Rs = BLPeriodo.GetPeriodosByActividad(ReqPeriodo)
        If Rs.Rows.Count > 0 Then
            cboPeriodo.DataTextField = "cPrdDescripcion"
            cboPeriodo.DataValueField = "nPrdCodigo"
            cboPeriodo.DataSource = Rs
            cboPeriodo.DataBind()
        End If
        Rs.Clear()
    End Sub

    Protected Sub btnGrabar2_Click(sender As Object, e As System.EventArgs) Handles btnGrabar2.Click
        Dim Row As GridViewRow
        Dim nDocPerEdiTipo As Integer
        Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
        Dim ObjDoc As BL_Documento = New BL_Documento()
        For Each Row In gvProDoc.Rows
            Dim cbo As New DropDownList
            cbo = CType(Row.FindControl("cboEstado"), DropDownList)
            nDocPerEdiTipo = gvProDoc.DataKeys(Row.RowIndex).Values("nDocPerEdiTipo")
            If Not cbo.SelectedValue = 0 Then
                ReqDoc.cDocCodigo = gvProDoc.DataKeys(Row.RowIndex).Item("cDocCodigo")
                ReqDoc.nDocEstado = cbo.SelectedValue
                ReqDoc.cPerCodigo = gvProDoc.DataKeys(Row.RowIndex).Item("cPerCodigo")
                ReqDoc.cDocObserv = ""
                ReqDoc.nDocPerTipo = 1006
                If Not ObjDoc.updEstadoDocumento(ReqDoc) Then Exit Sub
            End If
        Next
        Response.Redirect("DocPendientes.aspx")
    End Sub

    Protected Sub cboPeriodo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboPeriodo.SelectedIndexChanged


        Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
        ReqPersona.cPerCodigo = Session("cPerCodigo")
        Dim ObjPer As BL_Persona = New BL_Persona()
        LoaderData_By_Periodo(ObjPer.getDelegadoAnduser(ReqPersona), cboPeriodo.SelectedValue, "6318,6319,6325", Val(cboFilMes.SelectedValue))

    End Sub

    Sub LoaderGVAtributo()
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

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc


        If nPrdCodigo = 0 Then
            Dim ReqPeriodo As BE_Req_Periodo = New BE_Req_Periodo()
            Dim objBL As BL_Periodo = New BL_Periodo()
            Dim ResPeriodo As BE_Res_Periodo = New BE_Res_Periodo()
            ReqPeriodo.nPrdActividad = 1
            ResPeriodo = objBL.get_PeriodoActual_ByActividad(ReqPeriodo)
            nPrdCodigo = ResPeriodo.nPrdCodigo
        End If
        'Para los Documentos Pendientes
        Dim Rs As DataTable = New DataTable()
        ReqTraDoc.iOpcion = 4
        ReqTraDoc.cPerCodigo = cPerCodigo
        ReqTraDoc.cDocEstado = cDocEstado
        ReqTraDoc.nPrdCodigo = nPrdCodigo
        ReqTraDoc.nMesCodigo = nMesCodigo
        ReqTraDoc.cUniOrgTransferencia = cUniOrgTransferencia
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
        gvDocEvaluar.DataSource = Rs
        gvDocEvaluar.DataBind()

        Rs.Clear()

        'Para los Proveidos
        ReqTraDoc.iOpcion = 7
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
        gvProDoc.DataSource = Rs
        gvProDoc.DataBind()
        Rs.Clear()

        'Para Las Copias
        cDocEstado = "6318,6319,6320,6321,6322,6323,6324,6325,6326,6328"
        ReqTraDoc.iOpcion = 8
        ReqTraDoc.cDocEstado = cDocEstado
        ReqTraDoc.cDocPerTipo = "5,7"
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
        gvCopias.DataSource = Rs
        gvCopias.DataBind()
        Rs.Clear()

        'DocDevueltos
        cDocEstado = "6324"
        ReqTraDoc.cDocEstado = cDocEstado
        ReqTraDoc.cDocPerTipo = "1"
        Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
        gvDevDoc.DataSource = Rs
        gvDevDoc.DataBind()
        Rs.Clear()

        LoaderEstados()
        LoaderGVAtributo()

    End Sub
    Sub LoaderEstados()
        Try
            Dim Row As GridViewRow
            Dim ReqConstante As BE_Req_Constante = New BE_Req_Constante
            Dim ObjConst As BL_Constante = New BL_Constante
            Dim Dt As New DataTable
            ReqConstante.nConCodigo = 1066
            ReqConstante.nConValor = 4
            ReqConstante.ConLeft = 2
            ReqConstante.ConValLeft = 63
            ReqConstante.cConValor = "6320,6321,6324,6328"
            Dt = ObjConst.ListarConstantes(ReqConstante)

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

                Dim bEstado As Boolean = BtnVisible(gvDocEvaluar.DataKeys(Row.RowIndex).Item("nDocTipo"))
                cbo.Enabled = bEstado
                chk.Visible = Not bEstado

            Next

            Dt.Clear()
            ReqConstante.nConCodigo = 1066
            ReqConstante.nConValor = 4
            ReqConstante.ConLeft = 2
            ReqConstante.ConValLeft = 63
            ReqConstante.cConValor = "6320,6321,6328"
            Dt = ObjConst.ListarConstantes(ReqConstante)

            For Each Row In gvProDoc.Rows
                Dim cbo As New DropDownList
                cbo = CType(Row.FindControl("cboEstado"), DropDownList)
                cbo.DataTextField = "cConDescripcion"
                cbo.DataValueField = "nConValor"
                cbo.DataSource = Dt
                cbo.DataBind()
                cbo.Items.Insert(0, "Select")
                cbo.Items(0).Value = 0

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
        If chkDelegado.Checked = False Then
            LoaderData_By_Periodo(Session("cPerCodigo"), cboPeriodo.SelectedValue, "6318,6319,6325", Val(cboFilMes.SelectedValue))
        Else
            Dim ReqPersona As BE_Req_Persona = New BE_Req_Persona()
            ReqPersona.cPerCodigo = Session("cPerCodigo")
            Dim ObjPer As BL_Persona = New BL_Persona()
            LoaderData_By_Periodo(ObjPer.getDelegadoAnduser(ReqPersona), cboPeriodo.SelectedValue, "6318,6319,6325", Val(cboFilMes.SelectedValue))
        End If
    End Sub

    Protected Sub btnCopia_Click(sender As Object, e As System.EventArgs) Handles btnCopia.Click
        Dim Row As GridViewRow
        Dim cDocCodigo As String
        Dim cFecha As String
        Dim cPerDelCodigo() As String = Split(Session("cPerDelCodigo"), ",")
        Dim I As Integer
        Dim chkEstado As New CheckBox
        Dim nMax As Integer
        Dim dFecha As DateTime = Date.Now
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc
        Dim Rs As DataTable
        cFecha = Format(dFecha, "MM/dd/yyyy HH:mm:ss")

        For Each Row In gvCopias.Rows
            cDocCodigo = gvCopias.DataKeys(Row.RowIndex).Values("cDocCodigo")
            chkEstado = CType(Row.FindControl("chkEstado"), CheckBox)
            If chkEstado.Checked = True Then
            End If
        Next
        Response.Redirect("DocPendientes.aspx")
    End Sub

    Protected Sub btnDocDevGrabar_Click(sender As Object, e As System.EventArgs) Handles btnDocDevGrabar.Click
        Dim Row As GridViewRow
        Dim cDocCodigo As String
        Dim cFecha As String
        Dim cPerDelCodigo() As String = Split(Session("cPerDelCodigo"), ",")
        Dim I As Integer
        Dim chkEstado As New CheckBox
        Dim nMax As Integer

        Dim dFecha As DateTime = Date.Now
        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc
        Dim Rs As DataTable

        cFecha = Format(dFecha, "MM/dd/yyyy HH:mm:ss")

        For Each Row In gvDevDoc.Rows
            cDocCodigo = gvDevDoc.DataKeys(Row.RowIndex).Values("cDocCodigo")
            chkEstado = CType(Row.FindControl("chkEstado"), CheckBox)

            If chkEstado.Checked = True Then
                ReqTraDoc.iOpcion = 11
                ReqTraDoc.cDocEstado = cDocCodigo
                Rs = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
                For x As Integer = 0 To Rs.Rows.Count - 1
                    nMax = Rs.Rows(x).Item(1)
                Next
                Rs.Clear()
                Dim ReqDoc As BE_Req_Documento = New BE_Req_Documento()
                Dim ObjDoc As BL_Documento = New BL_Documento()
                ReqDoc.cDocCodigo = cDocCodigo
                ReqDoc.nCarCodigo = 30
                ReqDoc.cCarObs = "DOCUMENTO ARCHIVADO"
                ReqDoc.nPercent = 0
                ReqDoc.dDocTraFec = cFecha
                For I = 0 To cPerDelCodigo.Length - 1
                    ReqDoc.nEleCodigo = nMax + I
                    ReqDoc.cPerCodigo = cPerDelCodigo(I)
                    If Not ObjDoc.setDocTratamiento(ReqDoc) Then Exit For
                Next
            End If
        Next
        Response.Redirect("DocPendientes.aspx")
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

        Dim ReqTraDoc As BE_Req_TraDoc = New BE_Req_TraDoc()
        Dim ObjTraDoc As BL_TraDoc = New BL_TraDoc
        Dim dt As DataTable

        ReqTraDoc.iOpcion = 22
        ReqTraDoc.cPerCodigo = Session("cPerCodigo")
        dt = ObjTraDoc.get_TraDoc_Procesos(ReqTraDoc)
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
