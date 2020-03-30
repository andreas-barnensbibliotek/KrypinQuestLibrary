Public Class KrypinQuestDAL

#Region "DATA LINQ SETUP"
    Private connectionObj As New connectionStringHandler
    Private _linqObj As New KrypinQuesLinqDataContext(connectionObj.CurrentConnectionString)

#End Region

#Region "GETTERS"

    Public Function getbokmarkelseGroup(awardgroupid As Integer) As QuestInfo
        Dim retobj As New QuestInfo
        Try
            Dim obj = (From i In _linqObj.tblAjBokmarkelseGruppers
                       Where i.AwardGroupID = awardgroupid
                       Select i).Single

            retobj.AwardGroupId = obj.AwardGroupID
            retobj.AwardName = obj.AwardGroup
            retobj.Occures = obj.Occures
            retobj.PointEarned = obj.PointEarned
            retobj.TotLevelUp = obj.ToLevelUp
            retobj.BibblomoneyEarnedID = obj.BibblimoneyEarnID
            retobj.Status = "hämtat bomkmärkelseGrupp"

        Catch ex As Exception
            retobj.Status = "Error"
        End Try

        Return retobj

    End Function

    Public Function getbokmarkelse(retobj As QuestInfo) As QuestInfo

        Try
            Dim obj = (From i In _linqObj.tblAjBokmarkelsers
                       Where i.Awardgroup = retobj.AwardGroupId
                       Select i).Single

            retobj.Aid = obj.Aid
            retobj.AwardName = obj.Awardname
            retobj.Level = obj.Levels ' vilken level bokmärket gäller ( integer)
            retobj.AwardBeskrivning = obj.Beskrivning 'beskrivning som beskriver bokmärket visas i scorboard
            retobj.AwardOccures = obj.Occurs ' max level (integer)
            retobj.BadgeSrc = obj.Badgesrc
            retobj.Status = "hämtat bomkmärkelse"

        Catch ex As Exception
            retobj.Status = "Error"
        End Try

        Return retobj

    End Function

    Public Function getQuest(retobj As QuestInfo) As QuestInfo

        Try
            Dim obj = (From i In _linqObj.tbl_aj_Quests
                       Where i.Aid = retobj.Aid
                       Select i).Single

            retobj.QuestID = obj.QuestId
            retobj.Uppdragsnamn = obj.Uppdrag
            retobj.Uppdragsbeskrivning = obj.Beskrivning ' vilken level bokmärket gäller ( integer)
            retobj.Active = obj.Active 'beskrivning som beskriver bokmärket visas i scorboard
            retobj.Status = "hämtat uppdrag"

        Catch ex As Exception
            retobj.Status = "Error"
        End Try

        Return retobj

    End Function

    Public Function getQuestTriggers(retobj As QuestInfo) As QuestInfo

        Try
            Dim obj = From i In _linqObj.tbl_aj_QuestTriggers
                      Where i.QID = retobj.QuestID
                      Select i

            For Each itm In obj
                Dim tmp As New QuestTriggerInfo
                tmp.QuestID = itm.QID
                tmp.QuestTriggerId = itm.QtriggerID
                tmp.TNamn = itm.TName
                tmp.TValue = itm.TValue
                retobj.QuestSubQuestList.Add(tmp)

            Next
            retobj.Status = "hämtat uppdrags trigger"

        Catch ex As Exception
            retobj.Status = "Error"
        End Try

        Return retobj

    End Function
#End Region

