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
public class MeetingButton : CustomActionButton
{
    public override string Name => "Meeting";
    public override float Cooldown => OptionGroupSingleton<CaptainOptions>.Instance.MeetingCooldown;
    public override float EffectDuration => 0f;
    public override int MaxUses => 1;
    public override LoadableAsset<Sprite> Sprite { get; } = new LoadableResourceAsset("NotEnoughFeatures.Resources.MeetingButton.png");
    
    protected override void OnClick()
    {
        var bt = ShipStatus.Instance.EmergencyButton;

        PlayerControl.LocalPlayer.NetTransform.Halt();
        var minigame = Object.Instantiate(bt.MinigamePrefab, Camera.main!.transform, false);

        var taskAdderGame = minigame as TaskAdderGame;
        if (taskAdderGame != null)
        {
            taskAdderGame.SafePositionWorld = bt.SafePositionLocal + (Vector2)bt.transform.position;
        }

        minigame.transform.localPosition = new Vector3(0f, 0f, -50f);
        minigame.Begin(null);

    }


    public override bool Enabled(RoleBehaviour role)
    {
        return role is Captain;
    }
}