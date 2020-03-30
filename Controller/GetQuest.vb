Public Class GetQuest

    Public Function getQuestbyAwardgroupid(awardgroupid As Integer) As QuestInfo
        Dim retobj As New QuestInfo

        Dim tmpObj As QuestInfo = getbokmarkelseguppById(awardgroupid)

        If tmpObj.Status <> "Error" Then
            tmpObj = getBokmarkelseByAid(tmpObj)

            If tmpObj.Status <> "Error" Then
                tmpObj = getQuestByid(tmpObj)

                If tmpObj.Status <> "Error" Then
                    tmpObj = getquesttriggerByQuestId(tmpObj)
                End If

            End If

        End If

        Return tmpObj

    End Function

    Private Function getbokmarkelseguppById(awardgroupid As Integer) As QuestInfo
        Dim dalobj = New KrypinQuestDAL
        Return dalobj.getbokmarkelseGroup(awardgroupid)

    End Function
    Private Function getBokmarkelseByAid(obj As QuestInfo) As QuestInfo
        Dim dalobj = New KrypinQuestDAL
        Return dalobj.getbokmarkelse(obj)
    End Function

    Private Function getQuestByid(obj As QuestInfo) As QuestInfo
        Dim dalobj = New KrypinQuestDAL
        Return dalobj.getQuest(obj)
    End Function

    Private Function getquesttriggerByQuestId(obj As QuestInfo) As QuestInfo
        Dim dalobj = New KrypinQuestDAL
        Return dalobj.getQuestTriggers(obj)
    End Function
End Class