#Region "ADD"

    Public Function addBokmarkelseGrupp(questobj As QuestInfo) As QuestInfo
        Try
            Dim bmobj As New tblAjBokmarkelseGrupper

            bmobj.AwardGroup = questobj.AwardName
            bmobj.Occures = questobj.Occures
            bmobj.PointEarned = questobj.PointEarned
            bmobj.ToLevelUp = questobj.TotLevelUp
            bmobj.BibblimoneyEarnID = questobj.BibblomoneyEarnedID


            _linqObj.tblAjBokmarkelseGruppers.InsertOnSubmit(bmobj)

            _linqObj.SubmitChanges()
            questobj.AwardGroupId = bmobj.AwardGroupID
            questobj.Status = "Ny bokmarkesgrupp inlagd (ok steg 1)"
            Return questobj

        Catch ex As Exception
            questobj.Status = "Error"
            Return questobj
        End Try
    End Function

    Public Function addBokmarkelse(questobj As QuestInfo) As QuestInfo
        Try

            If questobj.AwardGroupId > 0 And questobj.Status <> "Error" Then
                Dim bmobj As New tblAjBokmarkelser

                bmobj.Awardgroup = questobj.AwardGroupId
                bmobj.Awardname = questobj.AwardName

                bmobj.Badgesrc = questobj.BadgeSrc
                bmobj.Levels = questobj.Level ' vilken level bokmärket gäller ( integer)
                bmobj.Occurs = questobj.AwardOccures ' max level (integer)
                bmobj.Beskrivning = questobj.AwardBeskrivning 'beskrivning som beskriver bokmärket visas i scorboard


                _linqObj.tblAjBokmarkelsers.InsertOnSubmit(bmobj)

                _linqObj.SubmitChanges()
                questobj.Aid = bmobj.Aid 'Detta är bokmärkets id
                questobj.Status = "Ny bokmärke! inlagd (ok steg 2)"
                Return questobj
            Else
                questobj.Status = "Error"
                Return questobj

            End If


        Catch ex As Exception
            questobj.Status = "Error"
            Return questobj
        End Try
    End Function

    Public Function addQuest(questobj As QuestInfo) As QuestInfo
        Try

            If questobj.Aid > 0 And questobj.Status <> "Error" Then
                Dim bmobj As New tbl_aj_Quest

                bmobj.Aid = questobj.Aid
                bmobj.Beskrivning = questobj.Uppdragsbeskrivning

                bmobj.Uppdrag = questobj.Uppdragsnamn
                bmobj.Active = questobj.Active

                _linqObj.tbl_aj_Quests.InsertOnSubmit(bmobj)

                _linqObj.SubmitChanges()
                questobj.QuestID = bmobj.QuestId 'Detta är bokmärkets id
                questobj.Status = "Nytt uppdrag inlagt (ok steg 3)"
                Return questobj
            Else
                questobj.Status = "Error"
                Return questobj

            End If


        Catch ex As Exception
            questobj.Status = "Error"
            Return questobj
        End Try
    End Function

    Public Function addQuesttrigger(questriggerobj As QuestTriggerInfo) As Integer
        Try
            Dim bmobj As New tbl_aj_QuestTrigger

            bmobj.QID = questriggerobj.QuestID
            bmobj.TName = questriggerobj.TNamn
            bmobj.TValue = questriggerobj.TValue

            _linqObj.tbl_aj_QuestTriggers.InsertOnSubmit(bmobj)

            _linqObj.SubmitChanges()

            Return bmobj.QtriggerID


        Catch ex As Exception
            Return 0
        End Try

    End Function

#End Region

#Region "Edit"
    Public Function EditbokmarkelseGroup(editObj As QuestInfo) As QuestInfo
        Dim retobj As New QuestInfo
        Try
            Dim obj = (From i In _linqObj.tblAjBokmarkelseGruppers
                       Where i.AwardGroupID = editObj.AwardGroupId
                       Select i).Single

            obj.AwardGroup = editObj.AwardName
            obj.Occures = editObj.Occures
            obj.PointEarned = editObj.PointEarned
            obj.ToLevelUp = editObj.TotLevelUp
            obj.BibblimoneyEarnID = editObj.BibblomoneyEarnedID
            retobj.Status = "Uppdaterad bomkmärkelseGrupp"

            _linqObj.SubmitChanges()
        Catch ex As Exception
            retobj.Status = "Error"
        End Try

        Return retobj

    End Function

    Public Function Editbokmarkelse(editObj As QuestInfo) As QuestInfo

        Try
            Dim obj = (From i In _linqObj.tblAjBokmarkelsers
                       Where i.Aid = editObj.Aid
                       Select i).Single

            obj.Awardname = editObj.AwardName
            obj.Badgesrc = editObj.BadgeSrc
            obj.Levels = editObj.Level ' vilken level bokmärket gäller ( integer)
            obj.Occurs = editObj.AwardOccures ' max level (integer)
            obj.Beskrivning = editObj.AwardBeskrivning 'beskrivning som beskriver bokmärket visas i scorboard

            editObj.Status = "Ändrad bomkmärkelse"

            _linqObj.SubmitChanges()

        Catch ex As Exception
            editObj.Status = "Error"
        End Try

        Return editObj

    End Function

    Public Function EditQuest(editobj As QuestInfo) As QuestInfo

        Try
            Dim obj = (From i In _linqObj.tbl_aj_Quests
                       Where i.QuestId = editobj.QuestID
                       Select i).Single

            obj.Uppdrag = editobj.Uppdragsnamn
            obj.Beskrivning = editobj.Uppdragsbeskrivning ' vilken level bokmärket gäller ( integer)
            obj.Active = editobj.Active 'beskrivning som beskriver bokmärket visas i scorboard
            editobj.Status = "Ändrat uppdrag"

            _linqObj.SubmitChanges()

        Catch ex As Exception

            editobj.Status = "Error"
        End Try

        Return editobj

    End Function

    Public Function editQuestTriggers(editobj As QuestTriggerInfo) As String

        Try
            Dim obj = (From i In _linqObj.tbl_aj_QuestTriggers
                       Where i.QtriggerID = editobj.QuestTriggerId
                       Select i).Single

            obj.TName = editobj.TNamn
            obj.TValue = editobj.TValue

            _linqObj.SubmitChanges()

            Return "Ändrad uppdragstrigger"

        Catch ex As Exception
            Return "Error"
        End Try

    End Function


