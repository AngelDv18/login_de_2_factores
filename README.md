# Sistema de Login con Autenticación en Dos Factores (2FA)

Este proyecto es una aplicación desarrollada en .NET MAUI con soporte para Android, que implementa un sistema de inicio de sesión seguro mediante autenticación en dos pasos.

## Descripción del Proyecto

El sistema permite a los usuarios iniciar sesión utilizando su **usuario o correo electrónico** junto con una **contraseña**. Una vez autenticado el primer paso, se envía un **código de 6 dígitos al correo electrónico del usuario**, el cual debe ser ingresado para completar el acceso a la plataforma.

Solo después de validar este segundo paso, el usuario es redirigido a su perfil personal.

## Características Principales

- Inicio de sesión con **correo/usuario y contraseña**.
- Envío automático de código de verificación (OTP) de **6 dígitos al email**.
- Pantalla de verificación del código (segundo paso).
- Acceso a plataforma solo si se completa la verificación.
- Visualización del **perfil del usuario**:
  - Nombre completo
  - Correo electrónico
  - Edad
  - Teléfono

## Tecnologías Utilizadas

- Lenguaje: **C#**
- Plataforma: **.NET MAUI**
- Destino: **Android**
- Backend/API: Local o remoto con soporte de envío de correos
- Sistema de envío de correos: SMTP (Gmail recomendado)
- Base de datos: MySQL (puede ser adaptada)

## Estructura General

- `/Views`: Interfaces de Login, Verificación, Perfil
- `/Services`: Lógica para envío de correos y autenticación
- `/Models`: Modelo de usuario
- `/Backend`: (opcional) API para gestionar usuarios, códigos y verificación

## Flujo de Autenticación

1. Usuario ingresa su correo/usuario y contraseña.
2. Si las credenciales son válidas, se genera un código aleatorio de 6 dígitos.
3. El código se envía por correo electrónico al usuario.
4. El usuario debe ingresar el código en la siguiente pantalla.
5. Si el código es correcto y no ha expirado, se accede al perfil del usuario.

## Consideraciones de Seguridad

- Las contraseñas están cifradas en la base de datos.
- El código 2FA tiene tiempo de expiración.
- Se bloquea el acceso tras múltiples intentos fallidos.

## 👤 Autor

Desarrollado por: **AngelDv**  
GitHub: [https://github.com/AngelDv18](https://github.com/AngelDv18)
