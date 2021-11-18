Imports Microsoft.Data.Sqlite

Public Class Locations
    Implements ILocations
    Private _connection As SqliteConnection
    Public Sub New(connection As SqliteConnection)
        _connection = connection
    End Sub

    Private Sub AutoCreateTable()
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "CREATE TABLE IF NOT EXISTS [Locations]([LocationId] INTEGER PRIMARY KEY AUTOINCREMENT,[X] INTEGER NOT NULL,[Y] INTEGER NOT NULL,[Z] INTEGER NOT NULL, UNIQUE([X],[Y],[Z]));"
        command.ExecuteNonQuery()
    End Sub

    Public Function Find(locationId As Long) As ILocation Implements ILocations.Find
        AutoCreateTable()
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "SELECT [X],[Y],[Z] FROM [Locations] WHERE [LocationId]=$locationid;"
        command.Parameters.AddWithValue("$locationid", locationId)
        Dim reader As SqliteDataReader = command.ExecuteReader()
        If reader.Read() Then
            Return New Location(locationId, reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2))
        End If
        Return Nothing
    End Function

    Private Sub CreateLocation(x As Integer, y As Integer, z As Integer)
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "INSERT INTO [Locations]([X],[Y],[Z]) VALUES($x,$y,$z);"
        command.Parameters.AddWithValue("$x", x)
        command.Parameters.AddWithValue("$y", y)
        command.Parameters.AddWithValue("$z", z)
        command.ExecuteNonQuery()
    End Sub

    Private Function FindLocation(x As Integer, y As Integer, z As Integer) As Long?
        Dim command As SqliteCommand = _connection.CreateCommand()
        command.CommandText = "SELECT [LocationId] FROM [Locations] WHERE [X]=$x AND [Y]=$y AND[Z]=$z;"
        command.Parameters.AddWithValue("$x", x)
        command.Parameters.AddWithValue("$y", y)
        command.Parameters.AddWithValue("$z", z)
        Dim reader As SqliteDataReader = command.ExecuteReader()
        If reader.Read() Then
            Return reader.GetInt64(0)
        End If
        Return Nothing
    End Function

    Public Function Create(x As Integer, y As Integer, z As Integer) As Long Implements ILocations.Create
        AutoCreateTable()
        CreateLocation(x, y, z)
        Return FindLocation(x, y, z).Value
    End Function
End Class
