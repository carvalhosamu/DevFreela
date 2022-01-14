<h3>comando para gerar migrations</h3>
o path do terminal deverá estar na pasta da class library do repositório

01 dotnet ef migrations add FirstMigration -s ..\DevFreela.API\DevFreela.API.csproj -o .\Persistentece\Migrations 
02 dotnet ef database update -s  ..\DevFreela.API\DevFreela.API.csproj


