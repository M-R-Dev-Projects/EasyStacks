
using HarmonyLib;
using MelonLoader;
using ScheduleOne.ItemFramework;

[assembly: MelonInfo(typeof(EasyStacks.Core), "EasyStacks", "1.0.0", "Re3ker", null)]
[assembly: MelonGame("TVGS", "Schedule I")]

namespace EasyStacks
{
    [HarmonyPatch]
    public class Core : MelonMod
    {
        const int NEW_STACK_SIZE = 100;
        static string[] stackCategories = { 
            "Consumable", 
            "Product", 
            "Ingredient", 
            "Growing", 
            "Packaging", 
            "Furniture",
            "Lighting", 
            "Equipment", 
            "Tools" 
        };

        [HarmonyPatch(typeof(ItemInstance), "StackLimit", MethodType.Getter)]
        [HarmonyPostfix]
        public static void StackLimitPatch(ItemInstance __instance, ref int __result)
        {
            
            if (__instance == null) return;

            if (!stackCategories.Contains(__instance.Category.ToString()))
            {
                return;
            }

            if (__instance.Category.ToString() == "Tools" && __instance.ID != "trashbag")
            {
                return;
            }

            __result = NEW_STACK_SIZE;
            return;
        }
    }
}