using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using TMPro;
using UnityEngine;

namespace PhantomPlus.Role;

[RegisterCustomRole]
public class BloodMoon : ImpostorRole, ICustomRole
{
    public string RoleName => "BloodMoon";
    public string RoleLongDescription => "Revenge On Everyone";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => Palette.ImpostorRoleHeaderTextRed;


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