Howto Scaffold ExceptionDb

- Set Startup Project to "Data" (Temp)
- Open Package Management Console 
-  Set Default Project : "Data"
- Execute following command


Scaffold-DbContext -Connection "Data Source=.;Initial Catalog=EsbExceptionDb;Integrated Security=True" -Provider Microsoft.EntityFrameworkCore.SqlServer -ContextDir "Context" -OutputDir "Entities" -Force