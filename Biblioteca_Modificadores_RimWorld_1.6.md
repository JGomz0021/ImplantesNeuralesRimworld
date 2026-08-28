# Biblioteca de modificadores — RimWorld 1.6

Referencia para implantes y otros `HediffDef`. Reúne los `StatDef` de las categorías Pawn en Core 1.6, Biotech e Ideology, y los campos propios de una etapa de Hediff.

> Alcance: son modificadores candidatos para un peón. Que un StatDef exista no asegura que afecte a todos los peones o situaciones; siempre hay que probarlo en juego. Quedan fuera los stats exclusivos de armas, edificios, materiales, ropa y objetos.

## Uso correcto en Hediffs

Los stats se sitúan dentro de una etapa. `statOffsets` suma una cantidad; `statFactors` multiplica el valor (`1.10` = +10%, `0.85` = −15%).

```xml
<stages>
  <li>
    <statOffsets><ShootingAccuracyPawn>5</ShootingAccuracyPawn></statOffsets>
    <statFactors><MoveSpeed>1.10</MoveSpeed></statFactors>
  </li>
</stages>
```

## Combate

| DefName | Tipo habitual | Efecto / nota |
|---|---|---|
| `ShootingAccuracyPawn` | offset | Precisión base en puntos porcentuales. `5` = +5 puntos; escala vanilla (rasgo *Careful shooter* usa `5`, *Trigger-happy* usa `-5`). |
| `ShootingAccuracyFactor_Touch`, `ShootingAccuracyFactor_Short`, `ShootingAccuracyFactor_Medium`, `ShootingAccuracyFactor_Long` | factor | Precisión por tramo de distancia. |
| `AimingDelayFactor` | factor | Tiempo de apuntado; menor que `1` es más rápido. |
| `RangedCooldownFactor` | factor | Recuperación tras disparar; menor es más rápido. |
| `MeleeDamageFactor` | factor | Daño melee infligido. |
| `MeleeCooldownFactor` | factor | Recuperación entre ataques melee; menor aumenta DPS. |
| `MeleeHitChance` | offset | Probabilidad de impactar en melee. |
| `MeleeDodgeChance` | offset | Probabilidad de esquivar melee en puntos porcentuales; escala vanilla (rasgo *Nimble* usa `15`). Para un implante, valores modestos como `2.5`–`5`. |
| `MeleeArmorPenetration` | offset | Penetración de ataques melee; depende también del arma. |
| `MeleeDoorDamageFactor` | factor | Daño melee contra puertas; Biotech. |
| `PawnTrapSpringChance` | factor | Activar trampas; menor es mejor. |
| `IncomingDamageFactor` | factor | Todo el daño recibido. Válido en una etapa de Hediff; `0.90` reduce 10%. |
| `StaggerDurationFactor` | factor | Duración del tambaleo; menor es mejor. |
| `MortarMissRadiusFactor` | factor | Error de morteros; menor es más preciso. |
| `ShootingAccuracyChildFactor` | factor | Precisión de niños; Biotech, situacional. |
| `MeleeDPS` | no usar | Valor informativo derivado de arma y otros stats. |

### Combate condicionado por entorno (Ideology)

Usar como offsets y proteger con `MayRequire="Ludeon.RimWorld.Ideology"`:

- `ShootingAccuracyOutdoorsDarkOffset`, `ShootingAccuracyOutdoorsLitOffset`, `ShootingAccuracyIndoorsDarkOffset`, `ShootingAccuracyIndoorsLitOffset`
- `MeleeHitChanceOutdoorsDarkOffset`, `MeleeHitChanceOutdoorsLitOffset`, `MeleeHitChanceIndoorsDarkOffset`, `MeleeHitChanceIndoorsLitOffset`
- `MeleeDodgeChanceOutdoorsDarkOffset`, `MeleeDodgeChanceOutdoorsLitOffset`, `MeleeDodgeChanceIndoorsDarkOffset`, `MeleeDodgeChanceIndoorsLitOffset`

## Capacidades corporales (`capMods`)

No son StatDefs. Cada entrada admite `offset`, `postFactor` o `setMax`.

| CapacityDef | Efecto |
|---|---|
| `Consciousness` | Consciencia general. |
| `Moving` | Movilidad. |
| `Manipulation` | Uso de manos, trabajo y puntería. |
| `Sight`, `Hearing`, `Talking`, `Eating` | Sentidos y funciones correspondientes. |
| `Breathing`, `BloodPumping`, `BloodFiltration`, `Metabolism` | Sistemas orgánicos. |

