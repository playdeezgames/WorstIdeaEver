Public Interface IDataContext
    Sub OpenWorld(worldName As String)
    Sub CloseWorld()
    ReadOnly Property PlayerCharacters() As IPlayerCharacters
End Interface

