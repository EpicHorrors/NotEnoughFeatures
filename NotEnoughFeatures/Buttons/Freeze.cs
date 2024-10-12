using NotEnoughFeatures.Role;
using MiraAPI.Hud;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using NotEnoughFeatures.Modifier.Freezer;
using NotEnoughFeatures.Modifier;
using MiraAPI.GameOptions;
using NotEnoughFeatures.Options;


namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class freeze : CustomActionButton<PlayerControl>
{
    public override string Name => "Freeze";
    public override float Cooldown => OptionGroupSingleton<Freeze>.Instance.FreezeCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.freeze.png");

    

    protected override void OnClick()
    {
        Target?.RpcAddModifier<Freezed>();
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
        base.Button.buttonLabelText.SetFaceColor(Palette.LightBlue);
        return role is NothernBreeze;
    }
}