```xml
<capMods>
  <li><capacity>Moving</capacity><postFactor>1.10</postFactor></li>
  <li><capacity>Manipulation</capacity><postFactor>1.10</postFactor></li>
</capMods>
```

## Movimiento, salud y necesidades

| DefName | Tipo habitual | Efecto |
|---|---|---|
| `MoveSpeed`, `CrawlSpeed`, `CaravanRidingSpeedFactor` | factor | Velocidad normal, arrastrándose o al montar. |
| `CarryingCapacity` | offset | Carga máxima. |
| `PainShockThreshold` | factor | Umbral para caer por shock de dolor. |
| `InjuryHealingFactor`, `ImmunityGainSpeed` | factor | Curación de heridas e inmunidad. |
| `LifespanFactor` | factor | Vida esperada. |
| `ComfyTemperatureMin`, `ComfyTemperatureMax` | offset | Límites de temperatura confortable. |
| `ToxicResistance`, `ToxicEnvironmentResistance`, `EMPResistance` | factor | Resistencia a toxicidad, ambiente tóxico y EMP. |
| `MentalBreakThreshold` | offset | Umbral de ánimo para crisis mental. |
| `MaxNutrition` | factor | Nutrición máxima. |
| `BedHungerRateFactor` | factor | Consumo de hambre en cama; menor es mejor. |
| `EatingSpeed` | factor | Velocidad al comer. |
| `RestRateMultiplier` | factor | Recuperación de descanso al dormir. |
| `RestFallRateFactor` | factor | Caída de descanso despierto; menor es mejor. |
| `JoyFallRateFactor` | factor | Caída de alegría; menor es mejor. |
| `FilthRate` | factor | Frecuencia con la que ensucia; menor es mejor. |
| `ForagedNutritionPerDay` | offset/factor | Nutrición al forrajear. |
| `MaxFlightTime`, `FlightCooldown` | offset/factor | Vuelo; depende del tipo de peón. |

## Trabajo y producción

| DefName | Tipo habitual | Efecto |
|---|---|---|
| `WorkSpeedGlobal`, `GeneralLaborSpeed` | factor | Velocidad global y de recetas generales. |
| `ConstructionSpeed`, `ConstructSuccessChance`, `FixBrokenDownBuildingSuccessChance` | factor/offset | Construcción y reparación de averías. |
| `MiningSpeed`, `MiningYield`, `DeepDrillingSpeed`, `SmoothingSpeed` | factor | Minería, rendimiento, perforación y alisado. |
| `PlantWorkSpeed`, `PlantHarvestYield`, `DrugHarvestYield` | factor | Trabajo y cosechas vegetales. |
| `ResearchSpeed`, `ReadingSpeed` | factor | Investigación/escaneo y lectura. |
| `CleaningSpeed`, `HuntingStealth` | factor | Limpieza y sigilo de caza. |
| `AnimalGatherSpeed`, `AnimalGatherYield` | factor | Ordeño, esquila y productos animales. |
| `SmeltingSpeed`, `CookSpeed` | factor | Fundición y cocina. |
| `FoodPoisonChance` | factor | Intoxicación de comida; menor es mejor. |
| `DrugSynthesisSpeed`, `DrugCookingSpeed` | factor | Producción de drogas. |
| `ButcheryFleshSpeed`, `ButcheryMechanoidSpeed` | factor | Velocidad de carnicería orgánica o mecanoide. |
| `ButcheryFleshEfficiency`, `ButcheryMechanoidEfficiency` | factor | Rendimiento de carnicería. |
| `HackingSpeed`, `HackingStealth` | factor | Pirateo. |
| `PruningSpeed`, `SuppressionPower` | factor | Poda y supresión; Ideology. |

## Medicina, aprendizaje, psíquica y social

| DefName | Tipo habitual | Efecto |
|---|---|---|
| `MedicalTendSpeed`, `MedicalOperationSpeed` | factor | Curación y operaciones. |
| `MedicalTendQuality`, `MedicalSurgerySuccessChance` | factor/offset | Calidad de cura y éxito quirúrgico. |
| `PsychicSensitivity`, `PsychicEntropyMax`, `PsychicEntropyRecoveryRate`, `MeditationFocusGain` | factor/offset | Sistemas psíquicos. |
| `GlobalLearningFactor`, `AnimalsLearningFactor` | factor | Aprendizaje humano y animal. |
| `NegotiationAbility`, `SocialImpact`, `PawnBeauty`, `ArrestSuccessChance` | factor/offset | Interacciones sociales. |
| `TradePriceImprovement`, `DrugSellPriceImprovement` | factor/offset | Precios de comercio. |
| `TameAnimalChance`, `TrainAnimalChance`, `BondAnimalChanceFactor` | factor | Animales. |
| `ConversionPower`, `CertaintyLossFactor`, `SocialIdeoSpreadFrequencyFactor` | factor | Ideology: conversión y certeza. |
| `SlaveSuppressionFallRate` | factor | Ideology: caída de supresión; menor es mejor. |
| `AnimalProductsSellImprovement`, `Terror` | factor/offset | Ideology: comercio animal y terror. |

