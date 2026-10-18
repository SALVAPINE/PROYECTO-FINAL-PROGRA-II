# Memoria comprobada

## Revisión vigente del CRUD simple — Diseñadores
- Solicitud expresa de revisión con skills/03_CRUD_Simple.md y skills/10_Revision_Proyecto.md. Se leyeron ambos: Skill 03 contiene reglas aplicadas; Skill 10 sigue como archivo PENDIENTE sin lista detallada. La solicitud autoriza esta revisión puntual, no habilita el Documento 10 ni otro módulo.
- Revisión estática actual: Entidad contiene siete propiedades sencillas sin SQL ni interfaz. Datos concentra ADO.NET, mapeo y SQL; Negocio valida y delega (también traduce SqlException 547); Presentación usa Negocio, controles existentes, eventos y try-catch, sin SQL directo. Los cuatro proyectos son .NET Framework 4.8; referencias sin ciclos: Datos→Entidad, Negocio→Datos/Entidad, Presentacion→Negocio/Entidad.
- SELECT/INSERT/UPDATE/DELETE usan valores de entrada parametrizados y tipos explícitos. UPDATE y DELETE filtran por CodigoDiseñador; INSERT deja generar IDENTITY. El helper Guardar recibe únicamente las dos sentencias constantes internas, no SQL proporcionado por el usuario. SqlConnection, SqlCommand y lectores se liberan con using.
- Designer y resx leídos: controles de campos, listado, estado, búsqueda y paginación existentes. TextoCambiado, filtro y navegación enlazados desde el constructor. Páginas de 10 con Skip/Take solo en Presentación; etiqueta filtrada basada en resultados.Count y tarjetas globales independientes de la página.
- Errores: TryParse en formulario, validaciones en Negocio, excepciones comunicadas con try-catch y FK 547 con mensaje específico. No se afirma que todos los errores posibles hayan sido probados.

### Pruebas ejecutadas previamente y evidencia disponible
- Compilación de solución: 0 errores y 0 advertencias en las ejecuciones registradas; no se volvió a compilar ni a ejecutar SQL durante esta revisión documental.
- Clase ConexionDatos con configuración real: apertura/cierre correctos y variable del usuario verificada sin exponer el secreto.
- Lecturas reales: listado, búsqueda por nombre/especialidad/correo/código, vacío, espacios, estados, sin coincidencias y entrada de apariencia SQL como parámetro.
- Formulario instanciado sin mostrar ventanas: eventos Enter y TextoCambiado, refresco, búsqueda automática al cambiar/borrar texto, regreso a página 1 y totales globales estables.
- Paginación en memoria: conjuntos 0/1/10/11/23, máximo 10 por página, navegación, orden y ausencia de omisiones/duplicados. No equivale a prueba visual multipágina con datos reales.
- Ciclo real con registro temporal: INSERT/UPDATE/DELETE, valores persistidos y desaparición comprobados; cinco registros originales comparados campo por campo antes/después. El alta consumió un valor IDENTITY.
- Validaciones ejecutadas: campos vacíos y PK 0; actualización sin PK rechazada. Carga de campos de edición, código de solo lectura, Limpiar conservando PK y Cancelar comprobados sin mostrar ventanas.
- ELIMINAR: PK inexistente devuelve cero filas y FK real 547 rechazada en transacciones sin confirmar; registros originales idénticos después.
- El estudiante confirmó por separado Agregar, Buscar automático, Editar y Eliminar. Esto registra su validación funcional general, no presupone que haya realizado cada caso límite de las listas manuales.

### Hallazgos y escenarios no comprobados
- Hallazgo estático: ObtenerResumen limita PorCategoria a 6; Resumenes.Aplicar cuenta esas entradas para statExtra. Con más de seis especialidades distintas no vacías, la tarjeta Categorías puede subcontar. No se ejecutó ese escenario ni se corrigió código. Propuesta: contar todas las especialidades para la tarjeta y limitar solo la serie gráfica.
- Hallazgo estático: si CargarDisenadores falla, muestra el error y conserva resultados anteriores; un guardado/borrado exitoso puede mostrar éxito aunque la recarga posterior haya fallado. No se simuló caída SQL. Propuesta: devolver resultado de recarga y advertir que la escritura se realizó pero la vista no se actualizó, sin repetir la escritura.
- Pendiente de comprobación específica: caída/conexión inválida durante búsqueda y recarga, límites de longitud y enteros, navegación visual con más de 10 registros reales y eliminación de la última fila de la última página, concurrencia entre consultar y guardar/eliminar. No marcar esos casos como correctos.
- No se modificó C#, Designer, resx o SQL en esta revisión. Se actualizaron únicamente MEMORY.md, ESTADO_DOCUMENTOS.md y docs/COMANDOS_RAPIDOS.md. Sin comandos Git/GitHub: corresponde al Documento 05 por instrucción actual del estudiante. Documento 02 revisado, cierre final pendiente; no se habilita otro documento ni módulo.

