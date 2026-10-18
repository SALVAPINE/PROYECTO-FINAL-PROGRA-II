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
- Trabajar Git/GitHub después de los CRUD y antes de Login/roles.

## Preparación documental — Documento 01
- Árbol real confirmado por el estudiante el 17/10/2026.
- Solución existente: `src/SistemaPublicidad/SistemaPublicidad.sln`, con Entidad, Datos, Negocio y Presentacion dentro de `src/SistemaPublicidad/`. Conservar los diseños existentes.
- `skills/`, `docs/` y `database/` son carpetas planas. `src/SistemaPublicidad/` contiene la solución existente, trasladada por autorización del estudiante.
- Skills 01 y 02 contienen instrucciones; eso no acredita ejecución de la conexión. Skills 03–11 pendientes.
- Documentos 02–10 bloqueados hasta autorización expresa. No ejecutar SQL ni desarrollar CRUD durante la preparación.
- Consultar `AGENTS.md`, `MEMORY.md` y `ESTADO_DOCUMENTOS.md` antes de continuar.

## Etapa vigente
Documento 01 validado y completado. El estudiante identificó posteriormente el Documento 02 como CRUD simple de Diseñadores y autorizó su implementación. Se reutilizan las cuatro capas y FrmDisenadores; páginas de 10 registros únicamente en Presentación y totales independientes de la página. Consultar docs/CRUD_DISENADORES.md para las pruebas ejecutadas y pendientes. Las restricciones de la preparación anterior son históricas; no se habilitan otros documentos ni módulos.
