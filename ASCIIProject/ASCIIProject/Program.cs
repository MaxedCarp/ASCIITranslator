using System;
using System.Windows;
using System.Windows.Forms;
using ASCIIProject;
namespace test
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            Encoder encoder = new Encoder();
            Decoder decoder = new Decoder();
            string input = string.Empty;
            int length = input.Length;
            char convertType;
            Console.Write("Do you want to Encode (E) or Decode (D)? ");
            convertType = char.Parse(Console.ReadLine());
            while (convertType != 'd' && convertType != 'D' && convertType != 'e' && convertType != 'E')
            {
                Console.Write("\nPlease try again (E or D): ");
                convertType = char.Parse(Console.ReadLine());
            }
            if (convertType == 'e' || convertType == 'E') //e || E
            {
                Console.Write("Please enter a character to encode (\"finish\" to finish): ");
                input = Console.ReadLine();
                encoder.Encode(input);
            }
            else if (convertType == 'd' || convertType == 'D') //d || D
            {
                Console.Write("Please enter the requested numbers to decode (\"finish\" to finish): ");
                input = Console.ReadLine();
                decoder.Decode(input);
            }

            if (convertType == 'e' || convertType == 'E')
            {
                Console.WriteLine(encoder);
            }
            if (convertType == 'd' || convertType == 'D')
            {
                Console.WriteLine(decoder);
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
