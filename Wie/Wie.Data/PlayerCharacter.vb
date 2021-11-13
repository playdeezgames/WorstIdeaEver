Friend Class PlayerCharacter
    Implements IPlayerCharacter

    Public ReadOnly Property Id As Integer Implements IPlayerCharacter.Id
        Get
            Throw New NotImplementedException()
        End Get
    End Property
End Class
