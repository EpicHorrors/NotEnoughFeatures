using NotEnoughFeatures.Modifier.Freezer;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using MiraAPI.Utilities;
using NotEnoughFeatures.Modifier;
using MiraAPI.GameOptions;
using NotEnoughFeatures.Options.NorthernBreeze;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Infect : CustomActionButton<PlayerControl>
{
    public override string Name => "Infect";
    public override float Cooldown => OptionGroupSingleton<virus>.Instance.InfectCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.infect.png");
    
    protected override void OnClick()
    {
        Target?.RpcAddModifier<Infected>();

    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.Data.Role.FindClosestTarget();
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.AcceptedGreen));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour role)
    {
        base.Button.buttonLabelText.SetFaceColor(Palette.CrewmateRoleHeaderVeryDarkBlue);
        return role is Virus;
    }
}