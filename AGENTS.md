# Trabajo en este repositorio

- Documento activo: 09 - Integración general.
- La solución `src/SistemaPublicidad/SistemaPublicidad.sln` referencia los proyectos de la raíz; no crear copias de las capas en `src`.
- Mantener Presentación -> Negocio -> Datos -> SQL Server. Entidad transporta datos.
- Los formularios actuales se construyen en C#; no generar `.Designer.cs` para los mismos controles.
- No publicar claves, archivos `.env`, respaldos ni datos personales de SQL Server.
- Las migraciones deben ser revisables, repetibles y conservar los registros existentes. Respaldar antes de cambiar el esquema.
- Registrar en MEMORY.md únicamente comprobaciones realizadas y sus límites. No marcar pruebas manuales como realizadas si solo se compiló.
- Marcar Documento 09 como COMPLETADO únicamente cuando los tres integrantes confirmen expresamente las pruebas. Una confirmación en este chat no representa a los tres.
- No iniciar Documento 10 ni publicar el sistema sin autorización expresa del grupo.
- Para revisar el Documento 09 seguir `skills/10_Revision_Proyecto.md` y `database/CONEXION_DATABASE.md`.
