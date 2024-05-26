# GO_05242024

## Introduction
This repository contains 2 applications:
1. Angular Frontend (found under the .\Frontend folder) - written in Angular 17 with Bootstrap and Toastr elements, this serves as the UI of the system.
2. .Net Minimal API Backend (found under the .\API folder) - written in .Net 8, this is structured using Clean Architecture and uses an EntityFramework In Memory database for persistence. The following endpoints are exposed for consumption by the Angular app:
   - GET /api/items (retrieve all items),
   - GET /api/items/{id} (retrieve an item by ID).
   - POST /api/items/ (create an item).
   - PUT /api/items/{id} (update an item by ID)

## Build and Setup

### Prerequisites
  - NodeJS for NPM (https://nodejs.org/en)
  - .Net Core 8 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
  - Angular 17 (installed via NPM - npm install -g @angular/cli)
  - VS Studio or VS Code
  - Docker desktop for setup using containers

### Containerless Build and Setup
#### Angular
  - Using the command line navigate to the Frontend folder of the repository.
  - Run the ```ng serve --port 16000``` command. Make sure the port is 16000 or 4200 as these are the only ports that the API will recognize for CORS.
  - Navigate to localhost:4200 (depending on the port selected above) to access the UI.
    ![image](https://github.com/WesleyGo/GO_05242024/assets/8520424/bc3b9555-0bb5-4e6b-a15f-7e50be12a0c6)

#### API
  - In VS Code or VS Studio, open the API folder or open the API.sln under the API folder. Please do note that the port should be set to 16001 as it is the port that the Angular app will look for. This can be done by modifying the launchSettings.json file.
  - Rebuild and run the solution. The swagger UI should show indicating a successful build. Please do note that trying out the API will not work in Swagger as it needs the X-API-Key header to access the endpoints.
    ![image](https://github.com/WesleyGo/GO_05242024/assets/8520424/e7361fe8-ccf9-46b8-b28c-a4327f90a5c8)

## Setup using containers
  - Using the docker cli, run this command on the root folder of the repository:
    ```
    docker compose up -d.
    ```
    After the build is done, the following should be seen in Docker Desktop.
    ![image](https://github.com/WesleyGo/GO_05242024/assets/8520424/820796de-97d1-4b29-84e7-db7353c70acd)
  - The Angular app can then be accessed via http://localhost:16000.

## Testing the API
  - The API is secured via a API key header. The header must have a header called X-API-Key which should have a value of 'my-api-key'. To test this, you can use curl to access the site like so:
    ```
    curl --location 'http://localhost:16001/api/items' \--header 'X-API-Key: my-api-key'
    ```
    or via postman
    ![image](https://github.com/WesleyGo/GO_05242024/assets/8520424/a02ce662-b572-4aed-8897-e0fc3b0b2496)

## Constraints and Limitations
  - No tests were written for this, but the architecture is designed to be testable via dependency injection.
  - No secret management was done. As such some sensitive information like the API key is hardcoded on the app itself.


    