## Validación del estudiante — funcionalidades de Diseñadores
- El estudiante confirmó que ELIMINAR funciona. AGREGAR, BUSCAR automático, EDITAR y ELIMINAR cuentan ahora con confirmación del estudiante, recibida por separado y en el orden acordado.
- Se conservan la paginación de 10 registros en Presentación y los totales independientes de la página. Esta confirmación no añade pruebas técnicas no ejecutadas ni certifica escenarios adicionales.
- No se modificó código en este cierre de validaciones. Documento 02 pendiente de revisión/cierre final; no se habilita ni inicia otro documento o módulo.

## Alcance vigente — ELIMINAR de Diseñadores
- El estudiante confirmó EDITAR; se trabajó únicamente ELIMINAR. Se conserva la integración existente en las cuatro capas y la PK real CodigoDiseñador.
- Cambio de código en FrmDisenadores.cs: confirmación identifica nombre/PK e indica que el borrado no se puede deshacer. Sin cambios a otras funciones, Designer, resx, paginación de 10 o cálculo de totales.
- Compilación: 0 errores y 0 advertencias. Pruebas: PK 0 rechazada; PK inexistente devuelve cero filas; FK real 547 rechazada y traducida al mensaje de registros relacionados. Transacciones SQL sin confirmar; todos los registros originales idénticos campo por campo antes/después. No hubo borrados persistentes en este paso.
- Fuente, ejecutable y configuración de pruebas eliminados. Prueba manual de confirmación/cancelación y borrado del registro de prueba pendiente; esperar validación de ELIMINAR antes de cerrar Documento 02 o avanzar.

## Alcance vigente — EDITAR de Diseñadores
- El estudiante confirmó la búsqueda automática. Se trabajó solo en EDITAR; ELIMINAR espera su confirmación.
- Implementación existente conservada en las cuatro capas: UPDATE parametrizado por PK real CodigoDiseñador; codigoEdicion proviene de la fila seleccionada y el control del código es de solo lectura. Se ajustó únicamente comentario y mensaje de éxito de edición en FrmDisenadores.cs.
- Compilación: 0 errores y 0 advertencias. Prueba del formulario sin mostrar: carga de campos/PK, Guardar habilitado, Limpiar conserva PK y Cancelar correcto; validación sin PK rechazada. Sin escrituras SQL en este paso. Archivos temporales eliminados.
- Sin cambios al diseñador, resx, Consulta, Agregar, búsqueda automática ni paginación de 10/totales. Prueba manual de guardado y cancelación pendiente, descrita en docs/CRUD_DISENADORES.md. No avanzar a Eliminar.

## Alcance vigente — ajuste de BUSCAR automáticamente
- El estudiante confirmó que BUSCAR funciona y pidió filtrar al ingresar texto sin Enter. Se ajustó solo FrmDisenadores.cs: enlace csBuscar.TextoCambiado y manejador que reutiliza CargarDisenadores.
- Sin cambios al diseñador, resx, control compartido, Datos, Negocio, otras operaciones o lógica de paginación. Páginas de 10 en Presentación, regreso a página 1 y totales globales conservados.
- Compilación: 0 errores, 0 advertencias. Prueba sin Enter ni ventanas mostradas: una letra, nombre completo, sin coincidencias y texto vacío en Todos/Activo/Inactivo; filas, página y totales correctos. Solo lecturas SQL; fuente/ejecutable/configuración temporales eliminados.
- Esperar confirmación manual del ajuste antes de EDITAR. Las instrucciones anteriores de requerir Enter son históricas; ahora es opcional.

