# Documento 02 — CRUD simple de Diseñadores

## Estado vigente — cuatro funcionalidades confirmadas
El estudiante confirmó por separado AGREGAR, BUSCAR automático, EDITAR y finalmente ELIMINAR. Se completó la secuencia de validaciones solicitada. Las secciones siguientes conservan el historial técnico y las pruebas manuales propuestas; sus indicaciones antiguas de esperar confirmación de una funcionalidad quedan resueltas por estas confirmaciones.

No se realizaron cambios nuevos de código ni pruebas adicionales al registrar esta última confirmación. Se mantiene la paginación de 10 únicamente en Presentación y los totales completos independientes de la página. Documento 02 pendiente de revisión/cierre final con el estudiante; ningún otro documento o módulo queda habilitado.

## Alcance vigente: ELIMINAR, esperando confirmación
- El estudiante confirmó EDITAR. Se revisó únicamente ELIMINAR; no se habilitan otros documentos.
- Se conserva Disenador y la integración existente: Datos/Eliminar usa DELETE parametrizado WHERE CodigoDiseñador=@Codigo con SqlConnection y using; Negocio valida PK positiva y traduce SqlException 547 al mensaje de diseños/órdenes relacionados; Presentación utiliza la PK de la fila seleccionada y maneja errores con try-catch.
- Ajuste de FrmDisenadores.cs: la confirmación identifica nombre y código e informa que el borrado es irreversible. Cancelar la confirmación regresa antes de llamar a Negocio. Tras eliminar, se conservan filtros, se recarga el conjunto, se ajusta la página y se actualiza el resumen global. No se modificó esa lógica existente ni otras funciones.
- Compilación: 0 errores y 0 advertencias. Prueba automática: PK 0 rechazada antes de SQL; código inexistente devuelve 0 filas; FK real 547 de un diseñador relacionado rechazada y traducida al mensaje previsto. Las pruebas SQL usaron transacciones sin confirmar; todos los registros originales se compararon campo por campo antes/después y coinciden. No se eliminaron registros persistentemente en esta etapa.
- Fuente, ejecutable y configuración de prueba eliminados. El DELETE exitoso del registro temporal fue probado en el ciclo histórico; la revisión visual de esta etapa sigue pendiente. Sin cambios en Designer, resx, Consultar, Agregar, búsqueda automática, Editar ni paginación de 10/totales.

### Prueba manual exacta de ELIMINAR
1. Abrir Diseñadores, vaciar búsqueda y seleccionar Todos. Seleccionar el registro de prueba utilizado en Agregar/Editar, sin relaciones. Anotar código, estado y total global.
2. Pulsar Eliminar: comprobar nombre y código en la confirmación. Responder No: la fila y los totales deben permanecer iguales.
3. Pulsar Eliminar sobre el mismo registro y responder Sí. Debe mostrar «Diseñador eliminado correctamente.» y desaparecer esa PK. El total global debe disminuir en uno y también el contador correspondiente a su estado.
4. Pulsar Consultar para comprobar que el registro sigue ausente. Si había varias páginas, verificar que la página actual siga siendo válida, máximo 10 filas y totales completos al navegar.
5. No es necesario eliminar registros originales para probar FK: el rechazo ya se verificó automáticamente sin cambios persistentes. Si se prueba manualmente con un diseñador relacionado, debe mostrar el aviso de relaciones y conservarlo.
6. Confirmar ELIMINAR al agente. El Documento 02 no se marca COMPLETADO hasta revisar la confirmación; no avanzar a otra etapa.

Archivos modificados: FrmDisenadores.cs, docs/CRUD_DISENADORES.md, MEMORY.md y ESTADO_DOCUMENTOS.md.

