Connection string located in `appsettings.json`
Default is:
```
"Default": "server=localhost;user=root;password=Root-7416;database=ciatecnica"
```
**root@localhost problem**, editing the user's password:
```
ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'Root-7416';
FLUSH PRIVILEGES;
```

**Applying the migrations to create the database:**
```
dotnet ef database update
```

**Running the application:**
```
dotnet run
```
