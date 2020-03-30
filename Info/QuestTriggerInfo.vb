Public Class QuestTriggerInfo
    Private _qtriggerid As String
    Public Property QuestTriggerId() As String
        Get
            Return _qtriggerid
        End Get
        Set(ByVal value As String)
            _qtriggerid = value
        End Set
    End Property
    Private _questid As Integer
    Public Property QuestID() As Integer
        Get
            Return _questid
        End Get
        Set(ByVal value As Integer)
            _questid = value
        End Set
    End Property
    Private _tnamn As String
    Public Property TNamn() As String
        Get
            Return _tnamn
        End Get
        Set(ByVal value As String)
            _tnamn = value
        End Set
    End Property
    Private _tvalue As String
    Public Property TValue() As String
        Get
            Return _tvalue
        End Get
        Set(ByVal value As String)
            _tvalue = value
        End Set
    End Property
End Class
