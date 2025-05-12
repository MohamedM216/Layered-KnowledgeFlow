## Project Structure

```
KnowledgeFlow/
├── KnowledgeFlowApi/ (Presentation)
│   ├── Controllers/
│   ├── Program.cs
│   └── appsettings.json
├── KnowledgeFlowApi.Application/
│   ├── Services/
│   ├── Interfaces/
│   ├── Models/ (DTOs)
│   └── Enums/
├── KnowledgeFlowApi.Infrastructure/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Entities/
│   ├── Repositories/
│   └── Interfaces/
└── KnowledgeFlow.sln
```