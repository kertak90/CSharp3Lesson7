using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    class Program
    {
        static void Main(string[] args)
        {

            //Тестовое подключение к базе
            using (var db = new Data.SongsDB())
            {
                var list = db.Tracks.Where(p => p.Name.StartsWith("A"))
                                        .OrderBy(p=>p.Name)
                                        .ToList();
                var newList = list.Select(p => new {
                                            Name = p.Name,
                                            Count = p.Name.Count()
                                        });
                Console.WriteLine($"Count - {list.Count()}");
                foreach(var item in list)
                {
                    Console.WriteLine($"{item.Name} - {item.Artist}");
                }
                Console.WriteLine();
                Console.WriteLine($"Count - {newList.Count()}");
                foreach (var item in newList)
                {
                    Console.WriteLine($"{item.Name} - {item.Count}");
                }
            }
            //using (var db = new Data.MusicsContainer())
            //{
            //    var list = db.MusicsSet;
            //    foreach(var m in list)
            //    {
            //        Console.WriteLine($"{m.Artist} - {m.Name}");
            //    }
            //}
            //Console.ReadLine();
        }
    }
}
