Public Interface ICreatures
    Function Find(creatureId As Long) As ICreature
    Function FindForPlayerCharacter(playerCharacterId As Long) As ICreature
    Function Create(locationId As Long) As Long
    Function Create(locationId As Long, playerCharacterId As Long) As Long
End Interface
