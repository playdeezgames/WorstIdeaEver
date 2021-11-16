Imports System
Imports Xunit
Imports Shouldly

Public Class GamePlayerCharacterIdTests
    <Fact>
    Sub ShouldInitiallyBeNull()
        Dim subject As IGame = New WieGame()
        subject.PlayerCharacterId.ShouldBeNull()
    End Sub
    <Fact>
    Sub ShouldBeRetrievableWhenSet()
        Dim subject As IGame = New WieGame()
        Dim expected As Int64 = 1
        subject.PlayerCharacterId = expected
        Dim actual = subject.PlayerCharacterId
        actual.ShouldBe(expected)
    End Sub
End Class


