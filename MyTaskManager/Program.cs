using System;
using System.Text;

namespace csharpik
{
    class Program
    {
        static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.GetEncoding(1251);
            Console.InputEncoding = Encoding.GetEncoding(1251);

            Menu menu = new();
            menu.ConsoleMenu();

        }
    }
}

