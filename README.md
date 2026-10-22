# Sistema de gestión de pagos y gastos

API REST en **ASP.NET Core 8** con autenticación JWT y control de acceso por roles, más un **cliente web MVC** que la consume por HTTP. Proyecto académico (ORT Uruguay).

## Estructura del repositorio
| Carpeta | Contenido |
|---|---|
| `API/` | API REST, lógica en capas y una aplicación web MVC propia |
| `Cliente/` | Cliente web MVC que consume la API con `HttpClient` y guarda el token JWT en sesión |

## Tecnologías
- C#, ASP.NET Core 8 (Web API y MVC)
- Entity Framework Core 8 con SQL Server (Code First y migraciones)
- Autenticación con JWT y roles
- Contraseñas hasheadas con BCrypt
- Swagger para documentar la API
- JavaScript para validaciones del lado del cliente
- Desplegado en Azure App Service durante el curso

## Arquitectura de la API (`API/`)
| Proyecto | Responsabilidad |
|---|---|
| `Obligatorio.LogicaNegocio` | Entidades, reglas de negocio y excepciones propias |
| `Obligatorio.LogicaAplicacion` | Casos de uso |
| `Obligatorio.LogicaAccesoDatos` | DbContext, repositorios y migraciones |
| `Obligatorio.DTOs` | DTOs y mappers |
| `Obligatorio.Utilidades` | Utilidades compartidas |
| `Obligatorio.WebAPI` | API REST |
| `Obligatorio.WebApp` | Aplicación web MVC |

## Funcionalidades
- Login con JWT y cambio de contraseña
- Alta y consulta de pagos (únicos y recurrentes)
- Gestión de tipos de gasto, con auditoría de cambios
- Reportes: pagos por usuario, pagos del mes, equipos con pagos únicos mayores a un monto, usuarios por monto de pago
- Vistas del cliente restringidas por rol (administrador, gerente y empleado)

## Cómo ejecutarlo
Requisitos: .NET 8 SDK y SQL Server (LocalDB o Azure SQL).

### 1. API
Desde la carpeta `API/Obligatorio.WebAPI`:

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<cadena de conexión>"
dotnet user-secrets set "Jwt:Key" "<clave aleatoria de al menos 64 caracteres>"
dotnet ef database update --project ../Obligatorio.LogicaAccesoDatos --startup-project .
dotnet run --launch-profile https
```

La API queda en `https://localhost:7080` y la documentación en `/swagger`.

### 2. Cliente
Desde la carpeta `Cliente`, verificá que `ApiBaseUrl` en `appsettings.json` apunte a tu API (por defecto `https://localhost:7080/api/`) y ejecutá:

```bash
dotnet run
```

Las migraciones crean el esquema pero no cargan datos iniciales: hace falta insertar roles, usuarios y datos base para poder iniciar sesión.

## Autora
Valentina Mazzulla
