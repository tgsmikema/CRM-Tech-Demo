## Project Overview

In this Tech demo, the main theme is a simple customer relationship management app, to track customer information, add new customers and delete customers. Also, there are two levels of login system, the Admin and User, who can both view customer information but Admin has the ability to view all customers in the database while Users can only view the customers that was created by him/her. Admin can also register another admin account but user does not have the ability to do so.

This tech demo consists two parts for the app to work together, the backend server side that handles data processing and authentication, which is written in C# with .NET framework, and the simple frontend renders the pages and calls API from the server is written in React with Vite.

### How to run Backend:

1) download DOTNET 6 SDK if you don't have it on your local machine from https://dotnet.microsoft.com/en-us/download and follow instruction to install it onto your local machine.

2) After the installation of DOTNET SDK, navigate from the root folder to: `…/backend/CustomerRelationManager/`

3) Open a command line terminal here, and enter the following command: `dotnet run`

4) The project is going to build and run in this terminal, don't worry about the yellow warning text, once the build is done, the backend is started and running.

optional) The default ports for the backend is https://localhost:8080 or http://localhost:8081 (note the first one is https and second one is http, by default we use the first port with https.). If the port number is in clash with other ports on your machine, you can change this setting from this file located at `…/backend/CustomerRelationManager/Properties/launchSettings.json`. Modify line 17, change the port number from 8080 to other port number as you like. If you have made this change, be sure to save this file and build the project again refer to step 3 above.

optional) Once the server is running, you can also test it's functionalities on swagger interface at: `https://localhost:8080/swagger/index.html`

### How to run Frontend:

1) make sure that you have 'node package manager' installed on your local machine.

2) navigate from the root folder to: `…/frontend/CrmFrontend/` , create a new `.env` file and add a single line `VITE_API_BASE_URL=https://localhost:8080` into the file. This will make sure that the frontend application can successfully communicate with the backend server. (note: if you have changed the port number from 8080 to anything else in the backend setup steps, you have to change this port number accordingly as well).

3) open a new command line terminal in this directory mentioned in the step 2, enter the following command `npm install` to install all dependencies.

4) then enter `npm run dev` to start the frontend server.

5) in your local browser, navigate to `http:localhost:5173/` to start browsing!
