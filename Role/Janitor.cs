using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Janitor : ImpostorRole, ICustomRole
{
    public string RoleName => "Janitor";
    public string RoleLongDescription => "Clean The Bodies";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => new Color32(255, 255, 0, 255);


    public ModdedRoleTeams Team => ModdedRoleTeams.Impostor;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        
        CanGetKilled = false,
        CanUseVent = true,
    };
    

    
}