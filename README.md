# 🎓 Academic Manager

**Academic Manager** es un sistema de gestión académica orientado a la administración de alumnos, inscripciones, cursos, docentes y calificaciones. El proyecto está diseñado aplicando buenas prácticas de arquitectura, separación de responsabilidades y uso de **SQL Server con procedimientos almacenados**.

Este proyecto forma parte de mi portafolio profesional y tiene como objetivo demostrar conocimientos sólidos en **C#**, **.NET**, **SQL Server** y **arquitectura backend**.

---

## 🧠 Descripción general

El sistema permite:

- Gestión de alumnos (crear, actualizar, eliminar).
- Control de estados activos/inactivos.
- Manejo de usuarios y roles.
- Persistencia de datos mediante **Stored Procedures**.
- Control transaccional y manejo de errores desde base de datos.
- Estructura preparada para crecer a módulos académicos completos.

---

## 🏗️ Arquitectura del proyecto

El proyecto sigue una estructura basada en **Clean Architecture**:

AcademicManager
│
├── Domain
│ ├── Entities
│ ├── Enums
│ └── Interfaces
│
├── Application
│ └── Services
│
├── Infrastructure
│ ├── Data
│ └── Repositories
│
├── API
│ └── Controllers
│
└── Tests

### Principios aplicados
- Separación de capas
- Inversión de dependencias
- Dominio independiente de infraestructura
- Repositorios basados en interfaces

---

## 🗄️ Base de datos

- **Motor:** SQL Server  
- **Acceso:** ADO.NET  
- **Autenticación:** SQL Server (`sa` en entorno de desarrollo)  
- **Persistencia:** Stored Procedures  
- **Transacciones:** Controladas desde SP  

### Entidades principales
- Alumno
- Usuario
- Rol
- Estados generales
- Históricos (preparado para auditoría)

---

## ⚙️ Tecnologías utilizadas

- **Lenguaje:** C#
- **Framework:** .NET
- **Base de datos:** SQL Server
- **Acceso a datos:** ADO.NET
- **ORM:** Entity Framework Core (configuración y soporte)
- **Control de versiones:** Git
- **Arquitectura:** Clean Architecture

---

## 🔐 Estados y roles

Estados generales definidos mediante enumeraciones:

```csharp
public enum EstadoGeneral
{
    Inactivo = 0,
    Activo = 1
}
 Roles de usuario:
public enum RolUsuario
{
    Administrador,
    Docente,
    Secretaria
}
Ejecución del proyecto

Clonar el repositorio:
git clone https://github.com/gortiz-dev/AcademicManager.git
Crear la base de datos en SQL Server.

Ejecutar los scripts SQL:

Tablas

Procedimientos almacenados

Triggers (para el historial)

Configurar la cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=db_AcademicManager;User Id=sa;Password=TU_PASSWORD;TrustServerCertificate=True;"
}
Ejecutar el proyecto desde Visual Studio.

🧪 Estado del proyecto

✔ Arquitectura definida

✔ Entidad Alumno implementada

✔ Repositorio con ADO.NET

✔ Conexión a base de datos funcional

🔧 En desarrollo continuo

🎯 Objetivo

Proyecto académico y profesional enfocado en:

Backend con arquitectura limpia

Uso real de SQL Server y Stored Procedures

Preparación para entornos laborales

Buenas prácticas de desarrollo en .NET

👤 Autor

Guillermo López
Estudiante de Ingeniería en Sistemas
Desarrollador Backend en formación
