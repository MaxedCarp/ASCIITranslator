using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIProject
{
    public class Encode
    {
        private string total = string.Empty;
        private string totalB = string.Empty;
        private string totalC = string.Empty;
        private int inputInt = 0;
        private char inputChar = ' ';
        public void Encoder(string input)
        {
            int length = input.Length;
            while (input.ToLower() != "finish")
            {
                bool parser = char.TryParse(input, out this.inputChar);
                while (length != 1)
                {
                    Console.Write("can not be longer nor shorter than 1 (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                }
                while (!parser)
                {
                    Console.Write("Not a character, try again (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                    parser = char.TryParse(input, out this.inputChar);
                }
                this.inputInt = (int)inputChar;
                this.total = this.total + this.inputInt;
                this.totalB = this.totalB + this.inputInt + " ";
                this.totalC = this.totalC + this.inputChar + " ";
                Console.WriteLine(this.inputInt);
                Console.WriteLine("So far: " + this.totalB);
                Console.WriteLine("So far: " + this.totalC);
                Console.Write("Please enter a character to encode (\"finish\" to finish): ");
                input = Console.ReadLine();
                length = input.Length;
            }
        }
        public void Get()
        {
            System.Windows.Clipboard.SetText(total);
            Console.WriteLine("\nSuccessfully copied \"{0}\" to clipboard!", System.Windows.Clipboard.GetText());
            Console.WriteLine("\nDigits: {0}", this.totalB);
            Console.WriteLine("String: {0}", System.Windows.Clipboard.GetText());
            Console.WriteLine("Separated Digits: {0}", this.totalC);
        }
    }
}
