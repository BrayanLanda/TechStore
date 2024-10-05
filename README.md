# Proyecto API de Gestión (Customer, Orders, Products)

Este proyecto es una API construida con **ASP.NET Core**, utilizando una arquitectura basada en **repositorios** y **servicios** para manejar la lógica de negocio. El proyecto incluye la gestión de **usuarios**, **clientes**, **pedidos**, **productos**, y **categorías**. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y maneja conexiones con una base de datos utilizando **Entity Framework Core**.

## Requisitos

- [.NET 6.0 SDK o superior](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL](https://www.mysql.com/downloads/)
- [Visual Studio 2022 o Visual Studio Code](https://visualstudio.microsoft.com/)
- [Postman (para probar la API)](https://www.postman.com/)

## Instalación

### 1. Clona el repositorio

```bash
git clone https://github.com/BrayanLanda/TechStore.git
cd TechStore 
```

### 2. Instalar paquetes NuGet
Ejecuta el siguiente comando para instalar las dependencias necesarias si aún no las tienes instaladas:

```bash
dotnet restore
```

- DotNetEnv
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.IdentityModel.Tokens
- System.IdentityModel.Tokens.Jwt
- System.Security.Cryptography.Algorithms
- Pomelo.EntityFrameworkCore.MySql
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore.Annotations
- Swashbuckle.AspNetCore
- Microsoft.VisualStudio.Web.CodeGeneration.Design

### 3. Configurar la Base de Datos
Este proyecto utiliza Entity Framework Core para la interacción con la base de datos. Ejecuta las migraciones para configurar la base de datos:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Ejecutar la API
Puedes ejecutar la API utilizando el siguiente comando:

```bash
dotnet run 
dotbet watch run
```

La API estará disponible en https://localhost:5001 (o el puerto que esté configurado).

### 5. Probar la API
Puedes probar la API utilizando herramientas como Postman o directamente desde Swagger. Swagger estará disponible en la siguiente URL una vez que inicies el proyecto:

https://localhost:5001/swagger (o el puerto que esté configurado)

## 6 Funcionalidades principales

### Usuarios (Users)
- Obtener todos los usuarios
- Obtener un usuario por correo electrónico
- Crear, actualizar y eliminar usuarios
- Autenticación con JWT

### Clientes (Customers)
- Obtener todos los clientes
- Obtener cliente por email
- Crear, actualizar y eliminar clientes

### Pedidos (Orders)
- Obtener todos los pedidos
- Obtener pedidos por estado o por cliente
- Crear, actualizar y eliminar pedidos

### Productos (Products)
- Obtener todos los productos
- Obtener productos por categoría
- Crear, actualizar y eliminar productos

### Categorías (Categories)
- Obtener todas las categorías
- Crear, actualizar y eliminar categorías




