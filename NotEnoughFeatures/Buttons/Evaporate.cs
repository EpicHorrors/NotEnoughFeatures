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
public class Evaporate : CustomActionButton<PlayerControl>
{
    public override string Name => "Evaporate";
    public override float Cooldown => OptionGroupSingleton<EclipseDarkenOption>.Instance.EvaporateCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.Invis.png");
    
    protected override void OnClick()
    {
        PlayerControl.LocalPlayer.RpcCustomMurder(Target, createDeadBody: true, teleportMurderer: false, playKillSound: true, resetKillTimer: true, showKillAnim: true);
    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance, ignoreColliders: true);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.White));
    }

    public override bool IsTargetValid(PlayerControl target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour role)
    {
        base.Button.buttonLabelText.SetFaceColor(Palette.Blue);
        return role is Eclipse;
    }
}