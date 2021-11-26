Public Interface IPlayerCharacterCreatures
    Function FindCreatureId(playerCharacterId As Long) As Long?
    Function Associate(creatureId As Long, playerCharacterId As Long) As Boolean
End Interface
