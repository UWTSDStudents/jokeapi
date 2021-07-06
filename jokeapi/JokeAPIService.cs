using System;
using jokeapi.models;
using jokeapilib;

namespace jokeapi
{
    public class JokeAPIService : IJokeAPI
    {
		private JokeManager<JokeEntry, Joke> manager = new JokeManager<JokeEntry, Joke>();

		public JokeEntry[] GetJokes()
		{
			return manager.Jokes.ToArray();
		}
		
		public JokeEntry GetJoke(string id)
		{
			return manager.Find(id);
		}
		
		public JokeEntry Next()
		{
			return manager.NextJoke();
		}
		
		public string Add(Joke joke)
		{
			return manager.Add(joke);
		}
		
		public bool Remove(string id)
		{
			return manager.Remove(id);
		}
		
		public bool Edit(string id, Joke newJoke)
		{
			return manager.Edit(id, newJoke);
		}
		
		public void Reset()
		{
			manager.Reset();
		}
    }
}
