using MiraAPI.Roles;
using UnityEngine;


namespace yanplaRoles.Roles.Neutral;

[RegisterCustomRole]

public class NeutralGhostRole : ImpostorGhostRole, ICustomRole 
{
    public string RoleName => "Neutral Ghost";
    public string RoleDescription => "You're dead, enjoy the afterlife";
    public string RoleLongDescription => RoleDescription;
    public Color RoleColor => Color.gray;
    public ModdedRoleTeams Team => ModdedRoleTeams.Neutral;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        IsGhostRole = true,
        CanUseSabotage = false,
        HideSettings = true,
    };

    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        // remove existing task header.
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return false;
    }

}