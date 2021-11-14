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
    Private Shared Function OfRecord(reader As SqliteDataReader) As IPlayerCharacter
        Return New PlayerCharacter(reader.GetInt64(0), reader.GetString(1))
    End Function
    Friend Shared Function All(connection As SqliteConnection) As List(Of IPlayerCharacter)
        AutoCreateTable(connection)
        Dim command As SqliteCommand = connection.CreateCommand
        command.CommandText = "SELECT [PlayerCharacterId], [PlayerCharacterName] FROM [PlayerCharacters];"
        Dim result As New List(Of IPlayerCharacter)
        Using reader = command.ExecuteReader
            While reader.Read()
                result.Add(OfRecord(reader))
            End While
        End Using
        Return result
    End Function
    Private Shared Function FindByName(connection As SqliteConnection, name As String) As IPlayerCharacter
        AutoCreateTable(connection)
        Dim command As SqliteCommand = connection.CreateCommand
        command.CommandText = "SELECT [PlayerCharacterId], [PlayerCharacterName] FROM [PlayerCharacters] WHERE [PlayerCharacterName]=$name;"
        command.Parameters.AddWithValue("$name", name)
        Using reader = command.ExecuteReader()
            If reader.Read() Then
                Return OfRecord(reader)
            End If
            Return Nothing
        End Using
    End Function
    Friend Shared Function Create(connection As SqliteConnection, name As String) As IPlayerCharacter
        If Not String.IsNullOrEmpty(name) Then
            AutoCreateTable(connection)
            If FindByName(connection, name) Is Nothing Then
                Dim command As SqliteCommand = connection.CreateCommand
                command.CommandText = "INSERT INTO [PlayerCharacters]([PlayerCharacterName]) VALUES($name);"
                command.Parameters.AddWithValue("$name", name)
                command.ExecuteNonQuery()
                Return FindByName(connection, name)
            End If
            Return Nothing
        End If
        Throw New ArgumentException(NameOf(name))
    End Function
End Class
