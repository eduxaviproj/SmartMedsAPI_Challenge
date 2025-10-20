# SmartMedsAPI-Challenge

API REST simples (em .NET 8 + EF Core + SQLite) para gerir medicamentos.

## Requisitos do desafio (cobertos)
- GET /api/medications` – lista medicamentos  
- POST /api/medications` – cria medicamento (`Quantity > 0`)  
- DELETE /api/medications/{id}` – remove por Id  
- Properties: `Name`, `Quantity`, `CreatedAt`  
- 1 teste unitário de exemplo

## Como correr
--bash--
dotnet restore
dotnet ef database update   # cria a BD via migrations
dotnet run
