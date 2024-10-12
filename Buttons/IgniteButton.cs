using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Roles;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using UnityEngine;
using NotEnoughFeatures.Role;
using yanplaRoles.Roles.Neutral;


namespace NotEnoughFeatures.Buttons;

[RegisterButton]
public class IgniteButton : CustomActionButton<PlayerControl>
{
    public override string Name => "Ignite";
    public override float Cooldown => 1;
    public override float EffectDuration => 0f;
    public override int MaxUses => 0;
    public override LoadableAsset<Sprite> Sprite => new LoadableResourceAsset("NotEnoughFeatures.Resources.Ignite.png");

    public override bool Enabled(RoleBehaviour? role)
    {
        base.Button.buttonLabelText.SetFaceColor(new Color(1f, 0.3f, 0f));
        return role is Arsonist;
    }

    public override void FixedUpdateHandler(PlayerControl playerControl)
    {
        var arsonist = playerControl.Data.Role as Arsonist;
        if (arsonist.ResetTimer.Ignite){
            ResetCooldownAndOrEffect();
            arsonist.ResetTimer.Ignite = false;
        }
        if (Timer >= 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (HasEffect && EffectActive)
        {
            EffectActive = false;
            Timer = Cooldown;
            OnEffectEnd();
        }

        if (CanUse() && arsonist.DousedAlive > 0)
        {
            Button?.SetEnabled();
        }
        else
        {
            Button?.SetDisabled();
        }

        Button?.SetCoolDown(Timer, EffectActive ? EffectDuration : Cooldown);

        FixedUpdate(playerControl);
    }

    protected override void OnClick()
    {
        if (Target == null) return;
        var arsonist = PlayerControl.LocalPlayer.Data.Role as Arsonist;
        arsonist.Ignite();
        arsonist.ResetTimer.Douse = true;
    }

    public override PlayerControl? GetTarget()
    {
        return PlayerControl.LocalPlayer.GetClosestPlayer(true, distance: 9999999999999999999);
    }

    public override void SetOutline(bool active)
    {
        Target?.cosmetics.SetOutline(active, new Il2CppSystem.Nullable<Color>(CustomRoleSingleton<Arsonist>.Instance.RoleColor));
    }

     public override bool IsTargetValid(PlayerControl? target)
    {
        if (target == null) return false;
        var arsonist = PlayerControl.LocalPlayer.Data.Role as Arsonist;
        return arsonist.dousedPlayers.Contains(target.PlayerId);
    }
}