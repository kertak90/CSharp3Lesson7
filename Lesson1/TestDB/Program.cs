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
            //3. Есть таблица Users. Столбцы в ней — Id, Name. Написать SQL-запрос, 
            //который выведет имена пользователей, начинающиеся на 'A' и встречающиеся 
            //в таблице более одного раза, и их количество.
            //
           
            using (var db = new Data.SongsDB())
            {
                var list = db.Tracks.Where(p => p.Name.StartsWith("A"))
                                        .OrderBy(p=>p.Name)
                                        .ToList();
                var newList = list.GroupBy(p=>p.Name)
                    .Select(p => new
                    {
                        Name = p.Key,
                        Count = p.Count()
                    });
                Console.WriteLine($"Count - {list.Count()}");
                foreach(var item in list)
                {
                    Console.WriteLine($"{item.Name} - {item.Artist}");
                }
                Console.WriteLine();                
                foreach (var item in newList)
                {
                    Console.WriteLine($"{item.Name} - {item.Count}");
                }
            }
                
            Console.ReadLine();
        }
    }
}
