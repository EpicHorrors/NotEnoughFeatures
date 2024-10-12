using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Networking;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Modifier;
using NotEnoughFeatures.Modifier.Freezer;
using NotEnoughFeatures.Options;
using NotEnoughFeatures.Options.NorthernBreeze;
using PhantomPlus.Role;
using Reactor.Utilities;
using Reactor.Utilities.Extensions;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static MiraAPI.Example.ExamplePlugin;

namespace PhantomPlus.Buttons;

[RegisterButton]
public class Clean : CustomActionButton<DeadBody>
{
    public override string Name => "Clean";
    public override float Cooldown => OptionGroupSingleton<janitor>.Instance.KillCooldown;
    public override float EffectDuration => 0;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.SwordButton.png");


    

    protected override void OnClick()
    {

        RpcClean(Target);
    }

    public override DeadBody GetTarget()
    {
        return PlayerControl.LocalPlayer.GetNearestDeadBody(2);
    }

    public override void SetOutline(bool active)
    {
        Target?.bodyRenderers[0].material.SetFloat("_Outline", active ? 1 : 0);
        Target?.bodyRenderers[0].material.SetColor("_OutlineColor", new Color32(255, 255, 0, 255));
    }

    public override bool IsTargetValid(DeadBody target)
    {
        return true;
    }

    

    public override bool Enabled(RoleBehaviour role)
    {
        return role is Janitor;
    }
}