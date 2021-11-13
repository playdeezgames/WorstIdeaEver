using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Fact]
        public void ShouldCallOutputAndInputMethodsAsLongAsTheEngineRuns()
        {
            List<bool> isRunningResults = new List<bool>() { true, true, false };
            Mock<IEngine> engine = new();
            engine.Setup(x => x.IsRunning()).Returns(()=> 
            {
                var result = isRunningResults.First();
                isRunningResults.RemoveAt(0);
                return result;
            });
            IRunner runner = new Runner();
            runner.Run(engine.Object);
            engine.Verify(x => x.IsRunning(), Times.Exactly(3));
            engine.Verify(x => x.ReceiveOutput(), Times.Exactly(2));
            engine.Verify(x => x.SendInput(It.IsAny<string>()), Times.Exactly(2));
            engine.VerifyNoOtherCalls();
        }
    }
}
