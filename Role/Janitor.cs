using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class Storm : ImpostorRole, ICustomRole
{
    public string RoleName => "Storm";
    public string RoleLongDescription => "This Land Is Mine";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.DisabledGrey;


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
        return GameManager.Instance.DidHumansWin(gameOverReason);
    }
}