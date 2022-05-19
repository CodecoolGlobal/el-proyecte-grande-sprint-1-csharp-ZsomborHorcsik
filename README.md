# ProMan

# Description

This project is a web based movie database with capabilities of users writing comments, reviews and creating collections of movies for themselves and then share it amogst other users. The data on the site comes from IMDBApi. This is a 5 sprint project, and the site is still in development. Please do check roadmap for further details.

## Technologies used 

- ASP.Net
- React
- Entity Framework with MSSQL
- Tailwind CSS
- Material Tailwind

## Requirements

- .Net 6.0
- Visual Studio IDEA
- Microsoft SQL server management studio 18.0
- Node 16/17/18


## How to run

To test or use the site, first you need to install Visual Studio and .net 6.0. The project solution will include all the dependencies for the idea. The backend logic functions as a REST Api, you can start up the server from visual studio. The front end can be run by opening up visual studio code, or any choosen idea, you need to have node 16 or above installed to be able to run the site and install all npm dependencies. Open up a terminal in your chosen idea, and type npm install, to install all dependencies automatically, they are included with the project. after that a npm start should run your server for the frontend. RUN THE SITE ONLY IN CHROME. Mozilla has a strict policy on how it looks up localhost server proxys, and the front end wont load the data properly.

## Roadmap(Sprint 3 Currently)

- user login and registration with authentication (Sprint 4)
- user levels such as admin, premium, normal membership with different actions (Sprint 4)
- Create personal collection of movies & share to others (Sprint 4)
- Create personaliezed recommendations based on user activity (Sprint 5)
- Deploy to project to docker & to heroku (Sprint 5)