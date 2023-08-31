# RatingDadJokes

Jokes Rating app

# Prerequisites

Docker needs to be installed
Docker Compose needs to be installed

# Set Up and Running through Visual Studio

To Set Up and run the application please follow this steps:

1. Run the docker-compose.yaml file using the following command "docker-compose -f ./docker-compose.yaml up"
2. Run the powershell script config.ps1
3. Make sure that the solution is configured to run the projects RatingDadJokesAPI and RatingDadJokesWeb.
4. Run the application using visual studio.
5. If the Web application is not being able to connect to the API, please, check the port where the API is running on and
   update the file RatingDadJokesAPI.Program.cs line 9. 

#