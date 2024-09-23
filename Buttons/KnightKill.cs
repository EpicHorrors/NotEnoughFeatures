using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Modifier.Freezer;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using PhantomPlus.Role;
using Reactor.Utilities;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace PhantomPlus.Buttons;

[RegisterButton]
public class knightKill : CustomActionButton<PlayerControl>
{
    public override string Name => "Kill";
    public override float Cooldown => OptionGroupSingleton<KnightKill>.Instance.KillCooldown;
    public override float EffectDuration => 0;
    public override int MaxUses => (int)OptionGroupSingleton<KnightKill>.Instance.KillUses;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.SwordButton.png");
    
    protected override void OnClick()
    {
        PlayerControl.LocalPlayer.RpcCustomMurder(Target, createDeadBody: false, teleportMurderer: false, playKillSound: false, resetKillTimer: false, showKillAnim: true);
    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.CrewmateBlue));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Knight;
    }
}