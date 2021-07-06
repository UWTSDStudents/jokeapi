using System;
using jokeapi.models;

namespace jokeapi
{
    public interface IJokeAPI
    {
        public JokeEntry[] GetJokes();
		public JokeEntry GetJoke(string id);
		public JokeEntry Next();
		public string Add(Joke joke);
		public bool Remove(string id);
		public bool Edit(string id, Joke newJoke);
		public void Reset();
    }
}
