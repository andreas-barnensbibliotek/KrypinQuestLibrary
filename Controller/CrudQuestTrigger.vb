Public Class CrudQuestTrigger
    Private _dalobj = New KrypinQuestDAL
    Private _getobj As New GetQuest


    Public Function addQuestTrigger(AwardGroupId As Integer, questobj As QuestTriggerInfo) As QuestInfo
        Dim retobj As New QuestInfo
        Dim getobj As New GetQuest
        Dim dalobj = New KrypinQuestDAL

        retobj = getobj.getQuestbyAwardgroupid(AwardGroupId)
        questobj.QuestID = retobj.QuestID

        If questobj.QuestID > 0 Then

            If dalobj.addQuesttrigger(questobj) > 0 Then
                retobj = getobj.getQuestbyAwardgroupid(AwardGroupId)
            Else
                retobj.Status = "Error"
            End If

        Else
            retobj.Status = "Error"
        End If

        Return retobj

    End Function
    Public Function editQuestTrigger(awardgroupId As Integer, editObj As QuestTriggerInfo) As QuestInfo
        Dim retobj As New QuestInfo

        retobj.Status = _dalobj.editQuestTriggers(editObj)

        If retobj.Status <> "Error" Then
            retobj = _getobj.getQuestbyAwardgroupid(awardgroupId)
        Else
            retobj.Status = "Error ingen ändring är gjord"
        End If

        Return retobj

    End Function

    Public Function delQuestTrigger(awardgroupId As Integer, triggerid As Integer) As QuestInfo
        Dim retobj As New QuestInfo

        If _dalobj.delQuestTriggerById(triggerid) Then
            retobj = _getobj.getQuestbyAwardgroupid(awardgroupId)
        Else
            retobj.Status = "Error inget bort taget"
        End If

        Return retobj
    End Function

End Class
