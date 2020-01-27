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
                while (length < 1)
                {
                    Console.Write("can not be shorter than 1 (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                }
                while (!isParsable)
                {
                    Console.Write("Not an integer, try again (\"finish\" to finish): ");
                    input = Console.ReadLine();
                    length = input.Length;
                    isParsable = int.TryParse(input, out this.inputInt);
                }
                this.inputChar = (char)inputInt;
                this.total += this.inputInt;
                if (this.inputInt == 32)
                {
                    Console.WriteLine("Space" + " (" + this.inputInt + "))");
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                }
                else if (this.inputInt > 64 && this.inputInt < 91)
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + ") / {0} ({1})", (char)(this.inputInt + 32), this.inputInt + 32);
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                }
                else if (this.inputInt > 96 && this.inputInt < 123)
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + ") / {0} ({1})", (char)(this.inputInt - 32), this.inputInt - 32);
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                }
                else if (this.inputInt < 65 && this.inputInt != 32)
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + "))");
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
                }
                else if (this.inputInt > 127 || this.inputInt < 0)
                {
                    Console.WriteLine("INVALID PLEASE TRY AGAIN");
                }
                else
                {
                    Console.WriteLine(this.inputChar + " (" + this.inputInt + "))");
                    this.totalC += this.inputChar + " ";
                    this.totalB += this.inputChar;
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
    }
}
