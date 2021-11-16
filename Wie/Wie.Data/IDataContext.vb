Public Interface IDataContext
    Property PlayerCharacterId As Nullable(Of Int64)
    Sub OpenWorld(worldName As String)
    Sub CloseWorld()
    ReadOnly Property PlayerCharacters() As IPlayerCharacters
End Interface

