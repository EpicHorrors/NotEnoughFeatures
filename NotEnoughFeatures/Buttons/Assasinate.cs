using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Assasinate : CustomActionButton<PlayerControl>
{
    public override string Name => "Assasinate";
    public override float Cooldown => OptionGroupSingleton<assasinate>.Instance.AssasinateCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => (int)OptionGroupSingleton<assasinate>.Instance.AssasinateUses;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.Assasinate.png");
    
    protected override void OnClick()
    {
        PlayerControl.LocalPlayer.RpcCustomMurder(Target, createDeadBody: false, teleportMurderer: true, playKillSound: true, resetKillTimer: true, showKillAnim: false);


    }

    public override PlayerControl GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, Distance, false);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(Palette.ImpostorRed));
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Assasin;
    }
}