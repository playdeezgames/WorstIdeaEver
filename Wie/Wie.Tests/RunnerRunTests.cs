using Moq;
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
            Mock<IInputter> inputter = new();
            Mock<IOutputter> outputter = new();
            Mock<IEngine> engine = new();
            engine.Setup(x => x.IsRunning()).Returns(false);
            IRunner runner = new Runner(inputter.Object, outputter.Object);
            runner.Run(engine.Object);
            engine.Verify(x => x.IsRunning(), Times.AtLeastOnce());
            engine.VerifyNoOtherCalls();
            inputter.VerifyNoOtherCalls();
            outputter.VerifyNoOtherCalls();
        }
        [Fact]
        public void ShouldCallOutputAndInputMethodsAsLongAsTheEngineRuns()
        {
            Mock<IInputter> inputter = new();
            Mock<IOutputter> outputter = new();
            List<bool> isRunningResults = new List<bool>() { true, true, false };
            Mock<IEngine> engine = new();
            engine.Setup(x => x.IsRunning()).Returns(()=> 
            {
                var result = isRunningResults.First();
                isRunningResults.RemoveAt(0);
                return result;
            });
            IRunner runner = new Runner(inputter.Object, outputter.Object);
            runner.Run(engine.Object);
            engine.Verify(x => x.IsRunning(), Times.Exactly(3));
            engine.Verify(x => x.ShowState(), Times.Exactly(2));
            engine.Verify(x => x.HandleInput(It.IsAny<string>()), Times.Exactly(2));
            engine.VerifyNoOtherCalls();
            inputter.Verify(x => x.Read(), Times.Exactly(2));
            inputter.VerifyNoOtherCalls();
            outputter.Verify(x => x.Write(It.IsAny<IEnumerable<string>>()), Times.Exactly(2));
            outputter.VerifyNoOtherCalls();
        }
    }
}
