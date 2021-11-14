Imports Microsoft.Data.Sqlite

Friend Class PlayerCharacter
    Implements IPlayerCharacter
    Private _id As Int64
    Private _name As String

    Friend Sub New(id As Int64, name As String)
        _id = id
        _name = name
    End Sub

    Public ReadOnly Property Id As Int64 Implements IPlayerCharacter.Id
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property Name As String Implements IPlayerCharacter.Name
        Get
            Return _name
        End Get
    End Property

    Private Shared Sub AutoCreateTable(connection As SqliteConnection)
        Dim command As SqliteCommand = connection.CreateCommand
        command.CommandText = "CREATE TABLE IF NOT EXISTS [PlayerCharacters]([PlayerCharacterId] INTEGER PRIMARY KEY, [PlayerCharacterName] TEXT NOT NULL UNIQUE);"
        command.ExecuteNonQuery()
    End Sub
    Friend Shared Function All(connection As SqliteConnection) As List(Of IPlayerCharacter)
        AutoCreateTable(connection)
        Dim command As SqliteCommand = connection.CreateCommand
        command.CommandText = "SELECT [PlayerCharacterId], [PlayerCharacterName] FROM [PlayerCharacters];"
        Dim result As New List(Of IPlayerCharacter)
        Using reader = command.ExecuteReader
            While reader.Read()
                result.Add(New PlayerCharacter(reader.GetInt64(0), reader.GetString(1)))
            End While
        End Using
        Return result
    End Function
End Class
