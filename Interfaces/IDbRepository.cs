using ConsoleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Interfaces
{
    public interface IDbRepository
    {
        public Task<IEnumerable<Word>> GetWordsAsync();
        public Task DeleteAsync();
        public Task AddAsync(List<Word> newList);
        public void Add(Word word);
        public void Update(int id, Word word);
        public Task SaveAsync();
    }
}
