using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIProject
{
    public class Encoder
    {
        private string total = string.Empty;
        private string totalB = string.Empty;
        private string totalC = string.Empty;
        private int inputInt = 0;
        private char inputChar = ' ';
        public void Encode(string input)
        {
            while (input.ToLower() != "finish")
            {
                bool isParsable = char.TryParse(input, out this.inputChar);
                while (!isParsable && input.ToLower() != "finish")
                {
                    Console.Write("Not a character, try again (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    isParsable = char.TryParse(LengthCheck(input), out this.inputChar);
                }
                while (inputChar < ' ' && input.ToLower() != "finish")
                {
                    Console.Write("Invalid character, please try again! (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    isParsable = char.TryParse(LengthCheck(input), out this.inputChar);
                }
                while (inputChar > '~' && input.ToLower() != "finish")
                {
                    Console.Write("Invalid character, please try again! (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    isParsable = char.TryParse(LengthCheck(input), out this.inputChar);
                }
                this.inputInt = (int)inputChar;
                this.total += this.inputInt;
                this.totalB += this.inputInt + " ";
                this.totalC += this.inputChar + " ";
                Console.WriteLine(this.inputInt);
                Console.WriteLine("So far: " + this.totalB);
                Console.WriteLine("So far: " + this.totalC);
                Console.Write("Please enter a character to encode (\"finish\" to finish): ");
                input = LengthCheck(Console.ReadLine());
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
        public override string ToString()
        {
            string output = string.Empty;
            System.Windows.Clipboard.SetText(total);
            output += string.Format("Successfully copied \"{0}\" to clipboard!\n", System.Windows.Clipboard.GetText());
            output += string.Format("\nDigits: {0}\n", this.totalB);
            output += string.Format("String: {0}\n", System.Windows.Clipboard.GetText());
            output += string.Format("Separated Characters: {0}", this.totalC);
            return output;
        }
        string LengthCheck(string input)
        {
            int length = input.Length;
            while (length != 1 && input.ToLower() != "finish")
            {
                Console.Write("Can not be longer nor shorter than 1 (\"finish\" to finish): ");
                input = Console.ReadLine();
                length = input.Length;
            }
            return input;
        }
    }
}
