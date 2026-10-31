# Revisión del proyecto - Documento 09

Esta es una lista de revisión del proyecto, no una definición de plugin.

1. Leer README.md, AGENTS.md, MEMORY.md, ESTADO_DOCUMENTOS.md y database/CONEXION_DATABASE.md.
2. Confirmar el estado de Git y las rutas de los cuatro proyectos de la solución de `src`.
3. Revisar referencias, entradas del menú, constructores de formularios y eventos. Los formularios se construyen por código y no usan Designer.
4. Revisar Login, cinco perfiles, permisos en SQL Server, cierre de sesión, búsqueda y actualización del Dashboard.
5. Contrastar tablas, campos, tipos, identidades, PK y FK del catálogo real. No deducir el esquema solo por las entidades.
6. Compilar la solución y ejecutar `check_refs.bat`, `check_sql.bat` y las pruebas de `tests/Integracion09`.
7. Las pruebas de integración requieren una base local de desarrollo y crean registros temporales que se eliminan al finalizar.
8. Comprobar visualmente Login, navegación, Roles, los 13 CRUD, sus detalles y PDF. Distinguir estas pruebas de las comprobaciones automáticas.
9. Documentar resultados verificados, pendientes y riesgos. Si la tarea es solo una revisión, esperar autorización antes de corregir.
