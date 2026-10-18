# Skill 02 — Conexión SQL Server

Estado del instructivo: COMPLETO. Ejecución: BLOQUEADA hasta autorización del documento 02.

## Objetivo y requisitos
Validar únicamente la conexión de la aplicación existente con SQL Server, sin implementar CRUD. Requiere árbol real confirmado y autorización expresa del estudiante para esta etapa.

## Procedimiento autorizado futuro
1. Leer AGENTS, MEMORY, ESTADO_DOCUMENTOS y database/CONEXION_DATABASE.md. Preferir CMD; no usar PowerShell mientras CMD esté disponible.
2. Confirmar con el estudiante instancia, base real, autenticación y entorno. No suponer instalación, Docker, credenciales ni disponibilidad del servicio.
3. Inspeccionar la configuración y Datos/ConexionDatos.cs antes de proponer cambios. Reutilizar la estructura existente, System.Data.SqlClient y .NET Framework; conservar diseños.
4. Mantener acceso SQL en Datos. Guardar contraseñas fuera del repositorio, de acuerdo con el mecanismo existente de variable de entorno. No imprimir secretos ni cadenas con contraseña.
5. Si se autorizan cambios, explicar cada ajuste con comentarios didácticos y POO básica. Liberar SqlConnection mediante using y manejar errores con try-catch. No introducir consultas concatenadas; las futuras consultas con valores deben ser parametrizadas.
6. Probar apertura y cierre de conexión únicamente en el entorno confirmado y autorizado. Registrar éxito solo con evidencia real; ante error, registrar el resultado sin secretos y resolver dentro del alcance autorizado.
7. No ejecutar database/01_Backup_Base_Datos.sql automáticamente. Antes de un respaldo confirmar base, ruta del servidor y autorización específica.
8. Actualizar MD con resultados comprobados, mostrar evidencia y preguntar antes de continuar. CRUD permanece bloqueado hasta su autorización.

## Criterio de cierre
Conexión abierta y cerrada con resultado observado, configuración explicada sin secretos y conformidad del estudiante. Si no se ejecutó la prueba, mantener estado SIN VERIFICAR.

## Estado comprobado
Existe código de conexión en Datos/ConexionDatos.cs. No se comprobó una instancia ni se abrió una conexión en esta preparación.
