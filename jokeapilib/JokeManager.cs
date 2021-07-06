using System;
using System.Collections.Generic;

namespace jokeapilib
{
	#nullable enable
    public class JokeManager<T, C> where T : class?, IJoke<C>, new()
    {
		// Attributes
		private int _currentJokeIndex;
		
		// Constructors
		public JokeManager()
		{
			Jokes = new List<T>();
			_currentJokeIndex = 0;
		}
		
		// Properties
		public List<T> Jokes { get; private set; }
		
		// Methods
		public string Add(C joke)
		{
			T newJoke = new T();
			newJoke.Id = Guid.NewGuid().ToString();
			newJoke.Copy(joke);
			Jokes.Add(newJoke);
			return newJoke.Id;
		}
		
		public bool Remove(string id)
		{
			T? joke = Find(id);
			if(joke == null) return false;
			Jokes.Remove(joke);
			return true;
		}
		
		public bool Edit(string id, C joke)
		{
			T? fndJoke = Find(id);
			if(fndJoke == null) return false;
			fndJoke.Copy(joke);
			return true;
		}
		
		public T? Find(string id)
		{
			return Jokes.Find(j => j.Id == id);
		}
		
		public T? NextJoke()
		{
			if(_currentJokeIndex < Jokes.Count)
			{
				int current = _currentJokeIndex++;
				return Jokes[current];
			}
			return null;
		}
		
		public void Reset()
		{
			_currentJokeIndex = 0;
		}
    }
}
