Public Class registerBadgeData
    Private _dalobj = New KrypinQuestDAL

    Public Function RegisterNewQuest(questObj As QuestInfo) As QuestInfo
        Dim respobj As QuestInfo = doQuestInsertion(questObj)
        Dim delobj As New DelQuest

        If respobj.Status <> "Error" Then
            respobj.Status = "Ny Quest inlagd felfri"
        Else
            respobj.Status = delobj.reroll(respobj)
        End If

        Return respobj
    End Function



    Private Function doQuestInsertion(questObj As QuestInfo) As QuestInfo

        Dim tmpObj As QuestInfo = stepOne(questObj)

        If tmpObj.Status <> "Error" Then
            tmpObj = stepTwo(tmpObj)

            If tmpObj.Status <> "Error" Then
                tmpObj = stepThree(tmpObj)

                If tmpObj.Status <> "Error" Then
                    tmpObj = stepFour(tmpObj)
                End If

            End If

        End If

        Return tmpObj

    End Function

    Private Function stepOne(questobj As QuestInfo) As QuestInfo
        Return _dalobj.addBokmarkelseGrupp(questobj)

    End Function

    Private Function stepTwo(tmpObj As QuestInfo) As QuestInfo
        Return _dalobj.addBokmarkelse(tmpObj)
    End Function

    Private Function stepThree(tmpObj As QuestInfo) As QuestInfo
        Return _dalobj.addQuest(tmpObj)
    End Function

    Private Function stepFour(questObj As QuestInfo) As QuestInfo
        If questObj.QuestID > 0 Then
            Dim tmpobj As List(Of QuestTriggerInfo) = questObj.QuestSubQuestList
            For Each itm In tmpobj
                itm.QuestID = questObj.QuestID
                itm.QuestTriggerId = _dalobj.addQuesttrigger(itm)

            Next

        Else
            questObj.Status = "Error"
        End If

        Return questObj
    End Function



End Class
