using System;
using Xunit;

using jokeapilib;

namespace jokeapixunit
{
    public class JokeAPITest
    {
		[Fact]
        public void AddJoke()
        {
			JokeManager<FakeJoke, FakeJoke> manager = new JokeManager<FakeJoke, FakeJoke>();
			FakeJoke joke = new FakeJoke()
			{
				Id = "",
				Author = "F. Thomas",
				Setup = "Why is an apple red?",
				Punchline = "Because it is an apple",
				Rating = 1
			};
			
			string id = manager.Add(joke);
			//Assert.Equal(1, manager.Jokes.Count);
			Assert.Single(manager.Jokes);
			Assert.NotEqual("", id);
			
			joke = new FakeJoke()
			{
				Id = "",
				Author = "G. Thomas",
				Setup = "What is red?",
				Punchline = "The sun",
				Rating = 3
			};
			
			id = manager.Add(joke);
			Assert.Equal(2, manager.Jokes.Count);
			Assert.NotEqual("", id);			
        }
		
		[Fact]
        public void RemoveJoke()
        {
			JokeManager<FakeJoke, FakeJoke> manager = new JokeManager<FakeJoke, FakeJoke>();
			string id = manager.Add(new FakeJoke()
			{
				Id = "",
				Author = "F. Thomas",
				Setup = "Why is an apple red?",
				Punchline = "Because it is an apple",
				Rating = 1
			});
			
			Assert.True(manager.Remove(id));
			//Assert.Equal(1, manager.Jokes.Count);
			Assert.Empty(manager.Jokes);
        }
		
		[Fact]
        public void FindJoke()
        {
			JokeManager<FakeJoke, FakeJoke> manager = new JokeManager<FakeJoke, FakeJoke>();
			FakeJoke fake = new FakeJoke()
			{
				Id = "",
				Author = "F. Thomas",
				Setup = "Why is an apple red?",
				Punchline = "Because it is an apple",
				Rating = 1
			};
			string id = manager.Add(fake);
			
			FakeJoke joke = manager.Find(id);			
			Assert.NotNull(joke);
			Assert.Equal(fake.Author, joke.Author);
			Assert.Equal(fake.Setup, joke.Setup);
			Assert.Equal(fake.Punchline, joke.Punchline);
			Assert.Equal(fake.Rating, joke.Rating);
        }
		
		[Fact]
        public void EditJoke()
        {
			JokeManager<FakeJoke, FakeJoke> manager = new JokeManager<FakeJoke, FakeJoke>();
			string id = manager.Add(new FakeJoke()
			{
				Id = "",
				Author = "F. Thomas",
				Setup = "Why is an apple red?",
				Punchline = "Because it is an apple",
				Rating = 1
			});
			
			FakeJoke fake = new FakeJoke()
			{
				Id = "",
				Author = "B. Jones",
				Setup = "Say Hello?",
				Punchline = "No say goodbye",
				Rating = 3			
			};
			
			Assert.True(manager.Edit(id, fake));
			
			FakeJoke joke = manager.Find(id);			
			Assert.Equal(fake.Author, joke.Author);
			Assert.Equal(fake.Setup, joke.Setup);
			Assert.Equal(fake.Punchline, joke.Punchline);
			Assert.Equal(fake.Rating, joke.Rating);
        }

		[Fact]
        public void NextJoke()
        {
			JokeManager<FakeJoke, FakeJoke> manager = new JokeManager<FakeJoke, FakeJoke>();
			FakeJoke[] fake = new FakeJoke[]
			{
				new FakeJoke()
				{
					Id = "",
					Author = "One",
					Setup = "Why is an apple red?",
					Punchline = "Because it is an apple",
					Rating = 1
				},
				new FakeJoke()
				{
					Id = "",
					Author = "Two",
					Setup = "Hello bob?",
					Punchline = "Hi",
					Rating = 2
				}
			};
				
			manager.Add(fake[0]);
			manager.Add(fake[1]);
			
			FakeJoke next = manager.NextJoke();			
			Assert.NotNull(next);
			Assert.Equal(fake[0].Author, next.Author);
			next = manager.NextJoke();			
			Assert.NotNull(next);
			Assert.Equal(fake[1].Author, next.Author);
			next = manager.NextJoke();			
			Assert.Null(next);
        }		
    }
}
