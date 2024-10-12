
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using MiraAPI.Utilities;
using NotEnoughFeatures.Modifier;
using NotEnoughFeatures.Options;
using MiraAPI.GameOptions;


namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Burn : CustomActionButton<PlayerControl>
{
    public override string Name => "Burn";
    public override float Cooldown => OptionGroupSingleton<DragonBurnOptions>.Instance.BurnCooldown;
    public override float EffectDuration => OptionGroupSingleton<DragonBurnOptions>.Instance.DieTimer;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.burn (2).png", 90f);

    public static Color forcedColor = Color.green;

    protected override void OnClick()
    {
        forcedColor = Color.green;
        Button.cooldownTimerText.color = forcedColor;
        
        Target?.RpcAddModifier<Burned>();
    }

    public override void OnEffectEnd()
    {
        Button.cooldownTimerText.color = Color.white;
    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.Data.Role.FindClosestTarget();
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.Blue));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Dragon;
    }
}