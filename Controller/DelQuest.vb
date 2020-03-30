Public Class DelQuest
    Private _dalobj = New KrypinQuestDAL

    Public Function DeleteQuest(delObj As QuestInfo) As QuestInfo
        Dim retobj As New QuestInfo

        If delObj.AwardGroupId > 0 And delObj.Aid > 0 And delObj.QuestID > 0 Then
            retobj.Status = reroll(delObj)
        Else
            retobj.Status = "Error Uppdraget finns inte"
        End If

        Return retobj

    End Function



    Public Function reroll(rollObj As QuestInfo) As String
        Dim retboj As String = ""

        If rollObj.AwardGroupId > 0 Then
            If rollback1(rollObj.AwardGroupId) Then
                retboj = "Bokmärkelsegrupp Deleted"
            Else
                retboj = "ERROR in deletion Bokmärkelsegrupp"
            End If
        End If

        If rollObj.Aid > 0 Then
            If rollback2(rollObj.Aid) Then
                retboj &= ", Bokmärkelse Deleted"
            Else
                retboj &= ", ERROR in deletion Bokmärkelse"
            End If
        End If

        If rollObj.QuestID > 0 Then
            If rollback3(rollObj.QuestID) Then
                retboj &= ", Quest Deleted "
            Else
                retboj &= ", ERROR in deletion Quest "
            End If
        End If

        Return retboj

    End Function

    Private Function rollback1(AwardGroupId As Integer) As Boolean
        Return _dalobj.delbokmarkesGrupp(AwardGroupId)
    End Function

    Private Function rollback2(Aid As Integer) As Boolean
        Return _dalobj.delbokmarkelse(Aid)
    End Function

    Private Function rollback3(QuestID As Integer) As Boolean
        _dalobj.delQuestTrigger(QuestID)
        Return _dalobj.delQuest(QuestID)
    End Function

End Class
