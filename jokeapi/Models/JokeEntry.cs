using System;
using jokeapilib;

namespace jokeapi.models
{
    public class JokeEntry : Joke, IJoke<Joke>
    {
		public string Id { get; set; }
		
		public void Copy(Joke joke)
		{
			Author = joke.Author;
			Setup = joke.Setup;
			Punchline = joke.Punchline;
			Rating = joke.Rating;
		}
    }
}
