using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumindoJokeAPI
{
    public class Joke
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string joke { get; set; }
        public string type { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public Flags flags { get; set; }
        public int id { get; set; }
        public string lang { get; set; }
        public bool internalError { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public List<string> causedBy { get; set; }
        public string additionalInfo { get; set; }
        public long timestamp { get; set; }
    }
}
