# RatingDadJokes

Jokes Rating app - by Daniel Carbajal Fernandez

# Prerequisites

Docker needs to be installed
Docker Compose needs to be installed

# External Services

1. Consul = Service Discovery, running on port 8500.
2. Vault = Secrets Manager, running on port 8200.
3. Redis = Cache Service, running on port 6379.

# Set Up and Running through Visual Studio

To Set Up and run the application please follow this steps:

1. Run the docker-compose.yaml file using the following command "docker-compose -f ./docker-compose.yaml up"
2. Run the powershell script config.ps1
3. Go to the visual studio console, make sure that the selected project is RatingDadJokes.Data, and run the command update-database to create the DB.
4. Make sure that the solution is configured to run the projects RatingDadJokesAPI and RatingDadJokesWeb.
5. Run the application using visual studio.
6. If the Web application is not being able to connect to the API, please, check the port where the API is running on and
   update the file RatingDadJokesAPI.Program.cs line 9. 