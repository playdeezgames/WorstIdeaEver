Public Interface IDataContext
    Sub OpenWorld(worldName As String)
    Sub CloseWorld()
    ReadOnly Property PlayerCharacters() As IPlayerCharacters
    ReadOnly Property Locations() As ILocations
    ReadOnly Property Creatures() As ICreatures
    ReadOnly Property PlayerCharacterCreatures() As IPlayerCharacterCreatures


End Interface

