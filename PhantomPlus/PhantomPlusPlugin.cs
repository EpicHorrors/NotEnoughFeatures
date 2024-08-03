using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Reactor;
using System.Linq;
using UnityEngine;
using PhantomPlus.Patches;



namespace PhantomPlus;


[BepInAutoPlugin]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[HarmonyPatch(typeof(MeetingHud))]
[HarmonyPatch("Update")]
[BepInDependency(ReactorPlugin.Id)]




public partial class PhantomPlusPlugin : BasePlugin
{


    

    public Harmony Harmony { get; } = new Harmony(Id);

   


    public override void Load()
    {


        Harmony.PatchAll();
    }



    

    
    
    



    
}