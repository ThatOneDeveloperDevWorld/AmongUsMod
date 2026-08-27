using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;

namespace dev.thatonedev.companion
{
    [BepInPlugin("dev.thatonedev.companion", "Companion Role", "1.0.0")]
    public class CompanionPlugin : BasePlugin
    {
        public override void Load()
        {
            Log.LogInfo("ThatOneDev mod loaded successfully");
            
            // load Harmony to process all patches written below
            var harmony = new Harmony("dev.thatonedev.companion");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch]
    public static class CompanionRolePatches
    {
        // Target a standard safe method or constructor/initializer pattern found in Among Us role systems
        [HarmonyPatch(typeof(RoleManager), "Awake")]
        [HarmonyPostfix]
        static void PostfixRoleAwake(RoleManager __instance)
        {
            Debug.Log("[CompanionMod] RoleManager Awake hook triggered.");
            
            if (__instance != null)
            {
                // Put your initialization or role setup code here
            }
        }
    }
}