## Alcance vigente: EDITAR, esperando confirmación
- El estudiante confirmó la búsqueda automática. Se avanzó solo a EDITAR; ELIMINAR espera confirmación de esta etapa.
- Se conservó la integración existente: Entidad/Disenador, Datos/Actualizar con UPDATE parametrizado y WHERE CodigoDiseñador=@Codigo, Negocio/Actualizar con validaciones y Presentación con carga del registro seleccionado. codigoEdicion conserva la PK; el TextBox de código es de solo lectura. No se modificaron esas capas ni otras funciones para duplicar lógica existente.
- Ajuste en FrmDisenadores.cs: comentario sobre la PK seleccionada y mensaje de éxito específico «Diseñador actualizado correctamente.» para edición; Agregar mantiene su mensaje.
- Compilación de solución correcta: 0 errores, 0 advertencias. Prueba con formulario instanciado sin mostrar: selección de fila, carga de campos, PK de solo lectura, Guardar habilitado, Limpiar conserva PK, Cancelar termina edición y validación rechaza actualizar sin PK. Sin INSERT/UPDATE/DELETE en este paso. Archivos temporales eliminados.
- La escritura UPDATE ya probada en el ciclo temporal histórico no reemplaza la prueba visual de esta etapa. Páginas de 10, totales, Consultar, Agregar, búsqueda automática, Designer y resx conservados.

### Prueba manual exacta de EDITAR
1. Abrir Diseñadores; dejar búsqueda vacía y filtro Todos. Seleccionar el registro de prueba creado al validar Agregar. Anotar código, datos y total global.
2. Pulsar Editar. Verificar que se carguen sus datos y que el código no pueda modificarse.
3. Cambiar Especialidad a Edicion validada y pulsar Guardar una sola vez. Debe mostrar «Diseñador actualizado correctamente.» y volver al listado. Comprobar mismo código, nueva especialidad y total de registros sin cambios.
4. Pulsar Consultar y volver a seleccionar el registro para confirmar persistencia del valor.
5. Pulsar Editar, cambiar temporalmente el nombre y pulsar Cancelar. Al volver a editar la misma fila, el nombre debe conservar su valor guardado.
6. Opcionalmente dejar nombre vacío o escribir edad no numérica y pulsar Guardar: debe informar el error sin guardar; pulsar Cancelar después.
7. Si hay varias páginas, verificar máximo 10 filas y totales estables al navegar. Confirmar EDITAR al agente; no avanzar a Eliminar antes de esa confirmación.

Archivos modificados: FrmDisenadores.cs, docs/CRUD_DISENADORES.md, MEMORY.md y ESTADO_DOCUMENTOS.md. Estado: EDITAR listo para prueba del estudiante; no validado manualmente todavía.

## Ajuste vigente: BUSCAR automáticamente al cambiar texto
- El estudiante confirmó BUSCAR por Enter y solicitó coincidencias automáticas al ingresar texto. No se avanza a EDITAR hasta validar este ajuste.
- FrmDisenadores.cs enlaza el evento existente csBuscar.TextoCambiado desde el constructor; su manejador reutiliza CargarDisenadores. Funciona al escribir, pegar y borrar, conservando Enter como refresco opcional. Sin modificaciones a Designer, resx, CampoBusqueda, Datos o Negocio.
- Conserva el filtro Todos/Activo/Inactivo, vuelve a página 1 y mantiene páginas de 10 solo en Presentación. El total filtrado refleja todas las coincidencias; las tarjetas globales no dependen de la búsqueda ni de la página.
- Compilación: 0 errores y 0 advertencias. Prueba temporal ejecutada sin mostrar ventanas y sin enviar Enter: una letra, nombre completo, texto sin coincidencias y búsqueda vacía en los tres estados; resultados, página inicial, límite de 10 y totales correctos. Solo lecturas SQL. Archivos de prueba temporales eliminados.
- Prueba manual pendiente: escribir una letra de un nombre visible sin pulsar Enter y comprobar coincidencias; completar el texto, pegar otro término y borrar todo. Confirmar actualización automática, recuperación del listado al vaciar y tarjetas globales sin cambios. Repetir con Activo/Inactivo. No avanzar a Editar sin confirmación.

