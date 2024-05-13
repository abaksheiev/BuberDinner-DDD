dotnet user-secrets set --project .\BS.Api\ "JwtSettings:Secret" "94ba0730-d5d2-4c16-abdd-1d2c18763150"

dotnet user-secrets list --project .\BS.Api\


 dotnet tool install --global  dotnet-ef

 dotnet-ef migrations add InitialCreate -p ./BS.Infrastructure -s ./BS.Api

 
 dotnet-ef database update InitialCreate -p ./BS.Infrastructure -s ./BS.Api