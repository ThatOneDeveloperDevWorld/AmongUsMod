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
        // Hooks into the game's role manager initialization sequence
        [HarmonyPatch(typeof(RoleManager), nameof(RoleManager.Initialize))]
        [HarmonyPostfix]
        static void PostfixRoleInitialize(RoleManager __instance)
        {
            Debug.Log("[CompanionMod] Injecting Companion role placeholder configuration.");
            
            // Safety check to ensure the role list exists before manipulation
            if (__instance.AllRoles != null)
            {
                // Custom role logic configuration can be initialized here
            }
        }
    }
}

