using FreeMonadDemo;
using NUnit.Framework;

namespace FreeMonadDemoTest
{
    [TestFixture]
    public class FreeMonadTests
    {
        [Test]
        public void TestProgramOutputsHelloWorld()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                var program = FreeMonad<ICommand>.WrapAsMonad(new WriteLine("Hello, World!"));

                new ConsoleFreeMonadInterpreter().Interpret(program);

                Assert.AreEqual("Hello, World!\r\n", sw.ToString());
            }
        }
    }
}