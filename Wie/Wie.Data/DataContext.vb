Imports Microsoft.Data.Sqlite

Public Class DataContext
    Implements IDataContext
    Private _connection As SqliteConnection = Nothing

    Public Sub OpenWorld(worldName As String) Implements IDataContext.OpenWorld
        CloseWorld()
        _connection = New SqliteConnection($"Data Source={worldName}.db")
        _connection.Open()
    End Sub

    Public Sub CloseWorld() Implements IDataContext.CloseWorld
        If _connection IsNot Nothing Then
            _connection.Close()
            _connection = Nothing
        End If
    End Sub

    Public Function GetPlayerCharacters() As List(Of IPlayerCharacter) Implements IDataContext.GetPlayerCharacters
        If _connection IsNot Nothing Then
            Return PlayerCharacter.All(_connection)
        End If
        Throw New NotImplementedException
    End Function

    Public Function CreatePlayerCharacter(name As String) As IPlayerCharacter Implements IDataContext.CreatePlayerCharacter
        If _connection IsNot Nothing Then
            Return PlayerCharacter.Create(_connection, name.Trim())
        End If
        Throw New NotImplementedException()
    End Function
End Class
