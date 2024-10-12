using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.CustomGameOverReasons;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Hacker : ImpostorRole, ICustomRole
{
    public string RoleName => "Hacker";
    public string RoleLongDescription => "Hack The Game";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.AcceptedGreen;


    public ModdedRoleTeams Team => ModdedRoleTeams.Neutral;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        
        CanGetKilled = true,
        CanUseVent = true,
    };
    public override void SpawnTaskHeader(PlayerControl playerControl)
    {
        // remove existing task header.
    }

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return gameOverReason == (GameOverReason)CustomGameOverReasonsEnum.EveryOneHacked;
    }
}