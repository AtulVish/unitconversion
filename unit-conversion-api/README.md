#  Unit Conversion API

A clean and scalable **.NET 8 Web API** for converting units across different categories like Length, Weight, and Temperature.

---

##  Features

- Convert units (e.g., km → m, kg → lb)
- Supports:
  -  Length
  -  Weight
  -  Temperature (Celsius, Fahrenheit, Kelvin)
- Clean service-based architecture
- Swagger UI for API testing
- Unit tests with passing results 

---

##  Tech Stack

- .NET 8 Web API
- C#
- ASP.NET Core
- Swagger (Swashbuckle)
- xUnit / MSTest (depending on your test project)

---

##  Project Structure
unit-conversion-api/
│
├── src/
│   └── UnitConversion.Api/
│       ├── Controllers/
│       ├── Models/
│       ├── Services/
│       │   ├── IUnitConversionService.cs
│       │   ├── UnitConversionService.cs
│       │   └── UnitDefinitions.cs
│       ├── Properties/
│       ├── appsettings.json
│       ├── appsettings.Development.json
│       ├── Program.cs
│       └── UnitConversion.Api.csproj
│
├── tests/
│   └── UnitConversion.Tests/
│       ├── UnitConversionServiceTests.cs
│       └── UnitConversion.Tests.csproj
│
├── README.md

---

## How to Run the API

### 1. Clone repository

bash
git clone <your-repo-url>
cd unit-conversion-api

dotnet run --project src/UnitConversion.Api

https://localhost:<port>/swagger

dotnet test

https://localhost:<port>
# Convert Length
# Request
GET /convert?value=10&from=km&to=m
# Response
{
  "value": 10,
  "from": "km",
  "to": "m",
  "result": 10000
}


# Convert Temperature
# Request
GET /convert?value=300&from=k&to=c
# Response
{
  "value": 300,
  "from": "k",
  "to": "c",
  "result": 26.85
}

---

#  Final Result

-  Clean structure documentation  
-  API examples  
-  Error handling  
-  Test coverage  
-  Fully production-style README  