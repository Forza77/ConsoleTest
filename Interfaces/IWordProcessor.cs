using ConsoleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Interfaces
{
    interface IWordProcessor
    {
        public IEnumerable<Word> GetResultWords(string input);
    }
}
