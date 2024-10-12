using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem.Web;
using NotEnoughFeatures;
using Reactor.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace NotEnoughFeatures.API
{
    public static class CreditsAPI
    {


        [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]

        public static void PingTrackerCreditsLobby(string modName, string credits, string projectLeader, PingTracker __instance)
        {
            __instance.text.text = $"{modName}\n {credits}\n {projectLeader}\n {__instance.text.text}";
        }

        public static void PingTrackerCreditsInGame(string modName, PingTracker __instance)
        {
            __instance.text.text = $"{modName}\n {__instance.text.text}";

        }

        public static void menuTextCredits(string modName, string Version)
        {
            ReactorCredits.Register($"\r{modName}", Version, isPreRelease: false, (location) => location == ReactorCredits.Location.MainMenu);

        }

    }
}
