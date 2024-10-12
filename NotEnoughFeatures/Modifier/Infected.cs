using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Modifiers.Types;
using MiraAPI.Networking;
using NotEnoughFeatures.Options;
using static UnityEngine.GraphicsBuffer;

namespace NotEnoughFeatures.Modifier;

[RegisterModifier]
public class Infected : BaseModifier
{
    public override string ModifierName => "Infected";
    public override bool HideOnUi => false;
    

    

    public override void OnActivate()
    {
        if (Player.AmOwner)
        {
            Player.RpcCustomMurder(Player, createDeadBody: true, teleportMurderer: false, playKillSound: true, resetKillTimer: false, showKillAnim: true);
        }
    }
}
