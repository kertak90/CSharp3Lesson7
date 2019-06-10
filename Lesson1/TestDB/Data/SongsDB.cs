
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestDB.Data
{
    class SongsDB : DbContext
    {
        public SongsDB() : this("name=SongsDB") { }
        public SongsDB(string ConnectionString) : base(ConnectionString) { }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Table> TableItems { get; set; }
    }

    [Table("SongsSet")]
    public class Track
    {
        [Key]
        public int Id { get; set; }

        [Required]        
        public string Name { get; set; }
        [Required]
        public string Artist { get; set; }
        public int Length { get; set; }
        //public TimeSpan TimeLength => TimeSpan.FromSeconds(Length);
    }

    [Table("Table")]
    public class Table
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string group_id { get; set; }
        [Required]
        public string descr { get; set; }        
    }
}
