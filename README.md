# IconAssessment
An online tool to check the price of parcels before making orders.

AUTHOR - Uche Igbokwe

Application was built using clean architecture, CQRS and SOLID principles.

## DEPENDENCIES/PREREQUISITIES

* .NET 6.0
* Aurelia Framework
* Typescript
* NodeJs 
* Mediator
* Domain Driven Design
* Repository Pattern
* XUnit
* Ensure port 8000, 5122 and 8080 are available

## SETUP

> **Note**: Begin by cloning the project and navigate into the IconAssessment folder. Ensure to have .NET 6, NodeJs v10 or above running on your device.

# START PROJECT VIA DOCKER:
Navigate to the root folder and run the command.
```
docker compose up 
```
The page comes up on, the submit button is responsible for authenticating the user
```
http://localhost:8080/
```
Due to minor setback, after clicking the submit button, manually enter the URL below
```
http://localhost:8080/#/welcome
```
  * Click the submit button to get token and automatically navigate to the Price Details page.
  * When you fill in the required data, it populates the best available price rate.


# START PROJECT MANUALLY:
To startup the API project, follow these steps:

* Navigate to the [API](src/API) project folder
```
cd src/API
```
```
dotnet build
```
* Run the command below and listen on https://localhost:8000/swagger:
```
dotnet run
```

To run the test, follow these steps:

* Navigate to the [Tests](src/Tests) project folder
```
cd src/Tests
```
```
dotnet build
```
```
dotnet run
```
To startup the CLIENT project, follow these steps:

> **Note**:  
Run `npm install -g aurelia-cli` on any CLI. [SETUP](https://aurelia.io/docs/tutorials/creating-a-todo-app#setup)

* Navigate to the [client](client) project folder
```
cd client
```
* Run the code below to install dependencies.
```
npm install
```
* Startup the CLIENT project
```
npm start
```

* To start the project.
```
http://localhost:8080/
```
  * Click the submit button to get token and automatically navigate to the Price Details page.
  * When you fill in the required data, it populates the best available price rate.



Incase of blockers, kindly contact me via: uchehenryigbokwe@gmail.com.

