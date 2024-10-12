using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using NotEnoughFeatures.CustomGameOverReasons;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Phaser : ImpostorRole, ICustomRole
{
    public string RoleName => "Phaser";
    public string RoleLongDescription => "Phase Through Walls And Kill Everyone";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => new Color32(150, 125, 125, 255);
    public ModdedRoleTeams Team => ModdedRoleTeams.Neutral;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        
        CanGetKilled = true,
        CanUseVent = true,
        UseVanillaKillButton = true,
        
    };

    public override bool DidWin(GameOverReason gameOverReason)
    {
        return gameOverReason == (GameOverReason)CustomGameOverReasonsEnum.KillEveryone;
    }
}