Public Interface IPlayerCharacters
    ReadOnly Property All() As List(Of IPlayerCharacter)
    Function Create(name As String) As IPlayerCharacter
End Interface
