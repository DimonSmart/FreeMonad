using FreeMonadDemo;
using NUnit.Framework;

namespace FreeMonadDemoTest
{
    [TestFixture]
    public class FreeMonadTests
    {
        [Test]
        public void TestGetTextMakeUppercaseAndWriteLine()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            var getHelloText = new GetText<Unit>("hello")
            {
                NextF = (string s) => new Free<Unit>()
                {
                    Next = new UpperCase<Unit>(s)
                    {
                        NextF = (s2) => new Free<Unit>()
                        {
                            Next = new WriteLine<Unit>(s2)
                            {
                                NextF = (s3) => new Pure<Unit>(Unit.Value)
                            }
                        }
                    }
                }
            };

            var interpreter = new Interpreter();
            // Option 1

            interpreter.InterpretCommand(getHelloText);
            // Optionn 2
            // interpreter.Interpret(new Free<Unit>() { Next = getHelloText });

            Assert.AreEqual("HELLO\r\n", output.ToString());

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }


        [Test]
        public void ChainVizualizationTest()
        {
            var getHelloText = new GetText<Unit>("hello")
            {
                NextF = (string s) => new Free<Unit>()
                {
                    Next = new UpperCase<Unit>(s)
                    {
                        NextF = (s2) => new Free<Unit>()
                        {
                            Next = new WriteLine<Unit>(s2)
                            {
                                NextF = (s3) => new Pure<Unit>(Unit.Value)
                            }
                        }
                    }
                }
            };

            var interpreter = new ChainVisualizerInterpreter();
            interpreter.InterpretCommand(getHelloText);
            Console.WriteLine(interpreter.LastCallGraph);
        }
    }
}