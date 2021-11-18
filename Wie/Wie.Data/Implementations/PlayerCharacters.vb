Imports Microsoft.Data.Sqlite

Friend Class PlayerCharacters
    Implements IPlayerCharacters
    Private _connection As SqliteConnection
    Public Sub New(connection As SqliteConnection)
        _connection = connection
    End Sub

    Public ReadOnly Property All As List(Of IPlayerCharacter) Implements IPlayerCharacters.All
        Get
            Return PlayerCharacter.All(_connection)
        End Get
    End Property

    Public Function Create(name As String) As IPlayerCharacter Implements IPlayerCharacters.Create
        Return PlayerCharacter.Create(_connection, name.Trim())
    End Function
End Class
