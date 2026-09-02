using System.ComponentModel;
namespace calculator
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Division(int a, int b)
        {
            //if (b == 0) throw new DivideByZeroException();
            if (b == 0) throw new Exception("Blud you cunt div by zeROO");
            return a / b;
        }

        public static void Main(string[] args)
        {
            Calculator cal = new Calculator();
            Console.WriteLine(cal.Division(10, 1));
        }
    }
}