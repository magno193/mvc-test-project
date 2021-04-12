Connection string is located in `appsettings.json`
<br>
**Default connection is:**

```
"Default": "server=localhost;user=root;password=Root-7416;database=ciatecnica"
```
**root@localhost problem**, editing the user's password:
```
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'Root-7416';
FLUSH PRIVILEGES;
```
<hr>
<br>


> ⚠️ First you need to apply the migrations!
> --

<br>

**Applying the migrations to create the database**:
```
dotnet ef database update
```
<hr>
<br>


> ✨ Then you can run the application
> --

<br>

**Running the application**:
```
dotnet run
```
**or** (with watch):
```
dotnet watch run -p Ciatecnica.csproj
```
<hr>
