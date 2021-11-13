Imports Moq
Imports Shouldly
Imports Wie.Data
Imports Xunit

Namespace Wie.Engine.Tests
    Public Class EngineTests
        <Fact>
        Sub ShouldInitiallyBeInARunningState()
            Dim dataContext As New Mock(Of IDataContext)
            Dim subject As IEngine = New WieEngine(dataContext.Object)
            subject.IsRunning.ShouldBe(True)
            dataContext.VerifyNoOtherCalls()
        End Sub
        <Fact>
        Sub ShouldInitiallyGiveSomeSortOfWelcomingOutput()
            Dim dataContext As New Mock(Of IDataContext)
            Dim subject As IEngine = New WieEngine(dataContext.Object)
            Dim result As IEnumerable(Of String) = subject.ShowState
            result.ShouldNotBeNull
            result.ShouldNotBeEmpty
            dataContext.VerifyNoOtherCalls()
        End Sub
        <Fact>
        Sub ShouldAcceptInput()
            Dim dataContext As New Mock(Of IDataContext)
            Dim subject As IEngine = New WieEngine(dataContext.Object)
            Should.NotThrow(Sub()
                                subject.HandleInput("whatever")
                            End Sub)
            dataContext.VerifyNoOtherCalls()
        End Sub
    End Class
End Namespace

