Imports Microsoft.Data.Sqlite

Friend Class Creatures
    Implements ICreatures
    Private _connection As SqliteConnection
    Public Sub New(connection As SqliteConnection)
        _connection = connection
    End Sub

    Public Function FindForPlayerCharacter(playerCharacterId As Long) As ICreature Implements ICreatures.FindForPlayerCharacter
        Return Nothing
    End Function
End Class
