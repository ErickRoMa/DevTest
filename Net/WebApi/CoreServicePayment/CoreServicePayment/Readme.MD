##  Technical Spec
# Dependencies
   * Framework: netcoreapp7.0
   * This project use Swagger with 'Swashbuckle.AspNetCore' package
        * [Swagger-Docs](https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=netcore-cli)
        * This configuration was included at Startup file.
   * Added .gitignore
   * Create Https Certificate:
        * dotnet dev-certs https --trust
# How run:    
    * Commands available to execute project:
        * Restore dependencies :  dotnet build    
        * Clean dependencies:  dotnet clean 
        * Execute project:  dotnet build
            * After run Follow Link : [Localhost](https://localhost:5001)