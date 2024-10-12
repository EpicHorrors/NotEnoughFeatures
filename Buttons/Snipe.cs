using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Modifier.Freezer;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Snipe : CustomActionButton<PlayerControl>
{
    public override string Name => "Snipe";
    public override float Cooldown => OptionGroupSingleton<KnightKill>.Instance.KillCooldown;
    public override float EffectDuration => 0;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.Snipe.png");
    
    protected override void OnClick()
    {
        if (Target.Data.Role.TeamType == RoleTeamTypes.Impostor)
        {
            Debug.Log("Target is an Impostor. Sheriff is shooting the Impostor.");
            PlayerControl.LocalPlayer.RpcMurderPlayer(Target, true);
        }
        else
        {
            Debug.Log("Target is not an Impostor. Sheriff is shooting themselves.");
            PlayerControl.LocalPlayer.RpcMurderPlayer(PlayerControl.LocalPlayer, true);
        }
    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.CrewmateRoleHeaderDarkBlue));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Sniper;
    }
}