## Mecanizadores y Biotech

Proteger con `MayRequire="Ludeon.RimWorld.Biotech"` si Biotech no es dependencia obligatoria.

| DefName | Tipo habitual | Efecto |
|---|---|---|
| `MechBandwidth`, `MechControlGroups` | offset | Ancho de banda y grupos de control. |
| `WorkSpeedGlobalOffsetMech` | offset | Trabajo de mecas controlados. |
| `MechRepairSpeed`, `MechFormingSpeed`, `SubcoreEncodingSpeed` | factor | Reparación, gestación y subnúcleos. |
| `MechRemoteRepairDistance`, `MechRemoteShieldDistance`, `MechRemoteShieldEnergy` | offset | Reparación y escudo remotos. |
| `MechEnergyUsageFactor`, `WastepacksPerRecharge`, `MechEnergyLossPerHP` | factor | Energía y residuos; menor es mejor. |
| `BandwidthCost`, `ControlTakingTime` | factor | Coste y tiempo de control; situacional. |
| `GrowthVatOccupantSpeed`, `LearningRateFactor` | factor | Tina de crecimiento y aprendizaje infantil. |
| `Fertility`, `HemogenGainFactor`, `RawNutritionFactor`, `CancerRate` | factor/offset | Fertilidad, hemógeno, comida cruda y cáncer. |
| `BiosculpterOccupantSpeed` | factor | Velocidad de ocupación del biosculptor; Ideology. |

## Stats de peón existentes pero no apropiados para un implante general

| DefName | Por qué evitarlo |
|---|---|
| `MeatAmount`, `LeatherAmount` | Definen recursos que rinde un cadáver, no una mejora funcional del colono vivo. |
| `MinimumHandlingSkill` | Requisito de manejo de animales; es una propiedad de la criatura. |
| `Wildness` | Conducta base de animal salvaje; no es un bonus de implante. |

## Campos especiales de `HediffStage`

No son StatDefs: `painOffset`, `painFactor`, `partEfficiencyOffset`, `partEfficiencyFactor`, `hungerRateFactorOffset`, `restFallFactor`, `makeImmuneTo`, `hediffGivers`, `mentalStateGivers`, `lifeThreatening`, `vomitMtbDays` y `deathMtbDays`.

## No usar en Hediffs XML

| Nombre | Motivo | Alternativa |
|---|---|---|
| `damageFactors` | No existe en `HediffDef`; provoca error XML. | `IncomingDamageFactor` para resistencia global. |
| `BluntDamageFactor`, `BoneDamageFactor`, `FractureChanceFactor` | No son StatDefs válidos para un Hediff. | Daño global, capacidades o código C# específico. |
| `MaxHitPoints` | Es de objetos; no aporta vida máxima genérica de Pawn mediante Hediff. | Curación, resistencia global o código C#. |
| `ResearchSpeedFactor`, `CookingSpeed`, `CraftingSpeed` | No son los DefName Core apropiados. | `ResearchSpeed`, `CookSpeed`, `GeneralLaborSpeed`. |
| Stats de arma, material, ropa o edificio | No afectan al peón como implante. | Usar la alternativa de categoría Pawn. |

## Validación y fuentes

1. Buscar el DefName exacto en `Data/*/Defs/Stats` de la versión objetivo.
2. Confirmar que pertenece a una categoría Pawn y colocarlo dentro de `stages/li`.
3. Proteger contenido de DLC opcional con `MayRequire`.
4. Cargar el mod, revisar el log y comprobar el panel de información del peón.

Fuentes: Defs instalados de Core/Biotech/Ideology 1.6; [RimWorld Wiki — Stats](https://rimworldwiki.com/wiki/Stats), [Shooting Accuracy](https://rimworldwiki.com/wiki/Shooting_Accuracy), [Hediffs](https://rimworldwiki.com/wiki/Hediffs), [RimworldModdingFiles — HediffDef](https://github.com/RimWorldMod/RimworldModdingFiles/blob/master/Defs/HediffDefs/Hediffs.xml) y [RimWorld Modding Wiki — Def Types](https://rimworldmodding.wiki.gg/wiki/Def_Types).

La instalación de la versión objetivo es la autoridad para nombres; la wiki y los foros se usan para interpretar comportamiento y balance.
