using System;
using Xunit;

using jokeapilib;

namespace jokeapixunit
{
    public class FakeJoke : IJoke<FakeJoke>
    {
		public string Id { get; set; }
		public string Author { get; set; }
		public string Setup { get; set; }
		public string Punchline { get; set; }
		public int Rating { get; set; }
		
		public void Copy(FakeJoke joke)
		{
			Author = joke.Author;
			Setup = joke.Setup;
			Punchline = joke.Punchline;
			Rating = joke.Rating;
		}
    }
}
