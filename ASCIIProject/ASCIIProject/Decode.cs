using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIProject
{
    public class Decoder
    {
        private string total = string.Empty;
        private string totalB = string.Empty;
        private string totalC = string.Empty;
        private int inputInt = 0;
        private char inputChar = ' ';
        public void Decode(string input)
        {
            int length = input.Length;
            while (input.ToLower() != "finish")
            {
                bool isParsable = int.TryParse(input, out this.inputInt);
                while (!isParsable && input.ToLower() != "finish")
                {
                    Console.Write("Not an integer, try again (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                    isParsable = int.TryParse(input, out this.inputInt);
                }
                while (length < 1 && input.ToLower() != "finish")
                {
                    Console.Write("Can not be shorter than 1 digit (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                }
                while (length > 3 && input.ToLower() != "finish")
                {
                    Console.Write("Can not be longer than 3 digits (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                }
                this.inputChar = (char)inputInt;
                if (this.inputInt == ' ')
                {
                    Console.WriteLine("Space" + " (" + this.inputInt + "))");
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                    this.total += this.inputInt;
                }
                else if (this.inputInt >= 'A' && this.inputInt <= 'Z')
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + ") / {0} ({1})", (char)(this.inputInt + 32), this.inputInt + 32);
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                    this.total += this.inputInt;
                }
                else if (this.inputInt >= 'a' && this.inputInt <= 'z')
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + ") / {0} ({1})", (char)(this.inputInt - 32), this.inputInt - 32);
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                    this.total += this.inputInt;
                }
                else if (this.inputInt > '~' || this.inputInt < ' ')
                {
                    Console.WriteLine("INVALID PLEASE TRY AGAIN");
                }
                else
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + "))");
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                    this.total += this.inputInt;
                }
                Console.Write("Please enter the requested numbers to decode (\"finish\" to finish): ");
                input = Console.ReadLine();
                length = input.Length;
            }
        }
        public void Get()
        {
            Console.WriteLine("\nDigits: {0}", this.totalB);
            Console.WriteLine("String: {0}", this.total);
            Console.WriteLine("Separated Digits: {0}", totalC);
        }
        public override string ToString()
        {
            string output = string.Empty;
            output += string.Format("Characters: {0}\n", this.totalB);
            output += string.Format("String: {0}\n", this.total);
            output += string.Format("Separated Characters: {0}", totalC);
            return output;
        }
    }
}