## Alcance vigente: BUSCAR, esperando confirmación
- El estudiante confirmó que AGREGAR funcionó. Se avanza solo a BUSCAR, según el orden acordado. Editar y Eliminar esperan su turno y confirmación; las secciones anteriores son historial.
- BUSCAR ya estaba integrado y no requirió modificar C#: Entidad conserva Disenador; Datos usa SELECT parametrizado por texto/estado con orden por PK y sin paginación SQL; Negocio normaliza texto y valida el filtro; Presentación usa csBuscar.EnterPresionado y cmbFiltroEstado.SelectedIndexChanged, vuelve a página 1 y muestra hasta 10 filas.
- Búsqueda parcial en nombre, especialidad, correo y representación del código. Texto vacío devuelve todos los resultados del estado elegido. El total de resultados corresponde al conjunto filtrado; las tarjetas globales no se calculan sobre las filas visibles.
- Compilación: 0 errores y 0 advertencias. Pruebas de lectura ejecutadas: nombre/especialidad/correo/código, espacios exteriores, texto vacío, Activo/Inactivo, texto inexistente y parámetro de apariencia SQL. Se observó un conjunto real de 6 registros.
- Se disparó Enter en el TextBox interno real de CampoBusqueda, con formulario instanciado sin mostrar ventanas: filas correctas, máximo 10, página inicial y total filtrado correctos, tarjetas globales sin cambios. No se ejecutó escritura SQL ni revisión visual manual.
- Prueba temporal, ejecutable y configuración eliminados. Sin cambios en Consultar, Agregar, Editar, Eliminar, Designer, resx o paginación. Archivos permanentes modificados: docs/CRUD_DISENADORES.md, MEMORY.md y ESTADO_DOCUMENTOS.md.

### Prueba manual exacta de BUSCAR
1. Ejecutar Diseñadores, seleccionar Todos y dejar búsqueda vacía; pulsar Enter. Anotar tarjetas globales y elegir un registro visible como referencia.
2. Escribir una parte de su nombre y pulsar Enter. Deben aparecer coincidencias por nombre, especialidad, correo o código; el registro elegido debe estar incluido. Repetir con su correo, especialidad y código. La coincidencia del código también es parcial.
3. Buscar un texto inexistente, por ejemplo SIN_COINCIDENCIA_CODEX_999: tabla vacía, total filtrado 0, página 1 y botones de navegación deshabilitados. Las tarjetas globales deben conservar sus valores.
4. Vaciar búsqueda y pulsar Enter: recuperar el conjunto del filtro elegido. Probar Activo e Inactivo: solo deben mostrarse filas del estado seleccionado.
5. Para cualquier búsqueda con más de 10 coincidencias, verificar máximo 10 filas por página, navegación sin cambiar el total filtrado ni tarjetas y regreso a página 1 al cambiar el texto y pulsar Enter. No crear registros para esta prueba sin autorización.
6. Confirmar BUSCAR al agente. No avanzar a EDITAR hasta esa confirmación.

## Alcance vigente: AGREGAR, esperando prueba del estudiante
El estudiante autorizó Agregar → Buscar → Editar → Eliminar, de una en una y con confirmación entre funcionalidades. En este paso solo se revisó y preparó AGREGAR. Las secciones siguientes sobre Consultar y ciclos previos son historial y no habilitan avanzar a Buscar, Editar o Eliminar.

### Integración de AGREGAR conservada
- Entidad: Disenador con propiedades sencillas, sin cambios.
- Datos: Insertar ya usa INSERT parametrizado sobre dbo.Tbl_Diseñadores y la conexión existente; SQL Server genera CodigoDiseñador IDENTITY. Sin cambios nuevos a Datos.
- Negocio: Insertar ya valida obligatorios, longitudes, edad y teléfono positivos y delega a Datos. Sin cambios nuevos a Negocio.
- Presentación: btnNuevo_Click prepara el alta y btnGuardar_Click usa Insertar cuando codigoEdicion es 0. Se ajustó únicamente la confirmación del alta a «Diseñador agregado correctamente.», conservando el mensaje previo de edición. No se modificaron Consultar, filtros, paginación, diseñador, resx ni las demás operaciones.
- Paginación existente: 10 registros en Presentación; los totales completos se actualizan tras guardar y no cambian al navegar de página.
- Verificación de este paso: compilación de solución correcta, 0 errores y 0 advertencias. No se ejecutó una nueva escritura SQL ni prueba visual; el INSERT probado en el ciclo temporal anterior sigue siendo evidencia histórica, no confirmación manual de esta etapa.

