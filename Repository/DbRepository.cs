﻿using ConsoleTest.Interfaces;
using ConsoleTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest.Repository
{
    //репозиторий для работы с базой данных
    public class DbRepository : IDbRepository
    {
        private readonly DataBaseContext dataBaseContext;
        public DbRepository(DataBaseContext dataBaseContext)
        {
            this.dataBaseContext = dataBaseContext;
        }
        public void Add(List<Word> List)=> dataBaseContext.AddRange(List);
        public void Add(Word word) => dataBaseContext.Add(word);
        public void Update(int id,Word word)
        {
            var updateWord = dataBaseContext.Words.FirstOrDefault(word => word.Id == id) ?? throw new Exception("Not Found");
            updateWord.Count += word.Count;
        }

        public void Delete()
        {
            foreach (var word in dataBaseContext.Words) dataBaseContext.Words.Remove(word);
        }

        public IEnumerable<Word> GetWords { get {return dataBaseContext.Words; } }
        public void Save() => dataBaseContext.SaveChanges();
    }
}
