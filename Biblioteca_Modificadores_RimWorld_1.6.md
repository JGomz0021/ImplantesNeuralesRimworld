# Biblioteca de modificadores — RimWorld 1.6

Biblioteca interna para el desarrollo de **Implantes Neurales**.

> Objetivo: evitar usar nombres de campos inventados o pertenecientes a otro tipo de Def. Cada modificador de esta lista debe considerarse apto solo cuando su tipo de uso está indicado explícitamente.

## 1. Modificadores confirmados para `<HediffDef>` → `<stages>`

Estos nombres aparecen como `StatDef` reales de RimWorld y pueden utilizarse dentro de `<statOffsets>` o `<statFactors>` cuando el tipo de stat lo permita.

### Combate

| DefName | Uso | Tipo recomendado |
|---|---|---|
| `ShootingAccuracyPawn` | Precisión de disparo del peón | `statOffsets` |
| `MeleeDodgeChance` | Probabilidad de esquivar en melee | `statOffsets` |
| `MeleeHitChance` | Probabilidad de acertar ataques melee | `statOffsets` |
| `MeleeDamageFactor` | Multiplicador del daño melee | `statFactors` |
| `MeleeCooldownFactor` | Multiplicador del tiempo de recuperación entre ataques melee | `statFactors` |
| `AimingDelayFactor` | Multiplicador del tiempo de apuntado | `statFactors` |
| `IncomingDamageFactor` | Multiplicador de todo el daño recibido | `statFactors` |
| `StaggerDurationFactor` | Multiplicador de la duración del stagger | `statFactors` |
| `ShootingAccuracyFactor_Touch` | Multiplicador de precisión a corta distancia | `statFactors` |
| `ShootingAccuracyFactor_Short` | Multiplicador de precisión a distancia corta | `statFactors` |
| `ShootingAccuracyFactor_Medium` | Multiplicador de precisión a distancia media | `statFactors` |
| `ShootingAccuracyFactor_Long` | Multiplicador de precisión a larga distancia | `statFactors` |

### Movimiento y capacidades físicas

| DefName | Uso | Tipo recomendado |
|---|---|---|
| `MoveSpeed` | Velocidad de movimiento | `statFactors` o `statOffsets` según el efecto buscado |
| `CarryingCapacity` | Capacidad de carga | `statOffsets` |

Para capacidades como `Moving`, `Manipulation`, `Consciousness` y `Sight`, usar `<capMods>`:

```xml
<capMods>
  <li>
    <capacity>Moving</capacity>
    <offset>0.10</offset>
  </li>
</capMods>
```

También existe `<postFactor>` para multiplicar una capacidad:

```xml
<capMods>
  <li>
    <capacity>Manipulation</capacity>
    <postFactor>1.10</postFactor>
  </li>
</capMods>
```

Capacidades vanilla relevantes confirmadas: `Consciousness`, `Moving`, `Manipulation`, `Breathing`, `BloodFiltration`, `BloodPumping`, `Metabolism`, `Eating`, `Talking`, `Hearing`, `Sight`.

### Trabajo

| DefName | Uso | Tipo recomendado |
|---|---|---|
| `WorkSpeedGlobal` | Multiplicador de velocidad de trabajo general | `statFactors` |
| `MedicalTendSpeed` | Velocidad para tratar heridas/enfermedades | `statFactors` |
| `MedicalTendQuality` | Calidad base de las curas | `statFactors`/`statOffsets` según diseño |
| `MedicalOperationSpeed` | Velocidad de operaciones médicas | `statFactors` |
| `MedicalSurgerySuccessChance` | Probabilidad base de éxito quirúrgico | `statFactors` |
| `ConstructionSpeed` | Velocidad de construcción | `statFactors` |
| `CookingSpeed` | Velocidad de cocina | `statFactors` |
| `MiningSpeed` | Velocidad de minería | `statFactors` |
| `ResearchSpeedFactor` | Velocidad de investigación | `statFactors` |
| `PlantWorkSpeed` | Velocidad de trabajo con plantas | `statFactors` |
| `CraftingSpeed` | Velocidad de fabricación | `statFactors` |

> Nota: los nombres anteriores son `StatDef` del juego; antes de implementar un implante concreto conviene comprobar además que el stat se aplica a **Pawn** y no a un objeto, edificio, arma o material.

### Sueño

| DefName | Uso | Tipo recomendado |
|---|---|---|
| `RestRateMultiplier` | Multiplicador de la velocidad con la que una criatura recupera descanso mientras duerme | `statFactors` |
| `RestFallRateFactor` | Multiplicador de la velocidad con la que cae la necesidad de sueño | `statFactors` |

**Importante:** `RestRateMultiplier` y `RestFallRateFactor` NO significan lo mismo.

- `RestRateMultiplier < 1`/`> 1` modifica la velocidad de recuperación mientras duerme.
- `RestFallRateFactor < 1` hace que el sueño se consuma más lentamente durante la vigilia.

Para el **Chip de regulación del sueño**, el modificador correcto para la especificación actual es:

```xml
<statFactors>
  <RestRateMultiplier>1.50</RestRateMultiplier>
</statFactors>
```

