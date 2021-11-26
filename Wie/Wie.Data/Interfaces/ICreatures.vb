Public Interface ICreatures
    Function Find(creatureId As Long) As ICreature
    Function Create(locationId As Long) As Long
End Interface
