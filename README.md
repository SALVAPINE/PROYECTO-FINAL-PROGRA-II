# Proyecto Final — Programación II

## Sistema
Cadena de Publicidad Multisucursal

## Curso
Programación II 2026

## Tecnologías
- C# .NET Framework
- Windows Forms
- sqlserver
- Docker
- Git y GitHub
- Agente de IA

## Arquitectura
El sistema utiliza arquitectura por capas:

Presentación -> Negocio -> Datos -> SQL Server

La capa Entidad contiene las clases utilizadas para transportar
la información entre las capas.

## Módulo patrón
Sucursales será desarrollado como ejemplo completo antes de
continuar con los módulos asignados a cada integrante.

## Reglas de trabajo
- Revisar y probar el código generado.
- No publicar credenciales reales.
- Mantener la arquitectura por capas.
- Registrar únicamente resultados verificados en MEMORY.md.
- Cerrar cada ciclo estable con Git y GitHub.

## Requisitos para ejecutar en Windows
- Windows con .NET Framework 4.8 instalado.
- SQL Server accesible desde el equipo donde se ejecuta la aplicación. La configuración actual espera `localhost,1433` y la base `Db_PublicidadMultisucursal`.
- `Presentacion/App.config` configura servidor, base y usuario (`sa`). La contraseña se obtiene de la variable de entorno `PUBLICIDAD_SQL_PASSWORD`; no la guardes en este README ni en GitHub.
- La aplicación compilada y sus DLL están en `Presentacion/bin/Release/net48`. El ZIP local preparado está en `Presentacion/bin/Release/SistemaPublicidad_Release.zip`; extráelo completo y ejecuta `SistemaPublicidad.exe`. La carpeta `bin/` se ignora en Git, así que el ZIP debe compartirse por separado y no está en GitHub.

## Restaurar la base de datos
1. El respaldo `.bak` está en el host, fuera del contenedor Docker: `../../DATABASE/Db_PublicidadMultisucursal_20261014.bak`. Tiene 6.017.024 bytes, última modificación 2026-10-14 11:50:25 y SHA-256 `ad6075039b5c4a1e31e5587f86bf79b80ba50d3704b538a7c7672bbc64ff510e`. `DATABASE/` está fuera de este repositorio Git; el respaldo no está en GitHub.
2. En SQL Server Management Studio, restaura el archivo como `Db_PublicidadMultisucursal`. El respaldo es del 14/10/2026 y es anterior a la tabla `dbo.Tbl_RolAccesos`.
3. Ejecuta el script local `../../DATABASE/06_Login_Roles.sql` en esa base para crear la tabla de permisos y sus valores iniciales si todavía no existen. `DATABASE/` está fuera de este repositorio Git.
4. Configura en Windows la variable de entorno `PUBLICIDAD_SQL_PASSWORD` con la contraseña de la cuenta SQL configurada. No publiques la contraseña.
5. Ejecuta `check_sql.bat`. El mensaje `[OK]` confirma que desde ese equipo se conectó y comprobó el catálogo esperado.

## Configuración de conexión
`Presentacion/App.config` contiene estos valores; la compilación los copia a `SistemaPublicidad.exe.config`:

| Clave | Valor actual | Uso |
|---|---|---|
| `ServidorSql` | `localhost,1433` | Dirección del servidor y puerto; `localhost` sirve si SQL Server está en ese mismo equipo. |
| `BaseDatosSql` | `Db_PublicidadMultisucursal` | Base de datos de la aplicación. |
| `UsuarioSql` | `sa` | Usuario SQL configurado actualmente. |
| `VariableEntornoPasswordSql` | `PUBLICIDAD_SQL_PASSWORD` | Variable de Windows con la contraseña; no se guarda en archivos versionados. |

Si SQL Server está en otro equipo, cambia `ServidorSql` por su nombre/IP y puerto accesible y valida la conexión desde el equipo donde ejecutarás la aplicación.

## Responsables y validación
- Integrante 1: Login y Roles, conforme a la asignación documentada para este proyecto.
- Cada integrante responde por los módulos CRUD que tenga asignados y verifica que sus operaciones se reflejen en SQL Server. El repositorio no registra los nombres ni la asignación de módulos de los integrantes 2 y 3.
- Los tres integrantes confirman las pruebas integradas antes de declarar completado el Documento 09.
- Release y ZIP se compilaron y verificaron localmente. La prueba manual de Login, Panel, Dashboard y CRUD en otro Windows sigue pendiente; no se afirma que la aplicación ya esté validada fuera de este equipo.
- Si el grupo solicita capturas, guárdalas directamente en `../../DOCS/` con nombres que indiquen pantalla, operación y fecha. No registres capturas de pruebas que no se hayan realizado.
