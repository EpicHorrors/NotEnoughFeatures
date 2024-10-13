using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.Options.NorthernBreeze;
using NotEnoughFeatures.Role;
using UnityEngine;

using NotEnoughFeatures.rpc;

namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class CleanButton : CustomActionButton<DeadBody>
{
    public override string Name => "Clean";
    public override float Cooldown => OptionGroupSingleton<janitor>.Instance.KillCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite => new LoadableResourceAsset("NotEnoughFeatures.Resources.CleanButton (2).png", 100);

    protected override void OnClick()
    {
        if (Target != null)
        {
            PlayerControl.LocalPlayer.SetKillTimer(GameOptionsManager.Instance.currentNormalGameOptions.KillCooldown);
            PlayerControl.LocalPlayer.RpcCleanBody(Target.ParentId);
        }
    }

    public override DeadBody? GetTarget()
    {
        return PlayerControl.LocalPlayer.GetNearestDeadBody(1f);
    }

    public override void SetOutline(bool active)
    {
        Target?.bodyRenderers[0].material.SetFloat("_Outline", active ? 1 : 0);
        Target?.bodyRenderers[0].material.SetColor("_OutlineColor", new Color32(255, 255, 0, 255));
    }

    public override bool IsTargetValid(DeadBody? target)
    {
        return true;
    }

    public override bool Enabled(RoleBehaviour? role)
    {
        base.Button.buttonLabelText.SetFaceColor(new Color32(255, 255, 0, 255));
        return role is Janitor;
    }
}
