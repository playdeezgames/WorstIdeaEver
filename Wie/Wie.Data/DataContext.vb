Imports Microsoft.Data.Sqlite

Public Class DataContext
    Implements IDataContext
    Private _connection As SqliteConnection = Nothing
    Private _playerCharacters As IPlayerCharacters = Nothing
    Private _playerCharacterId As Long?

    Public ReadOnly Property PlayerCharacters As IPlayerCharacters Implements IDataContext.PlayerCharacters
        Get
            Return _playerCharacters
        End Get
    End Property

    Public Property PlayerCharacterId As Long? Implements IDataContext.PlayerCharacterId
        Get
            Return _playerCharacterId
        End Get
        Set(value As Long?)
            _playerCharacterId = value
        End Set
    End Property

    Public Sub OpenWorld(worldName As String) Implements IDataContext.OpenWorld
        CloseWorld()
        _connection = New SqliteConnection($"Data Source={worldName}.db")
        _connection.Open()
        _playerCharacters = New PlayerCharacters(_connection)
    End Sub

    Public Sub CloseWorld() Implements IDataContext.CloseWorld
        If _connection IsNot Nothing Then
            _playerCharacters = Nothing
            _connection.Close()
            _connection = Nothing
        End If
    End Sub
End Class
