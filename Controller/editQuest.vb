Public Class editQuest
    Private _dalobj = New KrypinQuestDAL
    Private _getobj As New GetQuest

    Public Function EditBokmarktesgrupp(editobj As QuestInfo) As QuestInfo
        Dim retobj As New QuestInfo

        Dim tmpObj As QuestInfo = _dalobj.EditbokmarkelseGroup(editobj)

        If tmpObj.Status <> "Error" Then

            tmpObj = _getobj.getQuestbyAwardgroupid(editobj.AwardGroupId)

        Else
            tmpObj.Status = "Error ingen ändring är gjord"
        End If

        Return tmpObj

    End Function

    Public Function Editbokmarkelse(editobj As QuestInfo) As QuestInfo
        Dim retobj As New QuestInfo

        Dim tmpObj As QuestInfo = _dalobj.Editbokmarkelse(getCriticalValues(editobj))

        If tmpObj.Status <> "Error" Then

            tmpObj = _getobj.getQuestbyAwardgroupid(tmpObj.AwardGroupId)
        Else
            tmpObj.Status = "Error ingen ändring är gjord"
        End If

        Return tmpObj

    End Function

    Public Function EditQuest(editobj As QuestInfo) As QuestInfo

        Dim tmpObj As QuestInfo = _dalobj.EditQuest(getCriticalValues(editobj))

        If tmpObj.Status <> "Error" Then
            tmpObj = _getobj.getQuestbyAwardgroupid(tmpObj.AwardGroupId)
        Else
            tmpObj.Status = "Error ingen ändring är gjord"
        End If

        Return tmpObj

    End Function


    Private Function getCriticalValues(editobj As QuestInfo) As QuestInfo

        Dim retobj As QuestInfo = _getobj.getQuestbyAwardgroupid(editobj.AwardGroupId)

        editobj.Aid = retobj.Aid
        editobj.QuestID = retobj.QuestID

        Return editobj

    End Function
End Class
