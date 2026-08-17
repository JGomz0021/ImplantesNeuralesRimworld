using HarmonyLib;
using RimWorld;
using Verse;

namespace ImplantesNeurales
{
    [DefOf]
    public static class ImplantesNeuralesDefOf
    {
        public static HediffDef MecanitasSanguineas;

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
}
