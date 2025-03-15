📂 Full Clean Architecture Solution Structure

/MyWebAPI.Solution
├── MyWebAPI.Api/            # ✅ API (Presentation Layer)
│   ├── Controllers/         # Controllers (API Endpoints)
│   ├── Middlewares/         # Custom Middleware
│   ├── Filters/             # Action Filters (optional)
│   ├── DependencyInjection/ # Service registration
│   ├── Program.cs           # Main entry point (startup)
│   ├── appsettings.json     # Configuration file
│
├── MyWebAPI.Application/    # ✅ Business Logic Layer
│   ├── Interfaces/          # Service & Repository Interfaces
│   ├── Services/            # Business Logic Services
│   ├── DTOs/                # Data Transfer Objects
│   ├── UseCases/            # CQRS Handlers (Optional)
│   ├── Validators/          # FluentValidation classes
│
├── MyWebAPI.Domain/         # ✅ Domain Layer (Entities & Core Logic)
│   ├── Entities/            # EF Core Models (User.cs, Order.cs)
│   ├── Enums/               # Enum definitions
│   ├── Exceptions/          # Custom exceptions
│   ├── ValueObjects/        # Value objects for domain modeling
│
├── MyWebAPI.Infrastructure/ # ✅ Infrastructure Layer (Persistence & External Services)
│   ├── Data/                # EF Core DBContext & Migrations
│   ├── Repository/          # Repository pattern for data access
│   ├── Services/            # External service integrations (e.g., Email, Redis, etc.)
│
├── MyWebAPI.Tests/          # ✅ Unit & Integration Tests
│   ├── ApiTests/            # API Integration tests
│   ├── ApplicationTests/    # Business logic tests
│   ├── InfrastructureTests/ # Database tests
│   ├── TestBase.cs          # Common test setup
│
├── MyWebAPI.sln             # ✅ Solution file
└── README.md                # Documentation