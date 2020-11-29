# LandmarkRemark
Project to showcase technical skills for TigerSpike

TimeBoxed to 3.5 hours Saturday 29/11/2020 and 5 hours Sunday 30/11/2020


## Overview: 
This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.

inital angular-google-maps (AGM) demo can be found here https://stackblitz.com/edit/angular-google-maps-demo-gi4wnp?file=index.html 

there are some clear limitations to AGM, and in hindsight, Maps JavaScript API would potentially be a better choice. 

AngularFire was unable to work, citing 'StaticInjectorErrors' meaning I could not utilise the backend I had created.



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



## Tasks:

Implement map ✔️
Implement get location ✔️
Implement worker to get user location every 5 seconds ✔️
Implement backend. ❌ 
Implement login. ❌ 
Implement pin saving to db ❌ 
Implement pin retriving from db ❌ 
Click on user Pin to save location (text pop up) ✔️
Click on other Pins to view notes (text pop up) ✔️ 
Click search icon top right to search Pins ❌ 



## Decisions and Thoughts:
The decision to use Angular Google Maps was made as it fit the requirements of the programming tests. (anaylsis can be seen above in Overview)

Firebase was chosen as a backend service provider as I was already experenced with it and had not used Microsoft LocalDb before.
* In hindsight, firebase was not the correct decision, AngularFire caused issues and did not work in the end, this caused the database side of this project to be redundnat.
AngularFire ate into a lot of time and I was unable to correctly showcase technical skills in regards to DBs and tests.


Bootstrap CSS, SASS, Angular CSS was not used, as it was not included in the backlog, and was deemed out of scope.

Names, accounts, and search functionality were not able to be completed as I ran out of time, and AngularFire was unable to be used.

Test functionality not implemented fully/correctly, inital plan was to create tests for backend functions, but that became obsolete on firebase failure.

I should have placed SRC in LandmarkRemark project instead of in ClientApp.


## Build
This is bound to change based off current installations of Angular.

```bash
cd {project}
cd ClientApp
```

Any version of 8 should work
```bash
npm i @angular/cli@8.0.0-rc.0
```

install dependencies 
 ```bash
 npm install
```

Start it locally
 ```bash
npm start
```



## Test
Tests were not implemented correctly as backend functionality would not work.
```bash
ng test
```