## Alcance vigente — BUSCAR de Diseñadores
- El estudiante confirmó que pudo agregar. AGREGAR validado por el estudiante; se revisó solo BUSCAR conforme al orden acordado. EDITAR y ELIMINAR no se inician hasta las confirmaciones respectivas.
- La implementación existente de BUSCAR cumple el alcance y se conservó sin cambios C#: SELECT parametrizado, filtros Todos/Activo/Inactivo, búsqueda parcial por nombre/especialidad/correo/código, lista completa en Datos y páginas de 10 únicamente en Presentación.
- Compilación: 0 errores, 0 advertencias. Pruebas de lectura contra SQL Server: campos de búsqueda, espacios, vacío, estados, cero coincidencias y parámetro de apariencia SQL correctos. Se observaron 6 registros.
- Evento Enter disparado sobre el TextBox real de csBuscar con el formulario sin mostrar: resultados, máximo 10 filas, página 1 y total filtrado correctos; tarjetas globales estables. Sin escrituras SQL ni validación visual manual.
- Archivos temporales eliminados. Solo se actualizaron docs/CRUD_DISENADORES.md, MEMORY.md y ESTADO_DOCUMENTOS.md. BUSCAR espera confirmación manual del estudiante antes de EDITAR.

## Alcance vigente — AGREGAR de Diseñadores, por etapas
- El estudiante autorizó Agregar → Buscar → Editar → Eliminar, una funcionalidad por vez y esperando su confirmación entre etapas. Este paso se limita a AGREGAR; no avanzar a Buscar sin confirmación.
- AGREGAR ya estaba implementado en Entidad/Datos/Negocio/Presentación y se conservó. Único ajuste de código: FrmDisenadores.cs conserva el modo alta antes de guardar y muestra «Diseñador agregado correctamente.» al insertar; la ruta de edición mantiene su comportamiento anterior.
- No se cambiaron Consultar, diseñador, resx, lógica de otras funcionalidades ni paginación. Páginas de 10 en Presentación y totales independientes de la página conservados.
- Compilación de solución: 0 errores y 0 advertencias. Sin nuevas escrituras SQL ni prueba visual en este paso. Prueba manual exacta en docs/CRUD_DISENADORES.md; AGREGAR pendiente de confirmación del estudiante. Las pruebas anteriores son históricas y no equivalen a esta confirmación.

## Alcance vigente — solo CONSULTAR de Diseñadores
- El estudiante autorizó únicamente CONSULTAR y pidió detenerse hasta su confirmación de prueba. No avanzar a otras funcionalidades ni documentos.
- Se reutilizó la lectura existente en Entidad/Datos/Negocio; solo se ajustó FrmDisenadores.cs para recargar al pulsar Consultar, mantener filtros y volver a página 1. Paginación de 10 exclusivamente en Presentación, con totales completos independientes de la página.
- Compilación: 0 errores y 0 advertencias. Prueba de lectura con formulario sin mostrar: refresco real, página inicial, tamaño máximo 10, filtro conservado y total global estable. Total SQL observado: 6 registros; sin escrituras SQL en este paso. Fuente, ejecutable y configuración temporales eliminados.
- No se modificaron Designer ni resx. La prueba visual del estudiante está pendiente; pasos e instrucciones en docs/CRUD_DISENADORES.md. Los CRUD previos y sus pruebas son históricos y no amplían el alcance actual.

## Ciclo CRUD real autorizado — Diseñadores
- El estudiante autorizó probar agregar, editar y eliminar un registro temporal, usando las capas existentes contra SQL Server.
- Ejecución con código 0: INSERT de una fila con PK IDENTITY verificada; UPDATE de una fila con valores y estado Inactivo verificados por lectura; DELETE de una fila y ausencia del registro temporal comprobada.
- Los cinco registros originales coincidieron campo por campo antes/después. El alta consumió un valor IDENTITY; no se hizo reseed ni cambio de esquema. Archivos temporales eliminados.
- Documento 02 continúa EN REVISIÓN: revisión visual y rechazo de eliminación por FK no probados. No se completó ni habilitó otra etapa. Las entradas anteriores sobre escrituras pendientes describen la ronda de pruebas anterior.

## Estado vigente — Documento 02 CRUD simple de Diseñadores
- El estudiante denominó explícitamente Documento 02 a CRUD simple y autorizó el plan de implementación. Esta instrucción posterior sustituye la denominación previa de Conexión SQL Server, conservando su evidencia histórica. Documento 01 sigue COMPLETADO; Documento 02 EN REVISIÓN, no completado. Documentos 03–10 bloqueados; 11 pendiente sin autorización.
- CRUD implementado en DisenadorDatos, DisenadorNegocio y FrmDisenadores; Entidad, Designer y resx conservados. Páginas de 10 únicamente en Presentación; listado completo filtrado y resumen global independientes de la página.
- Compilación de la solución: 0 errores, 0 advertencias. Pruebas de lectura real (5 registros), filtros, búsqueda, resumen y validaciones correctas. Paginación probada sin mostrar ventanas con listas 0/1/10/11/23: límites, orden y totales estables. Archivos temporales eliminados.
- No se ejecutaron escrituras reales ni revisión visual manual. No declarar esas pruebas correctas; pruebas y alcance en docs/CRUD_DISENADORES.md. No avanzar sin autorización del estudiante.
- Los registros anteriores son históricos y no sustituyen este estado vigente.

