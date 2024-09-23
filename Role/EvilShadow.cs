using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class EvilShadow : ImpostorRole, ICustomRole
{
    public string RoleName => "EvilShadow";
    public string RoleLongDescription => "Corrupted Everyone";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.Black;


    public ModdedRoleTeams Team => ModdedRoleTeams.Neutral;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        UseVanillaKillButton = true,
        CanGetKilled = true,
        CanUseVent = true,
        AffectedByLightOnAirship = false,
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