### Prueba manual exacta de AGREGAR
1. Abrir la solución y el módulo Diseñadores. En Consultar dejar búsqueda vacía y filtro Todos; anotar total de resultados, total de diseñadores y activos actuales.
2. Pulsar Nuevo. Deben mostrarse campos vacíos, código de solo lectura y estado Activo; Guardar debe estar habilitado.
3. Escribir Edad=25, Telefono=55551234, Especialidad=Prueba Agregar y Correo=prueba.agregar@example.com; dejar Nombre vacío. Pulsar Guardar: debe rechazar el nombre y no insertar.
4. Completar Nombre=Prueba Agregar Diseñadores y escribir Edad=abc. Pulsar Guardar: debe rechazar el entero y no insertar.
5. Corregir Edad=25 y pulsar Guardar una sola vez. Debe aparecer «Diseñador agregado correctamente.», regresar al listado y existir un nuevo registro con código generado por SQL Server. El total global y activos deben aumentar en uno respecto al paso 1.
6. Con más de 10 resultados, navegar páginas: máximo 10 filas y totales iguales entre páginas. Con 10 o menos, solo una página.
7. Pulsar Nuevo, escribir un nombre y pulsar Cancelar: no debe generarse otro registro.
8. Confirmar el resultado al agente. No probar Buscar, Editar o Eliminar como nuevas etapas hasta la confirmación solicitada. No eliminar el registro de prueba durante esta etapa.

Archivos modificados en este paso: FrmDisenadores.cs, docs/CRUD_DISENADORES.md, MEMORY.md y ESTADO_DOCUMENTOS.md. Estado: AGREGAR listo para prueba manual, no validado por el estudiante.

## Alcance actual: solo CONSULTAR, pendiente de confirmación del estudiante
- Por instrucción posterior, este paso se limita a CONSULTAR. La funcionalidad de escritura documentada abajo pertenece a pasos previos; no se modificó ni ejecutó en este paso.
- Se reutilizaron Entidad/Disenador.cs, Datos/DisenadorDatos.cs, Negocio/DisenadorNegocio.cs y ConexionDatos existentes. No requirieron cambios nuevos: lectura ADO.NET parametrizada, métodos sencillos y lista completa para Presentación.
- Único archivo de código ajustado: Presentacion/Formularios/FrmDisenadores.cs. btnTabConsultar_Click recarga SQL Server y vuelve a página 1, manteniendo búsqueda y estado. Paginación de 10 exclusivamente en Presentación; etiqueta de total filtrado y tarjetas globales independientes de la página.
- Compilación posterior: 0 errores, 0 advertencias. Prueba temporal de solo lectura, sin mostrar ventanas: recarga desde la lista real, regreso a página 1, hasta 10 filas, filtro Inactivo conservado y total global estable. Total real observado en esta prueba: 6; no se realizaron INSERT/UPDATE/DELETE. Los recuentos anteriores de 5 corresponden a pruebas históricas.
- Fuente, ejecutable y configuración temporales eliminados. Designer y resx sin modificaciones en este paso. No se considera aprobada la revisión visual.

### Cómo probar CONSULTAR
1. Si Visual Studio estaba abierto antes de configurar PUBLICIDAD_SQL_PASSWORD, cerrarlo y abrirlo de nuevo.
2. Abrir src/SistemaPublicidad/SistemaPublicidad.sln y ejecutar el proyecto Presentacion. Entrar al módulo Diseñadores por la navegación existente.
3. Pulsar Consultar: comprobar columnas reales, listado y total de resultados. La prueba automática más reciente observó 6 registros; usar el total actual de SQL Server al comparar.
4. Buscar un nombre con Enter y cambiar Todos/Activo/Inactivo; verificar coincidencias y que la primera página se seleccione tras cada consulta. Vaciar la búsqueda y seleccionar Todos para recuperar el listado completo.
5. Con más de 10 resultados, verificar máximo 10 por página, navegación anterior/siguiente y que ni el total filtrado ni las tarjetas cambien al navegar. Con 10 o menos resultados solo debe existir una página; no agregar registros solo para esta prueba sin autorización.
6. Confirmar el resultado al agente. No probar ni avanzar a funcionalidades de escritura en este paso.

El estudiante confirmó el Documento 01 y posteriormente denominó Documento 02 a esta etapa, autorizando su implementación. Se usa skills/03_CRUD_Simple.md como guía; esto no habilita el Documento 03.

