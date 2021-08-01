# Movie API
API to manage movies and viewers with C# and ASP.NET Core Web API

#### Class Diagram
![Class Diagram](https://i.postimg.cc/WzDRhDGF/movies-api-3.png)



### Start application

#### Como iniciar essa aplicação

Para iniciar essa aplicação, você precisa primeiramente, criar um arquivo chamado **.env** e adicionar valores para as seguintes variáveis:

`SQL_SERVER_ADDRESS=`
`SQL_CATALOG=MovieDb`
`SQL_USER_ID=`
`SQL_PASSWORD=`
`SQL_PID=Express`
`SQLPAD_ADMIN=`
`SQLPAD_ADMIN_PASSWORD=`
`SQLPAD_CONNECTIONS__sqlserverdemo__name=SQL Server Dev` 

Valores sugeridos para as variáveis são:
* localhost - para a variável `SQL_SERVER_ADDRESS` que é o nome do servidor de banco de dados onde o banco de dados da aplicação está rodando, nesta aplicação de exemplo, o banco se encontra em um container do Docker;
* MovieDB - para a variável `SQL_CATALOG` que é o nome do banco de dados;
* `SQL_USER_ID` nome do usuário de banco de dados;
* `SQL_PASSWORD` senha do banco de dados, recomendamos usar uma senha forte, com caracteres especiais, letras maiusculas, letras minúsculas e números;
* `SQLPAD_ADMIN` e `SQLPAD_ADMIN_PASSWORD` são login e senha utilizados pelo SQL Pad, aplicação utilizada para visualizar o banco de dados;

Após modificar os valores das variáveis, você deve rodar o comando do Docker para iniciar a criação e instância dos contêineres do Docker. Para isso, utilize o seguinte comando:

`docker-compose up -d`

Após os containeres serem iniciados, você terá os seguintes endereços disponíveis:

* `localhost:1433` - para o banco de dados SQL Server;
* `http://localhost:3011` - para o SQL Pad, onde você poderá navegar pelo banco de dados e visualizar as tabelas; 



#### Subir a aplicação
Abra o arquivo de solução do projeto (arquivo **MoviesApi.sln**) no Visual Studio, depois, vá na opção **Build** em seguida **Build Solution**. Após isso, inicie a aplicação com a tecla de atalho **CTRL + F5**.

Após isso, a aplicação será iniciada no navegador e abrirá o endereço:
* `http://localhost:5000/swagger/ui/index.html`



#### Visualizar o banco de dados

Acesse o endereço: `http://localhost:3011` insira o login e senha que estão no arquivo **.env** na pasta raiz da aplicação.

![movies-api-1.png](https://i.postimg.cc/63bJWVvx/movies-api-1.png)

Em seguida, insira os dados necessários para criar a coneção com o banco de dados SQL Server:
![movies-api-2.png](https://i.postimg.cc/hjtRRZh0/movies-api-2.png)