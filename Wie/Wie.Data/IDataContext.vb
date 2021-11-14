Public Interface IDataContext
    Sub OpenWorld(worldName As String)
    Sub CloseWorld()
    Function GetPlayerCharacters() As List(Of IPlayerCharacter)
    Function CreatePlayerCharacter(name As String) As IPlayerCharacter
End Interface