### Mecanización / Biotech

| DefName | Uso | Tipo recomendado |
|---|---|---|
| `MechBandwidth` | Bandwidth disponible para el mecanizador | `statOffsets` |
| `MechControlGroups` | Grupos de control disponibles | `statOffsets` |
| `MechRepairSpeed` | Velocidad con la que el mecanizador repara mecas | `statFactors` |
| `MechFormingSpeed` | Velocidad de gestación/formación de mecas | `statFactors` |
| `MechRemoteRepairDistance` | Distancia de reparación remota | `statOffsets` |
| `MechRemoteShieldDistance` | Distancia para escudo remoto | `statOffsets` |
| `MechRemoteShieldEnergy` | Energía del escudo remoto | `statOffsets` |
| `WorkSpeedGlobalOffsetMech` | Offset de velocidad de trabajo aplicado a los mecas controlados | `statOffsets` |

Estos son contenido de **Biotech** y deben estar protegidos con `MayRequire="Ludeon.RimWorld.Biotech"` cuando corresponda en Defs que puedan cargarse sin Biotech.

## 2. Campos de daño específicos de Hediff

No todo modificador de daño es un `StatDef`.

Un `HediffDef` puede utilizar:

```xml
<damageFactors>
  <Blunt>0.85</Blunt>
</damageFactors>
```

Esto es diferente de `<statFactors>` y sirve para modificar tipos concretos de `DamageDef`.

Ejemplos de tipos de daño que pueden aparecer en `damageFactors` incluyen `Blunt`, `Cut`, `Burn`, `Flame`, `Bullet`, `Stab`, etc., dependiendo de los `DamageDef` cargados.

**Para resistencia general al daño**, el `StatDef` confirmado es:

```xml
<statFactors>
  <IncomingDamageFactor>0.85</IncomingDamageFactor>
</statFactors>
```

## 3. Modificadores que NO deben utilizarse como StatDef

Estos nombres fueron usados en versiones del mod, pero **no deben considerarse modificadores válidos de `<statFactors>`**:

| Nombre | Problema | Alternativa |
|---|---|---|
| `BluntDamageFactor` | No es el StatDef correcto para reducir daño contundente recibido por un peón. El `BluntDamageMultiplier` existe en el contexto de materiales/armas, no como defensa de un Pawn. | `<damageFactors><Blunt>...</Blunt></damageFactors>` o `IncomingDamageFactor` |
| `BoneDamageFactor` | No existe como StatDef vanilla para Hediffs. | Requiere otro sistema; no existe un multiplicador XML genérico de daño por parte ósea. |
| `FractureChanceFactor` | No existe como StatDef vanilla para Hediffs. | Requiere código/una mecánica específica; no debe inventarse como StatDef. |
| `MaxHitPoints` | Existe como StatDef, pero corresponde principalmente a objetos/ThingDefs y no es un modificador genérico de salud máxima de Pawn mediante Hediff. | Para aumentar la salud de un Pawn hay que usar el sistema de salud/cuerpo apropiado; no asumir que `<statFactors><MaxHitPoints>` funcionará en un Hediff. |

## 4. Errores de concepto que debemos evitar

### `StatDef` ≠ capacidad ≠ campo especial

RimWorld tiene varios sistemas diferentes:

1. **Stats** → `<statOffsets>` / `<statFactors>`
2. **Capacidades** → `<capMods>`
3. **Daño por tipo** → `<damageFactors>`
4. **Propiedades de partes corporales** → `<addedPartProps>`
5. **Comportamientos especiales** → `comps` / clases C#

No se debe convertir automáticamente una propiedad del juego en un `<StatDef>` inventando su nombre.

## 5. Modificadores comprobados directamente en el mod

Los siguientes ya aparecen en Hediffs del proyecto y/o coinciden con ejemplos vanilla comprobados:

- `ShootingAccuracyPawn`
- `MeleeDodgeChance`
- `MeleeDamageFactor`
- `MoveSpeed`
- `MechBandwidth`
- `MechControlGroups`
- `MechRepairSpeed`
- `WorkSpeedGlobalOffsetMech`
- `RestRateMultiplier`

**Advertencia:** que un nombre aparezca en el proyecto no significa automáticamente que esté colocado en el bloque correcto. Por ejemplo, `MechRepairSpeed` es un stat válido pero su aplicación debe ir en `<statFactors>`; `MechBandwidth` y `MechControlGroups` son offsets; y `WorkSpeedGlobalOffsetMech` es un offset, no un factor.

## 6. Fuentes de verificación

- RimWorld Wiki — listado y documentación de Stats.
- RimWorld Wiki — documentación de Hediffs y estructura de `<stages>`, `<statOffsets>`, `<statFactors>` y `<capMods>`.
- Defs del Core/Biotech de RimWorld usados como referencia para ejemplos reales.
- Código/Defs vanilla publicados y ejemplos de mods que utilizan los mismos `StatDef`.

Esta biblioteca debe actualizarse cuando se compruebe un nuevo modificador dentro de los Defs de la versión objetivo del mod.
