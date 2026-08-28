using System;
using System.Linq;
using HarmonyLib;
using RimWorld;
using Verse;

namespace ImplantesNeurales
{
    [DefOf]
    public static class ImplantesNeuralesDefOf
    {
        public static HediffDef MecanitasSanguineas;
        public static HediffDef ChipSubprocesamientoNeural;
        public static HediffDef Chip_Regulacion_Sueno;
        public static HediffDef ChipAsistentePunteria;
        public static HediffDef Exoesqueleto_Ataque;
        public static HediffDef Exoesqueleto_Trabajo;
        public static HediffDef Servomotores_Musculares;
        public static HediffDef Refuerzo_Oseo;
        public static HediffDef NeuraLink;
        public static HediffDef NeuraLinkSignal;
        public static ThingDef CentroComputo;

        static ImplantesNeuralesDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ImplantesNeuralesDefOf));
        }
    }

    [StaticConstructorOnStartup]
    public static class ImplantesNeuralesHarmony
    {
        static ImplantesNeuralesHarmony()
        {
            new Harmony("JGomz21.implantessubneural").PatchAll();
        }
    }

    [HarmonyPatch(typeof(Hediff_Injury), "BleedRate", MethodType.Getter)]
    public static class HediffInjuryBleedRatePatch
    {
        private const float MecanitasSanguineasBleedRateFactor = 0.80f;

        [HarmonyPostfix]
        private static void ReduceBleeding(Hediff_Injury __instance, ref float __result)
        {
            Pawn pawn = __instance.pawn;
            if (pawn == null || !pawn.health.hediffSet.HasHediff(ImplantesNeuralesDefOf.MecanitasSanguineas))
            {
                return;
            }

            __result *= MecanitasSanguineasBleedRateFactor;
        }
    }

    [HarmonyPatch(typeof(Pawn_HealthTracker), "AddHediff", new Type[] { typeof(Hediff), typeof(BodyPartRecord), typeof(DamageInfo?), typeof(DamageWorker.DamageResult) })]
    public static class AddHediff_AutoAssignDefaultBodyPart
    {
        [HarmonyPrefix]
        private static void AssignDefaultPart(Hediff hediff, BodyPartRecord part)
        {
            if (part != null || hediff == null || hediff.Part != null || !(hediff is Hediff_Implant))
            {
                return;
            }

            BodyPartDef target = DefaultBodyPartFor(hediff.def);
            if (target == null)
            {
                return;
            }

            BodyPartRecord record = hediff.pawn?.health?.hediffSet?.GetNotMissingParts()
                .FirstOrDefault(p => p.def == target);
            if (record != null)
            {
                hediff.Part = record;
            }
        }

        private static BodyPartDef DefaultBodyPartFor(HediffDef def)
        {
            if (def == ImplantesNeuralesDefOf.ChipSubprocesamientoNeural || def == ImplantesNeuralesDefOf.Chip_Regulacion_Sueno
                || def == ImplantesNeuralesDefOf.NeuraLink)
            {
                return DefDatabase<BodyPartDef>.GetNamed("Brain");
            }
            if (def == ImplantesNeuralesDefOf.ChipAsistentePunteria)
            {
                return DefDatabase<BodyPartDef>.GetNamed("Eye");
            }
            if (def == ImplantesNeuralesDefOf.Exoesqueleto_Ataque || def == ImplantesNeuralesDefOf.Exoesqueleto_Trabajo
                || def == ImplantesNeuralesDefOf.Servomotores_Musculares || def == ImplantesNeuralesDefOf.Refuerzo_Oseo)
            {
                return DefDatabase<BodyPartDef>.GetNamed("Torso");
            }
            return null;
        }
    }

    public class HediffCompProperties_NeuraLink : HediffCompProperties
    {
        public HediffCompProperties_NeuraLink()
        {
            compClass = typeof(HediffComp_NeuraLink);
        }
    }

    public class HediffComp_NeuraLink : HediffComp
    {
        private const int UpdateIntervalTicks = 60;
        private const int NetworkRadiusSquared = 90000;
        private const int MaxConnectionsPerCenter = 5;

        public override void CompPostTick(ref float severityAdjustment)
        {
            if (parent.pawn.IsHashIntervalTick(UpdateIntervalTicks))
            {
                UpdateSignal();
            }
        }

        public override void CompPostPostRemoved()
        {
            RemoveSignal();
        }

        private void UpdateSignal()
        {
            Pawn pawn = parent.pawn;
            Building assignedCenter = FindAssignedCenter(pawn);
            bool shouldReceiveSignal = pawn.IsColonist && pawn.Spawned && assignedCenter != null;
            Hediff signal = pawn.health.hediffSet.hediffs.FirstOrDefault(hediff => hediff.def == ImplantesNeuralesDefOf.NeuraLinkSignal);

            if (shouldReceiveSignal && signal == null)
            {
                pawn.health.AddHediff(HediffMaker.MakeHediff(ImplantesNeuralesDefOf.NeuraLinkSignal, pawn));
            }
            else if (!shouldReceiveSignal && signal != null)
            {
                pawn.health.RemoveHediff(signal);
            }
        }

        private void RemoveSignal()
        {
            Pawn pawn = parent.pawn;
            Hediff signal = pawn.health.hediffSet.hediffs.FirstOrDefault(hediff => hediff.def == ImplantesNeuralesDefOf.NeuraLinkSignal);
            if (signal != null)
            {
                pawn.health.RemoveHediff(signal);
            }
        }

        private Building FindAssignedCenter(Pawn pawn)
        {
            if (pawn.Map == null) return null;

            var centers = pawn.Map.listerBuildings.AllBuildingsColonistOfDef(ImplantesNeuralesDefOf.CentroComputo);
            Building bestCenter = null;
            int minConnections = int.MaxValue;

            foreach (Building center in centers)
            {
                CompPowerTrader power = center.GetComp<CompPowerTrader>();
                if (power == null || !power.PowerOn) continue;

                if (center.Position.DistanceToSquared(pawn.Position) > NetworkRadiusSquared) continue;

                int currentConnections = CountConnectedPawns(center);
                if (currentConnections < MaxConnectionsPerCenter && currentConnections < minConnections)
                {
                    minConnections = currentConnections;
                    bestCenter = center;
                }
            }

            return bestCenter;
        }

        private int CountConnectedPawns(Building center)
        {
            if (center.Map == null) return 0;

            int count = 0;
            var allPawns = center.Map.mapPawns.AllPawnsSpawned;
            foreach (Pawn pawn in allPawns)
            {
                if (!pawn.IsColonist || !pawn.Spawned) continue;

                var neuraLinkHediff = pawn.health.hediffSet.hediffs.FirstOrDefault(h => h.def == ImplantesNeuralesDefOf.NeuraLink);
                if (neuraLinkHediff == null) continue;

                var comp = neuraLinkHediff.TryGetComp<HediffComp_NeuraLink>();
                if (comp != null && comp.FindAssignedCenter(pawn) == center)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
