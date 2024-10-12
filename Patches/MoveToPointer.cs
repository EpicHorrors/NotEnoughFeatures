
using Cpp2IL.Core.Attributes;
using Reactor.Utilities.Attributes;
using UnityEngine;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using MiraAPI.GameOptions;
using MiraAPI.PluginLoading;
using Reactor;
using Reactor.Networking;
using Reactor.Networking.Attributes;
using UnityEngine;
using static NotEnoughFeatures.ExamplePlugin;
using PhantomPlus.Patches;

using Reactor.Utilities;
using System.Collections;
using Il2CppSystem.Xml.Schema;
using NotEnoughFeatures.Buttons;
using Hazel;
using Reactor.Networking.Rpc;
using NotEnoughFeatures.Options;

[RegisterInIl2Cpp]

public class MoveToPointer : MonoBehaviour
{
    

    private void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        
        transform.position = pos;

        
    }
}