Public Class KrypinQuestMainController
    Public Function RegisterQuest(questobj As QuestInfo) As QuestInfo
        Dim newquest As New QuestInfo
        Dim regObj As New registerBadgeData

        Return regObj.RegisterNewQuest(questobj)

    End Function

    Public Function GetUppdrag(awardgroupid As Integer) As QuestInfo
        Dim obj As New GetQuest

        If awardgroupid > 0 Then
            Return obj.getQuestbyAwardgroupid(awardgroupid)
        Else
            Dim errobj As New QuestInfo
            errobj.Status = "Error inget id angivet"

            Return errobj
        End If
    End Function

    Public Function EditBokmarkelseUppdrag(questobj As QuestInfo) As QuestInfo

        Return EditQuestdata("all", questobj)

    End Function

    Public Function EditBokmarktesgrupp(questobj As QuestInfo) As QuestInfo

        Return EditQuestdata("bokmarkelsegrupp", questobj)

    End Function

    Public Function EditBokmarkte(questobj As QuestInfo) As QuestInfo

        Return EditQuestdata("bokmarkelse", questobj)

    End Function

    Public Function EditUppdrag(questobj As QuestInfo) As QuestInfo

        Return EditQuestdata("uppdrag", questobj)

    End Function

    Public Function AddQuestTrigger(AwardGroupId As Integer, editTrigger As QuestTriggerInfo) As QuestInfo
        Dim retobj As New QuestInfo
        Dim regObj As New CrudQuestTrigger

        If AwardGroupId > 0 Then
            retobj = regObj.addQuestTrigger(AwardGroupId, editTrigger)
        Else
            retobj.Status = "Error inget id angivet"
        End If

        Return retobj

    End Function

    Public Function EditQuestTrigger(AwardGroupId As Integer, editTrigger As QuestTriggerInfo) As QuestInfo
        Dim retobj As New QuestInfo
        Dim regObj As New CrudQuestTrigger

        If AwardGroupId > 0 Then
            retobj = regObj.editQuestTrigger(AwardGroupId, editTrigger)
        Else
            retobj.Status = "Error inget id angivet"
        End If

        Return retobj

    End Function
    Public Function DelQuestTrigger(AwardGroupId As Integer, questTriggerid As Integer) As QuestInfo
        Dim retobj As New QuestInfo
        Dim regObj As New CrudQuestTrigger

        If AwardGroupId > 0 Then
            retobj = regObj.delQuestTrigger(AwardGroupId, questTriggerid)
        Else
            retobj.Status = "Error inget id angivet"
        End If

        Return retobj
    End Function
    Public Function DeleteQuest(AwardGroupId As Integer) As QuestInfo
        Dim delobj As New DelQuest

        If AwardGroupId > 0 Then
            Return delobj.DeleteQuest(getUppdrag(AwardGroupId))
        Else
            Dim errobj As New QuestInfo
            errobj.Status = "Error inget id angivet"

            Return errobj
        End If
    End Function

    Private Function EditQuestdata(typ As String, questobj As QuestInfo) As QuestInfo
        Dim obj As New editQuest
        Dim retobj As New QuestInfo

        If questobj.AwardGroupId > 0 Then

            Select Case typ
                Case "bokmarkelsegrupp"
                    retobj = obj.EditBokmarktesgrupp(questobj)

                Case "bokmarkelse"
                    retobj = obj.Editbokmarkelse(questobj)

                Case "uppdrag"
                    retobj = obj.EditQuest(questobj)

                Case "all"
                    obj.EditBokmarktesgrupp(questobj)
                    obj.Editbokmarkelse(questobj)
                    retobj = obj.EditQuest(questobj)
            End Select

        Else
            retobj.Status = "Error inget id angivet"

        End If

        Return retobj

    End Function
End Class
