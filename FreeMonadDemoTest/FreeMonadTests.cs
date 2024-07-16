using FreeMonadDemo;
using NUnit.Framework;

namespace FreeMonadDemoTest
{
    [TestFixture]
    public class FreeMonadTests
    {
        // [Test]
        //public void TestProgramOutputsHelloWorld()
        //{
        //    using var sw = new StringWriter();
        //    Console.SetOut(sw);

        //    var interpreter = new Interpreter();

        //    var getAppleText = new GetAppleText();
        //    var appleText = interpreter.Execute(getAppleText, Unit.Value);

        //    var upperCase = new UpperCase(appleText);
        //    var upperCaseResult = interpreter.Execute(upperCase, appleText);

        //    var writeLine = new WriteLine(upperCaseResult);
        //    interpreter.Execute(writeLine, upperCaseResult);

        //    var output = sw.ToString();
        //    Assert.AreEqual("APPLE\r\n", output);
        //}

        [Test]
        public void TestChain()
        {
            var getAppleText = new GetText<Unit>("Hello")
            {
                NextF = (string s2) => new Free<Unit>()
                {
                    Next = new UpperCase<Unit>(s2)
                    {
                        NextF = (s3) => new Free<Unit>()
                        {
                            Next = new WriteLine<Unit>(s3)
                            {
                                NextF = (s4) => new Pure<Unit>(Unit.Value)
                            }
                        }
                    }
                }
            };
        }

        [Test]
        public void TestGetTextMakeUppercaseAndWriteLine()
        {
            // Redirect console output
            var output = new StringWriter();
            Console.SetOut(output);

            // Define the operations chain
            GetText<Unit> getHelloText = new GetText<Unit>("hello")
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
            // Specify the type argument explicitly
            interpreter.Interpret<Unit>(new Free<Unit>() { Next = getHelloText });

            // Assert that "HELLO" was printed to the console
            Assert.AreEqual("HELLO\n", output.ToString());

            // Reset console output to standard output
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}