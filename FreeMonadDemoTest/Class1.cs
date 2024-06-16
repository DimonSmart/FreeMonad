using FreeMonadDemo;
using NUnit.Framework;

[TestFixture]
public class FreeMonadTests
{
    [Test]
    public void TestProgramOutputsHelloWorld()
    {
        // Redirect the console output to a StringWriter
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);

            // Create the program using Free Monad
            var program = FreeMonad<ICommand>.WrapAsMonad(new WriteLine("Hello, World!"));

            // Interpret the program
            FreeMonadInterpreter.Interpret(program);

            // Assert that the expected output was written to the console
            Assert.AreEqual("Hello, World!\r\n", sw.ToString());
        }
    }
}
