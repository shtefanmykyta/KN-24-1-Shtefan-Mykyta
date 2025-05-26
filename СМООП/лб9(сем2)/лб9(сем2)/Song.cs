using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб9_сем2_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    //Завдання 3
    public class Song
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Composer { get; set; }
        public int Year { get; set; }
        public string Lyrics { get; set; }
        public List<string> Performers { get; set; }
        public Song()
        {
            Performers = new List<string>();
        }
        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Composer: {Composer}, Year: {Year}, Performers: {string.Join(", ", Performers)}";
        }
    }
}
