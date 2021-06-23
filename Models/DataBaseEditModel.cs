using ConsoleTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Models
{
    //модель для редактирования базы данных
    public class DataBaseEditModel:BaseModel,IDbEditor
    {
        public List<Word> TextAnalisator(string[] text)
        {
            var itogList = new List<Word>();
            var wordList = new List<string>();
            foreach(var line in text)
            {
               wordList.AddRange(line.Split(new char[] { ' ', ',', '.', ':' , ';' }, StringSplitOptions.RemoveEmptyEntries));
            }
            while(wordList.Count!=0)
            {
                var word = wordList[0];
                if (word.Length < 3 || word.Length > 15)
                {
                    wordList.RemoveAll(w => w == word);
                    continue;
                }
                int count = 0;
                for(int i  = 0; i < wordList.Count; i++)
                {
                    if (word.ToLower() == wordList[i].ToLower()) count++;
                }
                if (count < 3)
                {
                    wordList.RemoveAll(w => w == word);
                    continue;
                }
                itogList.Add(new Word() { Value = word, Count = count });
                wordList.RemoveAll(w =>w==word);
            }
            return itogList;
        }
        public void AddAndUpdateDataBase(List<Word> list)
        {
            var dbWords = dbRepository.GetWords;
            foreach (var word in list)
            {
                var dbWord = dbWords.FirstOrDefault(w => w.Value == word.Value);
                if (dbWord == null) dbRepository.Add(word);
                else dbRepository.Update(dbWord.Id, word);
            }
            dbRepository.Save();
        }
        public void DeleteWordsOnDataBase()
        {
            dbRepository.Delete();
            dbRepository.Save();
        }
    }
}