## Estado vigente — cierre explícito del Documento 01
- El estudiante confirmó literalmente: «Documento 01 validado; actualiza MEMORY.md y ESTADO_DOCUMENTOS.md y habilita solo Documento 02».
- Documento 01: COMPLETADO por validación explícita del estudiante. Documento 02: HABILITADO y único documento activo; no se marca como completado.
- Documentos 03–10: BLOQUEADOS. Documento 11: PENDIENTE, sin autorización de ejecución. No iniciar tareas adicionales por esta transición; esperar la instrucción del estudiante.
- Evidencia conservada: esquema de 15 tablas, 126 columnas, 15 PK y 18 FK; respaldo validado con VERIFYONLY y copia externa de hash coincidente; cuatro capas y referencias inspeccionadas; mapeo de controles documentado.
- ConexionDatos y el App.config real se probaron mediante un programa temporal .NET Framework: apertura/cierre correctos. No se ejecutó la interfaz Windows Forms, no se compiló la solución completa y no se realizó restauración de prueba. Estas pruebas no se consideran aprobadas.
- Esta transición actualiza únicamente MEMORY.md y ESTADO_DOCUMENTOS.md. Sin comandos Git/GitHub ni implementación de CRUD, Login, roles, Panel o Dashboard.
- Las secciones siguientes son registros históricos; sus menciones a rutas antiguas, bloqueos o pendientes anteriores no reemplazan este estado vigente.

## Variable del usuario y conexión verificadas — 17/10/2026
- Con autorización expresa se configuró y verificó PUBLICIDAD_SQL_PASSWORD en el entorno del usuario de Windows, desde el secreto local .env, sin imprimirlo ni copiarlo a documentación.
- Programa temporal .NET Framework compilado con el código real de ConexionDatos y copia del App.config de Presentacion: ProbarConexion devolvió true, apertura y cierre correctos, ejecución con código 0.
- Se eliminaron fuente, ejecutable y configuración temporales. No se abrió la interfaz Windows Forms ni se compiló la solución completa; no se ejecutó CRUD ni se modificó el diseñador o esquema.
- Reiniciar Visual Studio para heredar la variable. Siguiente paso pendiente de autorización; documentos 03–10 siguen bloqueados. Las entradas anteriores describen estados históricos.

## Validación de configuración autorizada — 17/10/2026
- El estudiante autorizó solo validar el nombre de variable en ConexionDatos y actualizar documentación, manteniendo intactos diseñadores y lógica CRUD.
- src/SistemaPublicidad/Datos/ConexionDatos.cs ahora comprueba string.IsNullOrWhiteSpace(nombreVariable) antes de Environment.GetEnvironmentVariable y lanza InvalidOperationException con mensaje explicativo si falta el nombre.
- La clase compiló aisladamente con csc de .NET Framework y System.Configuration: código 0. DLL temporal eliminada. No se compiló la solución completa ni se ejecutó conexión SQL desde la aplicación.
- Documentadas las diferencias de controles en el mapeo y el estado de la corrección en la propuesta y documentación de conexión. La carga de PUBLICIDAD_SQL_PASSWORD sigue pendiente; no se cambiaron variables de entorno persistentes.

## Traslado de la solución autorizado — 17/10/2026
- El estudiante solicitó actualizar src para coincidir con la ubicación src/SistemaPublicidad.
- Se trasladaron SistemaPublicidad.sln, LEEME.txt y las carpetas Entidad, Datos, Negocio y Presentacion a src/SistemaPublicidad mediante CMD, sin sobrescribir destinos.
- Se compararon huellas antes/después de 58 archivos: solución, cuatro proyectos, 18 pares cs/Designer y 17 resx. Todas coinciden.
- Se verificó existencia de todos los archivos incluidos y referencias de proyecto de los cuatro csproj. Las referencias relativas se conservan y no presentan ciclos.
- No se alteró código, diseño, configuración o esquema SQL. No se compiló ni ejecutó la aplicación. La caché .vs existente permanece en src/. Las rutas históricas anteriores describen su ubicación en ese momento.

