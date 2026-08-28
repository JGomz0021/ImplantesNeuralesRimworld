# CONTEXTO DEL PROYECTO

## Contexto general

- Estoy desarrollando un mod para **RimWorld**.
- Actualmente está escrito puramente en **XML**, pero en el futuro es posible agregar código en **C# con Harmony** para funcionalidades que XML no puede cubrir.
- El mod está hecho para **RimWorld 1.6**. Usa esta versión como ancla para escribir y modificar el mod.
- El mod ya tiene una estructura con:
  - `ThingDefs`
  - `Research`
  - `Recipes`
  - `HediffDefs` (`HeDefs`)
- Al realizar ajustes, guíate por la estructura y los patrones que ya existen en el proyecto.
- Existe un archivo llamado `Biblioteca_Modificadores_Rimworld_1.6.md`, donde se documentan modificadores y stats que funcionan correctamente, incluyendo ejemplos de modificadores o stats que no funcionan.

---

# MI NIVEL DE EXPERIENCIA

- Tengo un nivel **principiante en modding de RimWorld**.
- No tengo conocimientos de **C#**.

---

# CONTROL DE VERSIONES (GIT/GITHUB)

- Uso **Git y GitHub** para el control de versiones.
- La rama que debes utilizar para el desarrollo del proyecto es:

  `Cambios_de_IA`

- Flujo de trabajo:

- Si sugieres cambios que puedan afectar:
  - La estructura de carpetas.

  Indícalo explícitamente antes de realizar o recomendar dichos cambios.

---

# CONVENCIONES XML

Cuando trabajes con XML de RimWorld:

- Ten en cuenta la estructura de `Defs` utilizada por el juego.
- Respeta las estructuras y convenciones de Defs como:
  - `ThingDef`
  - `PawnKindDef`
  - `RecipeDef`
  - `HediffDef`
  - `ResearchProjectDef`
  - Y otras que correspondan.
- Utiliza las convenciones típicas de **XPath** para los patches de RimWorld.
- Antes de crear una nueva estructura, revisa los patrones existentes en el proyecto y reutilízalos cuando sea apropiado.

## Convenciones de carpetas

Los archivos nuevos deben seguir, cuando corresponda, la estructura estándar de mods de RimWorld:

- `About/`
- `Defs/`
- `Patches/`
- `Textures/`
- `Assemblies/`
- `Source/`

No cambies innecesariamente la estructura existente del proyecto.

---

# CUANDO SE NECESITE C#

- Si consideras que una funcionalidad **no puede realizarse completamente mediante XML**, avisa antes de implementar una solución en C#.

---

# NUEVOS MODIFICADORES O STATS

Cuando sea necesario añadir un nuevo modificador o stat:

1. Revisa primero el código fuente del juego disponible en:

   `/home/jair/.steam/debian-installation/steamapps/common/RimWorld/Data/`

2. Comprueba si existe algún sistema, `StatDef`, modificador o comportamiento existente que pueda reutilizarse.
3. Evita crear sistemas nuevos si el juego ya proporciona una solución compatible.
4. Si se añade un nuevo modificador o stat, indícalo explícitamente en la respuesta.
5. Explica brevemente qué se añadió y para qué sirve.

## Biblioteca de modificadores

El proyecto contiene:

`Biblioteca_Modificadores_Rimworld_1.6.md`

Esta biblioteca contiene modificadores y stats comprobados, incluyendo ejemplos que funcionan y ejemplos que no funcionan.

- Consulta esta biblioteca antes de crear o utilizar nuevos modificadores o stats.
- Cuando se añada un modificador o stat nuevo, primero debe comprobarse que funciona correctamente dentro del juego.
- Una vez que yo confirme que funciona en el juego, añádelo a:

  `Biblioteca_Modificadores_Rimworld_1.6.md`

- No marques un modificador o stat como confirmado hasta que yo haya comprobado que funciona dentro del juego.

---

# MANEJO DE ERRORES Y LOGS

Si comparto un error o log de RimWorld, especialmente errores **rojos en la consola de desarrollador**:

1. Interpreta primero el error.
2. Explícalo línea por línea cuando sea posible.
3. Identifica:
   - Qué archivo o Def está relacionado.
   - Qué clase o método podría estar involucrado, si aplica.
   - Qué significa el error.
   - Cuál es la causa probable.
4. Después de analizarlo, propone una solución.
5. Evita realizar cambios grandes antes de identificar la causa del error.

No asumas automáticamente que la solución es correcta si el log no proporciona suficiente información.

---

# RITMO DE TRABAJO

- Solo implementa múltiples funcionalidades en una misma respuesta si yo lo solicito explícitamente.
- Prioriza soluciones simples, fáciles de probar y fáciles de revertir.
- No realices refactorizaciones grandes si no son necesarias para la tarea actual.

---

# REGLAS GENERALES DE TRABAJO

- Antes de modificar algo, revisa cómo está implementado actualmente en el proyecto.
- Prioriza reutilizar estructuras, Defs y patrones existentes.
- No inventes propiedades XML de RimWorld si no estás seguro de que existen.
- Cuando exista una duda sobre si un modificador, stat, Def o propiedad funciona en RimWorld 1.6, compruébalo en el código fuente disponible o en la documentación/biblioteca del proyecto.
- Mantén compatibilidad con **RimWorld 1.6** como prioridad.
- Explica los cambios importantes antes o después de realizarlos de forma que pueda entenderlos como principiante.
- Si una solución requiere C#, indícalo antes de implementarla.
- Si una modificación puede afectar Git, la estructura del proyecto o el flujo de trabajo establecido, indícalo explícitamente.