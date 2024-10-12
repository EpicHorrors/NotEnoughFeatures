using MiraAPI.Roles;
using MiraAPI.Utilities.Assets;
using TMPro;
using UnityEngine;

namespace NotEnoughFeatures.Role;

[RegisterCustomRole]
public class Chameleon : ImpostorRole, ICustomRole
{
    public string RoleName => "Chameleon";
    public string RoleLongDescription => "You Are Invisible While Not Moving";
    public string RoleDescription => RoleLongDescription;
    public Color RoleColor => new Color32(255, 255, 0, 255);
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;

    public CustomRoleConfiguration Configuration => new CustomRoleConfiguration(this)
    {
        
        CanGetKilled = true,
        CanUseVent = true,
    };


    public void PlayerControlFixedUpdate(PlayerControl playerControl)
    {
        if (playerControl.MyPhysics.Velocity.magnitude > 0)
        {
            SpriteRenderer rend = playerControl.cosmetics.currentBodySprite.BodySprite;
            TextMeshPro tmp = playerControl.cosmetics.nameText;
            tmp.color = Color.Lerp(tmp.color, new Color(tmp.color.r, tmp.color.g, tmp.color.b, 1), Time.deltaTime * 4f);
            rend.color = Color.Lerp(rend.color, new Color(1, 1, 1, 1), Time.deltaTime * 4f);

            foreach (var cosmetic in playerControl.cosmetics.transform.GetComponentsInChildren<SpriteRenderer>())
            {
                cosmetic.color = Color.Lerp(cosmetic.color, new Color(1, 1, 1, 1), Time.deltaTime * 4f);
            }
        }
        else
        {
            SpriteRenderer rend = playerControl.cosmetics.currentBodySprite.BodySprite;
            TextMeshPro tmp = playerControl.cosmetics.nameText;
            tmp.color = Color.Lerp(tmp.color, new Color(tmp.color.r, tmp.color.g, tmp.color.b, playerControl.AmOwner ? 0.3f : 0), Time.deltaTime * 4f);
            rend.color = Color.Lerp(rend.color, new Color(1, 1, 1, playerControl.AmOwner ? 0.3f : 0), Time.deltaTime * 4f);

            foreach (var cosmetic in playerControl.cosmetics.transform.GetComponentsInChildren<SpriteRenderer>())
            {
                cosmetic.color = Color.Lerp(cosmetic.color, new Color(1, 1, 1, playerControl.AmOwner ? 0.3f : 0), Time.deltaTime * 4f);
            }
        }
    }

}