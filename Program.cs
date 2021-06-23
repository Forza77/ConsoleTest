using ConsoleTest.Models;
using ConsoleTest.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var modelBuilder = new ModelBuilder(new DbRepository(new DataBaseContext()));
            if (args.Length>0)
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("Недопустимое колличество параметров строки");
                    return;
                }
                switch (args[0].ToLower())
                {
                    case "обновление словаря":
                    case "создание словаря": 
                        {
                            var dbEditModel = modelBuilder.CreateModel<DataBaseEditModel>();
                            Console.WriteLine("Введите путь к файлу");
                            var path = Console.ReadLine().Trim('"');
                            try
                            {
                                var file = File.ReadAllLines(path, Encoding.UTF8);
                                dbEditModel.AddAndUpdateDataBase(dbEditModel.TextAnalisator(file));
                            }
                            catch
                            {
                                Console.WriteLine("Введен некорректный путь");
                            }
                            break; 
                        }
                    case "очистить словарь": 
                        {
                            var dbEdit = modelBuilder.CreateModel<DataBaseEditModel>();
                            dbEdit.DeleteWordsOnDataBase();
                            break; 
                        }
                }
            }
            else
            {
                var builder = new StringBuilder();
                var model = modelBuilder.CreateModel<WordProcessorModel>();
                var list = new List<Word>();
                ConsoleKeyInfo keyInfo;
                while (true)
                {

                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape) break;
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (builder.Length == 0) break;
                        else
                        {
                            list.Add(new Word() { Value = builder.ToString() });
                            Console.WriteLine();
                            model.GetResultWords(builder.ToString()).ToList().ForEach(w => { list.Add(w); Console.WriteLine(w.Value); });
                            builder.Clear();
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (builder.Length == 0) continue;
                        else
                        {
                            builder.Remove(builder.Length - 1, 1);
                            Console.Clear();
                            if (list.Count != 0) list.ForEach(w => Console.WriteLine(w.Value));
                            Console.Write(builder.ToString());
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        builder.Append(keyInfo.KeyChar);
                        Console.Clear();
                        if (list.Count != 0) list.ForEach(w => Console.WriteLine(w.Value));
                        Console.Write(builder.ToString());
                    }
                    else if (char.IsLetter(keyInfo.KeyChar))
                    {
                        builder.Append(keyInfo.KeyChar);
                        Console.Clear();
                        if (list.Count != 0) list.ForEach(w => Console.WriteLine(w.Value));
                        Console.Write(builder.ToString());
                    }
                }
            }
        }
    }
}
