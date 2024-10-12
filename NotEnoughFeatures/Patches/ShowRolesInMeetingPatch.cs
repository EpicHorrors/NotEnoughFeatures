using HarmonyLib;
using UnityEngine;

namespace NotEnoughFeatures.Patches;

[HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Update))]
public static class ShowRolesInMeetingPatch
{
    public static void Postfix(MeetingHud __instance)
    {
        var player = PlayerControl.LocalPlayer;

        foreach (PlayerVoteArea playerVoteArea in __instance.playerStates)
        {
            var targetPlayer = Utils.PlayerById(playerVoteArea.TargetPlayerId);
            playerVoteArea.ColorBlindName.transform.localPosition = new Vector3(-0.93f, -0.2f, -0.1f);

            if (playerVoteArea.TargetPlayerId == player.PlayerId && !player.Data.IsDead || player.Data.IsDead && !targetPlayer.Data.IsDead)
            {
            playerVoteArea.NameText.color = targetPlayer.Data.Role.NameColor;
            playerVoteArea.NameText.text = targetPlayer.name + "\n" + targetPlayer.Data.Role.NiceName;
            }
            else if (player.Data.IsDead && targetPlayer.Data.IsDead) 
            {
            var role = Utils.GetPlayerLastRole(targetPlayer.PlayerId);
            playerVoteArea.NameText.color = role.NameColor;
            playerVoteArea.NameText.text = targetPlayer.name + "\n" + role.NiceName;
            }
        }
    }
}