## Implementación
- Solución existente: src/SistemaPublicidad/SistemaPublicidad.sln, .NET Framework 4.8.
- Entidad/Disenador.cs conservada: siete propiedades correspondientes a las siete columnas reales de dbo.Tbl_Diseñadores.
- Datos/DisenadorDatos.cs: Listar, Buscar, Insertar, Actualizar y Eliminar; System.Data.SqlClient y ConexionDatos existentes, parámetros tipados, conexiones y lectores con using. PK CodigoDiseñador IDENTITY, sin enviarla al insertar. Consultas ordenadas por PK; sin paginación SQL.
- Negocio/DisenadorNegocio.cs: campos obligatorios, longitudes 45/45/150, edad y teléfono positivos, PK válida para actualizar/eliminar y filtros de estado válidos. Se informa el error 547 al eliminar un diseñador con relaciones. Estas validaciones positivas son reglas de aplicación; no restricciones nuevas de SQL.
- Presentacion/Formularios/FrmDisenadores.cs: carga inicial, búsqueda por código/nombre/especialidad/correo, filtro Todos/Activo/Inactivo, nuevo, edición, confirmación de eliminación, guardar, cancelar y limpiar conservando PK en edición. try-catch para comunicar errores.
- Paginación de 10 solo en Presentación mediante Skip/Take. Se reutilizan btnPagAnterior, btnPagina, btnPagSiguiente y se enlazan desde el constructor. Los filtros regresan a la primera página; una reducción del conjunto ajusta la página al rango disponible.
- lblTotalRegistros usa el total filtrado completo. Las tarjetas existentes usan el resumen de todos los registros del módulo; navegar páginas no recalcula ni altera esos totales.
- No se modificaron Designer, resx, estructura SQL, Login, roles o Dashboard ni se creó otra solución.

## Pruebas ejecutadas
- Inspección SQL previa: 5 registros, todos activos; PK, tipos, nulabilidad y referencias verificados. Diseños y Órdenes de Trabajo referencian diseñadores con NO_ACTION.
- dotnet build de la solución existente, sin restauración: compilación correcta, 0 errores y 0 advertencias. La ejecución dentro del entorno restringido falló por acceso a .dotnet; la compilación fuera de él terminó correctamente.
- Programa temporal contra ensamblados compilados y configuración real: Listar devuelve 5; filtro Activo devuelve 5 e Inactivo 0; búsqueda Alejandro devuelve 1; entrada de apariencia SQL se trata como valor y devuelve 0; resumen total coincide con Listar.
- Validaciones de campos vacíos y código de eliminación 0 rechazadas antes de cualquier escritura.
- Formulario instanciado sin mostrar ventanas; paginación ejercitada mediante sus métodos con listas en memoria de 0, 1, 10, 11 y 23 registros. Se verificaron límite de 10, orden, ausencia de omisiones y duplicados, navegación anterior/siguiente y totales/tarjetas sin cambios al navegar.
- Se compararon las huellas del Designer y resx antes/después: idénticas. Programa de pruebas, fuente y configuración temporales eliminados.

## Ciclo real autorizado: alta, edición y eliminación
- Posteriormente el estudiante autorizó un ciclo real mediante un registro temporal identificado por un token único y un correo de prueba.
- Programa temporal usando los ensamblados reales de Negocio/Datos y el App.config de Presentacion; ejecución con código 0.
- INSERT afectó una fila y se verificó su lectura, valores y PK IDENTITY generada.
- UPDATE afectó una fila; lectura posterior verificó nombre, edad, especialidad, teléfono y estado Inactivo. El registro dejó de aparecer en el filtro Activo.
- DELETE afectó una fila y se comprobó la ausencia del registro temporal.
- Los cinco registros originales se compararon campo por campo antes/después: idénticos. El alta temporal consume un valor IDENTITY; no se realizó reseed ni se alteró el esquema.
- Fuente, ejecutable y configuración de prueba eliminados. Las menciones anteriores a ausencia de escrituras corresponden a la primera ronda de pruebas.

## Pendiente: no declarar validado todavía
- En la etapa posterior ELIMINAR se probó el rechazo por FK dentro de una transacción sin confirmar, conservando todos los registros. El ciclo temporal anterior verifica eliminación sin relaciones.
- No se hizo revisión visual ni recorrido manual de botones, mensajes y pestañas. Instanciar el formulario sin mostrarlo no sustituye esa revisión.
- No se marca este documento COMPLETADO. Revisar los resultados con el estudiante antes del siguiente paso; otros documentos permanecen bloqueados.
