using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Models
{
    //Объект базы данных
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int Count { get; set; }
    }
}
