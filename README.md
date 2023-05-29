# Ship CRUD APIs

This is a sample C# application to have CRUD Operations for ship objects.
Local file based database is used in it (SQLite) and authentication is also mocked.

# Pre Requisite

1. DotNet 7 SDK. 
You can download it from https://dotnet.microsoft.com/en-us/download/dotnet/7.0
2. Install Docker (if you want to run the application in docker container)
3. Postman (to test APIs)
# Start Backend Server(Default method)

Downlaod the code.

```
Get the code by either git clone or by downloading zip folder.

```

Run Server
```
# Go to the code folder
cd <code_folder>

# Run Server
dotnet run

Server will start on http://localhost:5000

```

# Start Backend Server Using Docker

You can also start server using docker. Make sure docker is installed.DockerFile is provided in code.

```
Get the code by either git clone or by downloading zip folder.

```

Run server using dockerfile
```
# Go to the code folder
cd <code_folder>

# Create docker image using given docker file
docker build -t aspnetapp .

# Create and run docker container
docker run -it --rm -p 5000:80 --name aspnetcore_sample aspnetapp

Server will run on http://localhost:5000

```


# Sample Application Usage

After starting the server, you can test following endpoints to have crud operations on ship objects
Use Postman to test the APIs.

```
POST Request http://localhost:5000/ships 
It will save a new ship object in DB.

Request body:
{
    "name": "sample ship",
    "length": 100,
    "width": 250,
    "code": "AAAA-1111-A1"
}
Ship code will have this unique format "AAAA-1111-A1". All validations are implemented.
It will also be unique for every ship object means you cannot have same code in 2 ships.


```

```
GET Request http://localhost:5000/ships 
It will return all ship objects from db

```

```
GET Request http://localhost:5000/ships/{id}
It will return single ship object for given integer id

```

```
PATCH Request http://localhost:5000/ships/{id}
It will update a ship object for given id. You can update single or full object in this.

Sample Request body:
{
    "name" : "new name"
}

```

```
DELETE Request http://localhost:5000/ships/{id}
It will delete a ship object for given id

```

# Authentication

For all above APIs, authentication is required.
I have mocked authentication using middlewares for simplicity.




```
In the request header for all apis, just add following new header 
"token" : "mujahid-4565xgfh-tykk45-12"

This token is hard coded. Only this token will work.
```

