Public Class QuestInfo
    Private _awardgroupId As Integer
    Public Sub New()
        _questSubquestList = New List(Of QuestTriggerInfo)
        _occures = 1 'antal gånger quest kan genomföras 0 hur många gånger som helst
        _active = 0
        _pointEarnded = 1 ' poäng man tjänar när man genomfört uppdraget
        _totlevup = 1   ' hur många poäng man behöver för att levla upp
        _level = 1 ' bokmärkets level ( integer)
        _awardOccure = 1 ' max level (integer)
        _bibblomoneyEarnedID = 1

    End Sub
    Public Property AwardGroupId() As Integer  'detta är bokmärkesGruppens id
        Get
            Return _awardgroupId
        End Get
        Set(ByVal value As Integer)
            _awardgroupId = value
        End Set
    End Property

    Private _aid As Integer 'Detta är bokmärkets id
    Public Property Aid() As Integer
        Get
            Return _aid
        End Get
        Set(ByVal value As Integer)
            _aid = value
        End Set
    End Property

    Private _occures As Integer
    Public Property Occures() As Integer
        Get
            Return _occures
        End Get
        Set(ByVal value As Integer)
            _occures = value
        End Set
    End Property
    Private _pointEarnded As Integer
    Public Property PointEarned() As Integer
        Get
            Return _pointEarnded
        End Get
        Set(ByVal value As Integer)
            _pointEarnded = value
        End Set
    End Property
    Private _totlevup As String
    Public Property TotLevelUp() As String
        Get
            Return _totlevup
        End Get
        Set(ByVal value As String)
            _totlevup = value
        End Set
    End Property
    Private _bibblomoneyEarnedID As String
    Public Property BibblomoneyEarnedID() As String
        Get
            Return _bibblomoneyEarnedID
        End Get
        Set(ByVal value As String)
            _bibblomoneyEarnedID = value
        End Set
    End Property

    Private _awardName As String
    Public Property AwardName() As String
        Get
            Return _awardName
        End Get
        Set(ByVal value As String)
            _awardName = value
        End Set
    End Property
    Private _level As Integer
    Public Property Level() As Integer
        Get
            Return _level
        End Get
        Set(ByVal value As Integer)
            _level = value
        End Set
    End Property

    Private _awardBeskrivning As String
    Public Property AwardBeskrivning() As String
        Get
            Return _awardBeskrivning
        End Get
        Set(ByVal value As String)
            _awardBeskrivning = value
        End Set
    End Property
    Private _awardOccure As Integer
    Public Property AwardOccures() As Integer
        Get
            Return _awardOccure
        End Get
        Set(ByVal value As Integer)
            _awardOccure = value
        End Set
    End Property

    Private _badgeSrc As String
    Public Property BadgeSrc() As String
        Get
            Return _badgeSrc
        End Get
        Set(ByVal value As String)
            _badgeSrc = value
        End Set
    End Property

    Private _questID As Integer
    Public Property QuestID() As Integer
        Get
            Return _questID
        End Get
        Set(ByVal value As Integer)
            _questID = value
        End Set
    End Property

    Private _uppdrag As String
    Public Property Uppdragsnamn() As String
        Get
            Return _uppdrag
        End Get
        Set(ByVal value As String)
            _uppdrag = value
        End Set
    End Property

    Private _uppdragsbeskrivning As String
    Public Property Uppdragsbeskrivning() As String
        Get
            Return _uppdragsbeskrivning
        End Get
        Set(ByVal value As String)
            _uppdragsbeskrivning = value
        End Set
    End Property

    Private _active As Integer
    Public Property Active() As Integer
        Get
            Return _active
        End Get
        Set(ByVal value As Integer)
            _active = value
        End Set
    End Property

    Private _questSubquestList As List(Of QuestTriggerInfo)
    Public Property QuestSubQuestList() As List(Of QuestTriggerInfo)
        Get
            Return _questSubquestList
        End Get
        Set(ByVal value As List(Of QuestTriggerInfo))
            _questSubquestList = value
        End Set
    End Property
    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

End Class
