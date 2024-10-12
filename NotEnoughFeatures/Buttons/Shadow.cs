using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.Role;
using Reactor.Utilities;
using UnityEngine;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class Shadow : CustomActionButton
{
    public override string Name => "Shadow";
    public override float Cooldown => OptionGroupSingleton<evilshadow>.Instance.ShadowCool;
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
        return role is EvilShadow;
    }
}