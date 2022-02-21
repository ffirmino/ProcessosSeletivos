REM Packages
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools

REM Package Manager Console
Scaffold-DbContext "Server=(localdb)\\MSSQLLocalDB11;Database=teste_webmotors;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBContext -Context "DbContextWebmotors" -Tables dbo.tb_AnuncioWebmotors -Force

REM Command Line
dotnet ef dbcontext scaffold "Server=(localdb)\\MSSQLLocalDB11;Database=teste_webmotors;Integrated Security=true;" Microsoft.EntityFrameworkCore.SqlServer -o DBContext -c "DbContextWebmotors" -t dbo.tb_AnuncioWebmotors -v -f
