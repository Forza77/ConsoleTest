using ConsoleTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Models
{
    //Модель которая возвращает результат
    public class WordProcessorModel:BaseModel,IWordProcessor
    {
        public IEnumerable<Word> GetResultWords(string input)
        {
            var itogList = new List<Word>();
            var list = dbRepository.GetWordsAsync().Result.OrderByDescending(word => word.Count).ThenBy(word => word.Value).ToList();
            foreach (var word in list)
            {
                if (word.Value.Length < input.Length) continue;
                if (word.Value.StartsWith(input, StringComparison.OrdinalIgnoreCase)) 
                { 
                    itogList.Add(word);
                    if (itogList.Count == 5) break;
                }
            }
            return itogList;
        }
    }
}
