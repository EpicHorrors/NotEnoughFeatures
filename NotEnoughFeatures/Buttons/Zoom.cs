using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Zoom : CustomActionButton
{
    public override string Name => "Zoom";
    public override float Cooldown => OptionGroupSingleton<evilshadow>.Instance.ZoomCooldown;
    public override float EffectDuration => OptionGroupSingleton<evilshadow>.Instance.ZoomDur;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.Assasinate.png");
    public static bool IsZoom { get; private set; }
    public static Color forcedColor = Color.green;

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

    private static IEnumerator ZoomOutCoroutine()
    {
        HudManager.Instance.ShadowQuad.gameObject.SetActive(false);
        IsZoom = true;
        var zoomDistance = OptionGroupSingleton<evilshadow>.Instance.ZoomDis;
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
        return role is EvilShadow;
    }
}