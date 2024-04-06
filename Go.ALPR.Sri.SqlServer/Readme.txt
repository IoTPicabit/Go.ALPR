 Pasos a seguir: 
   - (Solo la primera vez) Necesitarás tener instalada la herramienta (dotnet tool install dotnet-ef --global   o  Install-Package Microsoft.EntityFrameworkCore.Tools)
   - Eliminar carpeta Entities y el archivo "SRIDbContext.cs" si existen.
   - Excluir del proyecto la clase "SRIDbContext.Partial.cs" y la carpeta "Entities.Extensions" si existen.
   - Recompilar el proyecto de "Go.ALPR.Sri.SqlServer" en exclusiva.
   - Lanzar el comando en la consola de nuget o en PMC(Package Manegement Console - Consola del administrador de paquetes --> Herramientas > Administrador de paquetes Nuget -> ...) desde Visual Studio.
   - Luego hay que modificar el namespace del "SRIDbContext.cs" para que cuadre con el que debe.
   - Tambien hay que eliminar el método "OnConfiguring(DbContextOptionsBuilder optionsBuilder)".
   - Re-enganchar al proyecto la clase "SRIDbContext.Partial.cs" y la carpeta "Entities.Extensions" si existen.

Consola:
dotnet ef dbcontext scaffold "Server=(LocalDB)\MSSQLLocalDB;Database=SRI;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -c SRIDbContext --data-annotations --output-dir "Entities" --context-dir "./"

PMC:(Asegurarse que el Proyecto Predeterminado es el proyecto destino de las entidades)
Scaffold-DbContext "Server=(LocalDB)\MSSQLLocalDB;Database=SRI;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Context "SRIDbContext" -DataAnnotations -ContextDir "./"  -OutputDir "Entities"