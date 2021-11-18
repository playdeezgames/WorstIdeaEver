Imports Microsoft.Data.Sqlite

Friend Class Creatures
    Implements ICreatures
    Private _connection As SqliteConnection
    Public Sub New(connection As SqliteConnection)
        _connection = connection
    End Sub

    Public Function FindForPlayerCharacter(playerCharacterId As Long) As ICreature Implements ICreatures.FindForPlayerCharacter
        AutoCreateTable()
        Return Nothing
    End Function

    Private Sub AutoCreateTable()
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "CREATE TABLE IF NOT EXISTS [Creatures]([CreatureId] INTEGER PRIMARY KEY AUTOINCREMENT,[LocationId] INTEGER NOT NULL,[PlayerCharacterId] INTEGER NULL);"
        command.ExecuteNonQuery()
    End Sub

    Public Function Create(locationId As Long) As Long Implements ICreatures.Create
        AutoCreateTable()
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "INSERT INTO [Creatures]([LocationId]) VALUES($locationid);"
        command.Parameters.AddWithValue("$locationid", locationId)
        command.ExecuteNonQuery()

        command = _connection.CreateCommand()
        command.CommandText = "SELECT [CreatureId] FROM [Creatures] WHERE [LocationId]=$locationid;"
        command.Parameters.AddWithValue("$locationid", locationId)
        Dim reader As SqliteDataReader = command.ExecuteReader()
        reader.Read()
        Return reader.GetInt64(0)
    End Function

    Public Function Create(locationId As Long, playerCharacterId As Long) As Long Implements ICreatures.Create
        AutoCreateTable()
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "INSERT INTO [Creatures]([LocationId],[PlayerCharacterId]) VALUES($locationid,$playercharacterid);"
        command.Parameters.AddWithValue("$locationid", locationId)
        command.Parameters.AddWithValue("$playercharacterid", playerCharacterId)
        command.ExecuteNonQuery()

        command = _connection.CreateCommand()
        command.CommandText = "SELECT [CreatureId] FROM [Creatures] WHERE [LocationId]=$locationid;"
        command.Parameters.AddWithValue("$locationid", locationId)
        Dim reader As SqliteDataReader = command.ExecuteReader()
        reader.Read()
        Return reader.GetInt64(0)
    End Function

    Public Function Find(creatureId As Long) As ICreature Implements ICreatures.Find
        AutoCreateTable()
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "SELECT [LocationId],[PlayerCharacterId] FROM [Creatures] WHERE [CreatureId]=$creatureid;"
        command.Parameters.AddWithValue("$creatureid", creatureId)
        Dim reader As SqliteDataReader = command.ExecuteReader()
        If reader.Read() Then
            Dim locationId As Long = reader.GetInt64(0)
            Dim playerCharacterId As Long? = Nothing
            If Not reader.IsDBNull(1) Then
                playerCharacterId = reader.GetInt64(1)
            End If
            Return New Creature(creatureId, locationId, playerCharacterId)
        End If
        Return Nothing
    End Function
End Class
