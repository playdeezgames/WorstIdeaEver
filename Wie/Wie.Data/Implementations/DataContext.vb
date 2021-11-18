Imports Microsoft.Data.Sqlite

Public Class DataContext
    Implements IDataContext
    Private _connection As SqliteConnection = Nothing
    Private _playerCharacters As IPlayerCharacters = Nothing
    Private _locations As ILocations = Nothing

    Public ReadOnly Property PlayerCharacters As IPlayerCharacters Implements IDataContext.PlayerCharacters
        Get
            Return _playerCharacters
        End Get
    End Property

    Public ReadOnly Property Locations As ILocations Implements IDataContext.Locations
        Get
            Return _locations
        End Get
    End Property

    Public Sub OpenWorld(worldName As String) Implements IDataContext.OpenWorld
        CloseWorld()
        _connection = New SqliteConnection($"Data Source={worldName}.db")
        _connection.Open()
        _playerCharacters = New PlayerCharacters(_connection)
        _locations = New Locations(_connection)
    End Sub

    Public Sub CloseWorld() Implements IDataContext.CloseWorld
        If _connection IsNot Nothing Then
            _locations = Nothing
            _playerCharacters = Nothing
            _connection.Close()
            _connection = Nothing
        End If
    End Sub
End Class
