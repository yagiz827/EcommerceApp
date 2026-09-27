# E-Commerce Backend

A **layered ASP.NET Core Web API** for an e-commerce site: user registration and login with **JWT** authentication, a product catalogue, and a shopping cart kept in **Redis**. Orders and persistent data are stored in **SQL Server** through Entity Framework Core.

> A learning project (2022) focused on clean layering, authentication and caching. Some features are still prototypes; for example, the cart endpoints use a fixed demo user.

## Architecture

The solution is split into layers, each with its own project:

```
Ecommerce (Web API)     → controllers, Swagger, JWT setup, Redis connection
   ↓
Bussiness               → services / business rules (users, products, orders, cart)
   ↓
DataAccessLayer         → EF Core repositories (DAL interfaces + EF implementations)
   ↓
Entities                → domain models (User, Product, Category, Order, ProductBasket…) and DTOs
Core                    → shared building blocks: generic repository, Result types, password hashing
```

## Features

- **Authentication:** register and log in with **HMAC-SHA512 password hashing with a per-user salt**; issues **JWT** bearer tokens
- **Shopping cart in Redis** (StackExchange.Redis), so cart reads and writes don't hit the SQL database
- **Checkout:** turns the cart into an order
- **Generic repository pattern** (`IEntityRepository<T>` / `EfEntityRepository`) and a **Result pattern** (`SuccessDataResult` / `ErrorDataResult`) for consistent responses
- **Swagger UI** for exploring the API

## API

| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/User/Register` | Create a user account |
| `POST` | `/api/User/Login` | Log in and receive a JWT |
| `POST` | `/api/User/addToCart` | Add a product to the cart (Redis) |
| `GET` | `/api/User/ShowTheCart` | Show the cart |
| `GET` | `/api/User/BuyTheCart` | Check out the cart |

## Built with

C# · .NET 6 · ASP.NET Core Web API · Entity Framework Core · SQL Server (LocalDB) · Redis · JWT · Swagger

## Running

1. Start Redis on `localhost:6379`, for example with `docker run -p 6379:6379 redis`.
2. Update the SQL Server connection string in `DataAccessLayer/Concrete/Database.cs` for your machine.
3. Open `EcommerceApp.sln` in Visual Studio, set **Ecommerce** as the startup project and run it. Swagger opens in the browser.
