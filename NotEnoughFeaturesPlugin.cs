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
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.API;


namespace MiraAPI.Example;

[BepInAutoPlugin("EpicHorrors.NotEnoughFeatures", "NotEnoughFeatures")]
[BepInProcess("Among Us.exe")]
[BepInDependency(ReactorPlugin.Id)]
[BepInDependency(MiraApiPlugin.Id)]
[ReactorModFlags(ModFlags.RequireOnAllClients)]
public partial class ExamplePlugin : BasePlugin, IMiraPlugin
{
    public Harmony Harmony { get; } = new(Id);
    public string OptionsTitleText => "NotEnough\nFeatures";
    public ConfigFile GetConfigFile() => Config;
    public static bool IsZoom { get; private set; }
    public static float zoom = 3f;
    public static bool toggle;
    public static bool toggleGun;



    public static ConfigEntry<bool> DarkModeConfig;
    public static ConfigEntry<bool> ShowWatermark;
    public override void Load()
    {
        DarkModeConfig = Config.Bind("DarkMode",
                                     "DarkMode",
                                     true,
                                     "Set this to false if you don't want dark mode for now");

        ShowWatermark = Config.Bind("Credits",
                                     "ShowCredits?",
                                     true,
                                     "Set this to false if you don't want to see the credits.");
        Harmony.PatchAll();

        CreditsAPI.menuTextCredits("NotEnoughFeatures", "v1.1");
        
        

    }


    [HarmonyPatch(typeof(ChatBubble))]
    public static class ChatBubblePatch
    {
        public static string ColorString(Color32 color, string str) => $"<color=#{color.r:x2}{color.g:x2}{color.b:x2}{color.a:x2}>{str}</color>";

        [HarmonyPatch(nameof(ChatBubble.SetText)), HarmonyPrefix]
        public static void SetText_Prefix(ChatBubble __instance, ref string chatText)
        {
            var sr = __instance.transform.Find("Background").GetComponent<SpriteRenderer>();
            if (ExamplePlugin.DarkModeConfig.Value) sr.color = new Color(0, 0, 0, 128);

            if (chatText.Contains("░") ||
                chatText.Contains("▄") ||
                chatText.Contains("█") ||
                chatText.Contains("▌") ||
                chatText.Contains("▒")) ;
            else
            {
                if (ExamplePlugin.DarkModeConfig.Value) chatText = ColorString(Color.white, chatText.TrimEnd('\0'));
                else chatText = ColorString(Color.black, chatText.TrimEnd('\0'));
            }
        }
    }
    [HarmonyPatch(typeof(ChatController), nameof(ChatController.Update))]
    


    class ChatControllerUpdatePatch
    {
        public static int CurrentHistorySelection = -1;

        private static SpriteRenderer QuickChatIcon;
        private static SpriteRenderer OpenBanMenuIcon;
        private static SpriteRenderer OpenKeyboardIcon;

        public static void Prefix()
        {
            ModManager.Instance.ShowModStamp();//Shows the mod's stamp...Incase if you wanna remove it just delete this line.
        }

