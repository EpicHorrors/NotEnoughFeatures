using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using PhantomPlus.Role;
using Reactor.Utilities;
using Rewired;
using TMPro;
using UnityEngine;
using NotEnoughFeatures;

using System.Collections;
using System;
using Reactor.Networking.Rpc;
using static MiraAPI.Example.ExamplePlugin;


namespace PhantomPlus.Buttons;

[RegisterButton]
public class InvisInvisibility : CustomActionButton
{
    public override string Name => "Invisible";
    public override float Cooldown => OptionGroupSingleton<InvisOptions>.Instance.InvisCooldown;
    public override float EffectDuration => OptionGroupSingleton<InvisOptions>.Instance.InvisDur;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.InvisButton.png");
    
    public static bool shadows;
    public static bool IsZoom { get; private set; }

    protected override void OnClick()
    {
        //hacker/eclipse tp ability
        RpcInvis(PlayerControl.LocalPlayer);
        
        Coroutines.Start(ZoomOutCoroutine());
    }

    

    public override void OnEffectEnd()
    {
        //hacker/eclipse tp ability
        RpcAppear(PlayerControl.LocalPlayer);
        
        Coroutines.Start(ZoomInCoroutine());

    }



    private static IEnumerator ZoomOutCoroutine()
    {
        HudManager.Instance.ShadowQuad.gameObject.SetActive(false);
        IsZoom = true;
        var zoomDistance = OptionGroupSingleton<InvisOptions>.Instance.ZoomDis;
        for (var ft = Camera.main!.orthographicSize; ft < zoomDistance; ft += 0.3f)
        {
            Camera.main.orthographicSize = MeetingHud.Instance ? 3f : ft;
            ResolutionManager.ResolutionChanged.Invoke((float)Screen.width / Screen.height, Screen.width, Screen.height, Screen.fullScreen);
            foreach (var cam in Camera.allCameras) cam.orthographicSize = Camera.main.orthographicSize;
            yield return null;
        }

        foreach (var cam in Camera.allCameras) cam.orthographicSize = zoomDistance;
        ResolutionManager.ResolutionChanged.Invoke((float)Screen.width / Screen.height, Screen.width, Screen.height, Screen.fullScreen);
    }

    private static IEnumerator ZoomInCoroutine()
    {
        for (var ft = Camera.main!.orthographicSize; ft > 3f; ft -= 0.3f)
        {
            Camera.main.orthographicSize = MeetingHud.Instance ? 3f : ft;
            ResolutionManager.ResolutionChanged.Invoke((float)Screen.width / Screen.height, Screen.width, Screen.height, Screen.fullScreen);
            foreach (var cam in Camera.allCameras) cam.orthographicSize = Camera.main.orthographicSize;

            yield return null;
        }

        foreach (var cam in Camera.allCameras) cam.orthographicSize = 3f;
        HudManager.Instance.ShadowQuad.gameObject.SetActive(true);
        IsZoom = false;

        ResolutionManager.ResolutionChanged.Invoke((float)Screen.width / Screen.height, Screen.width, Screen.height, Screen.fullScreen);
    }



    public override bool Enabled(RoleBehaviour role)
    {
        return role is Invisiblility;
    }
}