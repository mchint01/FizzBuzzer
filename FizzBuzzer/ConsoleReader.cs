using FizzBuzzer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzer
{
    public class ConsoleReader : IReader
    {
        public void Read()
        {
            Console.Read();
        }
    }
}
