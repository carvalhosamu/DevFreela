<h1> Dev Freela </h1>

Projeto desenvolvido no curso .net direto ministrado pelo LuizDev.net ao ponto com o objetivo de fixar as seguintes tecnologias :

<ul>
<li>ASP.NET core</li>
<li>SQL Server</li>
<li>CQRS com MediatR</li>
<li>Validações com Fluent Validations</li>
<li>Swagger</li>
<li>JWT</li>
</ul>

<h3>Comando para gerar migrations</h3>
o path do terminal deverá estar na pasta da class library do repositório:

01 dotnet ef migrations add FirstMigration -s ..\DevFreela.API\DevFreela.API.csproj -o .\Persistentece\Migrations <br/>
02 dotnet ef database update -s  ..\DevFreela.API\DevFreela.API.csproj


