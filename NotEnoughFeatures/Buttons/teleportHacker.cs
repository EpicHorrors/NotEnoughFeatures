using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Role;

using Reactor.Utilities;
using System.Collections;
using UnityEngine;

namespace NotEnoughFeatures.Buttons;
[RegisterButton]
public class TeleportHacker : CustomActionButton
{
    public override string Name => "GlitchOut";

    public override float Cooldown => OptionGroupSingleton<TeleporterHackerOption>.Instance.TeleportCooldown;


    public override float EffectDuration => OptionGroupSingleton<TeleporterHackerOption>.Instance.TeleportDuration;

    public override int MaxUses => 0;

    public override LoadableAsset<Sprite> Sprite => new LoadableResourceAsset("NotEnoughFeatures.Resources.Teleport.png");
    public static bool IsZoom { get; private set; }
    public static Color forcedColor = Color.green;

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Hacker;
    }
    protected override void OnClick()
    {
        forcedColor = Color.green;
        Button.cooldownTimerText.color = forcedColor;
        Coroutines.Start(ZoomOutCoroutine());
    }

    public override void OnEffectEnd()
    {
        Button.cooldownTimerText.color = Color.white;
        Coroutines.Start(ZoomInCoroutine());
    }

    protected override void FixedUpdate(PlayerControl playerControl)
    {
        base.FixedUpdate(playerControl);

        if (!EffectActive) return;

        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerControl.NetTransform.RpcSnapTo(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            ResetCooldownAndOrEffect();
        }
    }

    private static IEnumerator ZoomOutCoroutine()
    {
        HudManager.Instance.ShadowQuad.gameObject.SetActive(false);
        IsZoom = true;
        var zoomDistance = OptionGroupSingleton<TeleporterHackerOption>.Instance.ZoomDistance;
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
}