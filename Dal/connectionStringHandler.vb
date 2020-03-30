Imports System.Configuration

Public Class connectionStringHandler
    Private _connectionstring As String

    Public Sub New()
        'Dim connstr As ConnectionStringSettingsCollection = ConfigurationManager.ConnectionStrings
        '_connectionstring = connstr.Item("SiteSqlServer").ConnectionString


    End Sub
    Public ReadOnly Property CurrentConnectionString() As String
        Get
            Return _connectionstring
        End Get

    End Property
End Class
