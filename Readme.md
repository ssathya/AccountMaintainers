
# .Net Core and Angular application

This project is a reproduction of a series of articles that I found at [Code Maze](https://code-maze.com/net-core-web-development-part1/). The project is implemented in multiple parts and each part is summarized below.

## Part 1
In this part the author ([Marinko Spasojevic](https://code-maze.com/author/marinko/ "Posts by Marinko Spasojevic")) discusses in setting up MySQL database that is going to be used with this application. I'm not going to use MySQL for this project but will be using SQL Server and hence will be skipping this section.
## Part2
We are going to create the project and set up the basic wiring for the API server.  After creating the project we did minor changes in launch.json to use port 5000 in development environment. 

We also create a handful of helper methods for configuring

 - CORS
 - IIS

For now only these two but will eventually add a bunch more helper methods.
We also update Startup.cs to use the helper methods.
## Part3

In this section we create two new projects,  Contracts and LoggerService. 
Contracts hold all the application level interfaces and individual services (such as Logger Service for now) will implement the interface(s). We then register the logger service with the main application via Dependency injection. 
We also test the logger service by changing the Values Controller - auto generated code which is a throw away when we complete the solution. 

## Part 4
Now that we have a feel how we are going to implement the application let's start with the data model and repository pattern that we'll use to access the database. 
We create the Account and Owners model and DbContext class that will link our models to the database. We then create repository patterns that will abstract all  (CRUD) our database operations. 

## Part 5
We now proceed to work on business logic; i.e. we'll start with the controllers. As the application evolves we might be tempted to move certain database logics to controllers. We'll keep all database logic inside the repository classes and controllers will be responsible for handling requests, model validation and returning responses to the frontend part of the application.

  

In this section we implement the owner controller and as it is built we update the repository logic to serve the controller.

*Until now the repository pattern logic is built using synchronous calls and the application suffers from performance issues with less than 10 records (did not index the database to illustrate this). We'll eventually modify them to use asynchronous calls but for the time being live with synchronous calls.*
