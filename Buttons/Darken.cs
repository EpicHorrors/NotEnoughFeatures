using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using PhantomPlus.Role;
using Reactor.Utilities;
using UnityEngine;

namespace PhantomPlus.Buttons;

[RegisterButton]
public class Darken : CustomActionButton
{
    public override string Name => "Darken";
    public override float Cooldown => OptionGroupSingleton<EclipseDarkenOption>.Instance.DarkenCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.darken.png");

    protected override void OnClick()
    {
        //hacker/eclipse tp ability
        
        
        ShipStatus.Instance.RpcUpdateSystem(SystemTypes.Sabotage, (byte)SystemTypes.Electrical);
        
    }

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Eclipse;
    }
}