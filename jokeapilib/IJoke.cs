using System;

namespace jokeapilib
{
    public interface IJoke<T>
    {
		public string Id { get; set; }
		public void Copy(T joke);
    }
}
