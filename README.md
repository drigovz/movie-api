# Movie API
API to manage movies and viewers with C# and ASP.NET Core Web API

#### Class Diagram
![Class Diagram](https://i.postimg.cc/WzDRhDGF/movies-api-3.png)



### Start application

#### How to start this application

To start this application, you first need to create a file on the root path of application called **.env** and add values for the following variables:

`SQL_SERVER_ADDRESS=`
`SQL_CATALOG=MovieDb`
`SQL_USER_ID=`
`SQL_PASSWORD=`
`SQL_PID=Express`
`SQLPAD_ADMIN=`
`SQLPAD_ADMIN_PASSWORD=`
`SQLPAD_CONNECTIONS__sqlserverdemo__name=SQL Server Dev` 

Suggested values for variables are:
* **localhost** - for the variable `SQL_SERVER_ADDRESS` which is the name of the database server where the application's database is running, in this example, the database is located in a Docker container;
* **MovieDB** - for the variable `SQL_CATALOG`, is the name of database;
* `SQL_USER_ID` user database name;
* `SQL_PASSWORD` password database, we recommend using a strong password, with special characters, uppercase letters, lowercase letters and numbers;
* `SQLPAD_ADMIN` and `SQLPAD_ADMIN_PASSWORD` are login and password used by SQL Pad, application used to view the database;

After modifying the variable values, you must run the Docker command to start creating the Docker containers. To do this, use the following command:

`docker-compose up -d`

After the containers are started, you will have the following addresses available:

* `localhost:1433` - for the SQL Server Database;
* `http://localhost:3011` - for SQL Pad, where you can browse the database and view the tables; 



#### Up the application
Open the project solution file (**MoviesApi.sln**) in Visual Studio, then go to option **Build** then **Build Solution**. After that, start the application with the shortcut key **CTRL + F5**.

The application will start in web browser and open the address:
* `http://localhost:5000/swagger/ui/index.html`



#### View the database

Access the address: `http://localhost:3011` insert the login and password that are in the **.env** file in the root folder of the application.

![movies-api-1.png](https://i.postimg.cc/63bJWVvx/movies-api-1.png)

Then enter the necessary data to create the connection to the SQL Server database:
![movies-api-2.png](https://i.postimg.cc/hjtRRZh0/movies-api-2.png)