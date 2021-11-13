using Moq;
using System;
using Wie.Engine;
using Xunit;

namespace Wie.Tests
{
    public class RunnerRunTests
    {
        [Fact]
        public void ShouldStopImmediatelyWhenTheEngineIsNotRunning()
        {
            Mock<IEngine> engine = new();
            engine.Setup(x => x.IsRunning()).Returns(false);
            IRunner runner = new Runner();
            runner.Run(engine.Object);
            engine.Verify(x => x.IsRunning(), Times.AtLeastOnce());
            engine.VerifyNoOtherCalls();
        }
    }
}
