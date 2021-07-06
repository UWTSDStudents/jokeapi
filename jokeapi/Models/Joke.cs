using System;
using jokeapilib;

namespace jokeapi.models
{
    public class Joke
    {
		public string Author { get; set; }
		public string Setup { get; set; }
		public string Punchline { get; set; }
		public int Rating { get; set; }
    }
}
