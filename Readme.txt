dotnet C# 5.0 Web API
=====================

docker image build -t webjokesapi .

docker run -it -v "C:\YOUR_DIR_PATH\WebAPIJokes":/work -p5000:5000 webjokesapi bash

http://localhost:5000/swagger/index.html
http://localhost:5000/api/joke