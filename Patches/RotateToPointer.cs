
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
using static MiraAPI.Example.ExamplePlugin;
using PhantomPlus.Patches;

using Reactor.Utilities;
using System.Collections;
using Il2CppSystem.Xml.Schema;
using PhantomPlus.Buttons;
using Hazel;
using Reactor.Networking.Rpc;
using NotEnoughFeatures.Options;

[RegisterInIl2Cpp]

public class RotateToPointer : MonoBehaviour
{
    public float offset = -90;
    public SpriteRenderer renderer;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        
    }
}