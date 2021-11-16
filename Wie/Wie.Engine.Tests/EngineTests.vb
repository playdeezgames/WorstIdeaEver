Imports Moq
Imports Shouldly
Imports Wie.Data
Imports Wie.Game
Imports Xunit

Namespace Wie.Engine.Tests
    Public Class EngineTests
        <Fact>
        Sub ShouldInitiallyBeInARunningState()
            Dim dataContext As New Mock(Of IDataContext)
            Dim game As New Mock(Of IGame)
            Dim subject As IEngine = New WieEngine(dataContext.Object, game.Object)
            subject.IsRunning.ShouldBe(True)
            dataContext.VerifyNoOtherCalls()
            game.VerifyNoOtherCalls()
        End Sub
        <Fact>
        Sub ShouldInitiallyGiveSomeSortOfWelcomingOutput()
            Dim dataContext As New Mock(Of IDataContext)
            Dim game As New Mock(Of IGame)
            Dim subject As IEngine = New WieEngine(dataContext.Object, game.Object)
            Dim result As IEnumerable(Of String) = subject.ShowState
            result.ShouldNotBeNull
            result.ShouldNotBeEmpty
            dataContext.VerifyNoOtherCalls()
            game.VerifyNoOtherCalls()
        End Sub
        <Fact>
        Sub ShouldAcceptInput()
            Dim dataContext As New Mock(Of IDataContext)
            Dim game As New Mock(Of IGame)
            Dim subject As IEngine = New WieEngine(dataContext.Object, game.Object)
            Should.NotThrow(Sub()
                                subject.HandleInput("whatever")
                            End Sub)
            dataContext.VerifyNoOtherCalls()
            game.VerifyNoOtherCalls()
        End Sub
    End Class
End Namespace

