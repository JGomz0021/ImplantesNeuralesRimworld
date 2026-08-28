# Implantes de Subprocesamiento Neural

Mod para **RimWorld 1.6** que incorpora implantes neurales y corporales para colonos y mecanizadores.

## Requisitos

- RimWorld 1.6
- DLC Biotech
- Harmony

## Contenido

- **Chip de subprocesamiento neural:** mejora consciencia y vista; para mecanizadores, añade ancho de banda, un grupo de control, velocidad de trabajo y reparación de mecas. A cambio, aumenta un 15% el consumo de hambre.
- **Chip de regulación del sueño:** aumenta un 50% la recuperación de descanso mientras el colono duerme.
- **Chip asistente de puntería:** se instala en un ojo y concede +5 puntos porcentuales de precisión de disparo.
- **Exoesqueleto de ataque:** mejora combate cuerpo a cuerpo, movilidad y manipulación; concede +10 puntos porcentuales de precisión de disparo y +5 de esquiva cuerpo a cuerpo.
- **Exoesqueleto de trabajo:** mejora movilidad y manipulación para tareas diarias.
- **Refuerzo óseo:** reduce un 15% todo el daño recibido. Esto mejora la resistencia a impactos y disminuye indirectamente el riesgo de fracturas; RimWorld no ofrece un modificador XML genérico de probabilidad de fractura ni de daño por tipo para Hediffs.
- **Servomotores musculares:** mejoran movilidad y manipulación en un 10%, velocidad de movimiento en un 5% y reducen un 10% todo el daño recibido, aumentando la supervivencia frente a golpes, cortes y otras heridas.
- **Mecanitas sanguíneas:** una colonia de nanobots médicos que circula por la sangre. Reducen un 20% el sangrado, aceleran un 25% la curación de heridas y aumentan un 10% el bombeo de sangre.
- **NeuraLink:** un implante cerebral con transceptor. Al conectarse a un centro de cómputo activo, mejora un 10% la manipulación y aporta asistencia de puntería.

Los implantes se fabrican en el banco de fabricación y la mayor parte se desbloquea con la investigación **Implantes avanzados**. Esta requiere Biónica y UltraMechtech.

## Centro de cómputo

El **Centro de cómputo** es una construcción eléctrica de 3×2 que se desbloquea con Implantes avanzados. Consume 600 W y da cobertura a los NeuraLink de los colonos en un radio de 200 casillas. Si el centro se apaga, se avería o el colono abandona el radio, el enlace y sus bonificaciones se retiran automáticamente.

## Estado de pruebas

Las definiciones y el ensamblado C# se revisan estáticamente en el repositorio. Es necesario probar el mod dentro de RimWorld para confirmar carga de Defs, disponibilidad de recetas, activación del enlace NeuraLink y balance durante una partida.
