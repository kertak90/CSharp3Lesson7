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
            using (var db = new Data.SongsDB())
            {
                foreach(var track in db.Tracks)
                {
                    Console.WriteLine($"{track.Id}\t{track.Name}\t{track.ArtistName}\t{track.Length}");
                }
            }
            Console.ReadLine();
        }
    }
}
