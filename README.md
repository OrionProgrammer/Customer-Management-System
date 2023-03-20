# README #

### Customer Management System ###

.Net 6.0 Blazor Web App and .Net Core 6.0 API

### Features ###

* .Net 6.0
* C#
* SQLite Database
* ASP.Net Core API
* Blazore Web App
* Razor Components
* Layered Architecture
* Exception Handling Middleware
* Visual Studio 2022
* Entity Framework Core
* Concurreny Check applied on EF fields
* SOLID Principles (Dependancy Injection, Single Resposibility, Interface Segregation)
* Respository Pattern + Generic Repository
* Asynchronous Tasks
* Unit of Work
* Swagger UI Documentation
* CRUD for Customer Details Domain


### How do I get set up? ###

#### The solution consists of the following projects ####

1.	Customer.API
2.	Customer.Domain
3.	Customer.Model
4.	Customer.Repository
5.	Customer.UI

#### Configuration ####

1.	Copy the clone link from this repo.
2.	Open Visual Studio Code or Visual Studio Professionl/Enterprise
3.	Click on clone repository and past the link. Alternatively, you may open Powershell and navigate to your projects folder. Then type `git clone CloneUrl` or right click, and your command pallete will automatically paste the link for you.

#### Dependencies
Visual Studio Community/Professional/Enterprise will automatically import dependecies required by the solution.

### Running the Projects

#### API
Open a new console and navigate to the Customer.API folder. Type 'dotnet run'

#### Blazor Web App
Open a new console and navigate to the Customer.UI folder. Type 'dotnet run'

#### Note
Make sure the APIBaseUrl is pointing to your localhost API Url. The setting to update is in the appSettings.json file, within the Customer.UI project

### Who do I talk to? ###

* email asheenk@gmail.com for further assistance
