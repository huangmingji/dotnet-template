# dotnet-template

dotnet project template

## __运行环境__

* .NET6
* postgresql

## __生成数据库迁移代码__  

```bash
 # dotnet ef migrations add InitialCreate
 # https://docs.microsoft.com/zh-cn/ef/core/get-started/netcore/new-db-sqlite
 dotnet ef migrations add <name>
```

## __更新数据库__  

```bash
 dotnet ef database update
```
