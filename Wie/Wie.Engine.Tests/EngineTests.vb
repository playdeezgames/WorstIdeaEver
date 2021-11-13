Imports System
Imports Shouldly
Imports Xunit

Namespace Wie.Engine.Tests
    Public Class EngineTests
        <Fact>
        Sub ShouldInitiallyBeInARunningState()
            Dim subject As IEngine = New WieEngine()
            subject.IsRunning.ShouldBe(True)
        End Sub
        <Fact>
        Sub ShouldInitiallyGiveSomeSortOfWelcomingOutput()
            Dim subject As IEngine = New WieEngine()
            Dim result As IEnumerable(Of String) = subject.ReceiveOutput
            result.ShouldNotBeNull
            result.ShouldNotBeEmpty
        End Sub
        <Fact>
        Sub ShouldAcceptInput()
            Dim subject As IEngine = New WieEngine()
            Should.NotThrow(Sub()
                                subject.SendInput("whatever")
                            End Sub)
        End Sub
    End Class
End Namespace