#End Region

#Region "Delete"
    Public Function delbokmarkesGrupp(AwardGroupId As Integer) As Boolean
        Try
            Dim delobj = (From itm In _linqObj.tblAjBokmarkelseGruppers
                          Where itm.AwardGroupID = AwardGroupId
                          Select itm).Single

            _linqObj.tblAjBokmarkelseGruppers.DeleteOnSubmit(delobj)
            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function delbokmarkelse(Aid As Integer) As Boolean
        Try
            Dim delobj = (From itm In _linqObj.tblAjBokmarkelsers
                          Where itm.Aid = Aid
                          Select itm).Single

            _linqObj.tblAjBokmarkelsers.DeleteOnSubmit(delobj)
            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function delQuest(QuestID As Integer) As Boolean
        Try
            Dim delobj = (From itm In _linqObj.tbl_aj_Quests
                          Where itm.QuestId = QuestID
                          Select itm).Single

            _linqObj.tbl_aj_Quests.DeleteOnSubmit(delobj)
            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function delQuestTrigger(QuestID As Integer) As Boolean
        Try
            Dim delobj = From itm In _linqObj.tbl_aj_QuestTriggers
                         Where itm.QID = QuestID
                         Select itm

            _linqObj.tbl_aj_QuestTriggers.DeleteAllOnSubmit(delobj)
            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function delQuestTriggerById(QtriggerID As Integer) As Boolean
        Try
            Dim delobj = (From itm In _linqObj.tbl_aj_QuestTriggers
                          Where itm.QtriggerID = QtriggerID
                          Select itm).Single

            _linqObj.tbl_aj_QuestTriggers.DeleteOnSubmit(delobj)
            _linqObj.SubmitChanges()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region
    'Public Function updHeroData(updobj As aj_katalogenStartBlock_Info) As Boolean

    '    Dim retobj As Boolean = False
    '    Try
    '        Dim questlist = From i In _linqObj.AJ_kat_StartBlock_Items
    '                        Select i
    '                        Where i.ItemId = updobj.HeroId

    '        For Each itm In questlist
    '            itm.ItemName = updobj.Itemblock1
    '            itm.ItemDescription = updobj.Itemblock2
    '            itm.LastModifiedOnDate = Date.Now
    '            itm.LastModifiedByUserId = updobj.LastModifiedByUserId
    '            retobj = True
    '        Next

    '        _linqObj.SubmitChanges()
    '    Catch ex As Exception

    '    End Try

    '    Return retobj
    'End Function

    'Public Function getStartBlockData(questobj As QuestInfo) As QuestResponseInfo


    '    Dim obj As New QuestResponseInfo
    '    Try
    '        Dim ret = (From i In _linqObj.tblAjBokmarkelseGruppers
    '                   Select i
    '                   Where i.ModuleId = modID).Single

    '        obj.HeroId = ret.ItemId
    '        obj.Itemblock1 = ret.ItemName
    '        obj.Itemblock2 = ret.ItemDescription

    '    Catch ex As Exception

    '    End Try


    '    Return obj

    'End Function

End Class
