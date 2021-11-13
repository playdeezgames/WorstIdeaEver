Imports System
Imports Shouldly
Imports Xunit

Namespace Wie.Engine.Tests
    Public Class EngineTests
        <Fact>
        Sub ShouldInitiallyBeInARunningState()
            Dim subject As IEngine = New WieEngine()
            subject.IsRunning().ShouldBe(True)
        End Sub
    End Class
End Namespace

