# Estado de documentos

Documento activo: **02 — CRUD SIMPLE, Diseñadores**. Cuatro funcionalidades confirmadas por el estudiante; revisión técnica/documental realizada, cierre final pendiente. Se usaron skills/03_CRUD_Simple.md y skills/10_Revision_Proyecto.md por solicitud expresa, sin habilitar el Documento 10. No avanzar ni habilitar otros documentos o módulos. Documento 01 COMPLETADO.

Confirmación recibida: «Documento 01 validado; actualiza MEMORY.md y ESTADO_DOCUMENTOS.md y habilita solo Documento 02».

| Documento | Tema | Estado de ejecución |
|---|---|---|
| 01 | Inspección inicial | COMPLETADO; validado explícitamente por el estudiante |
| 02 | CRUD simple — Diseñadores | Funcionalidades confirmadas; revisión de capas, parámetros, controles y errores realizada. Dos hallazgos estáticos y casos límite pendientes documentados en MEMORY.md. Pruebas ejecutadas diferenciadas de confirmaciones manuales. Cierre final pendiente |
| 03 | Etapa posterior, alcance por confirmar | BLOQUEADO / PENDIENTE; skills/03_CRUD_Simple.md se usa como guía del Documento 02, sin habilitar este documento |
| 04 | CRUD relacional | BLOQUEADO / PENDIENTE |
| 05 | Git/GitHub, según instrucción actual del estudiante | BLOQUEADO / PENDIENTE; no se ejecutaron comandos Git/GitHub en esta revisión |
| 06 | Alcance por confirmar tras el ajuste de numeración | BLOQUEADO / PENDIENTE |
| 07 | Login y roles | BLOQUEADO / PENDIENTE |
| 08 | Panel de navegación | BLOQUEADO / PENDIENTE |
| 09 | Dashboard | BLOQUEADO / PENDIENTE |
| 10 | Revisión del proyecto | BLOQUEADO / PENDIENTE |
| 11 | Publicación | PENDIENTE; sin autorización de ejecución |

La numeración identifica documentos; no autoriza etapas. Solicitar confirmación al terminar cada paso. No confundir archivos existentes con funcionalidades verificadas.

Revisión vigente: sin cambios de código ni nuevas pruebas de ejecución. Se inspeccionaron cuatro capas .NET Framework 4.8, referencias sin ciclos, controles existentes, parámetros SQL tipados, PK real, using, validaciones y try-catch. Evidencia previa: compilaciones correctas; lecturas y búsquedas reales; paginación en memoria 0/1/10/11/23; ciclo temporal INSERT/UPDATE/DELETE; edición/cancelación sin ventanas; rechazo FK real con transacciones revertidas. El estudiante confirmó las cuatro funciones. No se dan por probados fallos de conexión/recarga, límites exhaustivos, concurrencia ni navegación visual multipágina real. Hallazgos sin corregir: tarjeta Categorías limitada a seis entradas y vista anterior conservada ante fallo de recarga. La numeración de archivos skills no habilita los documentos correspondientes.

Evidencia previa del documento 02: validación del nombre de variable aplicada en ConexionDatos y compilación aislada correcta; posteriormente se probó la clase real con la configuración de la aplicación, como se detalla abajo. No se ejecutaron formularios ni se agregó CRUD.

## Prueba de conexión autorizada — 17/10/2026

Se configuró PUBLICIDAD_SQL_PASSWORD para el usuario de Windows y se verificó su valor sin imprimir el secreto. Se compiló un programa temporal de .NET Framework con el código real de src/SistemaPublicidad/Datos/ConexionDatos.cs y una copia del App.config de Presentacion. ProbarConexion devolvió true: apertura y cierre correctos; código de salida 0. Se eliminaron todos los archivos temporales. No se ejecutó la interfaz Windows Forms ni se compiló la solución completa. No se ejecutaron CRUD ni se modificaron tablas o diseñadores. Reiniciar Visual Studio para que herede la variable. Los documentos 03–10 siguen bloqueados; el 11 continúa pendiente sin autorización de ejecución. No se realizó restauración de prueba. La habilitación del documento 02 no acredita pruebas adicionales ni autoriza iniciar otra etapa.
