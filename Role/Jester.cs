using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.CustomGameOverReasons;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class Jester : ImpostorRole, ICustomRole
{
    public string RoleName => "Jester";
    public string RoleLongDescription => "Get voted out to win";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => new Color32(236, 98, 165, byte.MaxValue);


    public ModdedRoleTeams Team => ModdedRoleTeams.Neutral;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        TasksCountForProgress = false,
        CanGetKilled = true,
        CanUseVent = true,
    };
    public string GetCustomEjectionMessage(NetworkedPlayerInfo player)
    {
        return $"{player.PlayerName} fooled everyone!";
    }

    public override void OnDeath(DeathReason reason)
    {
        if (reason == DeathReason.Exile)
        {
            GameManager.Instance.RpcEndGame((GameOverReason)CustomGameOverReasonsEnum.JesterByVote, false);
        }
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return gameOverReason == (GameOverReason)CustomGameOverReasonsEnum.JesterByVote;
    }
}