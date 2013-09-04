

Public Module modTraDoc
    Public gnCopCantidad As Integer = 20
    Public Arreglo(gnCopCantidad, 1) As String
    Public RutDoc As String = "E:\Campus\DocInternos\TramiteDocumentario\"
    Public RutDescarga As String = "D:/Campus/DocInternos/TramiteDocumentario"
    Public RutTraOnLinRuta As String = "campus.uss.edu.pe/campus/FileRegistro"


End Module

Public Module DocTipo
    Public gnDocFacResolucion As Long = 8004
    Public gnDocOficio As Long = 8100
    Public gnDocMultiple As Long = 8102
    Public gnDocPerRRHH As Long = 8805
    Public gnDocInvestigacion As Long = 8806
    Public gnDocSolicitud As Long = 8600
    Public gnDocCarta As Long = 8700
    Public gnDocOtros As Long = 8800
    Public gnDocInforme As Long = 8804
    Public gnDocMemorandun As Long = 8803
    Public gnDocTransferencia As Long = 880106

    'Trámites ONLINE
    Public gnDocCurConvalidacion As Long = 8806001
    Public gnDocCurMatReserva As Long = 8806002
    Public gnDocCurMatRectificacion As Long = 8806003
    Public gnDocSerVarios As Long = 8806004
End Module


Public Enum DocPerTipo
    gDocPerTipTransOrigen = 1
    gDocPerTipTransDestino = 2
    gDocPerTipTransUsuario = 3
End Enum