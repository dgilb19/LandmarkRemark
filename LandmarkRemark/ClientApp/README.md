# LandmarkRemark



# Overview: 
This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.

inital angular-google-maps (AGM) demo can be found here https://stackblitz.com/edit/angular-google-maps-demo-gi4wnp?file=index.html 

there are some clear limitations to AGM, and in hindsight, Maps JavaScript API would potentially be a better choice. 



1. Backlog
 a. As a user (of the application) I can see my current location on a map.
 b. As a user I can save a short note at my current location.
 c. As a user I can see notes that I have saved at the location they were saved on the map.
 d. As a user I can see the location, text, and user-name of notes other users have saved.
 e. As a user I have the ability to search for a note based on contained text or user-name.
 


2. Technology Stack
The Microsoft.NET Web Application must use .NET Core and function as a Single-Page Application(SPA), leveraging either​ React​ or​ Angular​ front-end
frame works to deliver the user interface. The application is not required to be responsive, but you should document your decision making proces shere either way
Source code must be developed and runnable in ​Microsoft Visual Studio​(2017 or greater) or ​VSCode​.


3.Backendsupport
developing a.NET web application, using Microsoft LocalDb for storage i sacceptable.


4. Support
n/a 

5. Deliverables
See PFD



# Tasks:

Implement map ✔️
Implement get location ✔️
Implement worker to get user location every 5 seconds ✔️
Implement backend. ❌ 
Implement login ❌ 
Implement pin saving to db ❌ 
Implement pin retriving from db ❌ 
Click on user Pin to save location (text pop up) ❌ 
Click on other Pins to view notes (text pop up) ❌ 
Click search icon top right to search Pins ❌ 



# Decisions:
The decision to use Angular Google Maps was made as it fit the requirements of the programming tests. (anaylsis can be seen above in Overview)

Firebase was chosen as a backend service provider as I was already experenced with it and had not used Microsoft LocalDb before.