        public static void Postfix(ChatController __instance)
        {
            if (ExamplePlugin.DarkModeConfig.Value)
            {
                __instance.freeChatField.background.color = new Color32(40, 40, 40, byte.MaxValue);
                __instance.freeChatField.textArea.compoText.Color(Color.white);
                __instance.freeChatField.textArea.outputText.color = Color.white;

                __instance.quickChatField.background.color = new Color32(40, 40, 40, byte.MaxValue);
                __instance.quickChatField.text.color = Color.white;

                if (QuickChatIcon == null) QuickChatIcon = GameObject.Find("QuickChatIcon")?.transform.GetComponent<SpriteRenderer>();
                else QuickChatIcon.sprite = Utils.LoadSprite("NotEnoughFeatures.ImageResource.DarkQuickChat.png", 100f);

                if (OpenBanMenuIcon == null) OpenBanMenuIcon = GameObject.Find("OpenBanMenuIcon")?.transform.GetComponent<SpriteRenderer>();
                else OpenBanMenuIcon.sprite = Utils.LoadSprite("NotEnoughFeatures.ImageResource.DarkReport.png", 100f);

                if (OpenKeyboardIcon == null) OpenKeyboardIcon = GameObject.Find("OpenKeyboardIcon")?.transform.GetComponent<SpriteRenderer>();
                else OpenKeyboardIcon.sprite = Utils.LoadSprite("NotEnoughFeatures.ImageResource.DarkKeyboard.png", 100f);
            }
            else
            {
                __instance.freeChatField.textArea.outputText.color = Color.black;
            }

            if (!__instance.freeChatField.textArea.hasFocus) return;
            __instance.freeChatField.textArea.characterLimit = AmongUsClient.Instance.AmHost ? 120 : 120;

            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.C))
                ClipboardHelper.PutClipboardString(__instance.freeChatField.textArea.text);
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.V))
                __instance.freeChatField.textArea.SetText(__instance.freeChatField.textArea.text + GUIUtility.systemCopyBuffer);
            if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.X))
            {
                ClipboardHelper.PutClipboardString(__instance.freeChatField.textArea.text);
                __instance.freeChatField.textArea.SetText("");
            }
        }
    }

    public enum CustomRpcCalls : uint
    {
        SayHello = 0,
        Invis = 1,
        Appear = 2,
        Fart = 3,
        EndFart = 4,
        Point = 5,
        EndPoint = 5,
        Gun = 6,
        EndGun = 7,
        Shoot = 8,
        EndShoot = 9,

        DestroyMeeting = 10,
        RestorMeeting = 11,
    }

    [MethodRpc((uint)CustomRpcCalls.Invis)]
    public static void RpcInvis(PlayerControl player)
    {
        player.Visible = false;
    }

    [MethodRpc((uint)CustomRpcCalls.Appear)]
    public static void RpcAppear(PlayerControl player)
    {
        player.Visible = true;
    }

    [MethodRpc((uint)CustomRpcCalls.Fart)]
    public static void RpcFart(PlayerControl player)
    {
        var fart = new GameObject("Fart");


        
        var spriteRenderer = fart.AddComponent<SpriteRenderer>();

        spriteRenderer.sprite = Utils.LoadSpriteIntoGame("NotEnoughFeatures.Resources.GarlicBackground.png", 50);
        spriteRenderer.sortingOrder = 10;

        fart.transform.position = PlayerControl.LocalPlayer.transform.position;



        fart.transform.localPosition = PlayerControl.LocalPlayer.transform.position;
    }

    [MethodRpc((uint)CustomRpcCalls.EndFart)]
    public static void RpcEndFart(PlayerControl player)
    {
        var Fart = GameObject.Find("Fart");

        Object.Destroy(Fart);
    }

    [MethodRpc((uint)CustomRpcCalls.Point)]
    public static void RpcPoint(PlayerControl player)
    {
        var point = new GameObject("Finger");

       

        var spriteRenderer = point.AddComponent<SpriteRenderer>();

        var fingerScript = point.AddComponent<RotateToPointer>();

        spriteRenderer.sprite = Utils.LoadSpriteIntoGame("NotEnoughFeatures.Resources.finger.png", 300);
        spriteRenderer.sortingOrder = 10;

        point.transform.SetParent(PlayerControl.LocalPlayer.transform);
        point.transform.localPosition = Vector3.zero;

        

        



    }

    [MethodRpc((uint)CustomRpcCalls.EndPoint)]
    public static void RpcEndPoint(PlayerControl player)
    {
        var point = GameObject.Find("Finger");

        Object.Destroy(point);
    }


    [MethodRpc((uint)CustomRpcCalls.Gun)]
    public static void RpcGun(PlayerControl player)
    {
        var point = new GameObject("Gun");



        var spriteRenderer = point.AddComponent<SpriteRenderer>();

        var fingerScript = point.AddComponent<RotateToPointer>();

        spriteRenderer.sprite = Utils.LoadSpriteIntoGame("NotEnoughFeatures.Resources.Gun.png", 300);
        spriteRenderer.sortingOrder = 10;

        point.transform.SetParent(PlayerControl.LocalPlayer.transform);
        point.transform.localPosition = Vector3.zero;







    }

    [MethodRpc((uint)CustomRpcCalls.EndGun)]
    public static void RpcEndGun(PlayerControl player)
    {
        var point = GameObject.Find("Gun");

        Object.Destroy(point);
    }

    






    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]

    [HarmonyPatch(typeof(KeyboardJoystick), nameof(KeyboardJoystick.Update))]
    public static class KeyboardJoystickUpdatePatchPatch
    {
        public static void Postfix()
        {
            if (Input.GetKeyDown(KeyCode.R) && OptionGroupSingleton<EmoteOptions>.Instance.CanEmote == true) //Change player
            {
                RpcFart(PlayerControl.LocalPlayer);

                Coroutines.Start(endFart());


            }


            if (Input.GetKeyDown(KeyCode.P) && OptionGroupSingleton<EmoteOptions>.Instance.CanEmote == true) //Change player
            {
                toggle = !toggle;

                if (toggle == false)
                {
                    RpcEndPoint(PlayerControl.LocalPlayer);
                }

                if (toggle == true)
                {
                    RpcPoint(PlayerControl.LocalPlayer);
                }

                

                
            }

            if (Input.GetKeyDown(KeyCode.G) && OptionGroupSingleton<EmoteOptions>.Instance.CanEmote == true) //Change player
            {
                toggleGun = !toggleGun;

                if (toggleGun == false)
                {
                    RpcEndGun(PlayerControl.LocalPlayer);
                }

                if (toggleGun == true)
                {
                    RpcGun(PlayerControl.LocalPlayer);
                }




            }

            


            IEnumerator endFart()
            {
                yield return new WaitForSeconds(5f);
                RpcEndFart(PlayerControl.LocalPlayer);
            }
        }
    }

}

