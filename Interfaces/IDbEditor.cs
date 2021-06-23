using ConsoleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Interfaces
{
    public interface IDbEditor
    {
        public List<Word> TextAnalisator(string[] text);
        public void AddAndUpdateDataBase(List<Word> list);
        public void DeleteWordsOnDataBase();
    }
}