## Respaldo y documentación autorizados — 17/10/2026
- El estudiante autorizó completar y ejecutar el respaldo, conservar copia externa y guardar el mapeo y la propuesta, sin modificar código ni diseñadores.
- Se inspeccionó la solución actual en src/SistemaPublicidad.sln, con proyectos directamente en src. No se movieron archivos durante este paso.
- SQL Server en contenedor sql_prog2a: permisos comprobados como mssql sobre /var/opt/mssql/data. Respaldo COPY_ONLY/CHECKSUM completado; RESTORE VERIFYONLY confirmó conjunto válido.
- Copia externa: database/Db_PublicidadMultisucursal_previo_20261017_01.bak, 5,558,272 bytes; SHA-256 coincide con el archivo interno: 5dbd78379db19af50cb42a0ed7b5e9130bf2198b9baee78c83c37191dda75dad.
- Mapeo de 126 columnas en docs/MAPEO_FORMULARIOS_SQLSERVER.md; propuesta en database/PROPUESTA_CONEXION.md. Sin cambios a C#, diseñador, resx, configuración o tablas.
- Respaldo validado sin restauración de prueba. Conexión desde la aplicación sin verificar. Pendiente autorización del siguiente paso. Las entradas anteriores describen estados históricos.

## Inspección de metadatos autorizada
- Aplicado skills/02_Conexion_SQLServer.md por solicitud expresa del estudiante: se consultaron catálogos con CMD y sqlcmd, sin modificar datos o esquema.
- Db_PublicidadMultisucursal: 15 tablas dbo, 126 columnas, 15 PK simples y 18 FK simples. Solo NIT en Tbl_Clientes y Tbl_Cotizaciones admite NULL. Todas las FK están habilitadas y confiables; acciones UPDATE/DELETE NO_ACTION.
- Inventario completo en database/CONEXION_DATABASE.md, sin contraseñas. Se preservaron nombres reales, incluidos CodgioProveedor y los identificadores con ñ.
- La consulta temporal fue eliminada. No se validó conexión desde Windows Forms, ni se ejecutó respaldo o CRUD. Pendiente confirmar siguiente paso.

## Consulta puntual posterior
- Por solicitud del estudiante se ejecutaron dos SELECT con CMD y sqlcmd. La ejecución fuera del entorno restringido devolvió Db_PublicidadMultisucursal y cinco tablas dbo: Tbl_Clientes, Tbl_Compras, Tbl_Cotizaciones, Tbl_DetalleCompra y Tbl_DetalleFactura.
- No se modificaron datos; no se probó la conexión desde Windows Forms. Se conserva el bloqueo del resto del documento 02. El archivo temporal de consulta fue eliminado.

## 17/10/2026 — Documento 01
- CMD disponible: la prueba previa creó, leyó y eliminó únicamente PruebaCodex.txt.
- El estudiante confirmó el árbol real y autorizó la estructura documental propuesta.
- Existen SistemaPublicidad.sln y los proyectos Entidad, Datos, Negocio y Presentacion en la raíz.
- Entidad.csproj declara .NET Framework v4.8. No se compiló ni ejecutó la aplicación en esta etapa.
- Presentacion contiene diseños existentes, incluidos FrmMain, FrmInicio y FrmLogin. Su presencia no certifica funcionamiento.
- Datos/ConexionDatos.cs contiene código para crear y probar una conexión con System.Data.SqlClient; obtiene la contraseña desde una variable de entorno. No se probó la conexión.
- El README tenía una referencia a PostgreSQL; se corrigió a SQL Server según el requisito del estudiante.

## Pendientes históricos de la preparación inicial
- El 17/10/2026 el estudiante proporcionó datos de SQL Server y autorizó guardarlos. Se guardaron en `.env` local excluido de Git, sin probar conexión ni desbloquear el documento 02. Consultar database/CONEXION_DATABASE.md para los datos no secretos. No copiar la contraseña a Markdown.
- Verificación documental realizada con CMD: skills contiene los 11 archivos solicitados; skills, docs y database no tienen subcarpetas; src está vacío. git diff --check terminó sin errores. Los cambios informados por git se limitan a los archivos documentales autorizados y .gitignore.
- Validación final del árbol documental por el estudiante.
- Autorización del documento 02 antes de cualquier prueba SQL Server.
- No hay respaldo ejecutado ni validación de CRUD registrada en esta etapa.
